using MeroBolee.Dto;
using MeroBolee.Infrastructure;
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
               PANNumber = obj.PANNumber,
               CountryId = obj.CountryId,
               CompanyStatusId = 1,//Registered
               ProvinceId = obj.ProvinceId,
               City =obj.City,
               Address1 = obj.Address1,
               Address2 = obj.Address2,
               Address3 = obj.Address3,
               Zip = obj.Zip,
               RegisteredAs = companyTypeEnum == CompanyTypeEnum.Bidder ?  "Bidder" : "BidInviter",
               MembershipTypeId = 1, //Registration
               CompanyEmail = obj.Email,
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
                PANNumber = dto.PANNumber,
                CountryId = dto.CountryId,
                CompanyStatusId = 1, //Registered
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
                PANNumber = entity.PANNumber,
                ReferenceCode = entity.ReferenceCode,
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
                First_Name = dto.FirstName,
                Middle_Name = dto.MiddleName,
                Last_Name = dto.LastName,
                Designation = dto.Designation,
                Person_email = dto.PersonEmail,
                Date_created = DateTime.Now,
                Date_modified = DateTime.Now
            };
        }

        public AddUserReponseDto UserEntityToResponse(UserEntity entity)
        {
            if (entity == null) return null;

            return new AddUserReponseDto
            {
                FirstName = entity.First_Name,
                MiddleName = entity.Middle_Name,
                LastName = entity.Last_Name,
                Designation = entity.Designation,
                PersonEmail = entity.Person_email,
                UserId = entity.User_Id
            };
        }

        public CompanyDetailResponse ToDetailResponse(CompanyEntity company, List<UserEntity> users, List<TenderEntity> tenders, IUploadFile fileService, string baseUrl, string defaultPic)
        {
            CompanyDetailResponse companyDetailResponse = new CompanyDetailResponse
            {
                Id = company.CompanyId,
                Name = company.Name,
                Country = company.Country.Country_Name,
                City = company.City,
                Address1 = company.Address1,
                Address2 = company.Address2,
                Address3 = company.Address3,
                Zip = company.Zip,
                ReferenceCode = company.ReferenceCode,
                ContactPerson = company.ContactPerson,
                Email = company.CompanyEmail,
                Website= company.CompanyWebsite,
                Phone1 = company.Phone1,
                Phone2 = company.Phone2,
                PANNumber = company.PANNumber,
                Province = company.Province.Province_Title,
                Status = company.CompanyStatus.Status,
                RegisteredDate = company.Date_created
            };

            companyDetailResponse.Users = new List<UserResponseDto>();

            foreach (UserEntity u in users)
            {
                UserResponseDto dto = new UserResponseDto
                {
                    Id = u.User_Id,
                    Designation = u.Designation,
                    FirstName = u.First_Name,
                    MiddleName = u.Middle_Name,
                    LastName = u.Last_Name,
                    Email = u.Person_email,
                    UserName = u.Username
                };
                bool dpExists =  fileService.FileExists(u.ProfilePicture).Result;
                if(!dpExists)
                {
                    dto.ProfilePic = defaultPic;
                }
                else
                {
                    dto.ProfilePic = $"{baseUrl}{u.ProfilePicture.Replace("\\","/")}";
                }
                companyDetailResponse.Users.Add(dto);
            }

            companyDetailResponse.Tenders = new List<TenderCard>();
            foreach (TenderEntity t in tenders)
            {
                TenderCard dto = new TenderCard
                {
                    TenderId = t.Tender_Id,
                    TenderCode = t.Tender_Code,
                    TenderTitle = t.Tender_Title,
                    CategoryName = t.CategoryEntity.Category,
                    CategoryId = t.Category_Id,
                    LiveStartDate = t.Live_Start_Date,
                    LiveEndDate = t.Live_End_Date,
                    RegistrationTill = t.RegistrationTill,
                    Status = t.TenderStatusEntity.Status,
                    StatusId = t.Tender_Status_Id,
                    CardInfo = (from tc in t.TenderCards
                                select new TenderCardInfo
                                {
                                    Id = tc.Id,
                                    Label = tc.Label,
                                    Value = tc.Value
                                }).ToList()
                };
                companyDetailResponse.Tenders.Add(dto);
            }

            return companyDetailResponse;
        }

        public CompanyCardResponseDto ToCard(CompanyEntity company)
        {
            return new CompanyCardResponseDto
            {
                Id = company.CompanyId,
                Name = company.Name,
                ReferenceCode = company.ReferenceCode,
                City = company.City,
                Country = company.Country.Country_Name,
                Email = company.CompanyEmail,
                Status = company.CompanyStatus.Status
            };
        }

    }
}
