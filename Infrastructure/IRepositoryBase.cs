using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Infrastructure
{
    public interface IRepositoryBase<T> where T: class
    {
        T Add(T t);
        IEnumerable<T> Get();
        T GetById(int id);
        void Delete(T t);
    }
}
