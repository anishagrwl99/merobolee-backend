using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Repository;
using MeroBolee.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public interface IEmailService
    {
        EmailResponseDto SendPreAuctionEmailBidder(SendEmailDto dto, bool isDraft);

        EmailResponseDto ReplyPreAuctionEmailByAdmin(ReplyEmailDto dto);
        EmailResponseDto ReplyPreAuctionEmailByBidder(ReplyEmailDto dto);

        EmailResponseDto SavePostAuctionEmailBidder(SendEmailDto dto, bool isDraft);

        EmailResponseDto ReplyPostAuctionEmailByBidInviter(ReplyEmailDto dto);
        EmailResponseDto ReplyPostAuctionEmailByAdmin(ReplyEmailDto dto);

        List<EmailResponseDto> GetInbox(long userId);
        List<TechnicalSupportEmailResponseDto> GetTechnicalSupportInbox(long userId);
        List<EmailResponseDto> GetOutbox(long userId);
        List<TechnicalSupportEmailResponseDto> GetTechnicalSupportOutbox(long userId);
        List<EmailResponseDto> GetDraft(long userId);
        EmailResponseDto GetEmailDetail(long emailId);
        TechnicalSupportEmailResponseDto GetTechnicalSupportEmailDetail(long emailId);
        bool ReadEmail(long emailId, long userId);
        bool ReadTechnicalSupportEmail(long emailId, long userId);

        EmailResponseDto SendDraftEmail(ReplyEmailDto dto);


        EmailResponseDto SaveDraftPreAuctionEmailBidder(SendEmailDto dto);


        //Bid Inviter
        EmailResponseDto SendPostAuctionEmailBidInviter(SendEmailDto dto, bool isDraft);


        //Admin
        EmailResponseDto SendPostAuctionEmailAdmin(SendEmailDto dto, bool isDraft);
    }

    public class EmailService : EmailMapper, IEmailService
    {

        private readonly IEmailRepository emailRepository;
        private readonly ITenderService tenderService;
        private readonly IUserService userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailService"/> class.
        /// </summary>
        /// <param name="emailRepository">The email repository.</param>
        /// <param name="tenderService">The tender service.</param>
        /// <param name="userService">The user service.</param>
        public EmailService(IEmailRepository emailRepository, ITenderService tenderService, IUserService userService)
        {
            this.emailRepository = emailRepository;
            this.tenderService = tenderService;
            this.userService = userService;
        }

        public EmailResponseDto GetEmailDetail(long emailId)
        {
            EmailEntity entity = emailRepository.GetEmailDetail(emailId);
            return EntityToDto(entity, false, entity.TenderCode);
        }

        public TechnicalSupportEmailResponseDto GetTechnicalSupportEmailDetail(long emailId)
        {
            return emailRepository.GetTechnicalSupportEmailDetail(emailId);
        }

        public List<EmailResponseDto> GetInbox(long userId)
        {
            List<EmailEntity> entities = emailRepository.GetInboxEmails(userId);
            return EntityToDtoList(entities, true);
        }

        public List<TechnicalSupportEmailResponseDto> GetTechnicalSupportInbox(long userId)
        {
            return emailRepository.GetTechnicalSupportInboxEmails(userId);
        }

        public List<EmailResponseDto> GetOutbox(long userId)
        {
            List<EmailEntity> entities = emailRepository.GetOutboxEmails(userId);
            return EntityToDtoList(entities, false);
        }
        public List<TechnicalSupportEmailResponseDto> GetTechnicalSupportOutbox(long userId)
        {
            return emailRepository.GetTechnicalSupportOutboxEmails(userId);            
        }

        public List<EmailResponseDto> GetDraft(long userId)
        {
            List<EmailEntity> entities = emailRepository.GetDraftEmails(userId);
            return EntityToDtoList(entities, false);
        }

        public EmailResponseDto SavePostAuctionEmailBidder(SendEmailDto dto, bool isDraft)
        {
            Tuple<long, List<long>> tender_user = tenderService.GetTenderIdFromCode(dto.TenderCode);
            if (tender_user.Item1 > 0)
            {
                EmailEntity entity = DtoToEntity(dto, isDraft, true);
                if (entity != null)
                {


                    entity.TenderId = tender_user.Item1;//Item 1 is tender id
                    entity.UserEmails = new List<UserEmailEntity>();
                    foreach (var u in tender_user.Item2)
                    {
                        entity.UserEmails.Add(new UserEmailEntity
                        {
                            Date_created = DateTime.Now,
                            Date_modified = DateTime.Now,
                            Email = entity,
                            IsRead = false,
                            UserId = u
                        });
                    }
                    List<long> users = GetMeroboleeEmailReceivers().Result;
                    foreach (var user in users)
                    {
                        entity.UserEmails.Add(new UserEmailEntity
                        {
                            Date_created = DateTime.Now,
                            Date_modified = DateTime.Now,
                            Email = entity,
                            IsRead = false,
                            UserId = user
                        });
                    }
                    emailRepository.AddEmail(entity);
                }
                entity.Body = "";
                return EntityToDto(entity, false, dto.TenderCode);
            }
            return null;
        }

        public EmailResponseDto SendPreAuctionEmailBidder(SendEmailDto dto, bool isDraft)
        {
            Tuple<long, List<long>> tender_user = tenderService.GetTenderIdFromCode(dto.TenderCode);

            if (tender_user.Item1 > 0)
            {
                EmailEntity entity = DtoToEntity(dto, isDraft, false);
                if (entity != null)
                {
                    entity.TenderId = tender_user.Item1;//Item 1 is tender id
                    List<long> users = GetMeroboleeEmailReceivers().Result;
                    entity.UserEmails = new List<UserEmailEntity>();                   
                    foreach (var user in users)
                    {
                        entity.UserEmails.Add(new UserEmailEntity
                        {
                            Date_created = DateTime.Now,
                            Date_modified = DateTime.Now,
                            Email = entity,
                            IsRead = false,
                            UserId = user
                        });
                    }
                    emailRepository.AddEmail(entity);
                }
                entity.Body = "";
                return EntityToDto(entity, false, dto.TenderCode);
            }
            return null;
        }

        public EmailResponseDto ReplyPreAuctionEmailByAdmin(ReplyEmailDto dto)
        {
            Tuple<long, long> parentEmail_Tender_Author = emailRepository.GetEmailTenderIdAndAuthorId(dto.EmailId);

            if (parentEmail_Tender_Author.Item1 > 0 && parentEmail_Tender_Author.Item2 > 0)
            {
                EmailEntity entity = DtoToEntity(dto, false, false);
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
                    List<long> users = GetReplyReceiversForAdmin(entity.AuthorId).Result;
                    foreach (var user in users)
                    {
                        entity.UserEmails.Add(new UserEmailEntity
                        {
                            Date_created = DateTime.Now,
                            Date_modified = DateTime.Now,
                            Email = entity,
                            IsRead = false,
                            UserId = user
                        });
                    }
                    emailRepository.AddEmail(entity);
                }
                entity.Body = "";
                return EntityToDto(entity, false, dto.TenderCode);
            }
            return null;
        }

        public EmailResponseDto ReplyPreAuctionEmailByBidder(ReplyEmailDto dto)
        {
            Tuple<long, long> parentEmail_Tender_Author = emailRepository.GetEmailTenderIdAndAuthorId(dto.EmailId);

            if (parentEmail_Tender_Author.Item1 > 0 && parentEmail_Tender_Author.Item2 > 0)
            {
                EmailEntity entity = DtoToEntity(dto, false, false);
                if (entity != null)
                {
                    entity.TenderId = parentEmail_Tender_Author.Item1;//Item 1 is tender id
                    List<long> users = GetMeroboleeEmailReceivers().Result;
                    entity.UserEmails = new List<UserEmailEntity>();
                    foreach (var user in users)
                    {
                        entity.UserEmails.Add(new UserEmailEntity
                        {
                            Date_created = DateTime.Now,
                            Date_modified = DateTime.Now,
                            Email = entity,
                            IsRead = false,
                            UserId = user
                        });
                    }

                    emailRepository.AddEmail(entity);
                }
                entity.Body = "";
                return EntityToDto(entity, false, dto.TenderCode);
            }
            return null;
        }

        public EmailResponseDto ReplyPostAuctionEmailByBidInviter(ReplyEmailDto dto)
        {
            Tuple<long, List<long>> tenderWinner = tenderService.GetTenderWinnerIdFromCode(dto.TenderCode);
            if (tenderWinner.Item1 > 0 && tenderWinner.Item2.Count > 0)
            {
                EmailEntity entity = DtoToEntity(dto, false, true);
                if (entity != null)
                {


                    entity.TenderId = tenderWinner.Item1;//Item 1 is tender id
                    entity.UserEmails = new List<UserEmailEntity>();
                    foreach (var winnerUser in tenderWinner.Item2)
                    {
                        entity.UserEmails.Add(new UserEmailEntity
                        {
                            Date_created = DateTime.Now,
                            Date_modified = DateTime.Now,
                            Email = entity,
                            IsRead = false,
                            UserId = winnerUser
                        });
                    }

                    List<long> users = GetMeroboleeEmailReceivers().Result;
                    foreach (var user in users)
                    {
                        entity.UserEmails.Add(new UserEmailEntity
                        {
                            Date_created = DateTime.Now,
                            Date_modified = DateTime.Now,
                            Email = entity,
                            IsRead = false,
                            UserId = user
                        });
                    }
                    emailRepository.AddEmail(entity);
                }
                entity.Body = "";
                return EntityToDto(entity, false, dto.TenderCode);
            }
            return null;
        }

        public EmailResponseDto ReplyPostAuctionEmailByAdmin(ReplyEmailDto dto)
        {
            Tuple<long, List<long>> tender_winner = tenderService.GetTenderWinnerIdFromCode(dto.TenderCode);
            Tuple<long, List<long>> tender_user = tenderService.GetTenderIdFromCode(dto.TenderCode);
            if (tender_winner.Item1 > 0 && tender_winner.Item2.Count > 0)
            {
                EmailEntity entity = DtoToEntity(dto, false, true);
                if (entity != null)
                {
                    entity.TenderId = tender_winner.Item1;//Item 1 is tender id
                    entity.UserEmails = new List<UserEmailEntity>();
                    foreach (var winnerUser in tender_winner.Item2)
                    {
                        entity.UserEmails.Add(//Bid Inviter 
                                            new UserEmailEntity
                                            {
                                                Date_created = DateTime.Now,
                                                Date_modified = DateTime.Now,
                                                Email = entity,
                                                IsRead = false,
                                                UserId = winnerUser
                                            });
                    }
                    foreach (var companyUser in tender_user.Item2)
                    {
                        entity.UserEmails.Add(//Bid Inviter 
                                            new UserEmailEntity
                                            {
                                                Date_created = DateTime.Now,
                                                Date_modified = DateTime.Now,
                                                Email = entity,
                                                IsRead = false,
                                                UserId = companyUser
                                            });
                    }
                    List<long> meroboleeUsers = GetReplyReceiversForAdmin(dto.UserId).Result;
                    foreach (var user in meroboleeUsers)
                    {
                        entity.UserEmails.Add(//Bid Inviter 
                                            new UserEmailEntity
                                            {
                                                Date_created = DateTime.Now,
                                                Date_modified = DateTime.Now,
                                                Email = entity,
                                                IsRead = false,
                                                UserId = user
                                            });
                    }
                    emailRepository.AddEmail(entity);
                }
                entity.Body = "";
                return EntityToDto(entity, false, dto.TenderCode);
            }
            return null;
        }

        public bool ReadEmail(long emailId, long userId)
        {
            UserEmailEntity ue = emailRepository.ReadEmail(emailId, userId);
            return ue != null;
        }
        public bool ReadTechnicalSupportEmail(long emailId, long userId)
        {
            TechnicalSupportReceiver ue = emailRepository.ReadTechnicalSupportEmail(emailId, userId);
            return ue != null;
        }



        #region Draft


        public EmailResponseDto SaveDraftPreAuctionEmailBidder(SendEmailDto dto)
        {
            Tuple<long, List<long>> tender_user = tenderService.GetTenderIdFromCode(dto.TenderCode);

            if (tender_user.Item1 > 0)
            {
                EmailEntity entity = DtoToEntity(dto, true, false);
                if (entity != null)
                {
                    entity.TenderId = tender_user.Item1;//Item 1 is tender id
                    List<long> users = GetMeroboleeEmailReceivers().Result;
                    entity.UserEmails = new List<UserEmailEntity>();
                    foreach (var user in users)
                    {
                        entity.UserEmails.Add(new UserEmailEntity
                        {
                            Date_created = DateTime.Now,
                            Date_modified = DateTime.Now,
                            Email = entity,
                            IsRead = false,
                            UserId = user
                        });
                    }
                    //entity.UserEmails = new List<UserEmailEntity>()
                    //                    {
                    //                        //Merobolee default user
                    //                        new UserEmailEntity
                    //                        {
                    //                            Date_created = DateTime.Now,
                    //                            Date_modified = DateTime.Now,
                    //                            Email = entity,
                    //                            IsRead = false,
                    //                            UserId = tender_user.Item2
                    //                        }
                    //                    };
                    emailRepository.AddEmail(entity);
                }
                entity.Body = "";
                return EntityToDto(entity, false, dto.TenderCode);
            }
            return null;
        }



        public EmailResponseDto SendDraftEmail(ReplyEmailDto dto)
        {
            EmailEntity e = emailRepository.SendDraftEmail(dto);
            return EntityToDto(e, false, dto.TenderCode);
        }

        #endregion


        #region Bid Inviter
        public EmailResponseDto SendPostAuctionEmailBidInviter(SendEmailDto dto, bool isDraft)
        {
            try
            {
                Tuple<long, List<long>> tenderWinner = tenderService.GetTenderWinnerIdFromCode(dto.TenderCode);
                if (tenderWinner.Item1 > 0 && tenderWinner.Item2.Count > 0)
                {
                    EmailEntity entity = DtoToEntity(dto, isDraft, true);
                    if (entity != null)
                    {


                        entity.TenderId = tenderWinner.Item1;//Item 1 is tender id
                        entity.UserEmails = new List<UserEmailEntity>();
                        foreach (var winnerUser in tenderWinner.Item2)
                        {
                            entity.UserEmails.Add(new UserEmailEntity
                            {
                                Date_created = DateTime.Now,
                                Date_modified = DateTime.Now,
                                Email = entity,
                                IsRead = false,
                                UserId = winnerUser
                            });
                        }

                        List<long> users = GetMeroboleeEmailReceivers().Result;
                        foreach (var user in users)
                        {
                            entity.UserEmails.Add(new UserEmailEntity
                            {
                                Date_created = DateTime.Now,
                                Date_modified = DateTime.Now,
                                Email = entity,
                                IsRead = false,
                                UserId = user
                            });
                        }
                        emailRepository.AddEmail(entity);
                    }
                    entity.Body = "";
                    return EntityToDto(entity, false, dto.TenderCode);
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion



        #region Admin

        public EmailResponseDto SendPostAuctionEmailAdmin(SendEmailDto dto, bool isDraft)

        {
            try
            {
                Tuple<long, List<long>> tenderWinner = tenderService.GetTenderWinnerIdFromCode(dto.TenderCode);
                Tuple<long, List<long>> tenderCreator = tenderService.GetTenderIdFromCode(dto.TenderCode);
                if (tenderWinner.Item1 > 0 && tenderWinner.Item2.Count > 0)
                {
                    EmailEntity entity = DtoToEntity(dto, isDraft, true);
                    if (entity != null)
                    {


                        entity.TenderId = tenderWinner.Item1;//Item 1 is tender id
                        entity.UserEmails = new List<UserEmailEntity>();
                        foreach (var winnerUser in tenderWinner.Item2)
                        {
                            entity.UserEmails.Add(new UserEmailEntity
                            {
                                Date_created = DateTime.Now,
                                Date_modified = DateTime.Now,
                                Email = entity,
                                IsRead = false,
                                UserId = winnerUser
                            });
                        }
                        foreach (var companyUser in tenderCreator.Item2)
                        {
                            entity.UserEmails.Add(new UserEmailEntity
                            {
                                Date_created = DateTime.Now,
                                Date_modified = DateTime.Now,
                                Email = entity,
                                IsRead = false,
                                UserId = companyUser
                            });
                        }
                        List<long> meroboleUsers = GetReplyReceiversForAdmin(dto.UserId).Result;
                        foreach (var user in meroboleUsers)
                        {
                            entity.UserEmails.Add(new UserEmailEntity
                            {
                                Date_created = DateTime.Now,
                                Date_modified = DateTime.Now,
                                Email = entity,
                                IsRead = false,
                                UserId = user
                            });
                        }
                        emailRepository.AddEmail(entity);
                    }
                    entity.Body = "";
                    return EntityToDto(entity, false, dto.TenderCode);
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion


        #region Private Methods

        private async Task<List<long>> GetMeroboleeEmailReceivers()
        {
            List<UserEntity> users = await userService.GetMeroboleeUsers();
            List<long> userIds = new List<long>();
            userIds.AddRange(users.Where(x => x.RoleId == 1).Select(x => x.Id).ToList());//Admins
            userIds.AddRange(users.Where(x => x.RoleId == 2).Select(x => x.Id).ToList());//Technical Support

            return userIds;
        }

        private async Task<List<long>> GetReplyReceiversForAdmin(long myId)
        {
            List<UserEntity> users = await userService.GetMeroboleeUsers();
            List<long> userIds = new List<long>();
            userIds.AddRange(users.Where(x => x.RoleId == 1 && x.Id != myId).Select(x => x.Id).ToList());//Admins
            userIds.AddRange(users.Where(x => x.RoleId == 2 && x.Id != myId).Select(x => x.Id).ToList());//Technical Support

            return userIds;
        }

        #endregion
    }
}
