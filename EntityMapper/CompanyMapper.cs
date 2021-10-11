using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    public class CompanyMapper
    {
        public CompanyEntity SupplierSignUpDToCompanyEntity(SupplierSignUp obj)
        {
            if (obj == null)
            {
                return null;
            }

            return new CompanyEntity
            {
               Name = obj.Name,
               CountryId = obj.CountryId,
               ProvinceId = obj.ProvinceId,
               City =obj.City,
               Address1 = obj.Address1,
               Address2 = obj.Address2,
               Address3 = obj.Address3,
               Zip = obj.Zip,
               RegisteredAs = "Bidder",
               MembershipTypeId = 1 //Registration
            };
        }
        
    }
}
