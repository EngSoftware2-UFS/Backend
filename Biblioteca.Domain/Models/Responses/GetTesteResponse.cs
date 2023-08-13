namespace Biblioteca.Domain.Models.Responses
{
    public class GetTesteResponse
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Descriptino { get; private set; }
        public bool IsActive { get; private set; }

        public GetTesteResponse(int id, string name, string descriptino, bool isActive)
        {
            Id = id;
            Name = name;
            Descriptino = descriptino;
            IsActive = isActive;
        }
    }
}