using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Repository;
using MeroBolee.Service.Tender;
using MeroBolee.Service.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public interface IEmailService
    {
        EmailResponseDto SendPreAuctionEmail(SendEmailDto dto, out bool isValidTender);
        EmailResponseDto SendPostAuctionEmail(SendEmailDto dto, out bool isValidTender);
        List<EmailResponseDto> GetInbox(long userId);
        List<EmailResponseDto> GetOutbox(long userId);
        EmailResponseDto GetEmailDetail(long emailId);
        bool ReadEmail(long emailId, long userId);

    }

    public class EmailService : EmailMapper, IEmailService
    {

        private readonly IEmailRepository emailRepository;
        private readonly ITenderService tenderService;

        public EmailService(IEmailRepository emailRepository, ITenderService tenderService)
        {
            this.emailRepository = emailRepository;
            this.tenderService = tenderService;
        }

        public EmailResponseDto GetEmailDetail(long emailId)
        {
            EmailEntity entity = emailRepository.GetEmailDetail(emailId);
            return EntityToDto(entity, false);
        }

        public List<EmailResponseDto> GetInbox(long userId)
        {
            List<EmailEntity> entities = emailRepository.GetInboxEmails(userId);
            return EntityToDtoList(entities, true);
        }

        public List<EmailResponseDto> GetOutbox(long userId)
        {
            List<EmailEntity> entities = emailRepository.GetOutboxEmails(userId);
            return EntityToDtoList(entities, false);
        }

        public EmailResponseDto SendPostAuctionEmail(SendEmailDto dto, out bool isValidTender)
        {
            Tuple<long, long> tender_user = tenderService.GetTenderIdFromCode(dto.TenderCode);
            if (tender_user.Item1 > 0)
            {
                EmailEntity entity = DtoToEntity(dto);
                if (entity != null)
                {


                    entity.TenderId = tender_user.Item1;//Item 1 is tender id
                    entity.UserEmails = new List<UserEmailEntity>()
                                        {
                                            //Merobolee default user
                                            new UserEmailEntity
                                            {
                                                Date_created = DateTime.Now,
                                                Date_modified = DateTime.Now,
                                                Email = entity,
                                                IsRead = false,
                                                UserId = 1
                                            },

                                            //Tender default user
                                            new UserEmailEntity
                                            {
                                                Date_created = DateTime.Now,
                                                Date_modified = DateTime.Now,
                                                Email = entity,
                                                IsRead = false,
                                                UserId = tender_user.Item2
                                            }
                                        };
                    emailRepository.AddEmail(entity);                    
                }
                isValidTender = true;
                entity.Body = "";
                return EntityToDto(entity, false);
            }
            isValidTender = false;
            return null;
        }

        public EmailResponseDto SendPreAuctionEmail(SendEmailDto dto, out bool isValidTender)
        {
            Tuple<long, long> tender_user = tenderService.GetTenderIdFromCode(dto.TenderCode);

            if (tender_user.Item1 > 0)
            {
                EmailEntity entity = DtoToEntity(dto);
                if (entity != null)
                {
                    entity.TenderId = tender_user.Item1;//Item 1 is tender id
                    entity.UserEmails = new List<UserEmailEntity>()
                                        {
                                            //Merobolee default user
                                            new UserEmailEntity
                                            {
                                                Date_created = DateTime.Now,
                                                Date_modified = DateTime.Now,
                                                Email = entity,
                                                IsRead = false,
                                                UserId = 1
                                            }
                                        };
                    emailRepository.AddEmail(entity);
                }
                isValidTender = true;
                entity.Body = "";
                return EntityToDto(entity, false);
            }
            isValidTender = false;
            return null;
        }

        public bool ReadEmail(long emailId, long userId)
        {
            UserEmailEntity ue = emailRepository.ReadEmail(emailId, userId);
            return ue != null;
        }
    }
}
