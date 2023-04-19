using MeroBolee.Dto;
using MeroBolee.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeroBolee.Repository.SupplierPerformanceTracking
{
    public interface ISupplierPerformanceTrackingRepository
    {
        Task AddBidderQuestion(IEnumerable<SupplierPerformanceTrackingEntity> supplierPerformanceTrackingEntities);

        Task<IEnumerable<SupplierPerformanceTrackingEntity>> GetSupplierPerformanceTracking(long tenderId, long companyId);

        Task UpdateSupplierPerformanceTracking(IEnumerable<SupplierPerformanceTrackingEntity> supplierPerformanceTrackingEntities);

        Task<IEnumerable<SupplierPerformanceTrackingEntity>> FetchBidderCriteria(long tenderId, long companyId);
        Task<double> CalculateTenderRating(long tenderId);
        Task<double> CalculateOverallRating(long tenderId, long companyId);
        Task<IEnumerable<TenderListDto>> SearchTender(string search);
        Task<IEnumerable<CriteriaDto>> FindCriteriaByTenderId(long tenderId);
        Task<SupplierPerformanceTrackingEntity> FetchSupplierPerformanceTrackingById(long id);
        Task UpdateSupplierPerformanceTrackingEntity(SupplierPerformanceTrackingEntity entity);
        Task AddSupplierPerformanceTracking(SupplierPerformanceTrackingEntity entity);
    }
}
