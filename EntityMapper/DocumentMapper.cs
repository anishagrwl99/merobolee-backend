using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    public class DocumentMapper
    {
        public CompanyDocumentEntity ToEntity(DocumentDto dto)
        {
            if (dto == null) return null;

            return new CompanyDocumentEntity
            {
                CompanyID = dto.CompanyId,
                UploadedBy = dto.UserId,
                DocumentTypeyId = dto.DocumentTypeId,
                DocumentStatusId = 1,
                Remarks = null,
            };
        }

        public List<DocumentResponseDto> ToListDto(List<CompanyDocumentEntity> entities, string baseUrl)
        {
            return entities.Select(x => new DocumentResponseDto()
            {
                DocumentStatusId = x.DocumentStatusId,
                DocumentStatus = x.DocumentStatus.Status,
                DocumentTypeId = x.DocumentTypeyId,
                DocumentType = x.DocumentType.TypeName,
                DocumentPath = $"{baseUrl}{x.DocumentPath.Replace('\\','/')}",
                UploadedBy = $"{x.UploadUserEntity.First_Name} {x.UploadUserEntity.Last_Name}",
                StatusChangedBy = x.StatusChangedUserEntity != null? $"{x.StatusChangedUserEntity.First_Name} {x.StatusChangedUserEntity.Last_Name}" : "",
                Remarks = x.Remarks
            }).ToList();
        }
    }
}
