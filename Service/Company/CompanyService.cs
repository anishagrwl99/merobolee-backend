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
        AddCompanyResponseDto AddCompany(AddCompanyDto companyDto, CompanyTypeEnum RegisteredAs);
        AddUserReponseDto AddUser(long companyId, AddUserDto user, int role);
        Task<List<CompanyCardResponseDto>> GetCompany(string search);
        Task<CompanyDetailResponse> GetCompanyDetail(long companyId, string baseUrl, string defaultPic);

        AddCompanyResponseDto UpdateCompany(long id, AddCompanyDto company, CompanyTypeEnum RegisteredAs);


        /// <summary>
        /// Change status of a company by an admin
        /// </summary>
        /// <param name="dto">A request payload</param>
        /// <returns></returns>
        Task<ChangeCompanyStatusResponseDto> ChangeCompanyStatus(ChangeCompanyStatusDto dto);

    }

    public class CompanyService : CompanyMapper, ICompanyService
    {
        private readonly ICompanyRepository CompanyRepository;
        private readonly IReferenceCodeService referenceCodeService;
        private readonly ICryptoService cryptoService;
        private readonly IUploadFile fileService;

        public CompanyService(ICompanyRepository CompanyRepository,
                                IReferenceCodeService referenceCodeService,
                                ICryptoService cryptoService,
                                IUploadFile fileService)
        {
            this.CompanyRepository = CompanyRepository;
            this.referenceCodeService = referenceCodeService;
            this.cryptoService = cryptoService;
            this.fileService = fileService;
        }

        public AddCompanyResponseDto AddCompany(AddCompanyDto companyDto, CompanyTypeEnum RegisteredAs)
        {
            try
            {
                CompanyEntity ent = AddCompanyDtoToEntity(companyDto, RegisteredAs);
                ent = CompanyRepository.AddCompany(ent, companyDto.UserId);

                if (RegisteredAs == CompanyTypeEnum.Bidder)
                {
                    ent.ReferenceCode = referenceCodeService.GenerateCode(ReferenceEnum.Bidder).Result + ent.CompanyId.ToString("D3");
                }
                else if (RegisteredAs == CompanyTypeEnum.BidInviter)
                {
                    ent.ReferenceCode = referenceCodeService.GenerateCode(ReferenceEnum.BidInviter).Result + ent.CompanyId.ToString("D3");
                }
                ent.FolderName = ent.CompanyId.ToString("D3") + ent.Name.GetFirstCharString();
                CompanyRepository.UpdateCompany(ent);

                return CompanyEntityToResponseDto(ent);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public AddUserReponseDto AddUser(long companyId, AddUserDto user, int role)
        {
            UserEntity entity = UserDtoToEntity(user);
            if (entity != null)
            {
                entity.Password = cryptoService.Encrypt(user.Password);
                entity.RoleId = role;
                entity.StatusId = 1;
                entity.IsEmailReceiver = true;
                entity = CompanyRepository.AddUser(companyId, entity);
                return UserEntityToResponse(entity);
            }
            return null;

        }

        public async Task<List<CompanyCardResponseDto>> GetCompany(string search)
        {
            try
            {
                List<CompanyEntity> companies = await CompanyRepository.GetCompany(search);
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

        public async Task<CompanyDetailResponse> GetCompanyDetail(long companyId, string baseUrl, string defaultPic)
        {
            try
            {
                Tuple<CompanyEntity, List<UserEntity>, List<TenderEntity>> resp = await CompanyRepository.GetCompanyDetail(companyId);
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

        public AddCompanyResponseDto UpdateCompany(long id, AddCompanyDto company, CompanyTypeEnum RegisteredAs)
        {
            throw new NotImplementedException();
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
                CompanyEntity ent = await CompanyRepository.GetCompany(dto.CompanyId);
                ent.Date_modified = DateTime.Now;
                ent.CompanyStatusId = dto.StatusId;
                ent = await CompanyRepository.ChangeCompanyStatus(ent);
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
