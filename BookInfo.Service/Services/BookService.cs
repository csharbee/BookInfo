using BookInfo.Core;
using BookInfo.Core.Models;
using BookInfo.Core.Repositories;
using BookInfo.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Service.Services
{
    public class BookService : Service<Book>, IBookService
    {
        public BookService(IUnitOfWork unitOfWork, IRepository<Book> repository) : base(unitOfWork, repository)
        {
        }
    }
}
