using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.EntityMapper;
using MeroBolee.Model;
using MeroBolee.Repository;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    /// <summary>
    /// Signup service interface
    /// </summary>
    public interface ISignupService
    {

        /// <summary>
        /// Method to signup onbording company
        /// </summary>
        /// <param name="data"></param>
        /// <param name="companyTypeEnum"></param>
        /// <returns></returns>
        Task<CompanyEntity> SignupCompany(UserSignUpDto data, CompanyTypeEnum companyTypeEnum);
    }

    /// <summary>
    /// Signup service implementation
    /// </summary>
    public class SignupService : ISignupService
    {
        private readonly ICryptoService cryptoService;
        private readonly IReferenceCodeService codeService;
        private readonly ISignupRepository signupRepo;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="cryptoService"></param>
        /// <param name="codeService"></param>
        /// <param name="signupRepo"></param>
        public SignupService(ICryptoService cryptoService, IReferenceCodeService codeService, ISignupRepository signupRepo)
        {
            this.cryptoService = cryptoService;
            this.codeService = codeService;
            this.signupRepo = signupRepo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="companyTypeEnum"></param>
        /// <returns></returns>
        public async Task<CompanyEntity> SignupCompany(UserSignUpDto data, CompanyTypeEnum companyTypeEnum)
        {
            try
            {
                CompanyMapper mapper = new();
                CompanyEntity companyEntity = mapper.SupplierSignUpDToCompanyEntity(data, companyTypeEnum);
               
                UserMapper userMapper = new();
                UserEntity user = userMapper.SupplierSignUpDToUserEntity(data, companyTypeEnum);
                user.Password = cryptoService.Encrypt(user.Password);
                companyEntity = await signupRepo.SignupSupplier(companyEntity, user);

                if(companyTypeEnum == CompanyTypeEnum.Bidder)
                {
                    companyEntity.ReferenceCode = await codeService.GenerateCode(ReferenceEnum.Bidder) + companyEntity.CompanyId.ToString("D3");
                }
                else
                {
                    companyEntity.ReferenceCode = await codeService.GenerateCode(ReferenceEnum.BidInviter) + companyEntity.CompanyId.ToString("D3");
                }

                companyEntity.FolderName = companyEntity.CompanyId.ToString("D3") +  data.Name.GetFirstCharString();
                companyEntity = await signupRepo.UpdateCompany(companyEntity);
                
                return companyEntity;

            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}
