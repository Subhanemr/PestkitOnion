using Microsoft.AspNetCore.Mvc;
using PestkitOnion.Application.Abstractions.Services;
using PestkitOnion.Application.Dtos.Position;

namespace PestkitOnion.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionsController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page, int take, bool isDeleted = false)
        {
            return Ok(await _positionService.GetAllAsync(page, take, isDeleted:isDeleted));
        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    if (id <= 0) return BadRequest();
        //    return Ok(await _categoryService.GetByIdAsync(id));
        //}
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreatePositionDto createPositionDto)
        {
            await _positionService.CreateAsync(createPositionDto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdatePositionDto updatePositionDto)
        {
            await _positionService.UpdateAsync(id, updatePositionDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _positionService.DeleteAsync(id);
            return NoContent();
        }
        [HttpDelete("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _positionService.SoftDeleteAsync(id);
            return NoContent();
        }
    }
}
