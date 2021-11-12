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
                Membership_Title = memeberShipDto.MembershipTitle,
                Membership_fee= memeberShipDto.Membershipfee,
                Duration = memeberShipDto.Duration,
                Duration_Type= memeberShipDto.DurationType,
                Discount= memeberShipDto.Discount,
                Status_Id= memeberShipDto.StatusId
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
                MembershipId= membershipType.Membership_Id,
                MembershipTitle = membershipType.Membership_Title,
                Duration = membershipType.Duration,
                DurationType = membershipType.Duration_Type,
                Discount = membershipType.Discount,
                Status = membershipType.Status.Status,
                StatusId= membershipType.Status_Id
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
                      MembershipId = membershipType.Membership_Id,
                      MembershipTitle = membershipType.Membership_Title,
                      Duration = membershipType.Duration,
                      DurationType = membershipType.Duration_Type,
                      Discount = membershipType.Discount,
                      Status = membershipType.Status.Status,
                      StatusId= membershipType.Status_Id
                  }
                );
            }
            return getMemberships;
        }

    }
}
