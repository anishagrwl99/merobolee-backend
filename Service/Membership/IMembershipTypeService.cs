using MeroBolee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.Membership
{
    public interface IMembershipTypeService
    {
        GetMembershipDto AddMembership(AddMemeberShipDto memeberShipDto);
        IEnumerable<GetMembershipDto> GetMemberships(string search);
        GetMembershipDto GetMembershipDetail(int id);

        GetMembershipDto UpdateMembership(int id, AddMemeberShipDto memeberShipDto);
        void DeleteCategory(int id);

    }
}
