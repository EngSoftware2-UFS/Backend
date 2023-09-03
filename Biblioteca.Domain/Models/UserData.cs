using Biblioteca.Domain.Enums;
using System.Text.Json.Serialization;

namespace Biblioteca.Domain.Models
{
    public class UserData
    {
        public ulong Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ETipoUsuario TipoUsuario { get; private set; }

        public UserData(ulong id, string name, string email, ETipoUsuario tipoUsuario)
        {
            Id = id;
            Name = name;
            Email = email;
            TipoUsuario = tipoUsuario;
        }
    }
}
