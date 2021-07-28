using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    public class MembershipTypeMapper
    {
        public MembershipTypeEntity MembershipDtoEntity(AddMemeberShipDto memeberShipDto)
        {
            if (memeberShipDto == null)
            {
                return null;
            }
            return new MembershipTypeEntity
            {
                Membership_Title = memeberShipDto.Membership_Title,
                Membership_fee= memeberShipDto.Membership_fee,
                Duration = memeberShipDto.Duration,
                Duration_Type= memeberShipDto.Duration_Type,
                Discount= memeberShipDto.Discount,
                Status_Id= memeberShipDto.Status_Id
            };

        }

        public GetMembershipDto MembershipEntityToDto(MembershipTypeEntity membershipType)
        {
            if (membershipType == null)
            {
                return null;
            }
            return new GetMembershipDto
            {
                Membership_Id= membershipType.Membership_Id,
                Membership_Title = membershipType.Membership_Title,
                Duration = membershipType.Duration,
                Duration_Type = membershipType.Duration_Type,
                Discount = membershipType.Discount,
                Status = membershipType.Status.Status,
                Status_Id= membershipType.Status_Id
            };

        }

        public IEnumerable<GetMembershipDto> MembershipEntityListToDto(IEnumerable<MembershipTypeEntity> membershipDtos)
        {

            List<GetMembershipDto> getMemberships = new List<GetMembershipDto>();
            if (membershipDtos == null)
            {
                return getMemberships = null;
            }
            foreach (MembershipTypeEntity membershipType in membershipDtos)
            {
                getMemberships.Add
                (
                  new GetMembershipDto
                  {
                      Membership_Id = membershipType.Membership_Id,
                      Membership_Title = membershipType.Membership_Title,
                      Duration = membershipType.Duration,
                      Duration_Type = membershipType.Duration_Type,
                      Discount = membershipType.Discount,
                      Status = membershipType.Status.Status,
                      Status_Id= membershipType.Status_Id
                  }
                );
            }
            return getMemberships;
        }

    }
}
