using MeroBolee.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Infrastructure
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private MeroBoleeDbContext meroBoleeDbContext;
        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public MeroBoleeDbContext meroBoleeDbContexts
        {
            get { return meroBoleeDbContext ?? (meroBoleeDbContext = dbFactory.Init()); }

        }
        public void SaveChange()
        {
            meroBoleeDbContexts.SaveChanges();
        }
    }
}
