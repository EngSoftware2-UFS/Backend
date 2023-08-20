using Biblioteca.Infrastructure.Context;
using Biblioteca.Infrastructure.Repositories;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Infrastructure
{
    public static class InfrastructureDI
    {
       public static void AddRepositories(IServiceCollection services)
        {
            // Database service
            string? connectionString = "Server=66.94.117.155; Port=3306; Database=es2_biblioteca; Uid=es2; Pwd=5KeWM58tNiSSEh2C;";//Environment.GetEnvironmentVariable("BIBLIOTECA_CONNECTION_STRING");
            services.AddDbContext<InfraDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            services.AddScoped<IAtendenteRepository, AtendenteRepository>();
        }
    }
}
