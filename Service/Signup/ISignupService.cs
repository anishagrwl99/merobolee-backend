using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.EntityMapper;
using MeroBolee.Model;
using MeroBolee.Repository;

namespace MeroBolee.Service
{
    public interface ISignupService
    {
        ResponseMsg SignupSupplier(SupplierSignUp data);
    }

    public class SignupService : ISignupService
    {
        private readonly ICryptoService cryptoService;
        private readonly ISignupRepository signupRepo;

        public SignupService(ICryptoService cryptoService, ISignupRepository signupRepo)
        {
            this.cryptoService = cryptoService;
            this.signupRepo = signupRepo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ResponseMsg SignupSupplier(SupplierSignUp data)
        {
            try
            {
                CompanyMapper mapper = new CompanyMapper();
                CompanyEntity companyEntity = mapper.SupplierSignUpDToCompanyEntity(data);
                UserMapper userMapper = new UserMapper();
                UserEntity user = userMapper.SupplierSignUpDToUserEntity(data);
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
