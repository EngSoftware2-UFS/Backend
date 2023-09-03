using AutoMapper;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain.Models;
using Biblioteca.Domain.Enums;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using BC = BCrypt.Net.BCrypt;

namespace Biblioteca.Services.Services
{
    public class LoginService : ILoginService
    {
        private readonly IAtendenteRepository _atendenteRepository;
        private readonly IBibliotecarioRepository _bibliotecarioRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _autoMapper;

        public LoginService(
            IAtendenteRepository atendenteRepository,
            IBibliotecarioRepository bibliotecarioRepository,
            IClienteRepository clienteRepository,
            IMapper autoMapper)
        {
            _atendenteRepository = atendenteRepository;
            _bibliotecarioRepository = bibliotecarioRepository;
            _clienteRepository = clienteRepository;
            _autoMapper = autoMapper;
        }

        public UserData? GetAuthenticatedUserById(string rawUserData)
        {
            if (rawUserData == null)
                return null;

            var (id, tipoUsuario) = GetUserInfo(rawUserData);

            if (id == null || tipoUsuario == null)
                return null;

            if (tipoUsuario == ETipoUsuario.ATENDENTE)
            {
                var atendente = _atendenteRepository.GetById((ulong)id);
                return _autoMapper.Map<UserData>(atendente.Result);
            }

            if (tipoUsuario == ETipoUsuario.CLIENTE)
            {
                var cliente = _clienteRepository.GetById((ulong)id);
                return _autoMapper.Map<UserData>(cliente.Result);
            }

            if (tipoUsuario == ETipoUsuario.BIBLIOTECARIO)
            {
                var bibliotecario = _bibliotecarioRepository.GetById((ulong)id);
                return _autoMapper.Map<UserData>(bibliotecario.Result);
            }

            return null;
        }

        private Tuple<ulong?, ETipoUsuario?> GetUserInfo(string rawData)
        {
            var userData = rawData.Split("-");
            if (userData.Length == 2)
            {
                ulong userId = Convert.ToUInt64(userData[0]);
                ETipoUsuario userType = (ETipoUsuario)Convert.ToByte(userData[1]);
                return new Tuple<ulong?, ETipoUsuario?>(userId, userType);
            }

            return new Tuple<ulong?, ETipoUsuario?>(null, null);
        }

        public async Task<UserData> Authenticate(Login userLogin)
        {
            if (userLogin.TipoUsuario == ETipoUsuario.ATENDENTE)
            {
                var atendente = await _atendenteRepository.GetByEmail(userLogin.Email);
                if (atendente == null)
                    throw new UnauthorizedAccessException("Email ou senha inválidos.");

                return Verify(atendente, atendente.Senha, userLogin.Senha);
            }

            if (userLogin.TipoUsuario == ETipoUsuario.CLIENTE)
            {
                var cliente = await _clienteRepository.GetByEmail(userLogin.Email);
                if (cliente == null)
                    throw new UnauthorizedAccessException("Email ou senha inválidos.");

                return Verify(cliente, cliente.Senha, userLogin.Senha);
            }

            if (userLogin.TipoUsuario == ETipoUsuario.BIBLIOTECARIO)
            {
                var bibliotecario = await _bibliotecarioRepository.GetByEmail(userLogin.Email);
                if (bibliotecario == null)
                    throw new UnauthorizedAccessException("Email ou senha inválidos.");

                return Verify(bibliotecario, bibliotecario.Senha, userLogin.Senha);
            }

            throw new UnauthorizedAccessException("Email ou senha inválidos.");
        }

        private UserData Verify<T> (T user, string userPassword, string password) where T : class
        {
            bool verified = BC.Verify(password, userPassword);

            if (!verified)
                throw new UnauthorizedAccessException("Email ou senha inválidos.");

            else return _autoMapper.Map<UserData>(user);
        }
    }
}
