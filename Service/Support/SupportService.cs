using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.EntityMapper;
using MeroBolee.Model;
using MeroBolee.Repository;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MeroBolee.Settings;
using System.Text;

namespace MeroBolee.Service
{
    /// <summary>
    /// Signup service interface
    /// </summary>
    public interface ISupportService
    {
        Task SendSupportEmail(CustomerSupportDto supportDto);
    }

    /// <summary>
    /// Signup service implementation
    /// </summary>
    public class SupportService : ISupportService
    {
        private readonly ISMTPEmailService emailService;
        private readonly AppDefaults defaultOptions;


        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="emailService"></param>
        /// <param name="defaultOptions"></param>
        public SupportService(ISMTPEmailService emailService, IOptions<AppDefaults> defaultOptions)
        {
            this.emailService = emailService;
            this.defaultOptions = defaultOptions.Value;
        }


        public async Task SendSupportEmail(CustomerSupportDto supportDto)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Name:  <strong>{supportDto.Name}</strong>");
                sb.AppendLine($"Email: <strong>{supportDto.Email}</strong>");
                sb.AppendLine($"Phone: <strong>{supportDto.MobileNumber}</strong>");
                sb.AppendLine($"Query: <strong>{supportDto.Query}</strong>");
                var email = emailService.ComposeEmail(defaultOptions.CustomerSupportEmail, $"Support Request - {supportDto.Email}", sb.ToString());
                await emailService.Send(email);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
