using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Migrations;
using MeroBolee.Settings;
using Microsoft.Extensions.Options;
using OtpNet;
using System.Threading.Tasks;

namespace MeroBolee.Service.Otp
{
    public class OtpService : IOtpService
    {
        private readonly TOTP _otp;

        public OtpService(IOptions<TOTP> otp)
        {
            this._otp = otp.Value;
        }
    
        public string GenerateOtp(OtpDto otpDto)
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

       


        public bool VerifyOtp(OtpVerifyDto otpVerifyDto)
        {
            try
            {
                var seed = _otp.Key;
                var bytes = Base32Encoding.ToBytes(seed);

                var totp = new Totp(bytes, step: 300);
                long timeStepMatched;
                bool verify = totp.VerifyTotp(DateTimeNPT.Now, otpVerifyDto.Input, out timeStepMatched, VerificationWindow.RfcSpecifiedNetworkDelay);
                return verify;
            }
            catch 
            {

                throw;
            }
        }
    }
}
