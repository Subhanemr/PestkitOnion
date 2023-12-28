using Microsoft.AspNetCore.Mvc;
using PestkitOnion.Application.Abstractions.Services;
using PestkitOnion.Application.Dtos.Account;

namespace PestkitOnion.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountsController(IAccountService service)
        {
            _service = service;
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult> Register([FromForm] RegisterDto register)
        {
            await _service.RegisterAsync(register);
            return NoContent();
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult> LogIn([FromForm] LogInDto login)
        {
            var result = await _service.LogInAsync(login);
            return Ok(result);
        }
    }
}
