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
        public CompanyEntity SupplierSignUpDToCompanyEntity(UserSignUpDto obj, CompanyTypeEnum companyTypeEnum)
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
               RegisteredAs = companyTypeEnum == CompanyTypeEnum.Bidder ?  "Bidder" : "BidInviter",
               MembershipTypeId = 1, //Registration
               Date_created = DateTime.Now,
               Date_modified = DateTime.Now
            };
        }


        public CompanyEntity AddCompanyDtoToEntity(AddCompanyDto dto, CompanyTypeEnum RegisteredAs)
        {
            if (dto == null) return null;
            return new CompanyEntity
            {
                Name = dto.CompanyName,
                CountryId = dto.CountryId,
                ProvinceId = dto.ProvinceId,
                City = dto.City,
                Address1 = dto.Address1,
                Address2 = dto.Address2,
                Address3 = dto.Address3,
                Zip = dto.Zip,
                RegisteredAs = RegisteredAs.ToString(),
                ContactPerson = dto.ContactPerson,
                CompanyEmail = dto.CompanyEmail,
                CompanyWebsite = dto.CompanyWebsite,
                Phone1 = dto.Phone1,
                Phone2 = dto.Phone2,
                MembershipTypeId = 2,
                Date_created = DateTime.Now,
                Date_modified = DateTime.Now
            };
        }

        public AddCompanyResponseDto CompanyEntityToResponseDto(CompanyEntity entity)
        {
            if (entity == null) return null;
            return new AddCompanyResponseDto
            {
                CompanyId = entity.CompanyId,
                CompanyName = entity.Name,
                CountryId = entity.CountryId,
                ProvinceId = entity.ProvinceId,
                Address1 = entity.Address1,
                Address2 = entity.Address2,
                Address3 = entity.Address3,
                Zip = entity.Zip,
                ContactPerson = entity.ContactPerson,
                CompanyEmail = entity.CompanyEmail,
                CompanyWebsite = entity.CompanyWebsite,
                Phone1 = entity.Phone1,
                Phone2 = entity.Phone2,
                City = entity.City
            };
        }


        public UserEntity UserDtoToEntity(AddUserDto dto)
        {
            if (dto == null) return null;

            return new UserEntity
            {
                User_Code = Guid.NewGuid(),
                First_Name = dto.First_Name,
                Middle_Name = dto.Middle_Name,
                Last_Name = dto.Last_Name,
                Designation = dto.Designation,
                Person_email = dto.Person_email,
                Date_created = DateTime.Now,
                Date_modified = DateTime.Now
            };
        }

        public AddUserReponseDto UserEntityToResponse(UserEntity entity)
        {
            if (entity == null) return null;

            return new AddUserReponseDto
            {
                First_Name = entity.First_Name,
                Middle_Name = entity.Middle_Name,
                Last_Name = entity.Last_Name,
                Designation = entity.Designation,
                Person_email = entity.Person_email,
                UserId = entity.User_Id
            };
        }
        
    }
}
