using MeroBolee.Dto;
using System.Threading.Tasks;

namespace MeroBolee.Service.Otp
{
    public interface IOtpService
    {
        string GenerateOtp();
        bool VerifyOtp(string otpCode);
    }
}
