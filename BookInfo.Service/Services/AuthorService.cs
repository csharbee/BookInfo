using BookInfo.Core;
using BookInfo.Core.Models;
using BookInfo.Core.Repositories;
using BookInfo.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookInfo.Service.Services
{
    public class AuthorService : Service<Author>, IAuthorService
    {
        public AuthorService(IUnitOfWork unitOfWork, IRepository<Author> repository) : base(unitOfWork, repository)
        {
        }
    }
}
