using Biblioteca.Domain.Interfaces;
using Biblioteca.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Services
{
    public static class ServicesDI
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IAtendenteService, AtendenteService>();
            services.AddScoped<IBibliotecarioService, BibliotecarioService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IObraService, ObraService>();
            services.AddScoped<IReservaService, ReservaService>();
        }
    }
}
