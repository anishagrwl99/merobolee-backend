using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.EntityMapper;
using MeroBolee.Model;
using MeroBolee.Repository;

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
        ResponseMsg SignupCompany(UserSignUpDto data, CompanyTypeEnum companyTypeEnum);
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
        public ResponseMsg SignupCompany(UserSignUpDto data, CompanyTypeEnum companyTypeEnum)
        {
            try
            {
                CompanyMapper mapper = new();
                CompanyEntity companyEntity = mapper.SupplierSignUpDToCompanyEntity(data, companyTypeEnum);
                companyEntity.ReferenceCode = companyTypeEnum== CompanyTypeEnum.Bidder ? 
                        codeService.GenerateCode(ReferenceEnum.Bidder).Result : codeService.GenerateCode(ReferenceEnum.BidInviter).Result;
                UserMapper userMapper = new();
                UserEntity user = userMapper.SupplierSignUpDToUserEntity(data, companyTypeEnum);
                user.Password = cryptoService.Encrypt(user.Password);
                bool result = signupRepo.SignupSupplier(companyEntity, user);
                if(result)
                {
                    return new ResponseMsg
                    {
                        statusCode = "200",
                        Message = "Supplier signup"
                    };
                }

            }
            catch (System.Exception ex)
            {
                return new ResponseMsg
                {
                    statusCode = "500",
                    Message = ex.Message
                };
            }

            return new ResponseMsg
            {
                statusCode = "400",
                Message = "Bad data supplied"
            };
        }

    }
}
