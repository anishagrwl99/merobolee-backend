using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public class MembershipTypeService : MembershipTypeMapper, IMembershipTypeService
    {
        private readonly IMembershipTypeRepository membershipTypeRepository;
        public MembershipTypeService(IMembershipTypeRepository membershipTypeRepository)
        {
            this.membershipTypeRepository = membershipTypeRepository;
        }

        public GetMembershipDto AddMembership(AddMemeberShipDto memeberShipDto)
        {
            return MembershipEntityToDto(membershipTypeRepository.AddMembershipType(MembershipDtoEntity(memeberShipDto)));
        }

        public void DeleteCategory(int id)
        {
             membershipTypeRepository.DeleteMembershipType(id);
        }

        public GetMembershipDto GetMembershipDetail(int id)
        {
            return MembershipEntityToDto(membershipTypeRepository.GetMembershipDetail(id));
        }

        public IEnumerable<GetMembershipDto> GetMemberships(string search)
        {
            return MembershipEntityListToDto(membershipTypeRepository.GetAllMembership(search));
        }

        public GetMembershipDto UpdateMembership(int id, AddMemeberShipDto memeberShipDto)
        {
            return MembershipEntityToDto(membershipTypeRepository.UpdateMembershipType(id,MembershipDtoEntity(memeberShipDto)));
        }
    }
}
