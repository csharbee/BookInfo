using BookInfo.Core;
using BookInfo.Core.Repositories;
using BookInfo.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainContext _mainContext;

        private BookRepository _bookRepository;
        private AuthorRepository _authorRepository;
        public IRepository BookRepository => _bookRepository = _bookRepository ?? new BookRepository(_mainContext);
        public IAuthorRepository AuthorRepository => _authorRepository = _authorRepository ?? new AuthorRepository(_mainContext);

        public UnitOfWork(MainContext mainContext)
        {
            _mainContext = mainContext;
        }
        public void Commit()
        {
            _mainContext.SaveChanges();
        }
        public async Task CommitAsync()
        {
            await _mainContext.SaveChangesAsync();
        }
    }
}
