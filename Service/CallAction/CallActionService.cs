using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Repository;
using MeroBolee.Service.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public interface ICallActionService
    {
        CallActionRequestResponseDto AddCallActionEmail(CallActionRequestDto dto);
        List<CallActionResponseDto> GetAllCallAction();
        List<CallActionResponseDto> GetAllCallActionNested();
        CallActionResponseDto GetCallActionDetail(int id);
        ResponseMsg ReadCallActionEmail(int id);
    }

    public class CallActionService : ICallActionService
    {

        private readonly ICallActionRepository callActionRepository;
        private readonly IUserService userService;

        public CallActionService(ICallActionRepository callActionRepository, IUserService userService)
        {
            this.callActionRepository = callActionRepository;
            this.userService = userService;
        }


        public CallActionRequestResponseDto AddCallActionEmail(CallActionRequestDto dto)
        {
            try
            {
                CallActionEmailEntity email = new CallActionEmailEntity
                {
                    SenderUserId = dto.SenderId,
                    ParentId = dto.ParentId,
                    Subject = dto.Subject,
                    MailBody = dto.EmailBody,
                    IsRead = false,
                    EmailSentOn = dto.EmailSentDateTime,
                    DateCreated = DateTime.Now
                };
                email = callActionRepository.SendCallActionEmail(email);
                return new CallActionRequestResponseDto
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
        public List<CallActionResponseDto> GetAllCallAction()
        {
            try
            {
                //collection.SelectMany(c => c.Children).Concat(collection).Where(c => c.id == id)

                List<CallActionEmailEntity> emails = callActionRepository.GetCallActionEmails();

                List<CallActionResponseDto> response = new List<CallActionResponseDto>();
                response = emails.Select(item => new CallActionResponseDto()
                {
                   
                    Id = item.Id,
                    IsRead = item.IsRead,
                    Subject = item.Subject,
                    SentOn = item.EmailSentOn,
                    ParentId = item.ParentId,
                    SenderName = $"{item.UserEntity.First_Name} {item.UserEntity.Last_Name}"
                }).ToList();

                 
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<CallActionResponseDto> GetAllCallActionNested()
        {
            try
            {
                //collection.SelectMany(c => c.Children).Concat(collection).Where(c => c.id == id)

                List<CallActionEmailEntity> emails = callActionRepository.GetCallActionEmailsNested();

                List<CallActionResponseDto> response = new List<CallActionResponseDto>();
                response = emails.Select(item => new CallActionResponseDto()
                {

                    Id = item.Id,
                    IsRead = item.IsRead,
                    Subject = item.Subject,
                    SentOn = item.EmailSentOn,
                    ParentId = item.ParentId,
                    SenderName = $"{item.UserEntity.First_Name} {item.UserEntity.Last_Name}",

                    Responses = item.Responses.Select(x => new CallActionResponseDto()
                    {
                        Id = x.Id,
                        ParentId = x.ParentId,
                        Subject = x.Subject,
                        SenderName = GetEmailSenderName(x.UserEntity, x.SenderUserId),//$"{x.UserEntity.First_Name} {x.UserEntity.Last_Name}"

                    }).ToList()

                }).ToList();


                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public CallActionResponseDto GetCallActionDetail(int id)
        {
            try
            {
                CallActionEmailEntity email = callActionRepository.GetCallActionEmailDetail(id);
                if (email != null)
                {
                    CallActionResponseDto response = new CallActionResponseDto
                    {
                        Id = email.Id,
                        Subject = email.Subject,
                        Body = email.MailBody,
                        SentOn = email.EmailSentOn,
                        ParentId = email.ParentId,
                        SenderName =  $"{email.UserEntity.First_Name} {email.UserEntity.Last_Name}",
                        
                        
                    };

                    if (email.ParentEmail != null)
                    {
                        response.Parent = new CallActionResponseDto
                        {
                            Id = email.ParentEmail.Id,
                            Subject = email.ParentEmail.Subject,
                            Body = email.ParentEmail.MailBody,
                            SentOn = email.ParentEmail.EmailSentOn,
                            SenderName = GetEmailSenderName(email.ParentEmail.UserEntity, email.ParentEmail.SenderUserId)
                            
                        };
                        var parentResponses = callActionRepository.GetCallActionParentEmailsResponses(email.Id, email.ParentId.Value);
                        if(parentResponses != null)
                        {
                            response.Parent.Responses = parentResponses.Select(x => new CallActionResponseDto()
                            {
                                Id = x.Id,
                                ParentId = x.ParentId,
                                Subject = x.Subject,
                                Body = x.MailBody,
                                SenderName = GetEmailSenderName(x.UserEntity, x.SenderUserId),

                            })
                            .ToList();
                        }

                    }
                    if(email.Responses != null)
                    {
                        response.Responses = email.Responses.Select(x => new CallActionResponseDto()
                        {
                            Id = x.Id,
                            ParentId = x.ParentId,
                            Subject = x.Subject,
                            Body = x.MailBody,
                            SenderName = GetEmailSenderName(x.UserEntity, x.SenderUserId),//$"{x.UserEntity.First_Name} {x.UserEntity.Last_Name}"

                        }).ToList();
                    }


                    return response;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ResponseMsg ReadCallActionEmail(int id)
        {
            try
            {
                CallActionEmailEntity email = callActionRepository.ReadCallActionEmail(id);
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

        private string GetEmailSenderName(UserEntity entity, int userId)
        {
            string name = "";
            if (entity == null)
            {
                var dto = userService.GetUserDetail(userId);
                name = $"{dto.First_Name} {dto.Last_Name}";
            }
            else
            {
                name = $"{entity.First_Name} {entity.Last_Name}";
            }
            return name;
        }

    }
}
