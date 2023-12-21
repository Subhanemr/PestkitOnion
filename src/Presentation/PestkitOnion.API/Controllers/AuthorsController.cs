using Microsoft.AspNetCore.Mvc;
using PestkitOnion.Application.Abstractions.Services;
using PestkitOnion.Application.Dtos.Author;

namespace PestkitOnion.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page, int take, bool isDeleted = false)
        {
            return Ok(await _authorService.GetAllAsync(page, take, isDeleted: isDeleted));
        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    if (id <= 0) return BadRequest();
        //    return Ok(await _categoryService.GetByIdAsync(id));
        //}
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateAuthorDto createAuthorDto)
        {
            await _authorService.CreateAsync(createAuthorDto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateAuthorDto updateAuthorDto)
        {
            await _authorService.UpdateAsync(id, updateAuthorDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _authorService.DeleteAsync(id);
            return NoContent();
        }
        [HttpDelete("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _authorService.SoftDeleteAsync(id);
            return NoContent();
        }

    }
}
