using Biblioteca.Domain.Enums;
using System.Text.Json.Serialization;

namespace Biblioteca.Domain.Models
{
    public class Login
    {
        public string Email { get; private set; }
        public string Senha { get; private set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ETipoUsuario TipoUsuario { get; private set; }

        public Login(string email, string senha, ETipoUsuario tipoUsuario)
        {
            Email = email;
            Senha = senha;
            TipoUsuario = tipoUsuario;
        }
    }
}
