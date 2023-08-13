namespace Biblioteca.Domain.Models.Requests
{
    public class AddTesteRequest
    {
        public string Name { get; private set; }
        public string Descriptino { get; private set; }
        public bool IsActive { get; private set; }

        public AddTesteRequest(string name, string descriptino, bool isActive)
        {
            Name = name;
            Descriptino = descriptino;
            IsActive = isActive;
        }
    }
}