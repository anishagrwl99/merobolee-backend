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
        Task<GetRequestHelpDto> PostRequest(PostTechnicalSupportDto requestHelp);

        Task<GetRequestHelpDto> PostReply(ReplyTechnicalSupportDto reply);

    }
}
