using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookInfo.API.DTOs
{
    public class ResponseDto<T>
    {
        public ResponseDto()
        {
            Errors = new List<string>();
        }
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public string InternalMessage { get; set; }
        public List<string> Errors { get; set; }

    }
    public class ResponseDto : ResponseDto<object>{ }
}
