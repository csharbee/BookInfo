using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookInfo.Core.Models;
using BookInfo.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorService.GetAllAsync();
            return Ok(authors);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _authorService.GetByIdAsync(id);
            return Ok(author);
        }
        [HttpGet("{id}/books")]
        public IActionResult GetWithBooks(int id)
        {
            var author = _authorService.GetAuthorsWithBooks(id);
            return Ok(author);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _authorService.AddAsync(author);
            return Created("", author);
        }
        [HttpPut]
        public IActionResult Update([FromBody] Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _authorService.Update(author);
            return NoContent();
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] Author author)
        {
            _authorService.Delete(author);
            return NoContent();
        }
    }
}
