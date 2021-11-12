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
                 Problem_title= postRequestHelpDto.ProblemTitle,
                 Description= postRequestHelpDto.Description,
                 Help_status_id= postRequestHelpDto.HelpStatusId,
                 User_id= postRequestHelpDto.UserId
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
                    Problem_title = updateRequestDto.ProblemTitle,
                    Description = updateRequestDto.Description,
                    Help_status_id = updateRequestDto.HelpStatusId,
                    Remark= updateRequestDto.Remark,
                    Help_close_date= updateRequestDto.ResolveDate
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
                    ProblemTitle = requestHelpEntity.Problem_title,
                    Description = requestHelpEntity.Description,
                    HelpStatusId = requestHelpEntity.Help_status_id,
                    Remark = requestHelpEntity.Remark,
                    ResolvDate = requestHelpEntity.Help_close_date,
                    Username= requestHelpEntity.UserEntity.Username,
                    UserCode= requestHelpEntity.UserEntity.User_Code,
                    UserId= requestHelpEntity.User_id
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
