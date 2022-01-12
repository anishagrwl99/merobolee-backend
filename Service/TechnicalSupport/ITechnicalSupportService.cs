using MeroBolee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public interface ITechnicalSupportService
    {
        /// <summary>
        /// Posts the request.
        /// </summary>
        /// <param name="requestHelp">The request help.</param>
        /// <returns></returns>
        GetRequestHelpDto PostRequest(PostTechnicalSupportDto requestHelp);

        /// <summary>
        /// Gets the request help.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        GetRequestHelpDto GetRequestHelp(int id);


        /// <summary>
        /// Gets all request help.
        /// </summary>
        /// <returns></returns>
        IEnumerable<GetRequestHelpDto> GetAllRequestHelp();


        /// <summary>
        /// Gets all request help by bidder.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IEnumerable<GetRequestHelpDto> GetAllRequestHelpByBidder(int id);


        /// <summary>
        /// Updates the request help.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestHelp">The request help.</param>
        /// <returns></returns>
        GetRequestHelpDto UpdateRequestHelp(int id, UpdateRequestHelpDto requestHelp);
    }
}
