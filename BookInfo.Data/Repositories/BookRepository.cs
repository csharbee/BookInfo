using BookInfo.Core.Models;
using BookInfo.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookInfo.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private MainContext Context { get => _context as MainContext; }
        public BookRepository(MainContext context) : base(context)
        {
        }

        public void Test()
        {
            throw new NotImplementedException();
        }
    }
}
