using BookInfo.Core.Models;
using BookInfo.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookInfo.Data.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(MainContext context) : base(context)
        {
        }
    }
}
