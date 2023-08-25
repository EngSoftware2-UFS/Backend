namespace Biblioteca.Domain.Models.Responses
{
    public class ErrorResponse
    {
        public List<string> Errors { get; set; }
        public string? StackTrace { get; set; }
    }
}
