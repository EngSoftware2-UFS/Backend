using Biblioteca.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Services
{
    public static class ServicesDI
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IAtendenteService, AtendenteService>();
        }
    }
}
