using MeroBolee.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Infrastructure
{
    public abstract class RepositoryBase <T> where T:class
    {
        private MeroBoleeDbContext meroBoleeDbContext;
        private readonly DbSet<T> dbSet;

        protected IDbFactory dbFactory
        {
            get;
            private set;
        }

        protected MeroBoleeDbContext meroBoleeDbContexts
        {
            get { return meroBoleeDbContext ?? (meroBoleeDbContext= dbFactory.Init()); }
        }

        public RepositoryBase(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            dbSet = meroBoleeDbContexts.Set<T>();
        }

        public virtual T Add(T t)
        {
            dbSet.Add(t);
            return t;
        }

        public virtual void Delete(T t)
        {
            dbSet.Remove(t);
        }

        public virtual IEnumerable<T> Get()
        {
            var list = dbSet.ToList();
            if (list.Count() == 0)
            {
                throw new ArgumentException();
            }
            return list;

        }

        public virtual T GetById(int id)
        {
            var detail = dbSet.Find(id);
            return detail;
        }

    }
}
