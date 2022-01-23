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
                DocumentId = x.Id,
                DocumentStatusId = x.DocumentStatusId,
                DocumentStatus = x.DocumentStatus.Status,
                DocumentTypeId = x.DocumentTypeyId,
                DocumentType = x.DocumentType.TypeName,
                DocumentPath = String.IsNullOrEmpty(x.DocumentPath) ? "" : $"{baseUrl}{x.DocumentPath.Replace('\\','/')}",
                UploadedBy = $"{x.UploadUserEntity.FirstName} {x.UploadUserEntity.LastName}",
                StatusChangedBy = x.StatusChangedUserEntity != null? $"{x.StatusChangedUserEntity.FirstName} {x.StatusChangedUserEntity.LastName}" : "",
                Remarks = x.Remarks
            }).ToList();
        }
    }
}
