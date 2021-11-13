using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public class MembershipTypeRepository: RepositoryBase<MembershipTypeEntity>, IMembershipTypeRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public MembershipTypeRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork): base(dbFactory)
        {
            this.unitOfWork = unitOfWork;                 
        }

        public MembershipTypeEntity AddMembershipType(MembershipTypeEntity membershipType)
        {
            try
            {
                meroBoleeDbContexts.MembershipTypeEntities.Add(membershipType);
                unitOfWork.SaveChange();
                meroBoleeDbContexts.StatusEntities.ToList();
                return membershipType;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void DeleteMembershipType(int id)
        {
            try
            {
                meroBoleeDbContexts.MembershipTypeEntities.Remove(GetById(id));
                unitOfWork.SaveChange();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public IEnumerable<MembershipTypeEntity> GetAllMembership(string search)
        {
            try
            {
                meroBoleeDbContexts.StatusEntities.ToList();
                return meroBoleeDbContexts.MembershipTypeEntities.Where(m => (search == null)
                || (m.Membership_Title.ToLower().Contains(search.ToLower()))
                || (m.Membership_fee.ToString().Contains(search.ToLower()))
                || (m.Duration.ToString().Contains(search.ToLower()))
                || (m.Duration_Type.ToLower().Contains(search.ToLower()))
                || (m.Status.Status.ToLower().Contains(search.ToLower()))
                || (m.Discount.ToString().Contains(search.ToLower()))
                ).ToList();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public MembershipTypeEntity GetMembershipDetail(int id)
        {
            try
            {
                MembershipTypeEntity membershipType = meroBoleeDbContexts.MembershipTypeEntities.Find(id);
                if (membershipType == null)
                {
                    return membershipType = null;
                }
                meroBoleeDbContexts.StatusEntities.ToList();
                return membershipType;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public MembershipTypeEntity UpdateMembershipType(int id, MembershipTypeEntity membershipType)
        {
            try
            {
                MembershipTypeEntity membership = GetMembershipDetail(id);
                if (membership == null)
                {
                    return membership = null;
                }
                membership.Membership_Title = membershipType.Membership_Title;
                membership.Duration = membershipType.Duration;
                membership.Duration_Type = membershipType.Duration_Type;
                membership.Membership_fee = membershipType.Membership_fee;
                membership.Discount = membershipType.Discount;
                membership.Date_modified = membershipType.Date_modified;
            //    membership.Modified_time_stamp = membershipType.Modified_time_stamp;
                unitOfWork.SaveChange();
                return membership;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
