using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Repository.RequestHelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.RequestHelp
{
    public class RequestHelpService: RequestHelpMapper, IRequestHelpService
    {
        private readonly IRequestHelpRepository requestHelpRepository;
        public RequestHelpService(IRequestHelpRepository requestHelpRepository)
        {
            this.requestHelpRepository = requestHelpRepository;
        }

        public IEnumerable<GetRequestHelpDto> GetAllRequestHelp()
        {
            return RequestHelpDtoToList(requestHelpRepository.GetAllRequestHelp());
        }

        public IEnumerable<GetRequestHelpDto> GetAllRequestHelpByBidder(int id)
        {
            return RequestHelpDtoToList(requestHelpRepository.GetAllRequestHelpByBidder(id));
        }

        public GetRequestHelpDto GetRequestHelp(int id)
        {
            return RequestHelpToDto(requestHelpRepository.GetRequestHelp(id));
        }

        public GetRequestHelpDto PostRequest(PostRequestHelpDto requestHelp)
        {
            return RequestHelpToDto(requestHelpRepository.PostRequest(RequestHelpDtoToEntity(requestHelp)));
        }

        public GetRequestHelpDto UpdateRequestHelp(int id, UpdateRequestHelpDto requestHelp)
        {
            return RequestHelpToDto(requestHelpRepository.UpdateRequestHelp(id,RequestHelpDtoToEntity(requestHelp)));
        }
    }
}
