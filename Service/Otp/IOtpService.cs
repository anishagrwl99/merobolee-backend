using MeroBolee.Dto;
using System.Threading.Tasks;

namespace MeroBolee.Service.Otp
{
    public interface IOtpService
    {
        Task<bool> CheckOtpSent(OtpDto otpDto);
        string GenerateOtp(string seed);
        Task<bool> VerifyOtp(string otpCode, long UserId, long CompanyId, string Email);
    }
}
