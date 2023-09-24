using Biblioteca.Domain.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Biblioteca.Application.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _hostEnvironment;

        public ExceptionFilter(IHostEnvironment hostEnvironment) =>
            _hostEnvironment = hostEnvironment;

        public void OnException(ExceptionContext context)
        {
            var errorList = new List<dynamic>() {
                new { Name = "KeyNotFoundException", Code = 404 },
                new { Name = "ValidationException", Code = 400 },
                new { Name = "UnauthorizedAccessException", Code = 401 },
                new { Name = "ArgumentException", Code = 409 },
                new { Name = "AccessViolationException", Code = 403 },
                new { Name = "OperationCanceledException", Code = 400 }
            };

            var exceptionType = context.Exception.GetType().Name;
            var err = errorList.Find(x => x.Name == exceptionType);

            var result = new ErrorResponse();
            result.StackTrace = context.Exception.StackTrace;
            var stCode = err != null ? err.Code : 500;
            result.Errors = new List<string>();
            var message = context.Exception.Message;

            if (exceptionType == "ValidationException")
            {
                var splitedMessage = message.Split("--");
                for (var i = 1; i < splitedMessage.Length; i++)
                {
                    result.Errors.Add(splitedMessage[i].Split("Severity")[0]);
                }
            }
            else
                result.Errors.Add(message);


            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true
            };
            string? bodyJson;
            if (!_hostEnvironment.IsDevelopment())
            {
                result.StackTrace = null;
                bodyJson = JsonSerializer.Serialize(result, serializeOptions);
            }
            else
                bodyJson = JsonSerializer.Serialize(result, serializeOptions);

            context.Result = new ContentResult
            {
                Content = bodyJson,
                ContentType = "text/json",
                StatusCode = stCode
            };
        }
    }
}
