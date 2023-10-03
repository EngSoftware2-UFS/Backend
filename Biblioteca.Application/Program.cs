using Biblioteca.Services;
using Biblioteca.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using Biblioteca.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddSingleton(config);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor insira um token válido.",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddControllers().AddJsonOptions(x =>
{
    //x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; // Prevent object cycles from include ef, but the object will be ugly
    x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    x.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

// AutoMapper service
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors(option =>
{
    option.AddPolicy("allcors", policy =>
    {
        policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    });
});

// Authorization
var key = Encoding.ASCII.GetBytes(config.GetValue<string>("Secret"));
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = true;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Application services
ServicesDI.AddServices(builder.Services);
InfrastructureDI.AddRepositories(builder.Services);

builder.Services.AddSingleton<Rotinas>();
builder.Services.AddHostedService(provider => provider.GetRequiredService<Rotinas>());
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseCors("allcors");

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
