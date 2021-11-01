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
        public EmailEntity DtoToEntity(SendEmailDto dto)
        {
            if (dto == null) return null;

            return new EmailEntity
            {
                AuthorId = dto.UserId,
                Body = dto.Body,
                Subject = dto.Subject,
                CompanyId = dto.CompanyId,
                Date_created = DateTime.Now,
                Date_modified = DateTime.Now
            };
        }

        public EmailResponseDto EntityToDto(EmailEntity entity, bool isInbox)
        {
            if (entity == null) return null;

            return new EmailResponseDto
            {
                Body = entity.Body,
                EmailId = entity.Id,
                IsRead = isInbox ? entity.UserEmails.FirstOrDefault().IsRead : false,
                SenderUserId = entity.AuthorId,
                Subject = entity.Subject
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
                    IsRead = isInbox ? entity.UserEmails.FirstOrDefault().IsRead : false,
                    SenderUserId = entity.AuthorId,
                    Subject = entity.Subject
                });
            }
            return emailResponseDto;

        }
    }
}
