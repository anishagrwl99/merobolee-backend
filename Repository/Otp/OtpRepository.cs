using MeroBolee.Utility;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.Otp
{
    public class OtpRepository : IOtpRepository
    {
        private readonly MeroBoleeDbContext meroBoleeDbContext;

        public OtpRepository(MeroBoleeDbContext meroBoleeDbContext)
        {
            this.meroBoleeDbContext = meroBoleeDbContext;
        }
        public async Task<string> GetUserEmailByUserId(long userId)
        {
            try
            {
                return await meroBoleeDbContext.UserEntities.Where(x => x.Id == userId).Select(x => x.Email).FirstOrDefaultAsync();
            }
            catch
            {

                throw;
            }
        }
        
        public async Task<long> GetCompanyIdByEmail(string email)
        {
            try
            {
                return await meroBoleeDbContext.UserEntities.Where(x => x.Email.Equals(email)).Select(x => x.Id).FirstOrDefaultAsync();
            }
            catch
            {

                throw;
            }
        }
        
        public async Task<long> GetUserIdByEmail(string email)
        {
            try
            {
                return await meroBoleeDbContext.CompanyEntities.Where(x => x.CompanyEmail.Equals(email)).Select(x => x.CompanyId).FirstOrDefaultAsync();
            }
            catch
            {

                throw;
            }
        }
    }
}
