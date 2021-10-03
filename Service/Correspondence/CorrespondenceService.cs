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
    public interface ICorrespondenceService
    {
        CorrespondenceRequestResponseDto AddCorrespondenceEmail(CorrespondenceRequestDto dto);
        List<CorrespondenceResponseDto> GetAllCorrespondances(int supplierId);
        CorrespondenceResponseDto GetCorrespondanceDetail(int id);
        ResponseMsg ReadCorrespondanceEmail(int id);
    }

    public class CorrespondenceService : ICorrespondenceService
    {

        private readonly ICorrespondenceRepository correspondenceRepository;
        public CorrespondenceService(ICorrespondenceRepository correspondenceRepository)
        {
            this.correspondenceRepository = correspondenceRepository;
        }


        public CorrespondenceRequestResponseDto AddCorrespondenceEmail(CorrespondenceRequestDto dto)
        {
            try
            {
                CorrespondenceEmailEntity email = new CorrespondenceEmailEntity
                {
                    SenderUserId = dto.SenderId,
                    TenderId = dto.TenderId,
                    Subject = dto.Subject,
                    MailBody = dto.EmailBody,
                    IsRead = false,
                    EmailSentOn = dto.EmailSentDateTime,
                    DateCreated = DateTime.Now
                };
                email = correspondenceRepository.SendCorrespondenceEmail(email);
                return new CorrespondenceRequestResponseDto
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
        public List<CorrespondenceResponseDto> GetAllCorrespondances(int supplierId)
        {
            try
            {
                List<CorrespondenceEmailEntity> emails = correspondenceRepository.GetCorrespondenceEmails(supplierId);

                List<CorrespondenceResponseDto> response = new List<CorrespondenceResponseDto>();
                response = emails.Select(item => new CorrespondenceResponseDto()
                {
                    Id = item.Id,
                    IsRead = item.IsRead,
                    Subject = item.Subject,
                    SentOn = item.EmailSentOn,
                    TenderId = item.TenderId,
                    SupplierName = $"{item.User.First_Name} {item.User.Last_Name}",
                    SupplierCompany = item.User.Company.Name

                }).ToList();
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public CorrespondenceResponseDto GetCorrespondanceDetail(int id)
        {
            try
            {
                CorrespondenceEmailEntity email = correspondenceRepository.GetCorrespondenceEmailDetail(id);
                if (email != null)
                {
                    CorrespondenceResponseDto response = new CorrespondenceResponseDto
                    {
                        Id = email.Id,
                        Subject = email.Subject,
                        Body = email.MailBody,
                        SentOn = email.EmailSentOn,
                        TenderId = email.TenderId,
                        SupplierName = $"{email.User.First_Name} {email.User.Last_Name}",
                        SupplierCompany = email.User.Company.Name
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

        public ResponseMsg ReadCorrespondanceEmail(int id)
        {
            try
            {
                CorrespondenceEmailEntity email = correspondenceRepository.ReadCorrespondenceEmail(id);
                if (email != null)
                {
                    return new ResponseMsg
                    {
                        statusCode = "200",
                        Message = "Correspondance email is opened for reading."
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
