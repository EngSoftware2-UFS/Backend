using Biblioteca.Domain.Models;

namespace Biblioteca.Domain.Interfaces
{
    public interface ILoginService
    {
        UserData? GetAuthenticatedUserById(string? rawUserData);
        Task<UserData> Authenticate(Login userLogin);
    }
}
