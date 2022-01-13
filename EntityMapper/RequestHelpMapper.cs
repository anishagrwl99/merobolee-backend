using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    public class RequestHelpMapper
    {

        public TechnicalSupportEntity RequestHelpDtoToEntity(PostTechnicalSupportDto postRequestHelpDto, List<long> receivers)
        {
            if (postRequestHelpDto == null)
            {
                return null;
            }

            else
            {
                TechnicalSupportEntity technicalSupportEntity =  new TechnicalSupportEntity
                {
                    Name = postRequestHelpDto.Name,
                    Email = postRequestHelpDto.Email,
                    Title = postRequestHelpDto.Title,
                    Description = postRequestHelpDto.Description,
                    UserId = postRequestHelpDto.UserId.HasValue? postRequestHelpDto.UserId.Value : null,
                    Date_created = DateTime.Now,
                    Date_modified = DateTime.Now
                };
                technicalSupportEntity.Receivers = new List<TechnicalSupportReceiver>();
                foreach (var receiver in receivers)
                {
                    technicalSupportEntity.Receivers.Add(new TechnicalSupportReceiver
                    {
                        IsRead = false,
                        UserId = receiver,
                        TechnicalSupportId = technicalSupportEntity.Id
                    });
                }
                return technicalSupportEntity;
            }

        }

        public TechnicalSupportEntity RequestHelpDtoToEntity(UpdateRequestHelpDto updateRequestDto)
        {
            if (updateRequestDto == null)
            {
                return null;
            }

            else
            {
                return new TechnicalSupportEntity
                {
                    Title = updateRequestDto.Title,
                    Description = updateRequestDto.Description,
                    Name = updateRequestDto.Name,
                    Email = updateRequestDto.Email,
                    UserId = updateRequestDto.UserId.HasValue? updateRequestDto.UserId.Value : null,
                    Id = updateRequestDto.Id
                };
            }

        }

        public GetRequestHelpDto RequestHelpToDto(TechnicalSupportEntity requestHelpEntity)
        {
            if (requestHelpEntity == null)
            {
                return null;
            }

            else
            {
                return new GetRequestHelpDto
                {
                    Id = requestHelpEntity.Id,
                    Title = requestHelpEntity.Title,
                    Email = requestHelpEntity.Email,
                    Name = requestHelpEntity.Name,
                    Description = requestHelpEntity.Description,
                    UserId = requestHelpEntity.UserId
                };
            }

        }

        public IEnumerable<GetRequestHelpDto> RequestHelpDtoToList(IEnumerable<TechnicalSupportEntity> requestHelp)
        {
            if (requestHelp == null)
            {
                return null;
            }
            else
            {
                List<GetRequestHelpDto> getRequestHelpDtos = new List<GetRequestHelpDto>();
                foreach (TechnicalSupportEntity requestHelpEntity in requestHelp)
                {
                    getRequestHelpDtos.Add(RequestHelpToDto(requestHelpEntity));
                }

                return getRequestHelpDtos;
            }
        }

    }
}
