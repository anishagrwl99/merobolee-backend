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

        public RequestHelpEntity RequestHelpDtoToEntity(PostRequestHelpDto postRequestHelpDto)
        {
            if (postRequestHelpDto == null)
            {
                return null;
            }

            else 
            {
                return new RequestHelpEntity 
                { 
                 Problem_title= postRequestHelpDto.Problem_title,
                 Description= postRequestHelpDto.Description,
                 Help_status_id= postRequestHelpDto.Help_status_id,
                 User_id= postRequestHelpDto.User_id
                };
            }
        
        }

        public RequestHelpEntity RequestHelpDtoToEntity(UpdateRequestHelpDto updateRequestDto)
        {
            if (updateRequestDto == null)
            {
                return null;
            }

            else
            {
                return new RequestHelpEntity
                {
                    Problem_title = updateRequestDto.Problem_title,
                    Description = updateRequestDto.Description,
                    Help_status_id = updateRequestDto.Help_status_id,
                    Remark= updateRequestDto.Remark,
                    Help_close_date= updateRequestDto.Resolve_date
                };
            }

        }

        public GetRequestHelpDto RequestHelpToDto(RequestHelpEntity requestHelpEntity)
        {
            if (requestHelpEntity == null)
            {
                return null;
            }

            else
            {
                return new GetRequestHelpDto
                {
                    Problem_title = requestHelpEntity.Problem_title,
                    Description = requestHelpEntity.Description,
                    Help_status_id = requestHelpEntity.Help_status_id,
                    Remark = requestHelpEntity.Remark,
                    Resolve_date = requestHelpEntity.Help_close_date,
                    Username= requestHelpEntity.UserEntity.Username,
                    User_code= requestHelpEntity.UserEntity.User_Code,
                    User_id= requestHelpEntity.User_id
                };
            }

        }

        public IEnumerable<GetRequestHelpDto> RequestHelpDtoToList(IEnumerable<RequestHelpEntity> requestHelp)
        {
            if (requestHelp == null)
            {
                return null;
            }
            else 
            {
                List<GetRequestHelpDto> getRequestHelpDtos = new List<GetRequestHelpDto>();
                foreach (RequestHelpEntity requestHelpEntity in requestHelp)
                {
                    getRequestHelpDtos.Add(RequestHelpToDto(requestHelpEntity));
                }

                return getRequestHelpDtos;
            }
        }

    }
}
