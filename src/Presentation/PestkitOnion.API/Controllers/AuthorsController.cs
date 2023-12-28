using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PestkitOnion.Application.Abstractions.Services;
using PestkitOnion.Application.Dtos.Author;

namespace PestkitOnion.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorsController(IAuthorService service)
        {
            _service = service;
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> Get(int page, int take, bool isDeleted = false)
        {
            return Ok(await _service.GetAllWhereAsync(page, take, isDeleted: isDeleted));
        }
        [HttpGet("[Action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult> Create([FromForm] CreateAuthorDto create)
        {
            await _service.CreateAsync(create);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("[Action]/{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateAuthorDto update)
        {
            await _service.UpdateAsync(id, update);
            return NoContent();
        }
        [HttpDelete("[Action]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
        [HttpDelete("[Action]/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _service.SoftDeleteAsync(id);
            return NoContent();
        }
        [HttpDelete("[Action]/{id}")]
        public async Task<IActionResult> ReverseSoftDelete(int id)
        {
            await _service.ReverseSoftDeleteAsync(id);
            return NoContent();
        }

    }
}
