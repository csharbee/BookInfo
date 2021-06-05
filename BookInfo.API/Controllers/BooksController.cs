using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookInfo.API.Filters;
using BookInfo.Core.Models;
using BookInfo.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseApiController
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
            return Success("Get All Books", null, books);
        }
        [ServiceFilter(typeof(BookNotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            return Success("Get The Book", null, book);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Book book)
        {
            await _bookService.AddAsync(book);
            return Created("Book Added", null, book);
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
