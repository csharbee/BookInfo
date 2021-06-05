using BookInfo.Core.Models;
using BookInfo.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Core
{
    public interface IUnitOfWork
    {
        IRepository<Book> BookRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        Task CommitAsync();
        void Commit();
    }
}
