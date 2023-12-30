using BlogProject.Business.DTOs.CategoryDTOs;
using BlogProject.Business.Services.Interfaces;
using BlogProject.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            Category category = await _service.GetByIdAsync(id);
            return StatusCode(StatusCodes.Status200OK, category);

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateDto Category)
        {
            await _service.Create(Category);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] CategoryUpdateDto categorydto)
        {
            bool result = await _service.Update(categorydto);
            if (result)
            {
                return StatusCode(StatusCodes.Status200OK, categorydto);
            }
            return StatusCode(StatusCodes.Status409Conflict);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
           await _service.Delete(id);
            return Ok();
        }
    }
}
