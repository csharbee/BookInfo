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
    public class BooksController : ControllerBase
    {
        private IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _bookService.AddAsync(book);
            return Created("", book);
        }
        [HttpPut]
        public IActionResult Update([FromBody] Book book)
        {
            _bookService.Update(book);
            return NoContent();
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] Book book)
        {
            _bookService.Delete(book);
            return NoContent();
        }
    }
}
