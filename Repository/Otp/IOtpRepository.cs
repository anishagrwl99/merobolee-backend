using System.Threading.Tasks;

namespace MeroBolee.Repository.Otp
{
    public interface IOtpRepository
    {
        Task<string> GetUserEmailByUserId(long userId);
    }
}
