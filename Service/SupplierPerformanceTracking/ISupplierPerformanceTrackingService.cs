using MeroBolee.Dto;
using MeroBolee.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeroBolee.Service.SupplierPerformanceTracking
{
    public interface ISupplierPerformanceTrackingService
    {
        Task<bool> SetQuestion(SetQuestionDto setQuestionDto);

        Task<bool> SetRating(SetRating setRating);

        Task<IEnumerable<SupplierPerformanceTrackingEntity>> GetBidderCriteria(long tenderId, long companyId);
        Task<double> GetTenderRating(long tenderId);
        Task<double> GetOverallRating(long tenderId, long companyId);
        Task<IEnumerable<TenderListDto>> GetTenderList(string search);
        Task<IEnumerable<CriteriaDto>> GetTenderCriteria(long tenderId);
        Task<bool> EditCriteria(CriteriaEditDto criteriaEditDto);
        Task<bool> DeleteCriteria(long id);
        Task<bool> AddCriteria(CriteraiAddDto criteraiAddDto);
    }
}
