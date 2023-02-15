using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Migrations;
using MeroBolee.Repository;
using MeroBolee.Repository.Otp;
using MeroBolee.Settings;
using Microsoft.Extensions.Options;
using OtpNet;
using System.Threading.Tasks;

namespace MeroBolee.Service.Otp
{
    public class OtpService : IOtpService
    {
        private readonly TOTP _otp;
        private readonly ISendEmailService sendEmailService;
        private readonly IOtpRepository otpRepository;

        public OtpService(IOptions<TOTP> otp, ISendEmailService sendEmailService, IOtpRepository otpRepository)
        {
            this._otp = otp.Value;
            this.sendEmailService = sendEmailService;
            this.otpRepository = otpRepository;
        }

        public string GenerateOtp()
        {
            try
            {

                var seed = _otp.Key;



                var bytes = Base32Encoding.ToBytes(seed);

                var totp = new Totp(bytes, step: 300);

                return totp.ComputeTotp(DateTimeNPT.Now);
            }
            catch 
            {

                throw;
            }
            
        }

       


        public bool VerifyOtp(string otpCode)
        {
            try
            {
                var seed = _otp.Key;
                var bytes = Base32Encoding.ToBytes(seed);

                var totp = new Totp(bytes, step: 300);
                long timeStepMatched;
                bool verify = totp.VerifyTotp(DateTimeNPT.Now, otpCode, out timeStepMatched, VerificationWindow.RfcSpecifiedNetworkDelay);
                return verify;
            }
            catch 
            {

                throw;
            }
        }

        public async Task<bool> CheckOtpSent(OtpDto otpDto)
        {
            try
            {
                SendEmailResponseDto sendEmailResponse = new SendEmailResponseDto();

                EmailRequestdto emailRequestdto = new EmailRequestdto();
                emailRequestdto.toEmailId = await otpRepository.GetUserEmailByUserId(otpDto.UserId);

                if (emailRequestdto.toEmailId == null)
                {
                    return false;
                }

                emailRequestdto.callFrom = "OtpGenerate";
                emailRequestdto.Otp = GenerateOtp();
                sendEmailResponse = sendEmailService.SendEmail(emailRequestdto);

                if (sendEmailResponse != null)
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
            catch
            {

                throw;
            }

        }
    }
}
