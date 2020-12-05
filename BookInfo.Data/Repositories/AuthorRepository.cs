using BookInfo.Core.Models;
using BookInfo.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Data.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private MainContext _mainContext { get => _context as MainContext; }
        public AuthorRepository(MainContext context) : base(context)
        {
        }

        public Author GetWithBooks(int id)
        {
            return _mainContext.Authors.Include(x => x.Books).SingleOrDefault(m => m.Id == id);
        }
    }
}
