using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    public class EmailMapper
    {
        public EmailEntity DtoToEntity(SendEmailDto dto, bool isDraft = false)
        {
            if (dto == null) return null;

            return new EmailEntity
            {
                AuthorId = dto.UserId,
                Body = dto.Body,
                Subject = dto.Subject,
                CompanyId = dto.CompanyId,
                IsDraft = isDraft,
                Date_created = DateTime.Now,
                Date_modified = DateTime.Now
            };
        }

        public EmailResponseDto EntityToDto(EmailEntity entity, bool isInbox, string tenderCode)
        {
            if (entity == null) return null;

            return new EmailResponseDto
            {
                Body = entity.Body,
                EmailId = entity.Id,
                TenderCode = tenderCode,
                IsRead = isInbox ? entity.UserEmails.FirstOrDefault().IsRead : false,
                SenderUserId = entity.AuthorId,
                Subject = entity.Subject,
                SentDate = entity.Date_created,
                AuthorName = $"{entity.User.First_Name} {entity.User.Middle_Name} {entity.User.Last_Name}".Replace("  ", " ")
            };
        }

        public List<EmailResponseDto> EntityToDtoList(List<EmailEntity> entities, bool isInbox)
        {
            if (entities == null || entities.Count < 1) return null;

            List<EmailResponseDto> emailResponseDto = new List<EmailResponseDto>();

            foreach (EmailEntity entity in entities)
            {
                emailResponseDto.Add(new EmailResponseDto
                {
                    Body = entity.Body,
                    EmailId = entity.Id,
                    AuthorName = $"{entity.User.First_Name} {entity.User.Middle_Name} {entity.User.Last_Name}".Replace("  ", " "),
                    SentDate = entity.Date_created,
                    IsRead = isInbox ? entity.UserEmails.FirstOrDefault().IsRead : true,
                    SenderUserId = entity.AuthorId,
                    Subject = entity.Subject
                });
            }
            return emailResponseDto;

        }
    }
}
