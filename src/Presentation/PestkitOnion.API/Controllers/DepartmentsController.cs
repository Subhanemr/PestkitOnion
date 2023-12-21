using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PestkitOnion.Application.Abstractions.Services;
using PestkitOnion.Application.Dtos.Author;
using PestkitOnion.Application.Dtos.Department;

namespace PestkitOnion.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page, int take, bool isDeleted = false)
        {
            return Ok(await _departmentService.GetAllAsync(page, take, isDeleted:isDeleted));
        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    if (id <= 0) return BadRequest();
        //    return Ok(await _categoryService.GetByIdAsync(id));
        //}
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateDepartmentDto createDepartmentDto)
        {
            await _departmentService.CreateAsync(createDepartmentDto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateDepartmentDto updateDepartmentDto)
        {
            await _departmentService.UpdateAsync(id, updateDepartmentDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _departmentService.DeleteAsync(id);
            return NoContent();
        }
        [HttpDelete("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _departmentService.SoftDeleteAsync(id);
            return NoContent();
        }
    }
}
