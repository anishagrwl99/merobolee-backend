using MeroBolee.Dto;
using MeroBolee.Model;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace MeroBolee.EntityMapper
{
    public class SupplierPerformanceTrackingMapper
    {
        public IEnumerable<SupplierPerformanceTrackingEntity> ToSupplierPerformanceTrackingEntities(SetQuestionDto setQuestionDto)
        {
            var list = new List<SupplierPerformanceTrackingEntity>();

            foreach (var item in setQuestionDto.Criterias)
            {
                var obj = new SupplierPerformanceTrackingEntity
                {
                    TenderId = setQuestionDto.TenderId,
                    CompanyId = setQuestionDto.CompanyId,
                    Criteria = item.Criteria,
                    CreatedDate = DateTimeNPT.Now,
                    ModifiedDate = DateTimeNPT.Now,
                    RatingCreatedDate = DateTimeNPT.Now,
                };
                list.Add(obj);
            }
            return list;
        }

        public SupplierPerformanceTrackingEntity ToSupplierPerformanceTrackingEntity(CriteraiAddDto criteraiAddDto)
        {
            var obj = new SupplierPerformanceTrackingEntity
            {
                TenderId = criteraiAddDto.TenderId,
                CompanyId = criteraiAddDto.CompanyId,
                Criteria = criteraiAddDto.Criteria,
                CreatedDate = DateTimeNPT.Now,
                ModifiedDate = DateTimeNPT.Now,
                RatingCreatedDate = DateTimeNPT.Now,
            };

            return obj;
        }
    }
}
