using BlogProject.Business.CategoryDTOs;
using BlogProject.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Categorys = await _service.GetAllAsync();
            return Ok(Categorys);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateDto Category)
        {
            await _service.Create(Category);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
