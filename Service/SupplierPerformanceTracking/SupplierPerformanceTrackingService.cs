using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Model;
using MeroBolee.Repository.SupplierPerformanceTracking;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.SupplierPerformanceTracking
{
    public class SupplierPerformanceTrackingService: SupplierPerformanceTrackingMapper,ISupplierPerformanceTrackingService
    {
        private readonly ISupplierPerformanceTrackingRepository supplierPerformanceTrackingRepository;

        public SupplierPerformanceTrackingService(ISupplierPerformanceTrackingRepository supplierPerformanceTrackingRepository)
        {
            this.supplierPerformanceTrackingRepository = supplierPerformanceTrackingRepository;
        }

        public async Task<bool> SetQuestion(SetQuestionDto setQuestionDto)
        {
            try
            {
                if (setQuestionDto.Criterias.Count != 0)
                {
                    var supplierPerformanceTrackingEntities = ToSupplierPerformanceTrackingEntities(setQuestionDto);
                    if (supplierPerformanceTrackingEntities.Count()==0)
                    {
                        return false;
                    }
                    else
                    {
                        await supplierPerformanceTrackingRepository.AddBidderQuestion(supplierPerformanceTrackingEntities);
                        return true;
                    }
                    
                }
                else
                {
                    return false;
                }
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> SetRating(SetRating setRating)
        {
            try
            {
                if (setRating.Ratings.Count()==0)
                {
                    return false;
                }
                else
                {
                    var list = new List<SupplierPerformanceTrackingEntity>();
                    var supplierPerformanceTrackingEntities = await supplierPerformanceTrackingRepository.GetSupplierPerformanceTracking(setRating.TenderId, setRating.CompanyId);

                    foreach (var item in setRating.Ratings)
                    {
                        var obj = supplierPerformanceTrackingEntities.Where(x => x.Id == item.Id).FirstOrDefault();
                        if (obj != null)
                        {
                            obj.Id = item.Id;
                            obj.Ratings = item.Rating;
                            obj.Remarks = item.Remarks;
                            obj.RatingCreatedDate = DateTimeNPT.Now;
                            list.Add(obj);
                        }
                    }

                    if (list.Count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        await supplierPerformanceTrackingRepository.UpdateSupplierPerformanceTracking(list);
                        return true;
                    }
                }
            }
            catch
            {

                throw;
            }
        }

        public async Task<IEnumerable<SupplierPerformanceTrackingEntity>> GetBidderCriteria(long tenderId, long companyId)
        {
            try
            {
                return await supplierPerformanceTrackingRepository.FetchBidderCriteria(tenderId, companyId);
            }
            catch
            {

                throw;
            }
        }

        public async Task<double> GetTenderRating(long tenderId)
        {
            try
            {
                return await supplierPerformanceTrackingRepository.CalculateTenderRating(tenderId);
            }
            catch
            {

                throw;
            }
        }

        public async Task<double> GetOverallRating(long tenderId, long companyId)
        {
            try
            {
                return await supplierPerformanceTrackingRepository.CalculateOverallRating(tenderId, companyId);
            }
            catch
            {

                throw;
            }
        }

        public async Task<IEnumerable<TenderListDto>> GetTenderList(string search)
        {
            try
            {
               return await supplierPerformanceTrackingRepository.SearchTender(search);
            }
            catch 
            {

                throw;
            }
        }

        public async Task<IEnumerable<CriteriaDto>> GetTenderCriteria(long tenderId)
        {
            try
            {
                return await supplierPerformanceTrackingRepository.FindCriteriaByTenderId(tenderId);
            }
            catch 
            {

                throw;
            }
        }

        public async Task<bool> EditCriteria(CriteriaEditDto criteriaEditDto)
        {
            try
            {
                var entity = await supplierPerformanceTrackingRepository.FetchSupplierPerformanceTrackingById(criteriaEditDto.Id);
                if (entity != null)
                {
                    entity.Criteria = criteriaEditDto.Criteria;
                    entity.ModifiedDate = DateTimeNPT.Now;
                    await supplierPerformanceTrackingRepository.UpdateSupplierPerformanceTrackingEntity(entity);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch 
            {

                throw;
            }
        }

        public async Task<bool> DeleteCriteria(long id)
        {
            try
            {
                var entity = await supplierPerformanceTrackingRepository.FetchSupplierPerformanceTrackingById(id);
                if (entity != null)
                {
                    entity.IsDeleted = true;
                    entity.ModifiedDate = DateTimeNPT.Now;
                    await supplierPerformanceTrackingRepository.UpdateSupplierPerformanceTrackingEntity(entity);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch 
            {

                throw;
            }
        }

        public async Task<bool> AddCriteria(CriteraiAddDto criteraiAddDto)
        {
            try
            {
                var entity = ToSupplierPerformanceTrackingEntity(criteraiAddDto);
                await supplierPerformanceTrackingRepository.AddSupplierPerformanceTracking(entity);
                return true;
            }
            catch 
            {

                throw;
            }
        }
    }
}
