using BookInfo.Core.Models;
using BookInfo.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Core.Services
{
    public interface IAuthorService : IService<Author>
    {
        Task<IEnumerable<Author>> GetAuthorsWithBooks(int id);
    }
}
