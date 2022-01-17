using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Model;
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
        private readonly IUserService userService;


        /// <summary>
        /// Initializes a new instance of the <see cref="TechnicalSupportService"/> class.
        /// </summary>
        /// <param name="requestHelpRepository">The request help repository.</param>
        public TechnicalSupportService (ITechnicalSupportRepository requestHelpRepository, IUserService userService)
        {
            this.requestHelpRepository = requestHelpRepository;
            this.userService = userService;
        }

        /// <summary>
        /// Posts the request.
        /// </summary>
        /// <param name="requestHelp">The request help.</param>
        /// <returns></returns>
        public async Task<GetRequestHelpDto> PostRequest(PostTechnicalSupportDto requestHelp)
        {
            try
            {
                List<long> receivers = await GetTechnicalSupportReceiverUsers();
                TechnicalSupportEntity ent = RequestHelpDtoToEntity(requestHelp, receivers);
                return RequestHelpToDto(await requestHelpRepository.PostRequest(ent));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GetRequestHelpDto> PostReply(ReplyTechnicalSupportDto reply)
        {
            try
            {
                List<long> receivers = await GetTechnicalSupportReceiverUsers(reply.ReplyUserId);
                receivers.Add(reply.SenderUserId);
                TechnicalSupportEntity ent = RequestHelpDtoToEntity(reply, receivers);
                return RequestHelpToDto(await requestHelpRepository.PostRequest(ent));
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<List<long>> GetTechnicalSupportReceiverUsers()
        {
            List<UserEntity> users = await userService.GetMeroboleeUsers();
            List<long> userIds = new List<long>();
            userIds.AddRange(users.Where(x => x.Role_Id == 1).Select(x => x.User_Id).ToList()); //Super Admin
            userIds.AddRange(users.Where(x => x.Role_Id == 3).Select(x => x.User_Id).ToList()); //Customer Support

            return userIds;
        }

        private async Task<List<long>> GetTechnicalSupportReceiverUsers(long myId)
        {
            List<UserEntity> users = await userService.GetMeroboleeUsers();
            List<long> userIds = new List<long>();
            userIds.AddRange(users.Where(x => x.Role_Id == 1 && x.User_Id != myId).Select(x => x.User_Id).ToList()); //Super Admin
            userIds.AddRange(users.Where(x => x.Role_Id == 3 && x.User_Id != myId).Select(x => x.User_Id).ToList()); //Customer Support

            return userIds;
        }

    }
}
