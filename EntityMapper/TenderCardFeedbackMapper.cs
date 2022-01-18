using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    public class TenderCardFeedbackMapper
    {
        public TenderCardFeedbackEntity ToEntity(TenderCardFeedbackDto dto)
        {
            return new TenderCardFeedbackEntity
            {
                CompanyId = dto.CompanyId,
                TenderId = dto.TenderId,
                UserId = dto.UserId,
                Date_created = DateTime.Now,
                Date_modified = DateTime.Now,
                Feeback = dto.Feedback
            };
        }

        public TenderCardFeedbackResponseDto ToDto(TenderCardFeedbackEntity entity)
        {
            TenderCardFeedbackResponseDto dto = new TenderCardFeedbackResponseDto();
            dto.CompanyId = entity.CompanyId;
            dto.TenderId = entity.TenderId;
            dto.UserId = entity.UserId;
            dto.Feedback = entity.Feeback;
            dto.SenderCompany = entity.Company.Name;
            dto.SenderName = $"{entity.User.FirstName} {(string.IsNullOrEmpty(entity.User.MiddleName) ? entity.User.LastName : entity.User.MiddleName + " " + entity.User.LastName)}";

            return dto;
        }
    }
}
