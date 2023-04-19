using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service;
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
               Name = obj.Name.Trim(),
               PANNumber = obj.PANNumber.Trim(),
               CountryId = obj.CountryId,
               CompanyStatusId = 1,//Registered
               ProvinceId = obj.ProvinceId,
               City =obj.City.Trim(),
               Address1 = obj.Address1.Trim(),
               Address2 = obj.Address2.Trim(),
               Address3 = obj.Address3.Trim(),
               Zip = obj.Zip,
               RegisteredAs = companyTypeEnum == CompanyTypeEnum.Bidder ?  "Bidder" : "BidInviter",
               MembershipTypeId = 1, //Registration
               CompanyEmail = obj.Email.Trim(),
               Date_created = DateTimeNPT.Now,
               Date_modified = DateTimeNPT.Now,
               MobileNumber = obj.MobileNo,
               PhoneNumber = obj.PhoneNo,
               ContactPerson = $"{obj.FirstName} {obj.LastName}"
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
                MobileNumber = dto.MobileNumber,
                PhoneNumber = dto.PhoneNumber,
                MembershipTypeId = 2,
                Date_created = DateTimeNPT.Now,
                Date_modified = DateTimeNPT.Now
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
                CountryId = entity.CountryId,
                ProvinceId = entity.ProvinceId,
                Address1 = entity.Address1,
                Address2 = entity.Address2,
                Address3 = entity.Address3,
                Zip = entity.Zip,
                ContactPerson = entity.ContactPerson,
                CompanyEmail = entity.CompanyEmail,
                CompanyWebsite = entity.CompanyWebsite,
                MobileNumber = entity.MobileNumber,
                PhoneNumber = entity.PhoneNumber,
                City = entity.City
            };
        }


        public UserEntity UserDtoToEntity(AddUserDto dto)
        {
            if (dto == null) return null;

            return new UserEntity
            {
                Code = Guid.NewGuid(),
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                LastName = dto.LastName,
                Designation = dto.Designation,
                Email = dto.PersonEmail,
                Date_created = DateTimeNPT.Now,
                Date_modified = DateTimeNPT.Now
            };
        }

        public AddUserReponseDto UserEntityToResponse(UserEntity entity)
        {
            if (entity == null) return null;

            return new AddUserReponseDto
            {
                FirstName = entity.FirstName,
                MiddleName = entity.MiddleName,
                LastName = entity.LastName,
                Designation = entity.Designation,
                PersonEmail = entity.Email,
                UserId = entity.Id
            };
        }

        public CompanyDetailResponse ToDetailResponse(CompanyEntity company, List<UserEntity> users, List<CommunityApprovalEntity> tenders, IUploadFile fileService, string baseUrl, string defaultPic)
        {
            CompanyDetailResponse companyDetailResponse = new CompanyDetailResponse
            {
                Id = company.CompanyId,
                Name = company.Name,
                Country = company.Country.Name,
                City = company.City,
                Address1 = company.Address1,
                Address2 = company.Address2,
                Address3 = company.Address3,
                Zip = company.Zip,
                ReferenceCode = company.ReferenceCode,
                ContactPerson = company.ContactPerson,
                Email = company.CompanyEmail,
                Website= company.CompanyWebsite,
                Phone1 = company.MobileNumber,
                Phone2 = company.PhoneNumber,
                PANNumber = company.PANNumber,
                Province = company.Province.Name,
                Status = company.CompanyStatus.Status,
                RegisteredDate = company.Date_created
            };

            if (users != null && users.Count > 0)
            {
                companyDetailResponse.Users = new List<UserResponseDto>();
                foreach (UserEntity u in users)
                {
                    UserResponseDto dto = new UserResponseDto
                    {
                        Id = u.Id,
                        Designation = u.Designation,
                        FirstName = u.FirstName,
                        MiddleName = u.MiddleName,
                        LastName = u.LastName,
                        Email = u.Email,
                        UserName = u.Username
                    };
                    bool dpExists = fileService.FileExists(u.ProfilePicture).Result;
                    if (!dpExists)
                    {
                        dto.ProfilePic = defaultPic;
                    }
                    else
                    {
                        dto.ProfilePic = $"{baseUrl}{u.ProfilePicture.Replace("\\", "/")}";
                    }
                    companyDetailResponse.Users.Add(dto);
                }
            }

            if (tenders != null && tenders.Count > 0)
            {
                companyDetailResponse.Tenders = new List<TenderCard>();
                foreach (CommunityApprovalEntity t in tenders)
                {
                    TenderCard dto = new TenderCard
                    {
                        TenderId = t.TenderId,
                        TenderCode = t.TenderEntities.Code,
                        TenderTitle = t.TenderEntities.Title,
                        CategoryName = t.CategoryEntity.Title,
                        CategoryId = t.CategoryId,
                        LiveStartDate = t.TenderEntities.LiveStartDate,
                        LiveEndDate = t.TenderEntities.LiveEndDate,
                        RegistrationTill = t.TenderEntities.RegistrationTill,
                        Status = t.TenderStatusEntity.Status,
                        StatusId = t.StatusId
                    };
                    companyDetailResponse.Tenders.Add(dto);
                }
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
                Country = company.Country.Name,
                Email = company.CompanyEmail,
                Status = company.CompanyStatus.Status
            };
        }

    }
}
