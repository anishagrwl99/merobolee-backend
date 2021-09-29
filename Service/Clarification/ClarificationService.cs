using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public interface IClarificationService
    {
        ClarificationRequestResponseDto AddClarificationEmail(ClarificationRequestDto dto);
        List<ClarificationResponseDto> GetAllClarification(int supplierId);
        ClarificationResponseDto GetClarificationDetail(int id);
        ResponseMsg ReadClarificationEmail(int id);
    }

    public class ClarificationService : IClarificationService
    {

        private readonly IClarificationRepository clarificationRepository;
        public ClarificationService(IClarificationRepository clarificationRepository)
        {
            this.clarificationRepository = clarificationRepository;
        }


        public ClarificationRequestResponseDto AddClarificationEmail(ClarificationRequestDto dto)
        {
            try
            {
                ClarificationEmailEntity email = new ClarificationEmailEntity
                {
                    SenderUserId = dto.SenderId,
                    CorrespondenceId = dto.CorrespondenceId,
                    Subject = dto.Subject,
                    MailBody = dto.EmailBody,
                    IsRead = false,
                    EmailSentOn = dto.EmailSentDateTime,
                    DateCreated = DateTime.Now
                };
                email = clarificationRepository.SendClarificationEmail(email);
                return new ClarificationRequestResponseDto
                {
                    MailId = email.Id,
                    Subject = email.Subject,
                    SentDate = email.DateCreated
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ClarificationResponseDto> GetAllClarification(int id)
        {
            try
            {
                List<ClarificationEmailEntity> emails = clarificationRepository.GetClarificationEmails(id);

                List<ClarificationResponseDto> response = new List<ClarificationResponseDto>();
                response = emails.Select(item => new ClarificationResponseDto()
                {
                    Id = item.Id,
                    IsRead = item.IsRead,
                    Subject = item.Subject,
                    SentOn = item.EmailSentOn,
                    CorrespondenceId = item.CorrespondenceId,
                    SenderName = $"{item.UserEntity.First_Name} {item.UserEntity.Last_Name}"

                }).ToList();
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ClarificationResponseDto GetClarificationDetail(int id)
        {
            try
            {
                ClarificationEmailEntity email = clarificationRepository.GetClarificationEmailDetail(id);
                if (email != null)
                {
                    ClarificationResponseDto response = new ClarificationResponseDto
                    {
                        Id = email.Id,
                        Subject = email.Subject,
                        Body = email.MailBody,
                        SentOn = email.EmailSentOn,
                        CorrespondenceId = email.CorrespondenceId,
                        SenderName = $"{email.UserEntity.First_Name} {email.UserEntity.Last_Name}"
                    };
                    return response;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ResponseMsg ReadClarificationEmail(int id)
        {
            try
            {
                ClarificationEmailEntity email = clarificationRepository.ReadClarificationEmail(id);
                if (email != null)
                {
                    return new ResponseMsg
                    {
                        statusCode = "200",
                        Message = "Clarification email is opened for reading."
                    };
                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }


    }
}
