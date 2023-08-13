using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Domain.Entities
{
    public class Teste
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Descriptino { get; private set; }
        public bool IsActive { get; private set; }

        public Teste(int id, string name, string descriptino, bool isActive)
        {
            Id = id;
            Name = name;
            Descriptino = descriptino;
            IsActive = isActive;
        }

        public Teste() { }
    }
}