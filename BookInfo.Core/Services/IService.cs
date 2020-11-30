using BookInfo.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookInfo.Core.Services
{
    public interface IService<T> : IRepository<T> where T : class
    {
        void ServiceTest();
    }
}
