﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PestkitOnion.Application.Abstractions.Services;
using PestkitOnion.Application.Dtos.Department;
using PestkitOnion.Application.Dtos.Tag;

namespace PestkitOnion.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page, int take, bool isDeleted = false)
        {
            return Ok(await _tagService.GetAllAsync(page, take, isDeleted:isDeleted));
        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    if (id <= 0) return BadRequest();
        //    return Ok(await _categoryService.GetByIdAsync(id));
        //}
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateTagDto createTagDto)
        {
            await _tagService.CreateAsync(createTagDto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateTagDto updateTagDto)
        {
            await _tagService.UpdateAsync(id, updateTagDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tagService.DeleteAsync(id);
            return NoContent();
        }
        [HttpDelete("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _tagService.SoftDeleteAsync(id);
            return NoContent();
        }
    }
}
