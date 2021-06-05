using BookInfo.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace BookInfo.API.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var responseDto = new ResponseDto();
                IEnumerable<ModelError> modelErrors = context.ModelState.Values.SelectMany(m => m.Errors);
                modelErrors.ToList().ForEach(m =>
                {
                    responseDto.Errors.Add(m.ErrorMessage);
                });
                responseDto.Success = false;
                responseDto.Message = "Not Valid Operation Sended!";
                context.Result = new BadRequestObjectResult(responseDto);
            }
        }
    }
}
