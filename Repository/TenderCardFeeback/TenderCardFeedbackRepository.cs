using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public interface ITenderCardFeedbackRepository
    {
        Task<TenderCardFeedbackEntity> SaveFeedback(TenderCardFeedbackEntity entity);
        Task<List<TenderCardFeedbackEntity>> ListTenderFeedback(long companyId, long tenderId);
    }
    public class TenderCardFeedbackRepository : RepositoryBase<TenderCardFeedbackEntity>, ITenderCardFeedbackRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public TenderCardFeedbackRepository(IUnitOfWork unitOfWork, IDbFactory dbFactory) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<TenderCardFeedbackEntity> SaveFeedback(TenderCardFeedbackEntity entity)
        {
            try
            {
                meroBoleeDbContexts.TenderCardFeedbacks.Add(entity);
                await unitOfWork.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<TenderCardFeedbackEntity>> ListTenderFeedback(long companyId, long tenderId)
        {
            try
            {
                return await meroBoleeDbContexts.TenderCardFeedbacks
                    .Include(x => x.User)
                    .Include(x => x.Company)
                    .Where(x=> x.CompanyId == companyId && x.TenderId == tenderId)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }

    }
}
