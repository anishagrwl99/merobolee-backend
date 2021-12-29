using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    /// <summary>
    /// Status repo interface
    /// </summary>
    public interface IStatusRepository : IRepositoryBase<CommonStatus>
    {
        /// <summary>
        /// Get common status
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CommonStatus>> GetCommonStatuses();

        /// <summary>
        /// Get user status
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserStatusEntity>> GetUserStatuses();


        /// <summary>
        /// get document status
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<DocumentStatusEntity>> GetDocumentStatuses();

        /// <summary>
        /// Get company status
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CompanyStatusEntity>> GetCompanyStatus();


        /// <summary>
        /// Get bid request status
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<BidRequestStatusEntity>> GetBidRequestStatuses();


        /// <summary>
        /// get payment status
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PaymentStatusEntity>> GetPaymentStatus();



        /// <summary>
        /// Get help request status
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<RequestHelpStatus>> GetRequestHelpStatus();


        /// <summary>
        /// Get tender status
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TenderStatusEntity>> GetTenderStatuses();


        /// <summary>
        /// Get a tender submission status
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TenderSubmissionStatus>> GetTenderSubmissionStatuses();
    }


    /// <summary>
    /// status repos implementation
    /// </summary>
    public class StatusRepository : RepositoryBase<CommonStatus>, IStatusRepository
    {

        private IUnitOfWork unitOfWork;


        /// <summary>
        /// Default const
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="dbFactory"></param>
        public StatusRepository(IUnitOfWork unitOfWork, IDbFactory dbFactory) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get commons tatus
        /// </summary>
        /// <returns></returns>

        public async Task<IEnumerable<CommonStatus>> GetCommonStatuses()
        {
            return await meroBoleeDbContexts.CommonStatusEntities.ToListAsync();
        }

        /// <summary>
        /// Get user status
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserStatusEntity>> GetUserStatuses()
        {
            return await meroBoleeDbContexts.UserStatusEntities.ToListAsync();
        }


        /// <summary>
        /// Get company status
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CompanyStatusEntity>> GetCompanyStatus()
        {
            return await meroBoleeDbContexts.CompanyStatusEntities.ToListAsync();
        }


        /// <summary>
        /// Get bid request status
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BidRequestStatusEntity>> GetBidRequestStatuses()
        {
            return await meroBoleeDbContexts.BidRequestStatusEntities.ToListAsync();
        }


        /// <summary>
        /// Get payment status
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PaymentStatusEntity>> GetPaymentStatus()
        {
            return await meroBoleeDbContexts.PaymentStatusEntities.ToListAsync();
        }


        /// <summary>
        /// Get request help status
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RequestHelpStatus>> GetRequestHelpStatus()
        {
            return await meroBoleeDbContexts.RequestHelpStatuses.ToListAsync();
        }


        /// <summary>
        /// Get tender status
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TenderStatusEntity>> GetTenderStatuses()
        {
            return await meroBoleeDbContexts.TenderStatus.ToListAsync();
        }

        /// <summary>
        /// Get a tender submission status
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TenderSubmissionStatus>> GetTenderSubmissionStatuses()
        {
            return await meroBoleeDbContexts.TenderSubmissionStatuses.ToListAsync();
        }



        /// <summary>
        /// get a document status
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DocumentStatusEntity>> GetDocumentStatuses()
        {
            return await meroBoleeDbContexts.DocumentStatusEntities.ToListAsync();
        }
    }
}
