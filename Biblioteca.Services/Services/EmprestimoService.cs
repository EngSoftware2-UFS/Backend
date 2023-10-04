using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Enums;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;
using Biblioteca.Domain.Views;
using Biblioteca.Infrastructure.Repositories.Interfaces;

namespace Biblioteca.Services.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly IReservaRepository _reservaRepository;
        private readonly IExemplarRepository _exemplarRepository;
        private readonly IClienteRepository _clienteRepository;

        public EmprestimoService(
            IEmprestimoRepository emprestimoRepository,
            IExemplarRepository exemplarRepository,
            IClienteRepository clienteRepository,
            IReservaRepository reservaRepository)
        {
            _emprestimoRepository = emprestimoRepository;
            _exemplarRepository = exemplarRepository;
            _clienteRepository = clienteRepository;
            _reservaRepository = reservaRepository;
        }

        public async Task<List<EmprestimoResponse>> GetEmprestimos(string? status)
        {
            List<EmprestimosView>? results = await _emprestimoRepository.GetAll(status);
            return FormatResponse(results);
        }

        public async Task<List<EmprestimoResponse>> GetEmprestimosByClient(string nomeCliente, string? status)
        {
            List<EmprestimosView>? results = await _emprestimoRepository.GetByClientName(nomeCliente);

            if (!string.IsNullOrEmpty(status))
                results = results.Where(r => r.Status.ToUpper() == status.ToUpper()).ToList();

            return FormatResponse(results);
        }

        private List<EmprestimoResponse> FormatResponse(List<EmprestimosView>? results)
        {
            if (results == null)
                throw new KeyNotFoundException("Not Found.");

            var emprestimos = new List<EmprestimoResponse>();
            results.ForEach(result =>
            {
                var emprestimo = emprestimos.Find(e => e.Id == result.Id);
                if (emprestimo == null)
                {
                    emprestimos.Add(new EmprestimoResponse(result));
                }
                else
                {
                    emprestimo.addObra(result.ObraId, result.Titulo);
                }
            });

            return emprestimos;
        }

        public async Task CriarEmprestimo(CriarEmprestimoRequest emprestimo)
        {
            var inadimplente = await _clienteRepository.ClienteInadimplente(emprestimo.ClientId);

            if (inadimplente)
                throw new InvalidOperationException("Resolva sua inadimplência antes de fazer outro emprestimo.");

            var reserva = await _reservaRepository.GetById(emprestimo.ReservaId);

            if (reserva == null)
                throw new InvalidOperationException("Reserva não encontrada.");

            if (reserva.ClienteId != emprestimo.ClientId)
                throw new InvalidOperationException("Esta reserva não pertence a este cliente.");

            if (!reserva.Status.Equals(EStatusReserva.ATIVA.ToString()))
                throw new InvalidOperationException($"Está reserva está {reserva.Status.ToLower()}.");

            var exemplares = await _reservaRepository.GetExemplares(emprestimo.ReservaId);

            Emprestimo emprestimoCriado = await _emprestimoRepository.CriarEmprestimo(emprestimo.AtendenteId, emprestimo.ClientId);
            for (var i = 0; i < exemplares.Count; i++)
            {
                var exemplarId = exemplares[i].ExemplarId;
                _exemplarRepository.AddExemplarToEmprestimo(emprestimoCriado.Id, exemplarId);
            }
            await _reservaRepository.FinalizarReserva(reserva);
        }

        public async Task RenovarEmprestimo(ulong emprestimoId)
        {
            var emprestimoEntity = await _emprestimoRepository.GetById(emprestimoId);

            if (emprestimoEntity == null)
                throw new InvalidOperationException("Emprestimo não encontrado.");

            if (emprestimoEntity.verificaInadimplencia())
                throw new InvalidOperationException("Não é possível renovar um empréstimo inadimplente.");

            if (emprestimoEntity.Status != EStatusEmprestimo.ATIVO.ToString())
                throw new InvalidOperationException($"Não é possível renovar um empréstimo {emprestimoEntity.Status.ToLower()}.");

            if (emprestimoEntity.PrazoDevolucao.Date != DateTime.Today)
                throw new InvalidOperationException("Só é possível renovar um empréstimo no ultimo dia do prazo.");

            emprestimoEntity.RenovarEmprestimo();
            await _emprestimoRepository.RenovarEmprestimo(emprestimoEntity);
        }

        public async Task CancelarEmprestimo(ulong emprestimoId)
        {
            var emprestimoEntity = await _emprestimoRepository.GetById(emprestimoId);

            if (emprestimoEntity == null)
                throw new InvalidOperationException("Emprestimo não encontrado.");

            if (emprestimoEntity.Status == EStatusEmprestimo.DEVOLVIDO.ToString())
                throw new InvalidOperationException("Este empréstimo está devolvido.");

            if (emprestimoEntity.Status == EStatusEmprestimo.CANCELADO.ToString())
                throw new InvalidOperationException("Este empréstimo já está cancelado.");

            await DisponibilizarExemplares(emprestimoId);
            await _emprestimoRepository.Cancelar(emprestimoEntity);
        }

        public async Task Devolver(ulong emprestimoId)
        {
            var emprestimoEntity = await _emprestimoRepository.GetById(emprestimoId);

            if (emprestimoEntity == null) 
                throw new InvalidOperationException("Emprestimo não encontrado.");

            if (emprestimoEntity.Status == EStatusEmprestimo.DEVOLVIDO.ToString())
                throw new InvalidOperationException("Este empréstimo já está devolvido.");

            if (emprestimoEntity.Status == EStatusEmprestimo.CANCELADO.ToString())
                throw new InvalidOperationException("Este empréstimo está cancelado.");

            if (emprestimoEntity.verificaInadimplencia())
                throw new InvalidOperationException("Não é possível devolver o empréstimo sem pagar a multa.");

            await DisponibilizarExemplares(emprestimoId);
            await _emprestimoRepository.Devolver(emprestimoEntity);
        }

        public async Task PagarMultaEDevolver(ulong emprestimoId)
        {
            var emprestimoEntity = await _emprestimoRepository.GetById(emprestimoId);

            if (emprestimoEntity == null)
                throw new InvalidOperationException("Emprestimo não encontrado.");

            if (emprestimoEntity.Status == EStatusEmprestimo.DEVOLVIDO.ToString())
                throw new InvalidOperationException("Este empréstimo já está devolvido.");

            if (emprestimoEntity.Status == EStatusEmprestimo.CANCELADO.ToString())
                throw new InvalidOperationException("Este empréstimo está cancelado.");

            if (!emprestimoEntity.verificaInadimplencia())
                throw new InvalidOperationException("Não há multa a ser paga neste empréstimo.");

            await DisponibilizarExemplares(emprestimoId);
            await _emprestimoRepository.PagarMultaEDevolver(emprestimoEntity);
        }

        private async Task DisponibilizarExemplares(ulong emprestimoId)
        {
            var emprestimoExemplares = await _emprestimoRepository.GetExemplares(emprestimoId);
            for (var i = 0; i < emprestimoExemplares.Count; i++)
            {
                var exemplarId = emprestimoExemplares[i].ExemplarId;
                var exemplar = await _exemplarRepository.GetById(exemplarId);
                if (exemplar != null)
                {
                    _exemplarRepository.DisponibilizarExemplar(exemplar.Id);
                }
            }
        }
    }
}
