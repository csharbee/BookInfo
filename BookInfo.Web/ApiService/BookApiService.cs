using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookInfo.Web.ApiService
{
    public class BookApiService
    {
        private readonly HttpClient _httpClient;
        public BookApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
