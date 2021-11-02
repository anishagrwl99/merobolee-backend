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

        EmailResponseDto ReplyPreAuctionEmailByAdmin(ReplyEmailDto dto);
        EmailResponseDto ReplyPreAuctionEmailByBidder(ReplyEmailDto dto);

        EmailResponseDto SendPostAuctionEmail(SendEmailDto dto, out bool isValidTender);

        EmailResponseDto ReplyPostAuctionEmailByBidInviter(ReplyEmailDto dto);
        EmailResponseDto ReplyPostAuctionEmailByAdmin(ReplyEmailDto dto);

        List<EmailResponseDto> GetInbox(long userId);
        List<EmailResponseDto> GetOutbox(long userId);
        EmailResponseDto GetEmailDetail(long emailId);
        bool ReadEmail(long emailId, long userId);


        EmailResponseDto SaveDraftPreAuctionEmailBidder(SendEmailDto dto); 
        EmailResponseDto SendDraftEmail(ReplyEmailDto dto); 



    }

    public class EmailService : EmailMapper, IEmailService
    {

        private readonly IEmailRepository emailRepository;
        private readonly ITenderService tenderService;
        private long _adminUserId = 1;

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

        public EmailResponseDto ReplyPreAuctionEmailByAdmin(ReplyEmailDto dto)
        {
            Tuple<long, long> parentEmail_Tender_Author = emailRepository.GetEmailTenderIdAndAuthorId(dto.EmailId);

            if (parentEmail_Tender_Author.Item1 > 0 && parentEmail_Tender_Author.Item2 > 0)
            {
                EmailEntity entity = DtoToEntity(dto);
                if (entity != null)
                {
                    entity.TenderId = parentEmail_Tender_Author.Item1;//Item 1 is tender id
                    entity.UserEmails = new List<UserEmailEntity>()
                                        {
                                            //User who sent an email
                                            new UserEmailEntity
                                            {
                                                Date_created = DateTime.Now,
                                                Date_modified = DateTime.Now,
                                                Email = entity,
                                                IsRead = false,
                                                UserId = parentEmail_Tender_Author.Item2
                                            }
                                        };
                    emailRepository.AddEmail(entity);
                }
                entity.Body = "";
                return EntityToDto(entity, false);
            }
            return null;
        }

        public EmailResponseDto ReplyPreAuctionEmailByBidder(ReplyEmailDto dto)
        {
            Tuple<long, long> parentEmail_Tender_Author = emailRepository.GetEmailTenderIdAndAuthorId(dto.EmailId);

            if (parentEmail_Tender_Author.Item1 > 0 && parentEmail_Tender_Author.Item2 > 0)
            {
                EmailEntity entity = DtoToEntity(dto);
                if (entity != null)
                {
                    entity.TenderId = parentEmail_Tender_Author.Item1;//Item 1 is tender id
                    entity.UserEmails = new List<UserEmailEntity>()
                                        {
                                            //Default User Id
                                            new UserEmailEntity
                                            {
                                                Date_created = DateTime.Now,
                                                Date_modified = DateTime.Now,
                                                Email = entity,
                                                IsRead = false,
                                                UserId = _adminUserId
                                            }
                                        };
                    emailRepository.AddEmail(entity);
                }
                entity.Body = "";
                return EntityToDto(entity, false);
            }
            return null;
        }

        public EmailResponseDto ReplyPostAuctionEmailByBidInviter(ReplyEmailDto dto)
        {
            Tuple<long, long> parentEmail_Tender_Author = emailRepository.GetEmailTenderIdAndAuthorId(dto.EmailId);
            if (parentEmail_Tender_Author.Item1 > 0 && parentEmail_Tender_Author.Item2 > 0)
            {
                EmailEntity entity = DtoToEntity(dto);
                if (entity != null)
                {


                    entity.TenderId = parentEmail_Tender_Author.Item1;//Item 1 is tender id
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

                                            //Supplier 
                                            new UserEmailEntity
                                            {
                                                Date_created = DateTime.Now,
                                                Date_modified = DateTime.Now,
                                                Email = entity,
                                                IsRead = false,
                                                UserId = parentEmail_Tender_Author.Item2
                                            }
                                        };

                    emailRepository.AddEmail(entity);
                }
                entity.Body = "";
                return EntityToDto(entity, false);
            }
            return null;
        }

        public EmailResponseDto ReplyPostAuctionEmailByAdmin(ReplyEmailDto dto)
        {
            Tuple<long, long> parentEmail_Tender_Author = emailRepository.GetEmailTenderIdAndAuthorId(dto.EmailId);
            Tuple<long, long> tender_user = tenderService.GetTenderIdFromCode(dto.TenderCode);
            if (parentEmail_Tender_Author.Item1 > 0 && parentEmail_Tender_Author.Item2 > 0)
            {
                EmailEntity entity = DtoToEntity(dto);
                if (entity != null)
                {


                    entity.TenderId = parentEmail_Tender_Author.Item1;//Item 1 is tender id
                    entity.UserEmails = new List<UserEmailEntity>()
                                        {
                                            //Bid Inviter
                                            new UserEmailEntity
                                            {
                                                Date_created = DateTime.Now,
                                                Date_modified = DateTime.Now,
                                                Email = entity,
                                                IsRead = false,
                                                UserId = 1
                                            },

                                            //Supplier 
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
                entity.Body = "";
                return EntityToDto(entity, false);
            }
            return null;
        }

        public bool ReadEmail(long emailId, long userId)
        {
            UserEmailEntity ue = emailRepository.ReadEmail(emailId, userId);
            return ue != null;
        }



        #region Draft

        public EmailResponseDto SaveDraftPreAuctionEmailBidder(SendEmailDto dto)
        {
            Tuple<long, long> tender_user = tenderService.GetTenderIdFromCode(dto.TenderCode);

            if (tender_user.Item1 > 0)
            {
                EmailEntity entity = DtoToEntity(dto, true);
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
                                                UserId = _adminUserId
                                            }
                                        };
                    emailRepository.AddEmail(entity);
                }
                entity.Body = "";
                return EntityToDto(entity, false);
            }
            return null;
        }

        public EmailResponseDto SendDraftEmail(ReplyEmailDto dto)
        {
            EmailEntity e = emailRepository.SendDraftEmail(dto);
            return EntityToDto(e, false);
        }

        #endregion
    }
}
