using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Model;
using MeroBolee.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public interface ITenderCardFeedbackService
    {
        Task<TenderCardFeedbackDto> AddFeedback(TenderCardFeedbackDto entity);
        Task<List<TenderCardFeedbackResponseDto>> ListTenderFeedback(long companyId, long tenderId);
    }

    public class TenderCardFeedbackService : TenderCardFeedbackMapper, ITenderCardFeedbackService
    {
        private readonly ITenderCardFeedbackRepository feedbackRepository;
        private readonly ITenderRepository tenderRepository;

        public TenderCardFeedbackService(ITenderCardFeedbackRepository feedbackRepository, ITenderRepository tenderRepository)
        {
            this.feedbackRepository = feedbackRepository;
            this.tenderRepository = tenderRepository;
        }



        public async Task<TenderCardFeedbackDto> AddFeedback(TenderCardFeedbackDto feedbackDto)
        {
            try
            {
                TenderCardFeedbackEntity ent = ToEntity(feedbackDto);
                await feedbackRepository.SaveFeedback(ent);
                TenderEntity te = await tenderRepository.GetTenderEntityOnly(feedbackDto.TenderId);
                te.StatusId = 2;
                await tenderRepository.UpdateTender(te);
                return feedbackDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<TenderCardFeedbackResponseDto>> ListTenderFeedback(long companyId, long tenderId)
        {
            try
            {
                List<TenderCardFeedbackEntity> entities = await feedbackRepository.ListTenderFeedback(companyId, tenderId);
                List<TenderCardFeedbackResponseDto> dto = new List<TenderCardFeedbackResponseDto>();
                foreach (var item in entities)
                {
                    dto.Add(ToDto(item));
                }
                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
