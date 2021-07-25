using MeroBolee.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Infrastructure
{
    public class DbFactory : Disposable,IDbFactory
    {
        private MeroBoleeDbContext meroBoleeDbContext;
        public MeroBoleeDbContext Init()
        {
            return meroBoleeDbContext ?? (meroBoleeDbContext = new MeroBoleeDbContext());
        }

        protected override void DisposeCore()
        {
            if (meroBoleeDbContext != null)
            {
                meroBoleeDbContext.Dispose();
            }
        }
    }

    
}
