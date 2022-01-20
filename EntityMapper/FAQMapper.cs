using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    /// <summary>
    /// Mapper for FAQ DTO and Entity
    /// </summary>
    public class FAQMapper
    {

        /// <summary>
        /// Map DTO to Entity
        /// </summary>
        /// <param name="dto">A FAQ payload</param>
        /// <returns></returns>
        public FAQEntity ToEntity(FAQAddDto dto)
        {
            if (dto == null) return null;
            return new FAQEntity
            {
                Question = dto.Question,
                Answer = dto.Answer,
                Date_created = DateTime.Now,
                Date_modified = DateTime.Now
            };
        }

        /// <summary>
        /// Map entity to Response Dto
        /// </summary>
        /// <param name="entity">A FAQ database object</param>
        /// <returns></returns>
        public FAQResponseDto ToResponseDto(FAQEntity entity)
        {
            if (entity == null) return null;
            return new FAQResponseDto
            {
                Id = entity.Id,
                Question = entity.Question,
                Answer = entity.Answer,
                CreatedDate = entity.Date_created,
                ModifiedDate = entity.Date_modified
            };
        }
    }
}
