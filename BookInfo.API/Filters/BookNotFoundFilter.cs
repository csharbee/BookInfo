using BookInfo.API.DTOs;
using BookInfo.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookInfo.API.Filters
{
    public class BookNotFoundFilter : ActionFilterAttribute
    {
        private IBookService _bookService;
        public BookNotFoundFilter(IBookService bookService)
        {
            _bookService = bookService;
        }
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var book = await _bookService.GetByIdAsync(id);
            if (book != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 404;
                errorDto.Errors.Add($"There is no book with {id}");
                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
