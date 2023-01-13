using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public interface ICompanyService
    {

        /// <summary>
        /// Adds the company.
        /// </summary>
        /// <param name="companyDto">The company dto.</param>
        /// <param name="RegisteredAs">The registered as.</param>
        /// <returns></returns>
        Task<AddCompanyResponseDto> AddCompany(AddCompanyDto companyDto, CompanyTypeEnum RegisteredAs);


        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="user">The user.</param>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        Task<AddUserReponseDto> AddUser(long companyId, AddUserDto user, int role);

        /// <summary>
        /// Gets the company.
        /// </summary>
        /// <param name="companyType">The company type.</param>
        /// <param name="search">The search.</param>
        /// <returns></returns>
        Task<List<CompanyCardResponseDto>> GetCompanyByType(CompanyTypeEnum companyType, string search);



        /// <summary>
        /// Gets all company.
        /// </summary>
        /// <param name="search">The search.</param>
        /// <returns></returns>
        Task<List<CompanyCardResponseDto>> GetAllCompany( string search);




        /// <summary>
        /// Get verified bid inviter companies
        /// </summary>
        /// <param name="companyType"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<List<CompanyCardResponseDto>> GetVerifiedCompany(CompanyTypeEnum companyType, string search);

        /// <summary>
        /// Gets the company detail.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="defaultPic">The default pic.</param>
        /// <returns></returns>
        Task<CompanyDetailResponse> GetCompanyDetail(long companyId, string baseUrl, string defaultPic);


        /// <summary>
        /// Updates the company.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        Task<AddCompanyResponseDto> UpdateCompany(AddCompanyResponseDto company);


        /// <summary>
        /// Change status of a company by an admin
        /// </summary>
        /// <param name="dto">A request payload</param>
        /// <returns></returns>
        Task<ChangeCompanyStatusResponseDto> ChangeCompanyStatus(ChangeCompanyStatusDto dto);

    }


    /// <summary>
    /// CompanyService 
    /// </summary>
    /// <seealso cref="MeroBolee.EntityMapper.CompanyMapper" />
    /// <seealso cref="MeroBolee.Service.ICompanyService" />
    public class CompanyService : CompanyMapper, ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IReferenceCodeService referenceCodeService;
        private readonly ICryptoService cryptoService;
        private readonly IUploadFile fileService;


        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyService"/> class.
        /// </summary>
        /// <param name="companyRepository">The company repository.</param>
        /// <param name="referenceCodeService">The reference code service.</param>
        /// <param name="cryptoService">The crypto service.</param>
        /// <param name="fileService">The file service.</param>
        public CompanyService(ICompanyRepository companyRepository,
                                IReferenceCodeService referenceCodeService,
                                ICryptoService cryptoService,
                                IUploadFile fileService)
        {
            this.companyRepository = companyRepository;
            this.referenceCodeService = referenceCodeService;
            this.cryptoService = cryptoService;
            this.fileService = fileService;
        }


        /// <summary>
        /// Adds the company.
        /// </summary>
        /// <param name="companyDto">The company dto.</param>
        /// <param name="RegisteredAs">The registered as.</param>
        /// <returns></returns>
        public async Task<AddCompanyResponseDto> AddCompany(AddCompanyDto companyDto, CompanyTypeEnum RegisteredAs)
        {
            try
            {
                CompanyEntity ent = AddCompanyDtoToEntity(companyDto, RegisteredAs);
                ent = await companyRepository.AddCompany(ent, companyDto.UserId);

                if (RegisteredAs == CompanyTypeEnum.Bidder)
                {
                    ent.ReferenceCode = referenceCodeService.GenerateCode(ReferenceEnum.Bidder).Result + ent.CompanyId.ToString("D3");
                }
                else if (RegisteredAs == CompanyTypeEnum.BidInviter)
                {
                    ent.ReferenceCode = referenceCodeService.GenerateCode(ReferenceEnum.BidInviter).Result + ent.CompanyId.ToString("D3");
                }
                ent.FolderName = ent.CompanyId.ToString("D3") + ent.Name.GetFirstCharString();
                await companyRepository.UpdateCompany(ent);

                return CompanyEntityToResponseDto(ent);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Add new user in a company
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="user"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<AddUserReponseDto> AddUser(long companyId, AddUserDto user, int role)
        {
            UserEntity entity = UserDtoToEntity(user);
            if (entity != null)
            {
                entity.Password = cryptoService.Encrypt(user.Password);
                entity.RoleId = role;
                entity.StatusId = 1;
                entity.IsEmailReceiver = true;
                entity = await companyRepository.AddUser(companyId, entity);
                return UserEntityToResponse(entity);
            }
            return null;

        }



        /// <summary>
        /// Get all company
        /// </summary>
        /// <param name="companyType"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<List<CompanyCardResponseDto>> GetCompanyByType(CompanyTypeEnum companyType, string search)
        {
            try
            {
                List<CompanyEntity> companies = await companyRepository.GetCompanyByType(companyType, search);
                List<CompanyCardResponseDto> reponseDtos = new List<CompanyCardResponseDto>();
                foreach (CompanyEntity item in companies)
                {

                    foreach (var item1 in item.CompanyUsers)
                    {
                        CompanyCardResponseDto dto = new CompanyCardResponseDto
                        {
                            Id = item.CompanyId,
                            Name = item.Name,
                            ReferenceCode = item.ReferenceCode,
                            City = item.City,
                            Email = item.CompanyEmail,
                            Status = item.CompanyStatus.Status,
                            Country = item.Country.Name,
                            UserId = item1.UserId
                        };
                        reponseDtos.Add(dto);

                    }

                }
                return reponseDtos;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<CompanyCardResponseDto>> GetAllCompany(string search)
        {
            try
            {
                List<CompanyEntity> companies = await companyRepository.GetAllCompany(search);
                List<CompanyCardResponseDto> reponseDtos = new List<CompanyCardResponseDto>();
                foreach (CompanyEntity item in companies)
                {
                    CompanyCardResponseDto dto = ToCard(item);
                    reponseDtos.Add(dto);
                }
                return reponseDtos;
            }
            catch (Exception)
            {

                throw;
            }

        }


        /// <summary>
        /// Get verified only company
        /// </summary>
        /// <param name="companyType"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<List<CompanyCardResponseDto>> GetVerifiedCompany(CompanyTypeEnum companyType, string search)
        {
            try
            {
                List<CompanyEntity> companies = await companyRepository.GetVerifiedCompany(companyType, search);
                List<CompanyCardResponseDto> reponseDtos = new List<CompanyCardResponseDto>();
                foreach (CompanyEntity item in companies)
                {
                    CompanyCardResponseDto dto = ToCard(item);
                    reponseDtos.Add(dto);
                }
                return reponseDtos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        
        /// <summary>
        /// Get company detail
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="baseUrl"></param>
        /// <param name="defaultPic"></param>
        /// <returns></returns>
        public async Task<CompanyDetailResponse> GetCompanyDetail(long companyId, string baseUrl, string defaultPic)
        {
            try
            {
                Tuple<CompanyEntity, List<UserEntity>, List<CommunityApprovalEntity>> resp = await companyRepository.GetCompanyDetail(companyId);
                if (resp != null)
                {
                    CompanyDetailResponse detail = ToDetailResponse(resp.Item1, resp.Item2, resp.Item3, fileService, baseUrl, defaultPic);

                    return detail;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Updates the company.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        public async Task< AddCompanyResponseDto> UpdateCompany(AddCompanyResponseDto company)
        {
            try
            {
                CompanyEntity comp = await companyRepository.GetCompany(company.CompanyId);
                if (comp != null)
                {
                    comp.Name = company.CompanyName;
                    comp.PANNumber = company.PANNumber;
                    comp.CountryId = company.CountryId;
                    comp.ProvinceId = company.ProvinceId;
                    comp.City = company.City;
                    comp.Address1 = company.Address1;
                    comp.Address2 = company.Address2;
                    comp.Address3 = company.Address3;
                    comp.Zip = company.Zip;
                    comp.ContactPerson = company.ContactPerson;
                    comp.CompanyEmail = company.CompanyEmail;
                    comp.CompanyWebsite = company.CompanyWebsite;
                    comp.MobileNumber = company.MobileNumber;
                    comp.PhoneNumber = company.PhoneNumber;
                    await companyRepository.UpdateCompany(comp);
                    return company;
                }
                else
                    return null;
            }
            catch (Exception)
            {

                throw;
            }
        }



        /// <summary>
        /// Change status of a company
        /// </summary>
        /// <param name="dto">Request payload</param>
        /// <returns></returns>
        public async Task<ChangeCompanyStatusResponseDto> ChangeCompanyStatus(ChangeCompanyStatusDto dto)
        {
            try
            {
                CompanyEntity ent = await companyRepository.GetCompany(dto.CompanyId);
                ent.Date_modified = DateTime.Now;
                ent.CompanyStatusId = dto.StatusId;
                ent = await companyRepository.ChangeCompanyStatus(ent);
                return new ChangeCompanyStatusResponseDto
                {
                    CompanyId = dto.CompanyId,
                    Status = ent.CompanyStatus.Status
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
