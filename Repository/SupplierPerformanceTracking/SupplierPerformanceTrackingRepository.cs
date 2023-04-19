using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.SupplierPerformanceTracking
{
    public class SupplierPerformanceTrackingRepository : RepositoryBase<SupplierPerformanceTrackingEntity>, ISupplierPerformanceTrackingRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public SupplierPerformanceTrackingRepository(IUnitOfWork unitOfWork, IDbFactory dbFactory) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddBidderQuestion(IEnumerable<SupplierPerformanceTrackingEntity> supplierPerformanceTrackingEntities)
        {
            try
            {
                meroBoleeDbContexts.SupplierPerformanceTrackingEntities.AddRange(supplierPerformanceTrackingEntities);
                await unitOfWork.SaveChangesAsync();
            }
            catch
            {

                throw;
            }
        }

        public async Task<IEnumerable<SupplierPerformanceTrackingEntity>> GetSupplierPerformanceTracking(long tenderId, long companyId)
        {
            try
            {
                return await meroBoleeDbContexts.SupplierPerformanceTrackingEntities.Where(x => x.TenderId == tenderId && x.CompanyId == companyId && x.IsDeleted==false).ToListAsync();
            }
            catch
            {

                throw;
            }
        }

        public async Task UpdateSupplierPerformanceTracking(IEnumerable<SupplierPerformanceTrackingEntity> supplierPerformanceTrackingEntities)
        {
            try
            {
                meroBoleeDbContexts.SupplierPerformanceTrackingEntities.UpdateRange(supplierPerformanceTrackingEntities);
                await unitOfWork.SaveChangesAsync();
            }
            catch
            {

                throw;
            }
        }

        public async Task<IEnumerable<SupplierPerformanceTrackingEntity>> FetchBidderCriteria(long tenderId, long companyId)
        {
            try
            {
                return await meroBoleeDbContexts.SupplierPerformanceTrackingEntities.Where(x => x.TenderId == tenderId && x.CompanyId == companyId && x.IsDeleted == false).ToListAsync();
            }
            catch
            {

                throw;
            }
        }

        public async Task<double> CalculateTenderRating(long tenderId)
        {
            return await meroBoleeDbContexts.SupplierPerformanceTrackingEntities.Where(x => x.TenderId == tenderId && x.IsDeleted == false).AverageAsync(x => x.Ratings);
        }

        public async Task<double> CalculateOverallRating(long tenderId, long companyId)
        {
            try
            {
                return await meroBoleeDbContexts.SupplierPerformanceTrackingEntities
               .GroupBy(x => new { x.TenderId, x.CompanyId,x.IsDeleted }).Where(x => x.Key.TenderId == tenderId && x.Key.CompanyId == companyId && x.Key.IsDeleted==false)
               .Select(x => x.Average(o => o.Ratings)).FirstOrDefaultAsync();
            }
            catch
            {

                throw;
            }
        }

        public async Task<IEnumerable<TenderListDto>> SearchTender(string search)
        {
            try
            {
                if (search==null)
                {
                    return await meroBoleeDbContexts.TenderEntities.Where(x => x.IsDeleted == false).OrderByDescending(x=>x.Date_created).Select(x=>new TenderListDto
                    {
                        Id=x.Id,
                        Title=x.Title
                    }).ToListAsync();
                }
                else
                {
                    return await meroBoleeDbContexts.TenderEntities.Where(m => m.IsDeleted == false && m.Title.ToLower().Contains(search.ToLower()))
                        .OrderByDescending(x => x.Date_created).Select(x => new TenderListDto
                        {
                            Id = x.Id,
                            Title = x.Title
                        }).ToListAsync();
                }
            }
            catch 
            {

                throw;
            }
        }

        public async Task<IEnumerable<CriteriaDto>> FindCriteriaByTenderId(long tenderId)
        {
            try
            {
                return await meroBoleeDbContexts.SupplierPerformanceTrackingEntities.Where(x => x.TenderId == tenderId && x.IsDeleted==false).
                    Select(x => new CriteriaDto
                    {
                        Criteria=x.Criteria
                    }).Distinct().ToListAsync();
            }
            catch 
            {

                throw;
            }
        }

        public async Task<SupplierPerformanceTrackingEntity> FetchSupplierPerformanceTrackingById(long id)
        {
            try
            {
                return await meroBoleeDbContexts.SupplierPerformanceTrackingEntities.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefaultAsync();
            }
            catch 
            {

                throw;
            }
        }

        public async Task UpdateSupplierPerformanceTrackingEntity(SupplierPerformanceTrackingEntity entity)
        {
            try
            {
                meroBoleeDbContexts.SupplierPerformanceTrackingEntities.Update(entity);
                await unitOfWork.SaveChangesAsync();
            }
            catch 
            {

                throw;
            }
        }

        public async Task AddSupplierPerformanceTracking(SupplierPerformanceTrackingEntity entity)
        {
            try
            {
                meroBoleeDbContexts.SupplierPerformanceTrackingEntities.Add(entity);
                await unitOfWork.SaveChangesAsync();
            }
            catch
            {

                throw;
            }
        }
    }
}
