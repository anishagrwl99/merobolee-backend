using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;

namespace MeroBolee.EntityMapper
{
    public class VendorEnlistmentMapper
    {
        public VendorEnlistmentEntity VendorEnlistmentDtoEntity(VendorEnlistmentAddDto vendorEnlistmentDto)
        {
            var entity = new VendorEnlistmentEntity()
            {
                Email2=vendorEnlistmentDto.Email2,
                Website=vendorEnlistmentDto.Website,
                Director_Name = vendorEnlistmentDto.DirectorName,
                Other_Contact = vendorEnlistmentDto.OtherContact,
                Other_Branches_Location = vendorEnlistmentDto.OtherBranchesLocation,
                Year_Of_Establishment = vendorEnlistmentDto.YearOfEstablishment,
                Number_Of_Full_Time_Employees = vendorEnlistmentDto.NumberOfFullTimeEmployees,
                Procurement_Detatil = vendorEnlistmentDto.ProcurementDetatil,
                Export_Countries = vendorEnlistmentDto.ExportCountries,
                Countries_With_Registered_Office = vendorEnlistmentDto.CountriesWithRegisteredOffice,
                Countries_With_Agent = vendorEnlistmentDto.CountriesWithAgent,
                Nature_Of_Business = string.Join(",", vendorEnlistmentDto.NatureOfBusiness),
                Vendor_Experience = vendorEnlistmentDto.VendorExperience,
                Contracts_Currently_Underway = vendorEnlistmentDto.ContractsCurrentlyUnderway,
                IsEnable = true,
                CompanyId=vendorEnlistmentDto.CompanyId,
                Date_Created=DateTimeNPT.Now,
                Date_Modified=DateTimeNPT.Now,
                HasCodeOfConduct=vendorEnlistmentDto.HasCodeOfConduct,
                HasSuppliedBefore=vendorEnlistmentDto.HasSuppliedBefore,
                HasCSRPolicies=vendorEnlistmentDto.HasCSRPolicies,
                HasInternationalQualityAssurance=vendorEnlistmentDto.HasInternationalQualityAssurance,
                HasLocalOrNationalQualityAssurance=vendorEnlistmentDto.HasLocalOrNationalQualityAssurance,
                CopyOfLastFinancialStatement = vendorEnlistmentDto.CopyOfLastFinancialStatement,
                CopyOfLatestAuditedAccount = vendorEnlistmentDto.CopyOfLatestAuditedAccount,
                CompanyRating = vendorEnlistmentDto.CompanyRating,
                SixMonthsCurrentBankStatement = vendorEnlistmentDto.SixMonthsCurrentBankStatement
            };
            return entity;
        }

        public IEnumerable<BidderProcurementCategoryEntity> BidderProcurementCategoryDtoEntity(long id, string bidderProcurementCategoryIds)
        {
            var numbers = bidderProcurementCategoryIds?.Split(',')?.Select(Int64.Parse)?.ToList();
            var list = new List<BidderProcurementCategoryEntity>();

            foreach (var item in numbers)
            {
                var entity = new BidderProcurementCategoryEntity()
                {
                    VendorEnlistmentId = id,
                    ProcurementCategoryId = item
                };
                list.Add(entity);
            }

            return list;
        }

        public IEnumerable<VendorEnlistmentReferencesEntity> VendorEnlistmentReferencesDtoEntity(long id, IEnumerable<VendorEnlistmentReferencesDto> vendorEnlistmentReferencesDto)
        {
            var list = new List<VendorEnlistmentReferencesEntity>();

            foreach (var item in vendorEnlistmentReferencesDto)
            {
                var entity = new VendorEnlistmentReferencesEntity()
                {
                    VendorEnlistmentId = id,
                    Name = item.Name,
                    Country = item.Country,
                    TypeOfContract = item.TypeOfContract,
                    Value = item.Value,
                    Year = item.Year,
                    ContactName = item.ContactName,
                    Phone = item.Phone,
                    Email = item.Email,
                    IsDeleted=false
                };
                list.Add(entity);
            }

            return list;
        }

        public IEnumerable<VendorEnlistmentAnnualIncomeEntity> VendorEnlistmentAnnualIncomeDtoEntity(long id, IEnumerable<VendorEnlistmentAnnualIncomeDto> vendorEnlistmentAnnualIncomeDtos)
        {
            var list = new List<VendorEnlistmentAnnualIncomeEntity>();

            foreach (var item in vendorEnlistmentAnnualIncomeDtos)
            {
                var entity = new VendorEnlistmentAnnualIncomeEntity()
                {
                    VendorEnlistmentId = id,
                    FiscalYear = item.FiscalYear,
                    IncomeSales = item.IncomeSales,
                    ExportSales = item.ExportSales,
                    IsDeleted=false
                };
                list.Add(entity);
            }

            return list;
        }

        public IEnumerable<VendorEnlistmentBankInfoEntity> VendorEnlistmentBankInfoDtoEntity(long id, IEnumerable<VendorEnlistmentBankInfoDto> vendorEnlistmentBankInfoDtos)
        {
            var list = new List<VendorEnlistmentBankInfoEntity>();

            foreach (var item in vendorEnlistmentBankInfoDtos)
            {
                var entity = new VendorEnlistmentBankInfoEntity()
                {
                    VendorEnlistmentId = id,
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
                list.Add(entity);
            }

            return list;
        }

        public VendorEnlistmentDetail VendorEnlistmentEntitytoDto(VendorEnlistmentEntity vendorEnlistmentEntity)
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
                CopyOfLastFinancialStatement=vendorEnlistmentEntity.CopyOfLastFinancialStatement,
                CopyOfLatestAuditedAccount=vendorEnlistmentEntity.CopyOfLatestAuditedAccount,
                CompanyRating=vendorEnlistmentEntity.CompanyRating,
                SixMonthsCurrentBankStatement=vendorEnlistmentEntity.SixMonthsCurrentBankStatement,
                Name=vendorEnlistmentEntity.Company.Name,
                Address1=vendorEnlistmentEntity.Company.Address1,
                Address2=vendorEnlistmentEntity.Company.Address2,
                Address3=vendorEnlistmentEntity.Company.Address3,
                Phone1=vendorEnlistmentEntity.Company.PhoneNumber,
                Phone2=vendorEnlistmentEntity.Company.MobileNumber,
                Email=vendorEnlistmentEntity.Company.CompanyEmail,
                Zip=vendorEnlistmentEntity.Company.Zip,
                City=vendorEnlistmentEntity.Company.City,
                Country=vendorEnlistmentEntity.Company.Country.Name,
                PanNumber=vendorEnlistmentEntity.Company.PANNumber
            };
            return obj;
        }

        public List<VendorEnlistmentReferencesDto> VendorEnlistmentReferencesEntitytoDto(List<VendorEnlistmentReferencesEntity> vendorEnlistmentReferencesEntities)
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

        public List<VendorEnlistmentAnnualIncomeDto> VendorEnlistmentAnnualIncomeEntityToDto(List<VendorEnlistmentAnnualIncomeEntity> vendorEnlistmentAnnualIncomeEntities)
        {

            var vendorEnlistmentAnnualIncomes = new List<VendorEnlistmentAnnualIncomeDto>();
            foreach (var item in vendorEnlistmentAnnualIncomeEntities)
            {
                if (!item.IsDeleted)
                {
                    var annualIncome = new VendorEnlistmentAnnualIncomeDto
                    {
                        Id=item.Id,
                        FiscalYear = item.FiscalYear,
                        IncomeSales = item.IncomeSales,
                        ExportSales = item.ExportSales
                    };
                    vendorEnlistmentAnnualIncomes.Add(annualIncome);
                }
            }
            return vendorEnlistmentAnnualIncomes;
        }

        public List<VendorEnlistmentBankInfoDto> VendorEnlistmentBankInfoEntityToDto(List<VendorEnlistmentBankInfoEntity> vendorEnlistmentBankInfoEntities)
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

        public List<long> BidderProcurementCategoryEntityToDto(List<BidderProcurementCategoryEntity> bidderProcurementCategoryEntities)
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

        public List<VendorEnlistmentDocumentDto> VendorEnlistmentDocumentEntityToDto(List<VendorEnlistmentDocumentEntity> vendorEnlistmentDocumentEntities, string baseUrl)
        {
            var list = new List<VendorEnlistmentDocumentDto>();
            foreach (var item in vendorEnlistmentDocumentEntities)
            {
                if (!item.IsDeleted)
                {
                    var obj = new VendorEnlistmentDocumentDto
                    {
                        Id=item.Id,
                        DocumentTypeId = item.DocumentTypeId,
                        DocumentPath = String.IsNullOrEmpty(item.DocumentPath) ? "" : $"{baseUrl}{item.DocumentPath.Replace('\\', '/')}",
                        Name=item.Document.TypeName
                    };
                    list.Add(obj);
                }
            }
            return list;
        }

        public VendorEnlistmentEntity UpdateVendorEnlistmentEntity(VendorEnlistmentEntity vendorEnlistment, VendorEnlistmentAddDto vendorEnlistmentDto)
        {
            vendorEnlistment.Email2 = vendorEnlistmentDto.Email2;
            vendorEnlistment.Website = vendorEnlistmentDto.Website;
            vendorEnlistment.Director_Name = vendorEnlistmentDto.DirectorName;
            vendorEnlistment.Other_Contact = vendorEnlistmentDto.OtherContact;
            vendorEnlistment.Other_Branches_Location = vendorEnlistmentDto.OtherBranchesLocation;
            vendorEnlistment.Year_Of_Establishment = vendorEnlistmentDto.YearOfEstablishment;
            vendorEnlistment.Number_Of_Full_Time_Employees = vendorEnlistmentDto.NumberOfFullTimeEmployees;
            vendorEnlistment.Procurement_Detatil = vendorEnlistmentDto.ProcurementDetatil;
            vendorEnlistment.Export_Countries = vendorEnlistmentDto.ExportCountries;
            vendorEnlistment.Countries_With_Registered_Office = vendorEnlistmentDto.CountriesWithRegisteredOffice;
            vendorEnlistment.Countries_With_Agent = vendorEnlistmentDto.CountriesWithAgent;
            vendorEnlistment.Nature_Of_Business = string.Join(",", vendorEnlistmentDto.NatureOfBusiness);
            vendorEnlistment.Vendor_Experience = vendorEnlistmentDto.VendorExperience;
            vendorEnlistment.Contracts_Currently_Underway = vendorEnlistmentDto.ContractsCurrentlyUnderway;
            vendorEnlistment.IsEnable = true;
            vendorEnlistment.CompanyId = vendorEnlistmentDto.CompanyId;
            vendorEnlistment.Date_Modified = DateTimeNPT.Now;
            vendorEnlistment.HasCodeOfConduct = vendorEnlistmentDto.HasCodeOfConduct;
            vendorEnlistment.HasSuppliedBefore = vendorEnlistmentDto.HasSuppliedBefore;
            vendorEnlistment.HasCSRPolicies = vendorEnlistmentDto.HasCSRPolicies;
            vendorEnlistment.HasInternationalQualityAssurance = vendorEnlistmentDto.HasInternationalQualityAssurance;
            vendorEnlistment.HasLocalOrNationalQualityAssurance = vendorEnlistmentDto.HasLocalOrNationalQualityAssurance;
            vendorEnlistment.CopyOfLastFinancialStatement = vendorEnlistmentDto.CopyOfLastFinancialStatement;
            vendorEnlistment.CopyOfLatestAuditedAccount = vendorEnlistmentDto.CopyOfLatestAuditedAccount;
            vendorEnlistment.CompanyRating = vendorEnlistmentDto.CompanyRating;
            vendorEnlistment.SixMonthsCurrentBankStatement = vendorEnlistmentDto.SixMonthsCurrentBankStatement;

            return vendorEnlistment;

        }

       public List<VendorEnlistmentReferencesEntity> UpdateVendorEnlistmentReferenceEntity(List<VendorEnlistmentReferencesEntity> vendorEnlistmentReferencesEntities,List<VendorEnlistmentReferencesDto> vendorEnlistmentReferencesDtos)
        {
            foreach (var item in vendorEnlistmentReferencesEntities)
            {
                item.IsDeleted = true;
            }

            foreach (var item in vendorEnlistmentReferencesDtos)
            {
                var check = vendorEnlistmentReferencesEntities.Where(x => x.Id == item.Id).FirstOrDefault();
                if (check != null)
                {
                    check.Name = item.Name;
                    check.Country = item.Country;
                    check.TypeOfContract = item.TypeOfContract;
                    check.Value = item.Value;
                    check.Year = item.Year;
                    check.ContactName = item.ContactName;
                    check.Phone = item.Phone;
                    check.Email = item.Email;
                    check.IsDeleted = false;
                }
                else
                {
                    var obj = new VendorEnlistmentReferencesEntity
                    {
                        Name = item.Name,
                        Country = item.Country,
                        TypeOfContract = item.TypeOfContract,
                        Value = item.Value,
                        Year = item.Year,
                        ContactName = item.ContactName,
                        Phone = item.Phone,
                        Email = item.Email
                    };
                    vendorEnlistmentReferencesEntities.Add(obj);
                }
            }

            return vendorEnlistmentReferencesEntities;
        }

        public List<VendorEnlistmentAnnualIncomeEntity> UpdateVendorEnlistmentAnnualIncomeEntity(List<VendorEnlistmentAnnualIncomeEntity> vendorEnlistmentAnnualIncomeEntities, List<VendorEnlistmentAnnualIncomeDto> vendorEnlistmentAnnualIncomeDtos)
        {
            foreach (var item in vendorEnlistmentAnnualIncomeEntities)
            {
                item.IsDeleted = true;
            }

            foreach (var item in vendorEnlistmentAnnualIncomeDtos)
            {
                var check = vendorEnlistmentAnnualIncomeEntities.Where(x => x.Id == item.Id).FirstOrDefault();
                if (check != null)
                {
                    check.FiscalYear=item.FiscalYear;
                    check.ExportSales = item.ExportSales;
                    check.IncomeSales = item.IncomeSales;
                    check.IsDeleted = false;
                }
                else
                {
                    var obj = new VendorEnlistmentAnnualIncomeEntity
                    {
                        FiscalYear = item.FiscalYear,
                        ExportSales = item.ExportSales,
                        IncomeSales = item.IncomeSales
                    };
                    vendorEnlistmentAnnualIncomeEntities.Add(obj);
                }
            }

            return vendorEnlistmentAnnualIncomeEntities;
        }

        public List<VendorEnlistmentBankInfoEntity> UpdateVendorEnlistmentBankInfoEntity(List<VendorEnlistmentBankInfoEntity> vendorEnlistmentBankInfoEntities,List<VendorEnlistmentBankInfoDto> vendorEnlistmentBankInfoDtos)
        {
            foreach (var item in vendorEnlistmentBankInfoEntities)
            {
                item.IsDeleted = true;
            }

            foreach (var item in vendorEnlistmentBankInfoDtos)
            {
                var check = vendorEnlistmentBankInfoEntities.Where(x => x.Id == item.Id).FirstOrDefault();
                if (check != null)
                {
                    check.BankName = item.BankName;
                    check.AccountName = item.AccountName;
                    check.AccountNumber = item.AccountNumber;
                    check.SwiftCode = item.SwiftCode;
                    check.Address = item.Address;
                    check.StreetName = item.StreetName;
                    check.StreetNumber = item.StreetNumber;
                    check.City = item.City;
                    check.PostalCode = item.PostalCode;
                    check.Country = item.Country;
                    check.PhoneNumber = item.PhoneNumber;
                    check.IsDeleted = false;
                }
                else
                {
                    var obj = new VendorEnlistmentBankInfoEntity
                    {
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
                        PhoneNumber = item.PhoneNumber,
                    };
                    vendorEnlistmentBankInfoEntities.Add(obj);
                }
            }

            return vendorEnlistmentBankInfoEntities;
        }

        public List<BidderProcurementCategoryEntity> UpdateBidderProcurementCategoryEntity(List<BidderProcurementCategoryEntity> bidderProcurementCategoryEntities,string ids,long vid)
        {
            foreach (var item in bidderProcurementCategoryEntities)
            {
                item.IsDeleted = true;
            }

            var numbers = ids?.Split(',')?.Select(Int64.Parse)?.ToList();

            foreach (var item in numbers)
            {
                var check = bidderProcurementCategoryEntities.Where(x => x.ProcurementCategoryId == item).FirstOrDefault();
                if (check != null)
                {
                    check.IsDeleted = false;
                }
                else
                {
                    var obj = new BidderProcurementCategoryEntity
                    {
                        VendorEnlistmentId=vid,
                        ProcurementCategoryId=item
                    };
                    bidderProcurementCategoryEntities.Add(obj);
                }
            }

            return bidderProcurementCategoryEntities;
        }
    }
}
