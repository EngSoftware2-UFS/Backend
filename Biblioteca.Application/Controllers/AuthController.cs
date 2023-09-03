using Biblioteca.Application.Filters;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain.Models;
using Biblioteca.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Application.Controllers
{
    [ApiController]
    [Route("login")]
    [TypeFilter(typeof(ExceptionFilter))]
    public class AuthController : ControllerBase
    {
        private readonly IConfigurationRoot _configuration;
        private readonly ILoginService _loginService;

        public AuthController(
            IConfigurationRoot configuration,
            ILoginService loginService)
        {
            _configuration = configuration;
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(Login user)
        {
            UserData userData = await _loginService.Authenticate(user);

            var token = TokenService.GenerateToken(userData, _configuration);

            return Ok(new
            {
                User = userData,
                Token = token
            });
        }
    }
}