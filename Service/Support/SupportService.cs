using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.EntityMapper;
using MeroBolee.Model;
using MeroBolee.Repository;
using System;

namespace MeroBolee.Service
{
    /// <summary>
    /// Signup service interface
    /// </summary>
    public interface ISupportService
    {
        void SendSupportEmail(CustomerSupportDto supportDto);
    }

    /// <summary>
    /// Signup service implementation
    /// </summary>
    public class SupportService : ISupportService
    {
        private readonly ISMTPEmailService emailService;


        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="emailService"></param>
        public SupportService(ISMTPEmailService emailService)
        {
            this.emailService = emailService;
        }


        public void SendSupportEmail(CustomerSupportDto supportDto)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
