using Biblioteca.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Biblioteca.Services.Services
{
    public class Rotinas : BackgroundService
    {
        private readonly IServiceScopeFactory _factory;
        private readonly TimeSpan _period = TimeSpan.FromHours(1);

        public Rotinas(
            IServiceScopeFactory factory )
        {
            _factory = factory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using PeriodicTimer timer = new PeriodicTimer(_period);
            while (
                !stoppingToken.IsCancellationRequested &&
                await timer.WaitForNextTickAsync(stoppingToken))
            {
                await using AsyncServiceScope asyncScope = _factory.CreateAsyncScope();
                var _reservaRepository = asyncScope.ServiceProvider.GetRequiredService<IReservaRepository>();
                var _emprestimoRepository = asyncScope.ServiceProvider.GetRequiredService<IEmprestimoRepository>();
                _reservaRepository.VerifyReservas();
                _emprestimoRepository.VerifyInadimplencia();
            }
        }
    }
}
