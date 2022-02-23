using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public interface ITenderSubmissionRepository : IRepositoryBase<TenderSubmission>
    {
        Task<TenderSubmission> GetById(long submissionId);
        Task<TenderSubmission> GetDetailById(long submissionId);
        Task<TenderSubmission> GetDetailById(long submissionId, long companyId, long userId);
        Task<TenderSubmission> Update(TenderSubmission ent);
        Task<List<TenderSubmission>> BidInviterTenderSubmissions(long companyId, long userId);
        Task<List<TenderSubmission>> AdminTenderSubmissions();

    }
    public class TenderSubmissionRepository : RepositoryBase<TenderSubmissionRepository>, ITenderSubmissionRepository
    {
        private readonly IUnitOfWork unitOfWork;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="dbFactory"></param>
        public TenderSubmissionRepository(IUnitOfWork unitOfWork, IDbFactory dbFactory) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public TenderSubmission Add(TenderSubmission t)
        {
            try
            {
                meroBoleeDbContexts.TenderSubmissions.Add(t);
                unitOfWork.SaveChange();
                return t;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(TenderSubmission t)
        {
            throw new NotImplementedException();
        }

        public Task<TenderSubmission> GetById(long submissionId)
        {
            try
            {
                return Task.Run(() =>
                {
                    return meroBoleeDbContexts.TenderSubmissions
                    .Where(x => x.SubmissionId == submissionId)
                    .Include(x => x.TenderSubmissionStatus)
                    .Include(x => x.Company)
                    .FirstOrDefault();
                });
            }
            catch (Exception)
            {

                throw;
            }
        }


        public Task<TenderSubmission> GetDetailById(long submissionId)
        {
            try
            {
                return Task.Run(() =>
                {
                    bool isFormSubmission = (from ts in meroBoleeDbContexts.TenderSubmissions
                                             where ts.SubmissionId == submissionId
                                             select ts.IsFormSubmission
                                             ).FirstOrDefault();

                    if (isFormSubmission)
                    {
                        return meroBoleeDbContexts.TenderSubmissions
                        .Where(x => x.SubmissionId == submissionId)
                        .Include(x => x.TenderSubmissionStatus)
                        .Include(x => x.TenderSubmissionDocuments)
                        .Include(x => x.ProductSpecifications)
                        .Include(x => x.PurchaseCriterias)
                        .Include(x => x.PriceSchedules)
                        .Include(x => x.EligibilityCriterias)
                        .Include(x => x.CreatedByUser)
                        .Include(x => x.CreatedByUser.UserStatus)
                        .Include(x => x.UpdatedByUser)
                        .Include(x => x.UpdatedByUser.UserStatus)
                        .Include(x => x.Company)
                        .Include(x => x.Company.CompanyStatus)
                        .Include(x => x.Company.Country)
                        .Include(x => x.Company.Province)
                        .Include(x => x.AdditionalDocuments)
                        .FirstOrDefault();
                    }
                    else
                    {
                        return meroBoleeDbContexts.TenderSubmissions
                        .Where(x => x.SubmissionId == submissionId)
                        .Include(x => x.TenderSubmissionStatus)
                        .Include(x => x.TenderSubmissionDocuments)
                        .Include(x => x.CreatedByUser)
                        .Include(x => x.CreatedByUser.UserStatus)
                        .Include(x => x.UpdatedByUser)
                        .Include(x => x.UpdatedByUser.UserStatus)
                        .Include(x => x.Company)
                        .Include(x => x.Company.CompanyStatus)
                        .Include(x => x.Company.Country)
                        .Include(x => x.Company.Province)
                        .FirstOrDefault();
                    }
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<TenderSubmission> GetDetailById(long submissionId, long companyId, long userId)
        {
            try
            {
                return Task.Run(() =>
                {
                    bool isFormSubmission = (from ts in meroBoleeDbContexts.TenderSubmissions
                                             where ts.SubmissionId == submissionId && ts.CompanyId == companyId
                                             select ts.IsFormSubmission
                                             ).FirstOrDefault();

                    if (isFormSubmission)
                    {
                        return meroBoleeDbContexts.TenderSubmissions
                        .Where(x => x.SubmissionId == submissionId && x.CompanyId == companyId)
                        .Include(x => x.TenderSubmissionStatus)
                        .Include(x => x.TenderSubmissionDocuments)
                        .Include(x => x.ProductSpecifications)
                        .Include(x => x.PurchaseCriterias)
                        .Include(x => x.PriceSchedules)
                        .Include(x => x.EligibilityCriterias)
                        .Include(x => x.AdditionalDocuments)
                        .Include(x => x.CreatedByUser)
                        .Include(x => x.CreatedByUser.UserStatus)
                        .Include(x => x.UpdatedByUser)
                        .Include(x => x.UpdatedByUser.UserStatus)
                        .Include(x => x.Company)
                        .Include(x => x.Company.CompanyStatus)
                        .Include(x => x.Company.Country)
                        .Include(x => x.Company.Province)
                        .FirstOrDefault();
                    }
                    else
                    {
                        return meroBoleeDbContexts.TenderSubmissions
                        .Where(x => x.SubmissionId == submissionId && x.CompanyId == companyId)
                        .Include(x => x.TenderSubmissionStatus)
                        .Include(x => x.TenderSubmissionDocuments)
                        .Include(x => x.CreatedByUser)
                        .Include(x => x.CreatedByUser.UserStatus)
                        .Include(x => x.UpdatedByUser)
                        .Include(x => x.UpdatedByUser.UserStatus)
                        .Include(x => x.Company)
                        .Include(x => x.Company.CompanyStatus)
                        .Include(x => x.Company.Country)
                        .Include(x => x.Company.Province)
                        .FirstOrDefault();
                    }
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<TenderSubmission> Update(TenderSubmission ent)
        {
            try
            {
                meroBoleeDbContexts.TenderSubmissions.Update(ent);
                await unitOfWork.SaveChangesAsync();
                return ent;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<TenderSubmission>> BidInviterTenderSubmissions(long companyId, long userId)
        {
            try
            {
                return Task.Run(() =>
                {
                    return meroBoleeDbContexts.TenderSubmissions
                    .Where(x => x.CompanyId == companyId)
                    .Include(x => x.TenderSubmissionStatus)
                    .Include(x => x.Company)
                    .ToList();

                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        IEnumerable<TenderSubmission> IRepositoryBase<TenderSubmission>.Get()
        {
            throw new NotImplementedException();
        }

        TenderSubmission IRepositoryBase<TenderSubmission>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TenderSubmission>> AdminTenderSubmissions()
        {
            try
            {
                return Task.Run(() =>
                {
                    return meroBoleeDbContexts.TenderSubmissions
                    .Where(x => x.StatusId != 1) //Pending payment status submission is not visible to admin
                    .Include(x => x.TenderSubmissionStatus)
                    .Include(x => x.Company)
                    .ToList();

                });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
