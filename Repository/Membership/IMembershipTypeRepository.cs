using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.Membership
{
   public interface IMembershipTypeRepository: IRepositoryBase<MembershipTypeEntity>
    {
        MembershipTypeEntity AddMembershipType(MembershipTypeEntity membershipType);
        IEnumerable<MembershipTypeEntity> GetAllMembership(string search);
        MembershipTypeEntity GetMembershipDetail(int id);
        MembershipTypeEntity UpdateMembershipType(int id, MembershipTypeEntity membershipType);
        void DeleteMembershipType(int id);
   }
}
