using System.Collections.Generic;
using System.Net;

namespace BookInfo.API.DTOs
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; set; }
        public HttpStatusCode Status { get; set; }
    }
}
