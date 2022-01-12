using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public class TechnicalSupportService : RequestHelpMapper, ITechnicalSupportService
    {
        private readonly ITechnicalSupportRepository requestHelpRepository;


        /// <summary>
        /// Initializes a new instance of the <see cref="TechnicalSupportService"/> class.
        /// </summary>
        /// <param name="requestHelpRepository">The request help repository.</param>
        public TechnicalSupportService (ITechnicalSupportRepository requestHelpRepository)
        {
            this.requestHelpRepository = requestHelpRepository;
        }

        /// <summary>
        /// Gets all request help.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GetRequestHelpDto> GetAllRequestHelp()
        {
            return RequestHelpDtoToList(requestHelpRepository.GetAllRequestHelp());
        }

        /// <summary>
        /// Gets all request help by bidder.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IEnumerable<GetRequestHelpDto> GetAllRequestHelpByBidder(int id)
        {
            return RequestHelpDtoToList(requestHelpRepository.GetAllRequestHelpByBidder(id));
        }

        /// <summary>
        /// Gets the request help.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public GetRequestHelpDto GetRequestHelp(int id)
        {
            return RequestHelpToDto(requestHelpRepository.GetRequestHelp(id));
        }


        /// <summary>
        /// Posts the request.
        /// </summary>
        /// <param name="requestHelp">The request help.</param>
        /// <returns></returns>
        public GetRequestHelpDto PostRequest(PostTechnicalSupportDto requestHelp)
        {
            return RequestHelpToDto(requestHelpRepository.PostRequest(RequestHelpDtoToEntity(requestHelp)));
        }


        /// <summary>
        /// Updates the request help.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestHelp">The request help.</param>
        /// <returns></returns>
        public GetRequestHelpDto UpdateRequestHelp(int id, UpdateRequestHelpDto requestHelp)
        {
            return RequestHelpToDto(requestHelpRepository.UpdateRequestHelp(id,RequestHelpDtoToEntity(requestHelp)));
        }
    }
}
