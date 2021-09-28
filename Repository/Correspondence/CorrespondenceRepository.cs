using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public interface ICorrespondenceRepository : IRepositoryBase<CorrespondenceEmailEntity>
    {
        public bool SendCorrespondenceEmail(CorrespondenceEmailEntity obj);
    }
    public class CorrespondenceRepository : RepositoryBase<CorrespondenceEmailEntity>, ICorrespondenceRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public CorrespondenceRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool SendCorrespondenceEmail(CorrespondenceEmailEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
