using Biblioteca.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Services
{
    public static class ServicesMDI
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<ITesteService, TesteService>();
        }
    }
}
