using MeroBolee.Model;
using MeroBolee.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    /// <summary>
    /// status service interface
    /// </summary>
    public interface IStatusService
    {

        /// <summary>
        /// get company status
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CompanyStatusEntity>> GetCompanyStatuses();


        /// <summary>
        /// get common status
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CommonStatus>> GetCommonStatuses();


        /// <summary>
        /// get document status
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<DocumentStatusEntity>> GetDocumentStatuses();


        /// <summary>
        /// get bid registration status
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<BidRequestStatusEntity>> GetBidRequestStatuses();

        /// <summary>
        /// Get user status
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserStatusEntity>> GetUserStatuses();

        /// <summary>
        /// get payment status
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PaymentStatusEntity>> GetPaymentStatuses();

        /// <summary>
        /// get request help status
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<RequestHelpStatus>> GetTechnicalSupportStatuses();

        /// <summary>
        /// Get tender status
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TenderStatusEntity>> GetTenderStatuses();

        /// <summary>
        /// get a tender submission status
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TenderSubmissionStatus>> GetTenderSubmissionStatuses();
    }


    /// <summary>
    /// status service impl
    /// </summary>
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository statusRepository;


        /// <summary>
        /// Default const
        /// </summary>
        /// <param name="statusRepository"></param>
        public StatusService(IStatusRepository statusRepository)
        {
            this.statusRepository = statusRepository;
        }

        /// <summary>
        /// Get bid request status
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BidRequestStatusEntity>> GetBidRequestStatuses()
        {
            return await statusRepository.GetBidRequestStatuses();
        }


        /// <summary>
        /// get payment status
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PaymentStatusEntity>> GetPaymentStatuses()
        {
            return await statusRepository.GetPaymentStatus();
        }


        /// <summary>
        /// get common status
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CommonStatus>> GetCommonStatuses()
        {
            return await statusRepository.GetCommonStatuses();
        }

        /// <summary>
        /// get help request status
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RequestHelpStatus>> GetTechnicalSupportStatuses()
        {
            return await statusRepository.GetTechnicalSupportStatus();
        }


        /// <summary>
        /// get user status
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserStatusEntity>> GetUserStatuses()
        {
            return await statusRepository.GetUserStatuses();
        }


        /// <summary>
        /// get company status
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CompanyStatusEntity>> GetCompanyStatuses()
        {
            return await statusRepository.GetCompanyStatus();
        }

        /// <summary>
        /// get tender status
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TenderStatusEntity>> GetTenderStatuses()
        {
            return await statusRepository.GetTenderStatuses();
        }

        /// <summary>
        /// Get a tender submission status
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TenderSubmissionStatus>> GetTenderSubmissionStatuses()
        {
            return await statusRepository.GetTenderSubmissionStatuses();
        }


        /// <summary>
        /// get a document status
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DocumentStatusEntity>> GetDocumentStatuses()
        {
            return await statusRepository.GetDocumentStatuses();
        }
    }
}
