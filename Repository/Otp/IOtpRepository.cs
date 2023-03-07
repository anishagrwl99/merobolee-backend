using System.Threading.Tasks;

namespace MeroBolee.Repository.Otp
{
    public interface IOtpRepository
    {
        Task<string> GetUserEmailByUserId(long userId);

        Task<long> GetCompanyIdByEmail(string email);

        Task<long> GetUserIdByEmail(string email);
    }
}
