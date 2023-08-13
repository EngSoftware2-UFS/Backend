namespace Biblioteca.Domain.Models.Responses
{
    public class GetTesteResponse
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Descriptino { get; private set; }
        public bool IsActive { get; private set; }

        public GetTesteResponse(string name, string descriptino, bool isActive)
        {
            Name = name;
            Descriptino = descriptino;
            IsActive = isActive;
        }
    }
}