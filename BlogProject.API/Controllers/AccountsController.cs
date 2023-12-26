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
        [HttpPost]
        public async Task<bool> Register([FromForm] RegisterDtos registerDtos)
        {
            return await _service.Register(registerDtos);

        }
    }
}
