using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.BidderRequest
{
    public class BidderRequestRepository: RepositoryBase<BidderRequestEntity>, IBidderRequestRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public BidderRequestRepository(IUnitOfWork unitOfWork, IDbFactory dbFactory): base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public BidderRequestEntity SendRequest(BidderRequestEntity bidderRequestEntity)
        {
            try
            {
                meroBoleeDbContexts.BidderRequestEntities.Add(bidderRequestEntity);
                unitOfWork.SaveChange();
                return bidderRequestEntity;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public BidderRequestEntity UpdateRequest(int id, int admin_status_id)
        {
            try
            {
                BidderRequestEntity bidderRequest = meroBoleeDbContexts.BidderRequestEntities.Where(m => m.User_id == id).First();
                bidderRequest.Admin_Status_Id = admin_status_id;
                bidderRequest.Date_modified = DateTime.Now;
                return bidderRequest;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
