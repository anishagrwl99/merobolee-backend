using MeroBolee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public interface IRequestHelpService
    {
        GetRequestHelpDto PostRequest(PostRequestHelpDto requestHelp);
        GetRequestHelpDto GetRequestHelp(int id);
        IEnumerable<GetRequestHelpDto> GetAllRequestHelp();
        IEnumerable<GetRequestHelpDto> GetAllRequestHelpByBidder(int id);
        GetRequestHelpDto UpdateRequestHelp(int id, UpdateRequestHelpDto requestHelp);
    }
}
