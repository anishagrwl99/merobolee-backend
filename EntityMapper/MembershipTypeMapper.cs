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
                MembershipTitle = memeberShipDto.MembershipTitle,
                MembershipFee= memeberShipDto.Membershipfee,
                Duration = memeberShipDto.Duration,
                DurationType= memeberShipDto.DurationType,
                Discount= memeberShipDto.Discount,
                StatusId= memeberShipDto.StatusId
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
                MembershipId= membershipType.MembershipId,
                MembershipTitle = membershipType.MembershipTitle,
                Duration = membershipType.Duration,
                DurationType = membershipType.DurationType,
                Discount = membershipType.Discount,
                Status = membershipType.Status.Status,
                StatusId= membershipType.StatusId
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
                      MembershipId = membershipType.MembershipId,
                      MembershipTitle = membershipType.MembershipTitle,
                      Duration = membershipType.Duration,
                      DurationType = membershipType.DurationType,
                      Discount = membershipType.Discount,
                      Status = membershipType.Status.Status,
                      StatusId= membershipType.StatusId
                  }
                );
            }
            return getMemberships;
        }

    }
}
