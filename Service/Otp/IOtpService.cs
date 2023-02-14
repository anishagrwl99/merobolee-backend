using MeroBolee.Dto;
using System.Threading.Tasks;

namespace MeroBolee.Service.Otp
{
    public interface IOtpService
    {
        Task<bool> CheckOtpSent(OtpDto otpDto);
        string GenerateOtp();
        bool VerifyOtp(string otpCode);
    }
}
