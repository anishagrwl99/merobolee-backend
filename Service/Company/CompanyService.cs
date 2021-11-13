using MeroBolee.Dto;
using MeroBolee.EntityMapper;
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
        IEnumerable<AddCompanyResponseDto> GetCompany(string search);
        CompanyDetailResponse GetCompanyDetail(long id, CompanyTypeEnum RegisteredAs);

        AddCompanyResponseDto UpdateCompany(long id, AddCompanyDto company, CompanyTypeEnum RegisteredAs);

    }

    public class CompanyService : CompanyMapper, ICompanyService
    {
        private readonly ICompanyRepository CompanyRepository;
        private readonly IReferenceCodeService referenceCodeService;
        private readonly ICryptoService cryptoService;

        public CompanyService(ICompanyRepository CompanyRepository, IReferenceCodeService referenceCodeService, ICryptoService cryptoService)
        {
            this.CompanyRepository = CompanyRepository;
            this.referenceCodeService = referenceCodeService;
            this.cryptoService = cryptoService;
        }

        public AddCompanyResponseDto AddCompany(AddCompanyDto companyDto, CompanyTypeEnum RegisteredAs)
        {
            try
            {
                CompanyEntity ent = AddCompanyDtoToEntity(companyDto, RegisteredAs);
                if (RegisteredAs == CompanyTypeEnum.Bidder)
                {
                    ent.ReferenceCode = referenceCodeService.GenerateCode(ReferenceEnum.Bidder).Result;
                }
                else if (RegisteredAs == CompanyTypeEnum.BidInviter)
                {
                    ent.ReferenceCode = referenceCodeService.GenerateCode(ReferenceEnum.BidInviter).Result;
                }
                ent = CompanyRepository.AddCompany(ent, companyDto.UserId);
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
                entity.Role_Id = role;
                entity.Status_id = 1;
                entity.IsEmailReceiver = true;
                entity = CompanyRepository.AddUser(companyId, entity);
                return UserEntityToResponse(entity);
            }
            return null;

        }

        public IEnumerable<AddCompanyResponseDto> GetCompany(string search)
        {
            try
            {
                IEnumerable<CompanyEntity> companies = CompanyRepository.GetCompany(search);
                List<AddCompanyResponseDto> reponseDtos = new List<AddCompanyResponseDto>();
                foreach (CompanyEntity item in companies)
                {
                    AddCompanyResponseDto dto = CompanyEntityToResponseDto(item);
                    reponseDtos.Add(dto);
                }
                return reponseDtos;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public CompanyDetailResponse GetCompanyDetail(long id, CompanyTypeEnum RegisteredAs)
        {
            try
            {
                return CompanyRepository.GetCompanyDetail(id, RegisteredAs);

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
    }
}
