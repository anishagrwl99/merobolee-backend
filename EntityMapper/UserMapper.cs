using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeroBolee.EntityMapper
{
    /// <summary>
    /// User Mapper 
    /// </summary>
    public class UserMapper
    {
        /// <summary>
        /// Map dto to entity
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="companyTypeEnum"></param>
        /// <returns></returns>
        public UserEntity SupplierSignUpDToUserEntity(UserSignUpDto obj, CompanyTypeEnum companyTypeEnum)
        {
            if (obj == null) return null;

            return new UserEntity
            {
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                Email = obj.Email,
                Password = obj.Password,
                Date_created = DateTimeNPT.Now,
                Date_modified = DateTimeNPT.Now,
                RoleId = companyTypeEnum == CompanyTypeEnum.Bidder ? 5 : 4, //Bidder(Supplier) role
                StatusId = 1, //Registered status
                IsEmailReceiver = true,
                ProfilePicture = ""
            };
        }


        /// <summary>
        /// User dto to entity
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public UserEntity UserDtoEntity(AddUserDto userDto)
        {
            if (userDto == null)
            {
                return null;
            }
            return new UserEntity
            {
                FirstName = userDto.FirstName,
                MiddleName = userDto.MiddleName,
                LastName = userDto.LastName,
                Designation = userDto.Designation,
                Username = userDto.Username,
                Password = userDto.Password
            };

        }
        /// <summary>
        /// map singup dto dto user entity
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public UserEntity SignUpDtoEntity(SignUpDto userDto)
        {
            if (userDto == null)
            {
                return null;
            }

            return new UserEntity
            {
                FirstName = userDto.FirstName,
                MiddleName = userDto.MiddleName,
                LastName = userDto.LastName,
                Designation = userDto.Designation,
                Email = userDto.PersonEmail,
                Username = userDto.Username,
                Password = userDto.Password,
                RoleId = userDto.RoleId,
                StatusId = userDto.StatusId
            };

        }

        /// <summary>
        /// user entity to dto
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        public GetUserDto UserEntityToDto(UserEntity userEntity)
        {
            if (userEntity == null)
            {
                return null;
            }

            GetUserDto getUser = new();

            if (userEntity.Role == null)
            {
                getUser.Role = null;
            }
            else
            {
                getUser.Role = userEntity.Role.Name;
            }


            if (userEntity.UserStatus == null)
            {
                getUser.UserStatus = null;
            }
            else
            {
                getUser.UserStatus = userEntity.UserStatus.Status;
            }


            getUser.UserId = userEntity.Id;
            getUser.UserCode = userEntity.Code;
            getUser.FirstName = userEntity.FirstName;
            getUser.MiddleName = userEntity.MiddleName;
            getUser.LastName = userEntity.LastName;
            getUser.Designation = userEntity.Designation;
            getUser.PersonEmail = userEntity.Email;
            getUser.Username = userEntity.Username;
            getUser.Password = "";
            getUser.RoleId = userEntity.RoleId;
            getUser.StatusId = userEntity.StatusId;
            getUser.ActivateDate = userEntity.ActivateDate;
            getUser.ExpriedDate = userEntity.ExpriedDate;
            return getUser;

        }


        public UserDetailDto UserDetailDto(UserEntity user, List<CompanyEntity> companies, string baseUrl)
        {
            UserDetailDto userDetailDto = new UserDetailDto
            {
                Designation = user.Designation,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                ProfilePicture = user.ProfilePicture,
                UserName = user.Username,
                RegistrationDate = user.Date_created,
                ActivationDate = user.ActivateDate
            };
            userDetailDto.Companies = (from c in companies
                                       select new CompanyDto
                                       {
                                           Address1 = c.Address1,
                                           Address2 = c.Address2,
                                           Address3 = c.Address3,
                                           City = c.City,
                                           Code = c.ReferenceCode,
                                           Country = c.Country.Name,
                                           Email = c.CompanyEmail,
                                           Id = c.CompanyId,
                                           Name = c.Name,
                                           MobileNumber = c.MobileNumber,
                                           PhoneNumber = c.PhoneNumber,
                                           Province = c.Province.Name,
                                           RegisteredDate = c.Date_created,
                                           Status = c.CompanyStatus.Status,
                                           Website = c.CompanyWebsite,
                                           Zip = c.Zip
                                       }).ToList();

            return userDetailDto;
        }

        /// <summary>
        /// user entity to dto
        /// </summary>
        /// <param name="user"></param>
        /// <param name="uploadFile"></param>
        /// <param name="baseUrl"></param>
        /// <param name="defaultImage"></param>
        /// <returns></returns>
        public IEnumerable<GetUserDto> UserEntityListToDto(IEnumerable<UserEntity> user, IUploadFile uploadFile, string baseUrl, string defaultImage)
        {
            if (user == null)
            {
                return null;
            }

            List<GetUserDto> getUsers = new();
            foreach (UserEntity userEntity in user)
            {
                GetUserDto userDto = UserEntityToDto(userEntity);
                
                bool fileExists = uploadFile.FileExists(userEntity.ProfilePicture).Result;
                if (!fileExists)
                {
                    userDto.ProfilePicture = defaultImage;
                }
                else
                {
                    userDto.ProfilePicture = $"{baseUrl}{userEntity.ProfilePicture.Replace("\\", "/")}";
                }
                getUsers.Add(userDto);
            }
            return getUsers;
        }

        private VendorEnlistmentDetail VendorEnlistmentEntitytoDto(VendorEnlistmentEntity vendorEnlistmentEntity)
        {
            var obj = new VendorEnlistmentDetail
            {
                Email2 = vendorEnlistmentEntity.Email2,
                Website=vendorEnlistmentEntity.Website,
                DirectorName = vendorEnlistmentEntity.Director_Name,
                OtherContact = vendorEnlistmentEntity.Other_Contact,
                OtherBranchesLocation = vendorEnlistmentEntity.Other_Branches_Location,
                YearOfEstablishment = vendorEnlistmentEntity.Year_Of_Establishment,
                NumberOfFullTimeEmployees = vendorEnlistmentEntity.Number_Of_Full_Time_Employees,
                ProcurementDetatil = vendorEnlistmentEntity.Procurement_Detatil,
                ExportCountries = vendorEnlistmentEntity.Export_Countries,
                CountriesWithRegisteredOffice = vendorEnlistmentEntity.Countries_With_Registered_Office,
                CountriesWithAgent = vendorEnlistmentEntity.Countries_With_Agent,
                NatureOfBusiness = new List<string>(vendorEnlistmentEntity.Nature_Of_Business.Split(',')),
                VendorExperience = vendorEnlistmentEntity.Vendor_Experience,
                ContractsCurrentlyUnderway = vendorEnlistmentEntity.Contracts_Currently_Underway,
                IsEnable = vendorEnlistmentEntity.IsEnable,
                DateCreated = vendorEnlistmentEntity.Date_Created,
                DateModified = vendorEnlistmentEntity.Date_Modified,
                HasCodeOfConduct = vendorEnlistmentEntity.HasCodeOfConduct,
                HasSuppliedBefore = vendorEnlistmentEntity.HasSuppliedBefore,
                HasCSRPolicies = vendorEnlistmentEntity.HasCSRPolicies,
                HasInternationalQualityAssurance = vendorEnlistmentEntity.HasInternationalQualityAssurance,
                HasLocalOrNationalQualityAssurance = vendorEnlistmentEntity.HasLocalOrNationalQualityAssurance,
                CopyOfLastFinancialStatement = vendorEnlistmentEntity.CopyOfLastFinancialStatement,
                CopyOfLatestAuditedAccount = vendorEnlistmentEntity.CopyOfLatestAuditedAccount,
                CompanyRating = vendorEnlistmentEntity.CompanyRating,
                SixMonthsCurrentBankStatement = vendorEnlistmentEntity.SixMonthsCurrentBankStatement
            };
            return obj;
        }

        private List<VendorEnlistmentReferencesDto> VendorEnlistmentReferencesEntitytoDto (List<VendorEnlistmentReferencesEntity> vendorEnlistmentReferencesEntities)
        {
            var vendorEnlistmentReferences = new List<VendorEnlistmentReferencesDto>();
            foreach (var item in vendorEnlistmentReferencesEntities)
            {
                if (!item.IsDeleted)
                {
                    var result = new VendorEnlistmentReferencesDto
                    {
                        Id=item.Id,
                        Name = item.Name,
                        Country = item.Country,
                        TypeOfContract = item.TypeOfContract,
                        Value = item.Value,
                        Year = item.Year,
                        ContactName = item.ContactName,
                        Phone = item.Phone,
                        Email = item.Email
                    };
                    vendorEnlistmentReferences.Add(result);
                }
                
            }
            return vendorEnlistmentReferences;
        }

        private List<VendorEnlistmentAnnualIncomeDto> VendorEnlistmentAnnualIncomeEntityToDto (List<VendorEnlistmentAnnualIncomeEntity> vendorEnlistmentAnnualIncomeEntities)
        {

            var vendorEnlistmentAnnualIncomes = new List<VendorEnlistmentAnnualIncomeDto>();
            foreach (var item in vendorEnlistmentAnnualIncomeEntities)
            {
                if (!item.IsDeleted)
                {
                    var annualIncome = new VendorEnlistmentAnnualIncomeDto
                    {
                        Id = item.Id,
                        FiscalYear = item.FiscalYear,
                        IncomeSales = item.IncomeSales,
                        ExportSales = item.ExportSales
                    };
                    vendorEnlistmentAnnualIncomes.Add(annualIncome);
                }
            }
            return vendorEnlistmentAnnualIncomes;
        }

        private List<VendorEnlistmentBankInfoDto> VendorEnlistmentBankInfoEntityToDto(List<VendorEnlistmentBankInfoEntity> vendorEnlistmentBankInfoEntities)
        {
            var vendorEnlistmentBankInfos = new List<VendorEnlistmentBankInfoDto>();
            foreach (var item in vendorEnlistmentBankInfoEntities)
            {
                if (!item.IsDeleted)
                {
                    var bankInfo = new VendorEnlistmentBankInfoDto
                    {
                        Id = item.Id,
                        BankName = item.BankName,
                        AccountName = item.AccountName,
                        AccountNumber = item.AccountNumber,
                        SwiftCode = item.SwiftCode,
                        Address = item.Address,
                        StreetName = item.StreetName,
                        StreetNumber = item.StreetNumber,
                        City = item.City,
                        PostalCode = item.PostalCode,
                        Country = item.Country,
                        PhoneNumber = item.PhoneNumber
                    };
                    vendorEnlistmentBankInfos.Add(bankInfo);
                }
            }
            return vendorEnlistmentBankInfos;
        }

        private List<long> BidderProcurementCategoryEntityToDto(List<BidderProcurementCategoryEntity> bidderProcurementCategoryEntities)
        {
            var list = new List<long>();
            foreach (var item in bidderProcurementCategoryEntities)
            {
                if (!item.IsDeleted)
                {
                    list.Add(item.ProcurementCategoryId);
                }
            }
            return list;
        }

        private List<VendorEnlistmentDocumentDto> VendorEnlistmentDocumentEntityToDto(List<VendorEnlistmentDocumentEntity> vendorEnlistmentDocumentEntities,string baseUrl)
        {
            var list= new List<VendorEnlistmentDocumentDto>();
            foreach (var item in vendorEnlistmentDocumentEntities)
            {
                if (!item.IsDeleted)
                {
                    var obj = new VendorEnlistmentDocumentDto
                    {
                        Id = item.Id,
                        DocumentTypeId = item.DocumentTypeId,
                        DocumentPath = String.IsNullOrEmpty(item.DocumentPath) ? "" : $"{baseUrl}{item.DocumentPath.Replace('\\', '/')}"
                    };
                    list.Add(obj);
                }
            }
            return list;
        }

    }
}
