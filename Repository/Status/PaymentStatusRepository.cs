using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public class PaymentStatusRepository :RepositoryBase<PaymentStatusEntity>, IPaymentStatusRepository
    {

        public PaymentStatusRepository(IDbFactory dbFactory) : base(dbFactory) { }
        public IEnumerable<PaymentStatusEntity> GetPaymentStatusEntities()
        {
            return meroBoleeDbContexts.PaymentStatusEntities.ToList();
        }
    }
}
