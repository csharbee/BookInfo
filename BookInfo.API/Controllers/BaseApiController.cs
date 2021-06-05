using BookInfo.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        [NonAction]
        protected IActionResult Success<T>(string message, string internalMessage, T data)
        {
            return Success(new ResponseDto<T>
            {
                Success = true,
                Message = message,
                InternalMessage = internalMessage,
                Data = data
            });
        }
        [NonAction]
        protected IActionResult Success<T>(ResponseDto<T> data)
        {
            return Ok(data);
        }

        [NonAction]
        protected IActionResult Created<T>(string message, string internalMessage, T data)
        {
            return Created(new ResponseDto<T>
            {
                Success = true,
                Message = message,
                InternalMessage = internalMessage,
                Data = data
            });
        }

        [NonAction]
        protected IActionResult Created<T>(ResponseDto<T> data)
        {
            return StatusCode((int)HttpStatusCode.Created, data);
        }

        [NonAction]
        protected IActionResult NotFound<T>(string message, string internalMessage, T data)
        {
            return NotFound(new ResponseDto<T>
            {
                Success = false,
                Message = message,
                InternalMessage = internalMessage,
                Data = data
            });
        }

        [NonAction]
        protected IActionResult NotFound<T>(ResponseDto<T> data)
        {
            return StatusCode((int)HttpStatusCode.NotFound, data);
        }
    }
}
