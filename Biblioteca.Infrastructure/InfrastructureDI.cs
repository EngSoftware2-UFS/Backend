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
            string? connectionString = Environment.GetEnvironmentVariable("BIBLIOTECA_CONNECTION_STRING");
            services.AddDbContext<InfraDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            services.AddScoped<IAtendenteRepository, AtendenteRepository>();
            services.AddScoped<IBibliotecarioRepository, BibliotecarioRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IReservaRepository, ReservaRepository>();
            services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
            services.AddScoped<IObraRepository, ObraRepository>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<IEditoraRepository, EditoraRepository>();
            services.AddScoped<IExemplarRepository, ExemplarRepository>();
        }
    }
}
