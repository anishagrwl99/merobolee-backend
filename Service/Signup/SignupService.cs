using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.EntityMapper;
using MeroBolee.Model;
using MeroBolee.Repository;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Identity;
using MeroBolee.Controllers.EmailService;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Server;

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
        Task<Tuple<long, string>> SignupCompany(UserSignUpDto data, CompanyTypeEnum companyTypeEnum);
    }

    /// <summary>
    /// Signup service implementation
    /// </summary>
    public class SignupService : ISignupService
    {
        private readonly ICryptoService cryptoService;
        private readonly IReferenceCodeService codeService;
        private readonly ISignupRepository signupRepo;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="cryptoService"></param>
        /// <param name="codeService"></param>
        /// <param name="signupRepo"></param>
        public SignupService(ICryptoService cryptoService, IReferenceCodeService codeService, ISignupRepository signupRepo, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.cryptoService = cryptoService;
            this.codeService = codeService;
            this.signupRepo = signupRepo;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="companyTypeEnum"></param>
        /// <returns></returns>
        public async Task<Tuple<long, string>> SignupCompany(UserSignUpDto data, CompanyTypeEnum companyTypeEnum)
        {
            try
            {
                Tuple<bool, string> tuple = await signupRepo.ValidateCompany(data.Email.Trim(), data.PANNumber.Trim());

                if (tuple.Item1 == true)
                {
                    var applicationUser = new IdentityUser
                    {
                        UserName = data.Email,
                        Email = data.Email,
                };  
                    var result = await userManager.CreateAsync(applicationUser, data.Password);
                    if (result.Succeeded)
                    {
                         var token = await userManager.GenerateEmailConfirmationTokenAsync(applicationUser);

                        EmailServiceController emailServiceController = new EmailServiceController();
                        EmailRequestdto emailRequestdto = new EmailRequestdto();
                        emailRequestdto.toEmailId = data.Email;
                        emailRequestdto.token = token;
                        emailRequestdto.id = applicationUser.Id;
                        if(companyTypeEnum == CompanyTypeEnum.Bidder) {
                            emailRequestdto.role = "Supplier";
                        } else {
                            emailRequestdto.role = "BidInviter";
                        }
                        emailServiceController.sendEmail(emailRequestdto);
                    } else {
                        return Tuple.Create<long, String>(0, "false");
                    }
                    CompanyMapper mapper = new();
                    CompanyEntity companyEntity = mapper.SupplierSignUpDToCompanyEntity(data, companyTypeEnum);

                    UserMapper userMapper = new();
                    UserEntity user = userMapper.SupplierSignUpDToUserEntity(data, companyTypeEnum);
                    user.Password = cryptoService.Encrypt(user.Password);
                    companyEntity = await signupRepo.SignupSupplier(companyEntity, user);

                    if (companyTypeEnum == CompanyTypeEnum.Bidder)
                    {
                        companyEntity.ReferenceCode = await codeService.GenerateCode(ReferenceEnum.Bidder) + companyEntity.CompanyId.ToString("D3");
                    }
                    else
                    {
                        companyEntity.ReferenceCode = await codeService.GenerateCode(ReferenceEnum.BidInviter) + companyEntity.CompanyId.ToString("D3");
                    }

                    companyEntity.FolderName = companyEntity.CompanyId.ToString("D3") + data.Name.GetFirstCharString();
                    companyEntity = await signupRepo.UpdateCompany(companyEntity);

                    return Tuple.Create<long, string>(companyEntity.CompanyId, "");
                }
                else
                {
                    return Tuple.Create<long, string>(0, tuple.Item2);
                }

            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}
