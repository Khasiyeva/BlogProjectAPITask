using BlogProject.Business.DTOs.AccountDTOs;
using BlogProject.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ICategoryService _service;

        public AccountsController(ICategoryService service)
        {
            _service = service;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromForm] RegisterDtos registerDtos)
        {
            await _service.Register(registerDtos);
            return Ok();

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromForm]LoginDto loginDto)
        {
            var result =await _service.LoginAsync(loginDto);
            return Ok(result);

        }
    }
}
