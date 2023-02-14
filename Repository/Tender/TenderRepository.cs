using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeroBolee.Service;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using MeroBolee.Utility;
using System.Reflection.Metadata.Ecma335;

namespace MeroBolee.Repository
{

    /// <summary>
    /// Tender repo impelentation
    /// </summary>
    /// 
    public class TenderRepository : RepositoryBase<TenderEntity>, ITenderRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private ICryptoService cryptoService;


        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="dbFactory"></param>
        /// <param name="cryptoService"></param>
        public TenderRepository(IUnitOfWork unitOfWork, IDbFactory dbFactory, ICryptoService cryptoService) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
            this.cryptoService = cryptoService;
        }

        /// <summary>
        /// Add tender to db
        /// </summary>
        /// <param name="tenderEntity"></param>
        /// <returns></returns>
        public TenderEntity AddTender(TenderEntity tenderEntity)
        {
            try
            {
                meroBoleeDbContexts.TenderEntities.Add(tenderEntity);
                unitOfWork.SaveChange();

                return tenderEntity;
            }

            catch (Exception)
            {
                throw;
            }

        }

        public List<CommunityApprovalEntity> AddCommunityApproval(List<CommunityApprovalEntity> communityApprovalEntity)
        {
            try
            {
                meroBoleeDbContexts.CommunityApprovalEntities.AddRange(communityApprovalEntity);
                unitOfWork.SaveChange();

                return communityApprovalEntity;
            }

            catch (Exception)
            {
                throw;
            }

        }

        //public TenderSubmission UpdateTenderSubmissionStatus(TenderSubmission tenderSubmission)
        //{
        //    try
        //    {
        //        meroBoleeDbContexts.TenderSubmissions.Update(tenderSubmission);
        //        unitOfWork.SaveChange();
        //        return tenderSubmission;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public TenderSubmission FindTenderSubmissionEntity(long companyId)
        //{
        //    try
        //    {
        //        return meroBoleeDbContexts.TenderSubmissions.Where(x => x.CompanyId == companyId).FirstOrDefault();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        /// <summary>
        /// Marketplace tender
        /// </summary>
        /// <param name="search"></param>
        /// <param name="procurementId"></param>
        /// <param name="algoId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TenderCard>> GetMarketplaceTender(string search, int? procurementId, int? algoId)
        {
            try
            {
                var timeNow = DateTimeNPT.Now;
                if (procurementId == null && algoId == null)
                {

                    return await (from t in meroBoleeDbContexts.TenderEntities
                                  join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                  join s in meroBoleeDbContexts.TenderStatus on t.StatusId equals s.StatusId
                                  where t.StatusId == 3 && t.IsDeleted == false && (search == null || t.Title.Contains(search)) && DateTime.Compare(t.RegistrationTill, DateTimeNPT.Now) > 0
                                  select new TenderCard
                                  {
                                      TenderId = t.Id,
                                      TenderCode = t.Code,
                                      TenderTitle = t.Title,
                                      CategoryId = c.Id,
                                      CategoryName = c.Category,
                                      LiveStartDate = t.LiveStartDate,
                                      LiveEndDate = t.LiveEndDate,
                                      RegistrationTill = t.RegistrationTill,
                                      Status = s.Status,
                                      Product = t.Product,
                                      Price = t.Price,
                                      Location = t.Location,
                                      DateOfExecution = t.DateOfExecution,
                                      DateCreated = t.Date_created,
                                      CompanyInfo = (from tc in meroBoleeDbContexts.CommunityApprovalEntities
                                                     where tc.TenderId == t.Id
                                                     select new CompanyInfo
                                                     {
                                                         Id = tc.CompanyId,
                                                         Name = tc.CompanyEntity.Name
                                                     }).ToList()
                                  }

                ).OrderByDescending(x => x.DateCreated).ToListAsync();
                }
                else if(procurementId!=null && algoId!=null)
                {
                    return await (from t in meroBoleeDbContexts.TenderEntities
                                  join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                  join s in meroBoleeDbContexts.TenderStatus on t.StatusId equals s.StatusId
                                  where t.StatusId == 3 && t.IsDeleted == false && (search == null || t.Title.Contains(search)) && DateTime.Compare(t.RegistrationTill, DateTimeNPT.Now) > 0
                                  && t.AlgoId == algoId && t.ProcurementId == procurementId
                                  select new TenderCard
                                  {
                                      TenderId = t.Id,
                                      TenderCode = t.Code,
                                      TenderTitle = t.Title,
                                      CategoryId = c.Id,
                                      CategoryName = c.Category,
                                      LiveStartDate = t.LiveStartDate,
                                      LiveEndDate = t.LiveEndDate,
                                      RegistrationTill = t.RegistrationTill,
                                      Status = s.Status,
                                      Product = t.Product,
                                      Price = t.Price,
                                      Location = t.Location,
                                      DateOfExecution = t.DateOfExecution,
                                      DateCreated = t.Date_created,
                                      CompanyInfo = (from tc in meroBoleeDbContexts.CommunityApprovalEntities
                                                     where tc.TenderId == t.Id
                                                     select new CompanyInfo
                                                     {
                                                         Id = tc.CompanyId,
                                                         Name = tc.CompanyEntity.Name
                                                     }).ToList()
                                  }

              ).OrderByDescending(x => x.DateCreated).ToListAsync();
                }
                else if (algoId != null)
                {
                    return await (from t in meroBoleeDbContexts.TenderEntities
                                  join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                  join s in meroBoleeDbContexts.TenderStatus on t.StatusId equals s.StatusId
                                  where t.StatusId == 3 && t.IsDeleted == false && (search == null || t.Title.Contains(search)) && DateTime.Compare(t.RegistrationTill, DateTimeNPT.Now) > 0
                                  && t.AlgoId == algoId
                                  select new TenderCard
                                  {
                                      TenderId = t.Id,
                                      TenderCode = t.Code,
                                      TenderTitle = t.Title,
                                      CategoryId = c.Id,
                                      CategoryName = c.Category,
                                      LiveStartDate = t.LiveStartDate,
                                      LiveEndDate = t.LiveEndDate,
                                      RegistrationTill = t.RegistrationTill,
                                      Status = s.Status,
                                      Product = t.Product,
                                      Price = t.Price,
                                      Location = t.Location,
                                      DateOfExecution = t.DateOfExecution,
                                      DateCreated = t.Date_created,
                                      CompanyInfo = (from tc in meroBoleeDbContexts.CommunityApprovalEntities
                                                     where tc.TenderId == t.Id
                                                     select new CompanyInfo
                                                     {
                                                         Id = tc.CompanyId,
                                                         Name = tc.CompanyEntity.Name
                                                     }).ToList()
                                  }

                ).OrderByDescending(x => x.DateCreated).ToListAsync();
                }
                else
                {
                    return await (from t in meroBoleeDbContexts.TenderEntities
                                  join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                  join s in meroBoleeDbContexts.TenderStatus on t.StatusId equals s.StatusId
                                  where t.StatusId == 3 && t.IsDeleted == false && (search == null || t.Title.Contains(search)) && DateTime.Compare(t.RegistrationTill, DateTimeNPT.Now) > 0
                                  && t.ProcurementId == procurementId
                                  select new TenderCard
                                  {
                                      TenderId = t.Id,
                                      TenderCode = t.Code,
                                      TenderTitle = t.Title,
                                      CategoryId = c.Id,
                                      CategoryName = c.Category,
                                      LiveStartDate = t.LiveStartDate,
                                      LiveEndDate = t.LiveEndDate,
                                      RegistrationTill = t.RegistrationTill,
                                      Status = s.Status,
                                      Product = t.Product,
                                      Price = t.Price,
                                      Location = t.Location,
                                      DateOfExecution = t.DateOfExecution,
                                      DateCreated = t.Date_created,
                                      CompanyInfo = (from tc in meroBoleeDbContexts.CommunityApprovalEntities
                                                     where tc.TenderId == t.Id
                                                     select new CompanyInfo
                                                     {
                                                         Id = tc.CompanyId,
                                                         Name = tc.CompanyEntity.Name
                                                     }).ToList()
                                  }

               ).OrderByDescending(x => x.DateCreated).ToListAsync();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<IEnumerable<TenderCard>> GetLiveBidMarketplaceTenderForAdmin(string search)
        {
            try
            {
                return await (from cm in meroBoleeDbContexts.CommunityApprovalEntities
                              join t in meroBoleeDbContexts.TenderEntities on cm.TenderId equals t.Id
                              join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                              join s in meroBoleeDbContexts.TenderStatus on t.StatusId equals s.StatusId
                              join c1 in meroBoleeDbContexts.CompanyEntities on cm.CompanyId equals c1.CompanyId
                              where
                              //((t.LiveStartDate >= DateTime.Now) && (t.LiveEndDate <= DateTime.Now)) 
                              ((DateTimeNPT.Now >= t.LiveStartDate) && (t.LiveEndDate <= DateTimeNPT.Now))
                              && t.IsDeleted == false && (search == null || t.Title.Contains(search))
                              select new TenderCard
                              {
                                  TenderId = t.Id,
                                  CompanyId = c1.CompanyId,
                                  CompanyName = c1.Name,
                                  TenderCode = t.Code,
                                  TenderTitle = t.Title,
                                  CategoryId = c.Id,
                                  CategoryName = c.Category,
                                  LiveStartDate = t.LiveStartDate,
                                  LiveEndDate = t.LiveEndDate,
                                  RegistrationTill = t.RegistrationTill,
                                  StatusId = 4,
                                  Status = "Live",
                                  Product = t.Product,
                                  DateOfExecution = t.DateOfExecution,
                                  DateCreated = t.Date_created

                              }

                ).OrderByDescending(x => x.DateCreated).ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// bid inivter tender history
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="search"></param>
        /// <param name="procurementId"></param>
        /// <param name="algoId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TenderCard>> GetBidIniviterTenderHistory(long companyId, string search, int? procurementId, int? algoId)
        {
            try
            {
                if (procurementId==null && algoId==null)
                {
                    return await (from cm in meroBoleeDbContexts.CommunityApprovalEntities
                                  join t in meroBoleeDbContexts.TenderEntities on cm.TenderId equals t.Id
                                  join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                  join s in meroBoleeDbContexts.TenderStatus on t.StatusId equals s.StatusId
                                  join c1 in meroBoleeDbContexts.CompanyEntities on cm.CompanyId equals c1.CompanyId
                                  where cm.CompanyId == companyId && t.StatusId == 3 && t.LiveEndDate < DateTimeNPT.Now && t.IsDeleted == false
                                              && (search == null || t.Title.Contains(search))
                                  select new TenderCard
                                  {
                                      TenderId = t.Id,
                                      CompanyId = c1.CompanyId,
                                      CompanyName = c1.Name,
                                      TenderCode = t.Code,
                                      TenderTitle = t.Title,
                                      CategoryId = c.Id,
                                      CategoryName = c.Category,
                                      LiveStartDate = t.LiveStartDate,
                                      LiveEndDate = t.LiveEndDate,
                                      RegistrationTill = t.RegistrationTill,
                                      StatusId = t.StatusId,
                                      Status = s.Status,
                                      Product = t.Product,
                                      DateOfExecution = t.DateOfExecution,
                                      DateCreated = t.Date_created,
                                      Price = t.Price,
                                      Location = t.Location,
                                      PostBidStatus = t.PostBidStatus
                                  }

                   ).OrderByDescending(x => x.DateCreated).ToListAsync();
                }
               else if(procurementId!=null && algoId!=null)
                {
                    return await (from cm in meroBoleeDbContexts.CommunityApprovalEntities
                                  join t in meroBoleeDbContexts.TenderEntities on cm.TenderId equals t.Id
                                  join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                  join s in meroBoleeDbContexts.TenderStatus on t.StatusId equals s.StatusId
                                  join c1 in meroBoleeDbContexts.CompanyEntities on cm.CompanyId equals c1.CompanyId
                                  where cm.CompanyId == companyId && t.StatusId == 3 && t.LiveEndDate < DateTimeNPT.Now && t.IsDeleted == false
                                              && (search == null || t.Title.Contains(search)) && t.ProcurementId==procurementId && t.AlgoId==algoId
                                  select new TenderCard
                                  {
                                      TenderId = t.Id,
                                      CompanyId = c1.CompanyId,
                                      CompanyName = c1.Name,
                                      TenderCode = t.Code,
                                      TenderTitle = t.Title,
                                      CategoryId = c.Id,
                                      CategoryName = c.Category,
                                      LiveStartDate = t.LiveStartDate,
                                      LiveEndDate = t.LiveEndDate,
                                      RegistrationTill = t.RegistrationTill,
                                      StatusId = t.StatusId,
                                      Status = s.Status,
                                      Product = t.Product,
                                      DateOfExecution = t.DateOfExecution,
                                      DateCreated = t.Date_created,
                                      Price = t.Price,
                                      Location = t.Location,
                                      PostBidStatus = t.PostBidStatus
                                  }

                   ).OrderByDescending(x => x.DateCreated).ToListAsync();
                }
                else if (procurementId!=null)
                {
                    return await (from cm in meroBoleeDbContexts.CommunityApprovalEntities
                                  join t in meroBoleeDbContexts.TenderEntities on cm.TenderId equals t.Id
                                  join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                  join s in meroBoleeDbContexts.TenderStatus on t.StatusId equals s.StatusId
                                  join c1 in meroBoleeDbContexts.CompanyEntities on cm.CompanyId equals c1.CompanyId
                                  where cm.CompanyId == companyId && t.StatusId == 3 && t.LiveEndDate < DateTimeNPT.Now && t.IsDeleted == false
                                              && (search == null || t.Title.Contains(search)) && t.ProcurementId==procurementId
                                  select new TenderCard
                                  {
                                      TenderId = t.Id,
                                      CompanyId = c1.CompanyId,
                                      CompanyName = c1.Name,
                                      TenderCode = t.Code,
                                      TenderTitle = t.Title,
                                      CategoryId = c.Id,
                                      CategoryName = c.Category,
                                      LiveStartDate = t.LiveStartDate,
                                      LiveEndDate = t.LiveEndDate,
                                      RegistrationTill = t.RegistrationTill,
                                      StatusId = t.StatusId,
                                      Status = s.Status,
                                      Product = t.Product,
                                      DateOfExecution = t.DateOfExecution,
                                      DateCreated = t.Date_created,
                                      Price = t.Price,
                                      Location = t.Location,
                                      PostBidStatus = t.PostBidStatus
                                  }

                   ).OrderByDescending(x => x.DateCreated).ToListAsync();
                }
                else
                {
                    return await (from cm in meroBoleeDbContexts.CommunityApprovalEntities
                                  join t in meroBoleeDbContexts.TenderEntities on cm.TenderId equals t.Id
                                  join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                  join s in meroBoleeDbContexts.TenderStatus on t.StatusId equals s.StatusId
                                  join c1 in meroBoleeDbContexts.CompanyEntities on cm.CompanyId equals c1.CompanyId
                                  where cm.CompanyId == companyId && t.StatusId == 3 && t.LiveEndDate < DateTimeNPT.Now && t.IsDeleted == false
                                              && (search == null || t.Title.Contains(search)) && t.AlgoId==algoId
                                  select new TenderCard
                                  {
                                      TenderId = t.Id,
                                      CompanyId = c1.CompanyId,
                                      CompanyName = c1.Name,
                                      TenderCode = t.Code,
                                      TenderTitle = t.Title,
                                      CategoryId = c.Id,
                                      CategoryName = c.Category,
                                      LiveStartDate = t.LiveStartDate,
                                      LiveEndDate = t.LiveEndDate,
                                      RegistrationTill = t.RegistrationTill,
                                      StatusId = t.StatusId,
                                      Status = s.Status,
                                      Product = t.Product,
                                      DateOfExecution = t.DateOfExecution,
                                      DateCreated = t.Date_created,
                                      Price = t.Price,
                                      Location = t.Location,
                                      PostBidStatus = t.PostBidStatus
                                  }

                   ).OrderByDescending(x => x.DateCreated).ToListAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }




        /// <summary>
        /// bid inivter tender active listing
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="procurementId"></param>
        /// <param name="algoId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TenderCard>> GetBidIniviterTenderListing(long companyId,int? procurementId, int? algoId)
        {
            try
            {
                if (procurementId!=null && algoId!=null)
                {
                    return await (from cm in meroBoleeDbContexts.CommunityApprovalEntities
                                  join t in meroBoleeDbContexts.TenderEntities on cm.TenderId equals t.Id
                                  join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                  join s in meroBoleeDbContexts.TenderStatus on t.StatusId equals s.StatusId
                                  join c1 in meroBoleeDbContexts.CompanyEntities on cm.CompanyId equals c1.CompanyId
                                  where cm.CompanyId == companyId /*&& t.StatusId != 3 */ && t.LiveEndDate > DateTimeNPT.Now && t.IsDeleted == false
                                  && t.ProcurementId==procurementId && t.AlgoId==algoId
                                  select new TenderCard
                                  {
                                      TenderId = t.Id,
                                      CompanyId = c1.CompanyId,
                                      CompanyName = c1.Name,
                                      TenderCode = t.Code,
                                      TenderTitle = t.Title,
                                      CategoryId = c.Id,
                                      CategoryName = c.Category,
                                      LiveStartDate = t.LiveStartDate,
                                      LiveEndDate = t.LiveEndDate,
                                      RegistrationTill = t.RegistrationTill,
                                      Status = s.Status,
                                      StatusId = cm.StatusId,
                                      Product = t.Product,
                                      DateOfExecution = t.DateOfExecution,
                                      DateCreated = t.Date_created,
                                      Price = t.Price,
                                      Location = t.Location
                                  }

                   ).OrderByDescending(x => x.DateCreated).ToListAsync();
                }
                else if (procurementId==null && algoId==null)
                {
                    return await (from cm in meroBoleeDbContexts.CommunityApprovalEntities
                                  join t in meroBoleeDbContexts.TenderEntities on cm.TenderId equals t.Id
                                  join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                  join s in meroBoleeDbContexts.TenderStatus on t.StatusId equals s.StatusId
                                  join c1 in meroBoleeDbContexts.CompanyEntities on cm.CompanyId equals c1.CompanyId
                                  where cm.CompanyId == companyId /*&& t.StatusId != 3 */ && t.LiveEndDate > DateTimeNPT.Now && t.IsDeleted == false
                                  select new TenderCard
                                  {
                                      TenderId = t.Id,
                                      CompanyId = c1.CompanyId,
                                      CompanyName = c1.Name,
                                      TenderCode = t.Code,
                                      TenderTitle = t.Title,
                                      CategoryId = c.Id,
                                      CategoryName = c.Category,
                                      LiveStartDate = t.LiveStartDate,
                                      LiveEndDate = t.LiveEndDate,
                                      RegistrationTill = t.RegistrationTill,
                                      Status = s.Status,
                                      StatusId = cm.StatusId,
                                      Product = t.Product,
                                      DateOfExecution = t.DateOfExecution,
                                      DateCreated = t.Date_created,
                                      Price = t.Price,
                                      Location = t.Location
                                  }

                    ).OrderByDescending(x => x.DateCreated).ToListAsync();
                }
                else if (procurementId!=null)
                {
                    return await (from cm in meroBoleeDbContexts.CommunityApprovalEntities
                                  join t in meroBoleeDbContexts.TenderEntities on cm.TenderId equals t.Id
                                  join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                  join s in meroBoleeDbContexts.TenderStatus on t.StatusId equals s.StatusId
                                  join c1 in meroBoleeDbContexts.CompanyEntities on cm.CompanyId equals c1.CompanyId
                                  where cm.CompanyId == companyId /*&& t.StatusId != 3 */ && t.LiveEndDate > DateTimeNPT.Now && t.IsDeleted == false
                                  && t.ProcurementId==procurementId
                                  select new TenderCard
                                  {
                                      TenderId = t.Id,
                                      CompanyId = c1.CompanyId,
                                      CompanyName = c1.Name,
                                      TenderCode = t.Code,
                                      TenderTitle = t.Title,
                                      CategoryId = c.Id,
                                      CategoryName = c.Category,
                                      LiveStartDate = t.LiveStartDate,
                                      LiveEndDate = t.LiveEndDate,
                                      RegistrationTill = t.RegistrationTill,
                                      Status = s.Status,
                                      StatusId = cm.StatusId,
                                      Product = t.Product,
                                      DateOfExecution = t.DateOfExecution,
                                      DateCreated = t.Date_created,
                                      Price = t.Price,
                                      Location = t.Location
                                  }

                   ).OrderByDescending(x => x.DateCreated).ToListAsync();
                }
                else
                {
                    return await (from cm in meroBoleeDbContexts.CommunityApprovalEntities
                                  join t in meroBoleeDbContexts.TenderEntities on cm.TenderId equals t.Id
                                  join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                  join s in meroBoleeDbContexts.TenderStatus on t.StatusId equals s.StatusId
                                  join c1 in meroBoleeDbContexts.CompanyEntities on cm.CompanyId equals c1.CompanyId
                                  where cm.CompanyId == companyId /*&& t.StatusId != 3 */ && t.LiveEndDate > DateTimeNPT.Now && t.IsDeleted == false
                                  && t.AlgoId==algoId
                                  select new TenderCard
                                  {
                                      TenderId = t.Id,
                                      CompanyId = c1.CompanyId,
                                      CompanyName = c1.Name,
                                      TenderCode = t.Code,
                                      TenderTitle = t.Title,
                                      CategoryId = c.Id,
                                      CategoryName = c.Category,
                                      LiveStartDate = t.LiveStartDate,
                                      LiveEndDate = t.LiveEndDate,
                                      RegistrationTill = t.RegistrationTill,
                                      Status = s.Status,
                                      StatusId = cm.StatusId,
                                      Product = t.Product,
                                      DateOfExecution = t.DateOfExecution,
                                      DateCreated = t.Date_created,
                                      Price = t.Price,
                                      Location = t.Location
                                  }

                   ).OrderByDescending(x => x.DateCreated).ToListAsync();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// get tender detail
        /// </summary>
        /// <param name="tenderId"></param>
        /// <returns></returns>
        public async Task<TenderEntity> GetTenderDetail(long tenderId)
        {
            try
            {
                TenderEntity ent = await meroBoleeDbContexts.TenderEntities
                    .Where(m => m.Id == tenderId)
                    .Include(x => x.TenderMaterialEntities)
                    //.Include(x => x.TenderCards)
                    //.Include(x => x.ExtraDocuments)
                    .Include(x => x.CategoryEntity)
                    .Include(x => x.CreatedByUser)
                    .Include(x => x.TenderStatusEntity)
                    .Include(x => x.Company)
                    .FirstOrDefaultAsync();
                ent.ExtraDocuments = await meroBoleeDbContexts.TenderExtraDocuments.Where(x => x.TenderId == tenderId).ToListAsync();

                return ent;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CommunityApprovalEntity> GetTenderDetailBidInviterStatus(long tenderId,long copmanyId)
        {
            try
            {
                CommunityApprovalEntity ent = await meroBoleeDbContexts.CommunityApprovalEntities
                    .Where(m => m.TenderId == tenderId && m.CompanyId == copmanyId)
                    .Include(x=>x.TenderEntities)
                    .ThenInclude(x => x.TenderMaterialEntities)
                    //.Include(x => x.TenderCards)
                    //.Include(x => x.ExtraDocuments)
                    .Include(x => x.CategoryEntity)
                    .Include(x => x.TenderStatusEntity)
                    .FirstOrDefaultAsync();
                ent.TenderEntities.ExtraDocuments = await meroBoleeDbContexts.TenderExtraDocuments.Where(x => x.TenderId == tenderId).ToListAsync();

                return ent;

            }
            catch (Exception)
            {
                throw;
            }
        }

        // public async Task<TenderEntity> GetTenderDetailForApproval(long tenderId, string userRole)
        // {
        //     try
        //     {
        //         TenderEntity ent = await meroBoleeDbContexts.TenderEntities
        //             .Where(m => m.Id == tenderId)
        //             .Include(x => x.TenderMaterialEntities)
        //             //.Include(x => x.TenderCards)
        //             //.Include(x => x.ExtraDocuments)
        //             .Include(x => x.CategoryEntity)
        //             .Include(x => x.CreatedByUser)
        //             .Include(x => x.TenderStatusEntity)
        //             .Include(x => x.Company)
        //             .FirstOrDefaultAsync();
        //         ent.ExtraDocuments = await meroBoleeDbContexts.TenderExtraDocuments.Where(x => x.TenderId == tenderId).ToListAsync();
        //         if(!(userRole.Equals("Bid Inviter") || userRole.Equals("Bidder")))
        //         {
        //             var list= (from c in meroBoleeDbContexts.CommunityApprovalEntities
        //                        where c.TenderId==tenderId
        //                        select c.StatusId).ToList();
        //             foreach (var item in list)
        //             {
        //                 if(item!=3)
        //                 {
        //                     return ent;
        //                 } 
        //             }
        //             ent.StatusId = 3;
        //         }
        //         return ent;
        //
        //     }
        //     catch (Exception)
        //     {
        //         throw;
        //     }
        // }

        public async Task<TenderEntity> FindTenderToUpdate(long tenderId)
        {
            try
            {
                TenderEntity ent = await meroBoleeDbContexts.TenderEntities
                    .Where(m => m.Id == tenderId).FirstOrDefaultAsync();
                return ent;
            }
             catch (Exception)
            {
                throw;
            }
        }

        public async Task<TenderEntity> GetTenderDetailNew(long tenderId)
        {
            try
            {
                //TenderEntity ent = new TenderEntity();
                TenderEntity ent = await meroBoleeDbContexts.TenderEntities
                    .Where(m => m.Id == tenderId)
                    .Include(x => x.CategoryEntity)
                    .Include(x => x.CreatedByUser)
                    .Include(x => x.TenderStatusEntity)
                    .Include(x => x.Company)
                    .FirstOrDefaultAsync();
                ent.TenderTermsConditionEntities = await meroBoleeDbContexts.TenderTermsConditionEntities.Where(x => x.TenderId == tenderId).FirstOrDefaultAsync();
                ent.TenderMaterialEntities = await meroBoleeDbContexts.TenderMaterialEntities.Where(x => x.TenderId == tenderId).ToListAsync();
                //  ent.TenderCards = await meroBoleeDbContexts.TenderCards.Where(x => x.TenderId == tenderId).ToListAsync();
                ent.ExtraDocuments = await meroBoleeDbContexts.TenderExtraDocuments.Where(x => x.TenderId == tenderId).ToListAsync();
                ent.Feedbacks = await GetTenderCardFeedback(tenderId);
                ent.AuctionLogs = await meroBoleeDbContexts.AuctionLogs.Where(x => x.TenderId == tenderId).ToListAsync();
                ent.BiddingHistories = await meroBoleeDbContexts.BiddingHistoryEntities.Where(x => x.TenderId == tenderId).ToListAsync();
                ent.BidRequests = await meroBoleeDbContexts.BidRequestEntities.Where(x => x.TenderId == tenderId).ToListAsync();
                ent.LiveBiddings = await meroBoleeDbContexts.LiveBiddingEntities.Where(x => x.TenderId == tenderId).ToListAsync();
                return ent;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<TenderEntity> GetTenderEntityOnly(long tenderId)
        {
            try
            {
                return await meroBoleeDbContexts.TenderEntities
                    .Include(x => x.ExtraDocuments)
                    .Include(x => x.TenderMaterialEntities)
                    //.Include(x => x.TenderCards)
                    .Where(x => x.Id == tenderId)
                    .FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CommunityApprovalEntity> GetTenderEntityOfCompany(long tenderId,long companyId)
        {
            try
            {

                return await (from c in meroBoleeDbContexts.CommunityApprovalEntities
                              join t in meroBoleeDbContexts.TenderEntities on c.TenderId equals t.Id
                              //join e in meroBoleeDbContexts.TenderExtraDocuments on t.Id equals e.TenderId
                              //join m in meroBoleeDbContexts.TenderMaterialEntities on t.Id equals m.TenderId
                              where c.TenderId == tenderId && c.CompanyId == companyId 
                              select c).FirstOrDefaultAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> CheckStatusInCommunityApproval(long tenderId)
        {
            try
            {

                var statusList = await meroBoleeDbContexts.CommunityApprovalEntities.Where(x=>x.TenderId==tenderId).Select(x=>x.StatusId).ToListAsync();
                foreach (var item in statusList)
                {
                    if (item != 3) return false;
                }
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<TenderEntity> GetTenderEntityOnly(long tenderId, long companyId)
        {
            try
            {
                return await (from br in meroBoleeDbContexts.BidRequestEntities
                              join t in meroBoleeDbContexts.TenderEntities on br.TenderId equals t.Id
                              where br.CompanyId == companyId && br.TenderId == tenderId
                              select t
                             ).FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// upcoming tender within 7 days
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="isAlert"></param>
        /// <param name="isLiveBidUpcoming"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TenderCard>> UpcomingBidderTender(long companyId, bool isAlert, bool isLiveBidUpcoming)
        {
            try
            {
                if (isAlert && isLiveBidUpcoming)
                {
                    return await (from bd in meroBoleeDbContexts.BidRequestEntities
                                  join t in meroBoleeDbContexts.TenderEntities on bd.TenderId equals t.Id
                                  join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                  join ts in meroBoleeDbContexts.TenderStatus on t.StatusId equals ts.StatusId
                                  join c1 in meroBoleeDbContexts.CompanyEntities on bd.CompanyId equals c1.CompanyId
                                  where bd.CompanyId == companyId
                                        && t.IsDeleted == false
                                        && t.StatusId == 3 //Tender should be approved
                                        && bd.BidRequestStatusId == 2 //Bid request should be approved
                                        && (t.LiveStartDate.AddDays(-3) <= DateTimeNPT.Now)//Tender live date should be within next 7 days
                                        && (t.LiveEndDate >= DateTimeNPT.Now)//Tender live end date should be future date
                                  select new TenderCard
                                  {
                                      TenderId = t.Id,
                                      CompanyId = c1.CompanyId,
                                      CompanyName = c1.Name,
                                      TenderCode = t.Code,
                                      TenderTitle = t.Title,
                                      CategoryId = c.Id,
                                      CategoryName = c.Category,
                                      LiveStartDate = t.LiveStartDate,
                                      LiveEndDate = t.LiveEndDate,
                                      RegistrationTill = t.RegistrationTill,
                                      StatusId = t.StatusId,
                                      Status = ts.Status,
                                      Product = t.Product,
                                      DateOfExecution = t.DateOfExecution,
                                      DateCreated = t.Date_created,
                                      Price = t.Price,
                                      Location = t.Location

                                      //CardInfo = (from tc in meroBoleeDbContexts.TenderCards
                                      //            where tc.TenderId == t.Id
                                      //            select new TenderCardInfo
                                      //            {
                                      //                Id = tc.Id,
                                      //                Label = tc.Label,
                                      //                Value = tc.Value
                                      //            }).ToList()
                                  }).OrderBy(x => x.LiveStartDate).ToListAsync();
                }
                else if(isAlert && !isLiveBidUpcoming) 
                {
                     return await (from bd in meroBoleeDbContexts.BidRequestEntities
                                  join t in meroBoleeDbContexts.TenderEntities on bd.TenderId equals t.Id
                                  join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                  join ts in meroBoleeDbContexts.TenderStatus on t.StatusId equals ts.StatusId
                                  join c1 in meroBoleeDbContexts.CompanyEntities on bd.CompanyId equals c1.CompanyId
                                  where bd.CompanyId == companyId
                                        && t.IsDeleted == false
                                        && t.StatusId == 3 //Tender should be approved
                                        && bd.BidRequestStatusId == 2 //Bid request should be approved
                                        && (t.RegistrationTill >= DateTimeNPT.Now)//Tender live date should be within next 7 days
                                        && (t.LiveEndDate >= DateTimeNPT.Now)//Tender live end date should be future date
                                  select new TenderCard
                                  {
                                      TenderId = t.Id,
                                      CompanyId = c1.CompanyId,
                                      CompanyName = c1.Name,
                                      TenderCode = t.Code,
                                      TenderTitle = t.Title,
                                      CategoryId = c.Id,
                                      CategoryName = c.Category,
                                      LiveStartDate = t.LiveStartDate,
                                      LiveEndDate = t.LiveEndDate,
                                      RegistrationTill = t.RegistrationTill,
                                      StatusId = t.StatusId,
                                      Status = ts.Status,
                                      Product = t.Product,
                                      DateOfExecution = t.DateOfExecution,
                                      DateCreated = t.Date_created,
                                      Price = t.Price,
                                      Location = t.Location

                                      //CardInfo = (from tc in meroBoleeDbContexts.TenderCards
                                      //            where tc.TenderId == t.Id
                                      //            select new TenderCardInfo
                                      //            {
                                      //                Id = tc.Id,
                                      //                Label = tc.Label,
                                      //                Value = tc.Value
                                      //            }).ToList()
                                  }).OrderBy(x => x.LiveStartDate).ToListAsync();
                }
                else
                {
                    return await (from bd in meroBoleeDbContexts.BidRequestEntities
                                  join t in meroBoleeDbContexts.TenderEntities on bd.TenderId equals t.Id
                                  join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                  join ts in meroBoleeDbContexts.TenderStatus on t.StatusId equals ts.StatusId
                                  join c1 in meroBoleeDbContexts.CompanyEntities on bd.CompanyId equals c1.CompanyId
                                  where bd.CompanyId == companyId
                                        && t.StatusId == 3 //Tender should be approved
                                        && t.IsDeleted == false
                                        && DateTime.Compare(t.LiveEndDate, DateTimeNPT.Now) > 0
                                  select new TenderCard
                                  {
                                      TenderId = t.Id,
                                      CompanyId = c1.CompanyId,
                                      CompanyName = c1.Name,
                                      TenderCode = t.Code,
                                      TenderTitle = t.Title,
                                      CategoryId = c.Id,
                                      CategoryName = c.Category,
                                      LiveStartDate = t.LiveStartDate,
                                      LiveEndDate = t.LiveEndDate,
                                      RegistrationTill = t.RegistrationTill,
                                      StatusId = t.StatusId,
                                      Status = ts.Status,
                                      Product = t.Product,
                                      DateOfExecution = t.DateOfExecution,
                                      DateCreated = t.Date_created,
                                      Price = t.Price,
                                      Location = t.Location
                                      //CardInfo = (from tc in meroBoleeDbContexts.TenderCards
                                      //            where tc.TenderId == t.Id
                                      //            select new TenderCardInfo
                                      //            {
                                      //                Id = tc.Id,
                                      //                Label = tc.Label,
                                      //                Value = tc.Value
                                      //            }).ToList()
                                  }).OrderByDescending(x => x.DateCreated).ToListAsync();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// upcoming tender within 7 days for bid inviter
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="procurementId"></param>
        /// <param name="algoId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TenderCard>> UpcomingBidInviterTender(long companyId, int? procurementId, int? algoId)

        {
            try
            {
                if (procurementId==null && algoId==null)
                {
                    return await (from cm in meroBoleeDbContexts.CommunityApprovalEntities
                                  join t in meroBoleeDbContexts.TenderEntities on cm.TenderId equals t.Id
                                  join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                  join ts in meroBoleeDbContexts.TenderStatus on t.StatusId equals ts.StatusId
                                  join c1 in meroBoleeDbContexts.CompanyEntities on cm.CompanyId equals c1.CompanyId
                                  where cm.CompanyId == companyId
                                        && t.IsDeleted == false
                                        && t.StatusId == 3 //Tender should be approved
                                        && (t.LiveStartDate.AddDays(-3) <= DateTimeNPT.Now)
                                        && (t.LiveEndDate >= DateTimeNPT.Now) //Tender live date should be within next 7 days
                                  select new TenderCard
                                  {
                                      TenderId = t.Id,
                                      CompanyId = c1.CompanyId,
                                      CompanyName = c1.Name,
                                      TenderCode = t.Code,
                                      TenderTitle = t.Title,
                                      CategoryId = c.Id,
                                      CategoryName = c.Category,
                                      LiveStartDate = t.LiveStartDate,
                                      LiveEndDate = t.LiveEndDate,
                                      RegistrationTill = t.RegistrationTill,
                                      StatusId = t.StatusId,
                                      Status = ts.Status,
                                      Product = t.Product,
                                      DateOfExecution = t.DateOfExecution,
                                      DateCreated = t.Date_created,
                                      Price = t.Price,
                                      Location = t.Location
                                  }).OrderBy(x => x.LiveStartDate).ToListAsync();
                }
                else if (procurementId!=null && algoId != null)
                {
                    return await (from cm in meroBoleeDbContexts.CommunityApprovalEntities
                                  join t in meroBoleeDbContexts.TenderEntities on cm.TenderId equals t.Id
                                  join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                  join ts in meroBoleeDbContexts.TenderStatus on t.StatusId equals ts.StatusId
                                  join c1 in meroBoleeDbContexts.CompanyEntities on cm.CompanyId equals c1.CompanyId
                                  where cm.CompanyId == companyId
                                        && t.IsDeleted == false
                                        && t.StatusId == 3 //Tender should be approved
                                        && (t.LiveStartDate.AddDays(-3) <= DateTimeNPT.Now)
                                        && (t.LiveEndDate >= DateTimeNPT.Now) //Tender live date should be within next 7 days
                                        && t.ProcurementId==procurementId && t.AlgoId==algoId
                                  select new TenderCard
                                  {
                                      TenderId = t.Id,
                                      CompanyId = c1.CompanyId,
                                      CompanyName = c1.Name,
                                      TenderCode = t.Code,
                                      TenderTitle = t.Title,
                                      CategoryId = c.Id,
                                      CategoryName = c.Category,
                                      LiveStartDate = t.LiveStartDate,
                                      LiveEndDate = t.LiveEndDate,
                                      RegistrationTill = t.RegistrationTill,
                                      StatusId = t.StatusId,
                                      Status = ts.Status,
                                      Product = t.Product,
                                      DateOfExecution = t.DateOfExecution,
                                      DateCreated = t.Date_created,
                                      Price = t.Price,
                                      Location = t.Location
                                  }).OrderBy(x => x.LiveStartDate).ToListAsync();
                }
                else if (procurementId!=null)
                {
                    return await (from cm in meroBoleeDbContexts.CommunityApprovalEntities
                                  join t in meroBoleeDbContexts.TenderEntities on cm.TenderId equals t.Id
                                  join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                  join ts in meroBoleeDbContexts.TenderStatus on t.StatusId equals ts.StatusId
                                  join c1 in meroBoleeDbContexts.CompanyEntities on cm.CompanyId equals c1.CompanyId
                                  where cm.CompanyId == companyId
                                        && t.IsDeleted == false
                                        && t.StatusId == 3 //Tender should be approved
                                        && (t.LiveStartDate.AddDays(-3) <= DateTimeNPT.Now)
                                        && (t.LiveEndDate >= DateTimeNPT.Now) //Tender live date should be within next 7 days
                                        && t.ProcurementId==procurementId
                                  select new TenderCard
                                  {
                                      TenderId = t.Id,
                                      CompanyId = c1.CompanyId,
                                      CompanyName = c1.Name,
                                      TenderCode = t.Code,
                                      TenderTitle = t.Title,
                                      CategoryId = c.Id,
                                      CategoryName = c.Category,
                                      LiveStartDate = t.LiveStartDate,
                                      LiveEndDate = t.LiveEndDate,
                                      RegistrationTill = t.RegistrationTill,
                                      StatusId = t.StatusId,
                                      Status = ts.Status,
                                      Product = t.Product,
                                      DateOfExecution = t.DateOfExecution,
                                      DateCreated = t.Date_created,
                                      Price = t.Price,
                                      Location = t.Location
                                  }).OrderBy(x => x.LiveStartDate).ToListAsync();
                }
                else
                {
                    return await (from cm in meroBoleeDbContexts.CommunityApprovalEntities
                                  join t in meroBoleeDbContexts.TenderEntities on cm.TenderId equals t.Id
                                  join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                  join ts in meroBoleeDbContexts.TenderStatus on t.StatusId equals ts.StatusId
                                  join c1 in meroBoleeDbContexts.CompanyEntities on cm.CompanyId equals c1.CompanyId
                                  where cm.CompanyId == companyId
                                        && t.IsDeleted == false
                                        && t.StatusId == 3 //Tender should be approved
                                        && (t.LiveStartDate.AddDays(-3) <= DateTimeNPT.Now)
                                        && (t.LiveEndDate >= DateTimeNPT.Now) //Tender live date should be within next 7 days
                                        && t.AlgoId==algoId
                                  select new TenderCard
                                  {
                                      TenderId = t.Id,
                                      CompanyId = c1.CompanyId,
                                      CompanyName = c1.Name,
                                      TenderCode = t.Code,
                                      TenderTitle = t.Title,
                                      CategoryId = c.Id,
                                      CategoryName = c.Category,
                                      LiveStartDate = t.LiveStartDate,
                                      LiveEndDate = t.LiveEndDate,
                                      RegistrationTill = t.RegistrationTill,
                                      StatusId = t.StatusId,
                                      Status = ts.Status,
                                      Product = t.Product,
                                      DateOfExecution = t.DateOfExecution,
                                      DateCreated = t.Date_created,
                                      Price = t.Price,
                                      Location = t.Location
                                  }).OrderBy(x => x.LiveStartDate).ToListAsync();
                }
               


            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<TenderCard>> UpcomingTenderForAdmin()

        {
            try
            {
                return await (from t in meroBoleeDbContexts.TenderEntities 
                              join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                              join ts in meroBoleeDbContexts.TenderStatus on t.StatusId equals ts.StatusId
                              where t.IsDeleted == false
                                    && t.StatusId == 3 //Tender should be approved
                                                       // && (t.LiveEndDate <= DateTime.Now.AddDays(3))
                                    && (t.LiveStartDate.AddDays(-7) <= DateTimeNPT.Now)//Tender live date should be within next 7 days
                                        && (t.LiveEndDate >= DateTimeNPT.Now)//Tender live end date should be future date

                              select new TenderCard
                              {
                                  TenderId = t.Id,
                                  TenderCode = t.Code,
                                  TenderTitle = t.Title,
                                  CategoryId = c.Id,
                                  CategoryName = c.Category,
                                  LiveStartDate = t.LiveStartDate,
                                  LiveEndDate = t.LiveEndDate,
                                  RegistrationTill = t.RegistrationTill,
                                  StatusId = t.StatusId,
                                  Status = ts.Status,
                                  Product = t.Product,
                                  DateOfExecution = t.DateOfExecution,
                                  DateCreated = t.Date_created,
                                  Price = t.Price,
                                  Location = t.Location,
                                  CompanyInfo = (from tc in meroBoleeDbContexts.CommunityApprovalEntities
                                                 where tc.TenderId == t.Id
                                                 select new CompanyInfo
                                                 {
                                                     Id = tc.CompanyId,
                                                     Name = tc.CompanyEntity.Name
                                                 }).ToList()
                              }).OrderByDescending(x => x.DateCreated).ToListAsync();


            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// upcoming tender within 7 days for bid inviter
        /// </summary>
        /// <param name="companyId"></param>
        ///   /// <param name="statusId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TenderCard>> CompanyTendersForAdmin(int statusId, long? companyId)

        {
            try
            {
                if (statusId == 4 || statusId == 5)
                {
                    if (statusId == 4)
                    {
                        return await (from  t in meroBoleeDbContexts.TenderEntities 
                                      join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                      join ts in meroBoleeDbContexts.TenderStatus on t.StatusId equals ts.StatusId
                                      //join c1 in meroBoleeDbContexts.CompanyEntities on cm.CompanyId equals c1.CompanyId
                                      where t.IsDeleted == false && DateTime.Compare(DateTimeNPT.Now, t.LiveEndDate) < 0 && t.StatusId == 3
                                      //(GETDATE()>=LiveStartDate) and (LiveEndDate >= GETDATE())
                                      select new TenderCard
                                      {
                                          TenderId = t.Id,
                                          //CompanyId = c1.CompanyId,
                                          //CompanyName = c1.Name,
                                          TenderCode = t.Code,
                                          TenderTitle = t.Title,
                                          CategoryId = c.Id,
                                          CategoryName = c.Category,
                                          LiveStartDate = t.LiveStartDate,
                                          LiveEndDate = t.LiveEndDate,
                                          RegistrationTill = t.RegistrationTill,
                                          StatusId = 4,
                                          Status = "Live",
                                          // StatusId = ((t.LiveStartDate >= DateTime.Now) && (t.LiveEndDate <= DateTime.Now)) ? 4 : t.StatusId,
                                          // Status = ((t.LiveStartDate >= DateTime.Now) && (t.LiveEndDate <= DateTime.Now)) ? "Live" : ts.Status,
                                          Product = t.Product,
                                          DateOfExecution = t.DateOfExecution,
                                          DateCreated = t.Date_created,
                                          CompanyInfo = (from tc in meroBoleeDbContexts.CommunityApprovalEntities
                                                         where tc.TenderId == t.Id
                                                         select new CompanyInfo
                                                         {
                                                             Id = tc.CompanyId,
                                                             Name = tc.CompanyEntity.Name
                                                         }).ToList()
                                      }).OrderByDescending(x => x.DateCreated)
                                                          .ToListAsync();
                    }
                    else
                    {
                        return await (from  t in meroBoleeDbContexts.TenderEntities 
                                      join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                      join ts in meroBoleeDbContexts.TenderStatus on t.StatusId equals ts.StatusId
                                      //join c1 in meroBoleeDbContexts.CompanyEntities on cm.CompanyId equals c1.CompanyId
                                      where t.IsDeleted == false && (t.LiveEndDate < DateTimeNPT.Now) && t.StatusId == 3
                                      select new TenderCard
                                      {
                                          TenderId = t.Id,
                                          //CompanyId = c1.CompanyId,
                                          //CompanyName = c1.Name,
                                          TenderCode = t.Code,
                                          TenderTitle = t.Title,
                                          CategoryId = c.Id,
                                          CategoryName = c.Category,
                                          LiveStartDate = t.LiveStartDate,
                                          LiveEndDate = t.LiveEndDate,
                                          RegistrationTill = t.RegistrationTill,
                                          StatusId = 5,
                                          Status = "Completed",
                                          CompanyInfo = (from tc in meroBoleeDbContexts.CommunityApprovalEntities
                                                         where tc.TenderId == t.Id
                                                         select new CompanyInfo
                                                         {
                                                             Id = tc.CompanyId,
                                                             Name = tc.CompanyEntity.Name
                                                         }).ToList(),
                                          Product = t.Product,
                                          DateOfExecution = t.DateOfExecution,
                                          DateCreated = t.Date_created
                                      }).OrderByDescending(x => x.DateCreated)
                                                     .ToListAsync();
                    }
                }
                else
                {
                    if (companyId.HasValue)
                    {
                        return await (from cm in meroBoleeDbContexts.CommunityApprovalEntities
                                      join t in meroBoleeDbContexts.TenderEntities on cm.TenderId equals t.Id
                                      join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                      join ts in meroBoleeDbContexts.TenderStatus on cm.StatusId equals ts.StatusId
                                      join c1 in meroBoleeDbContexts.CompanyEntities on cm.CompanyId equals c1.CompanyId
                                      where cm.CompanyId == companyId.Value && t.IsDeleted == false && t.StatusId == statusId
                                      select new TenderCard
                                      {
                                          TenderId = t.Id,
                                          CompanyId = c1.CompanyId,
                                          CompanyName = c1.Name,
                                          TenderCode = t.Code,
                                          TenderTitle = t.Title,
                                          CategoryId = c.Id,
                                          CategoryName = c.Category,
                                          LiveStartDate = t.LiveStartDate,
                                          LiveEndDate = t.LiveEndDate,
                                          RegistrationTill = t.RegistrationTill,
                                          //StatusId = ((t.LiveStartDate >= DateTime.Now) && (t.LiveEndDate <= DateTime.Now)) ? 4 : t.StatusId,
                                          //Status = ((t.LiveStartDate >= DateTime.Now) && (t.LiveEndDate <= DateTime.Now)) ? "Live" : ts.Status,
                                          StatusId = cm.StatusId,
                                          Status = ts.Status,
                                          Product = t.Product,
                                          DateOfExecution = t.DateOfExecution,
                                          DateCreated = t.Date_created
                                          //CardInfo = (from tc in meroBoleeDbContexts.TenderCards
                                          //            where tc.TenderId == t.Id
                                          //            select new TenderCardInfo
                                          //            {
                                          //                Id = tc.Id,
                                          //                Label = tc.Label,
                                          //                Value = tc.Value
                                          //            }).ToList()
                                      }).OrderByDescending(x => x.DateCreated)
                                      .ToListAsync();
                    }
                    else
                    {
                        return await (from t in meroBoleeDbContexts.TenderEntities
                                         join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                         join ts in meroBoleeDbContexts.TenderStatus on t.StatusId equals ts.StatusId
                                         //join c1 in meroBoleeDbContexts.CompanyEntities on cm.CompanyId equals c1.CompanyId
                                         where t.IsDeleted == false && t.StatusId == statusId

                                         select new TenderCard
                                         {
                                             TenderId = t.Id,
                                             //CompanyId = c1.CompanyId,
                                             //CompanyName = c1.Name,
                                             CompanyInfo = (from tc in meroBoleeDbContexts.CommunityApprovalEntities
                                                             where tc.TenderId == t.Id
                                                             select new CompanyInfo
                                                             {
                                                                 Id = tc.CompanyId,
                                                                 Name = tc.CompanyEntity.Name
                                                             }).ToList(),
                                             TenderCode = t.Code,
                                             TenderTitle = t.Title,
                                             CategoryId = c.Id,
                                             CategoryName = c.Category,
                                             LiveStartDate = t.LiveStartDate,
                                             LiveEndDate = t.LiveEndDate,
                                             RegistrationTill = t.RegistrationTill,
                                             StatusId = t.CommunityApprovalStatus,
                                             Status = ts.Status,
                                             //StatusId = ((t.LiveStartDate >= DateTime.Now) && (t.LiveEndDate <= DateTime.Now)) ? 4 : t.StatusId,
                                             //Status = ((t.LiveStartDate >= DateTime.Now) && (t.LiveEndDate <= DateTime.Now)) ? "Live" : ts.Status,
                                             Product = t.Product,
                                             DateOfExecution = t.DateOfExecution,
                                             DateCreated = t.Date_created
                                             //CardInfo = (from tc in meroBoleeDbContexts.TenderCards
                                             //            where tc.TenderId == t.Id
                                             //            select new TenderCardInfo
                                             //            {
                                             //                Id = tc.Id,
                                             //                Label = tc.Label,
                                             //                Value = tc.Value
                                             //            }).ToList()
                                         }) .OrderByDescending(x => x.DateCreated)
                                      .ToListAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// update tender
        /// </summary>
        /// <param name="tenderEntity"></param>
        /// <returns></returns>
        public async Task<TenderEntity> UpdateTender(TenderEntity tenderEntity)
        {
            try
            {
                meroBoleeDbContexts.TenderEntities.Update(tenderEntity);
                await unitOfWork.SaveChangesAsync();

                tenderEntity.TenderStatusEntity = meroBoleeDbContexts.TenderStatus.Where(x => x.StatusId == tenderEntity.StatusId).FirstOrDefault();
                tenderEntity.TenderTermsConditionEntities = meroBoleeDbContexts.TenderTermsConditionEntities.Where(x => x.TenderId == tenderEntity.Id).FirstOrDefault();
                tenderEntity.TenderMaterialEntities = meroBoleeDbContexts.TenderMaterialEntities.Where(x => x.TenderId == tenderEntity.Id).ToList();
                tenderEntity.CategoryEntity = meroBoleeDbContexts.CategoryEntities.Where(x => x.Id == tenderEntity.CategoryId).FirstOrDefault();
                tenderEntity.ApprovedByUser = meroBoleeDbContexts.UserEntities.Where(x => x.Id == tenderEntity.ApprovedBy).FirstOrDefault();
                tenderEntity.CreatedByUser = meroBoleeDbContexts.UserEntities.Where(x => x.Id == tenderEntity.CreatedBy).FirstOrDefault();

                return tenderEntity;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public async Task<TenderEntity> UpdateTenderStatus(TenderEntity tenderEntity)
        {
            try
            {
                meroBoleeDbContexts.TenderEntities.Update(tenderEntity);
                await unitOfWork.SaveChangesAsync();

                return tenderEntity;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public async Task<IEnumerable<CommunityApprovalDto>> FindCommunityApprovalEntityByTenderId(long tenderId)
        {
            try
            {
                return await (from ca in meroBoleeDbContexts.CommunityApprovalEntities
                              join c in meroBoleeDbContexts.CompanyEntities on ca.CompanyId equals c.CompanyId
                              join s in meroBoleeDbContexts.TenderStatus on ca.StatusId equals s.StatusId
                              where ca.TenderId == tenderId
                              select new CommunityApprovalDto
                              {
                                  CompanyId = ca.CompanyId,
                                  CompanyName = c.Name,
                                  Status = s.Status,
                                  StatusId=ca.StatusId
                              }).ToListAsync();
            }
            catch 
            {
                throw ;
            }

        }

        public async Task<List<TenderExtraDocumentEntity>> AddTenderDocuments(List<TenderExtraDocumentEntity> entities)
        {
            try
            {
                await meroBoleeDbContexts.TenderExtraDocuments.AddRangeAsync(entities);
                await unitOfWork.SaveChangesAsync();
                return entities;
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Get a tender id from a tender code
        /// </summary>
        /// <param name="tenderCode">Unique tender code of a tender</param>
        /// <returns><see cref="Tuple{T1, T2}"/></returns>
        public Tuple<long, List<long>> GetTenderIdFromCode(string tenderCode)
        {
            Tuple<long, long> tenderInfo = (from cm in meroBoleeDbContexts.CommunityApprovalEntities
                                            join t in meroBoleeDbContexts.TenderEntities on cm.TenderId equals t.Id
                                            where t.Code == tenderCode
                                            select Tuple.Create(t.Id,(long)cm.CompanyId)
                                           ).FirstOrDefault();

            List<long> userIds = (from c in meroBoleeDbContexts.CompanyEntities
                                  join uc in meroBoleeDbContexts.UserCompanies on c.CompanyId equals uc.CompanyId
                                  where c.CompanyId == tenderInfo.Item2
                                  select uc.UserId
             ).ToList();

            //Tuple<long, long> tender_User = (from t in meroBoleeDbContexts.TenderEntities
            //                                 join c in meroBoleeDbContexts.CompanyEntities on t.CompanyId equals c.CompanyId
            //                                 join uc in meroBoleeDbContexts.UserCompanies on c.CompanyId equals uc.CompanyId
            //                                 join u in meroBoleeDbContexts.UserEntities on uc.UserId equals u.User_Id
            //                                 where t.Tender_Code == tenderCode && u.IsEmailReceiver == true
            //                                 select Tuple.Create(t.Tender_Id, u.User_Id)
            //                                ).FirstOrDefault();
            return Tuple.Create(tenderInfo.Item1, userIds);
        }


        public Tuple<long, List<long>> GetTenderWinnerIdFromCode(string tenderCode)
        {
            Tuple<long, long> tenderInfo = (from cm in meroBoleeDbContexts.CommunityApprovalEntities
                                            join t in meroBoleeDbContexts.TenderEntities on cm.TenderId equals t.Id
                                            where t.Code == tenderCode
                                            select Tuple.Create(t.Id, (long)cm.CompanyId)
                                           ).FirstOrDefault();

            List<long> userIds = (from tw in meroBoleeDbContexts.TenderWinnerEntities
                                  join c in meroBoleeDbContexts.CompanyEntities on tw.WinnerCompanyId equals c.CompanyId
                                  join uc in meroBoleeDbContexts.UserCompanies on c.CompanyId equals uc.CompanyId
                                  where tw.TenderId == tenderInfo.Item1
                                  select uc.UserId
                                  ).ToList();

            return Tuple.Create(tenderInfo.Item1, userIds);

            //Tuple<long, long> tender_Winner = (from t in meroBoleeDbContexts.TenderEntities
            //                                   join tw in meroBoleeDbContexts.TenderWinnerEntities on t.Tender_Id equals tw.TenderId
            //                                   join c in meroBoleeDbContexts.CompanyEntities on tw.WinnerCompanyId equals c.CompanyId
            //                                   join cu in meroBoleeDbContexts.UserCompanies on c.CompanyId equals cu.CompanyId
            //                                   join u in meroBoleeDbContexts.UserEntities on cu.UserId equals u.User_Id
            //                                   where t.Tender_Code == tenderCode && u.IsEmailReceiver == true
            //                                   select Tuple.Create(t.Tender_Id, u.User_Id)
            //                                  ).FirstOrDefault();
            //return tender_Winner;
        }

        public bool EndTenderAuction(long tenderId)
        {
            try
            {
                TenderEntity te = meroBoleeDbContexts.TenderEntities.Where(x => x.Id == tenderId).FirstOrDefault();
                if (te != null)
                {
                    te.LiveEndDate = DateTimeNPT.Now;
                    te.CancelRemarks = "Bidding not received";
                    meroBoleeDbContexts.TenderEntities.Update(te);
                    unitOfWork.SaveChange();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public CommunityApprovalEntity ApproveTenderByBidInviter(CommunityApprovalEntity ent)
        {
            try
            {
                meroBoleeDbContexts.CommunityApprovalEntities.Update(ent);
                unitOfWork.SaveChange();
                return ent;
            }
            catch
            {
                throw;
            }
        }



        public async Task SetTenderStatusToFeedback(TenderEntity tenderEntity)
        {
            try
            {
                meroBoleeDbContexts.TenderEntities.Update(tenderEntity);
                await meroBoleeDbContexts.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Tuple<decimal, DateTime, DateTime> GetMaxQuotationAllowed(long tenderId)
        {
            try
            {
                var tuple = (from te in meroBoleeDbContexts.TenderEntities
                             where te.Id == tenderId
                             select Tuple.Create(te.MaxQuotation, te.LiveStartDate, te.LiveEndDate)
                                                           ).FirstOrDefault();

                return tuple;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<bool> DeleteTender(TenderEntity entity)
        {
            try
            {
                if (entity.TenderTermsConditionEntities != null)
                {
                    //meroBoleeDbContexts.TenderTermsConditionEntities.Remove(entity.TenderTermsConditionEntities);
                    var tenderTermsConditionEntity = await meroBoleeDbContexts.TenderTermsConditionEntities.Where(x => x.TenderId == entity.Id).ToListAsync();
                    entity.TenderTermsConditionEntities.IsDeleted = true;

                }

                if (entity.TenderMaterialEntities != null && entity.TenderMaterialEntities.Count > 0)
                {
                    //meroBoleeDbContexts.TenderMaterialEntities.RemoveRange(entity.TenderMaterialEntities);
                    List<TenderMaterialEntity> tenderMaterialEntity = new List<TenderMaterialEntity>();

                    tenderMaterialEntity = await meroBoleeDbContexts.TenderMaterialEntities.Where(x => x.TenderId == entity.Id).ToListAsync();
                    foreach (var item in tenderMaterialEntity)
                    {
                        item.IsDeleted = true;
                    }
                    entity.TenderMaterialEntities = tenderMaterialEntity;
                }

                //if (entity.TenderCards != null && entity.TenderCards.Count > 0)
                //{
                //    meroBoleeDbContexts.TenderCards.RemoveRange(entity.TenderCards);
                //}

                if (entity.Feedbacks != null && entity.Feedbacks.Count > 0)
                {
                    //meroBoleeDbContexts.TenderCardFeedbacks.RemoveRange(entity.Feedbacks);
                    List<TenderCardFeedbackEntity> tenderCardFeedbackEntities = new List<TenderCardFeedbackEntity>();

                    tenderCardFeedbackEntities = await meroBoleeDbContexts.TenderCardFeedbacks.Where(x => x.TenderId == entity.Id).ToListAsync();
                    foreach (var item in tenderCardFeedbackEntities)
                    {
                        item.IsDeleted = true;
                    }
                    entity.Feedbacks = tenderCardFeedbackEntities;

                }

                if (entity.ExtraDocuments != null && entity.ExtraDocuments.Count > 0)
                {
                    // meroBoleeDbContexts.TenderExtraDocuments.RemoveRange(entity.ExtraDocuments);
                    List<TenderExtraDocumentEntity> tenderExtraDocumentEntities = new List<TenderExtraDocumentEntity>();

                    tenderExtraDocumentEntities = await meroBoleeDbContexts.TenderExtraDocuments.Where(x => x.TenderId == entity.Id).ToListAsync();
                    foreach (var item in tenderExtraDocumentEntities)
                    {
                        item.IsDeleted = true;
                    }
                    entity.ExtraDocuments = tenderExtraDocumentEntities;
                }
                if (entity.AuctionLogs != null && entity.AuctionLogs.Count > 0)
                {
                    List<AuctionLog> auctionLogs = new List<AuctionLog>();

                    auctionLogs = await meroBoleeDbContexts.AuctionLogs.Where(x => x.TenderId == entity.Id).ToListAsync();
                    foreach (var item in auctionLogs)
                    {
                        item.IsDeleted = true;
                    }
                    entity.AuctionLogs = auctionLogs;
                }
                if (entity.BiddingHistories != null && entity.BiddingHistories.Count > 0)
                {
                    List<BiddingHistoryEntity> biddingHistories = new List<BiddingHistoryEntity>();

                    biddingHistories = await meroBoleeDbContexts.BiddingHistoryEntities.Where(x => x.TenderId == entity.Id).ToListAsync();
                    foreach (var item in biddingHistories)
                    {
                        item.IsDeleted = true;
                    }
                    entity.BiddingHistories = biddingHistories;
                }
                if (entity.BidRequests != null && entity.BidRequests.Count > 0)
                {
                    List<BidRequestEntity> bidRequests = new List<BidRequestEntity>();

                    bidRequests = await meroBoleeDbContexts.BidRequestEntities.Where(x => x.TenderId == entity.Id).ToListAsync();
                    foreach (var item in bidRequests)
                    {
                        item.IsDeleted = true;
                    }
                    entity.BidRequests = bidRequests;
                }
                if (entity.LiveBiddings != null && entity.LiveBiddings.Count > 0)
                {
                    List<LiveBiddingEntity> liveBiddings = new List<LiveBiddingEntity>();

                    liveBiddings = await meroBoleeDbContexts.LiveBiddingEntities.Where(x => x.TenderId == entity.Id).ToListAsync();
                    foreach (var item in liveBiddings)
                    {
                        item.IsDeleted = true;
                    }
                    entity.LiveBiddings = liveBiddings;
                }
                // meroBoleeDbContexts.TenderEntities.Remove(entity);
                entity.IsDeleted = true;
                await unitOfWork.SaveChangesAsync();
                return true;
            }
            catch
            {

                throw;
            }
        }

        public async Task<List<TenderCardFeedbackEntity>> GetTenderCardFeedback(long tenderId)
        {
            try
            {
                return await meroBoleeDbContexts.TenderCardFeedbacks.Where(x => x.TenderId == tenderId).ToListAsync();
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> isSupplierRegistered(long tenderId, long userId, long companyId)
        {
            try
            {
                int isSupplierRegistered = await meroBoleeDbContexts.BidRequestEntities.Where(x => x.TenderId == tenderId).Where(x => x.UserId == userId).Where(x => x.CompanyId == companyId).Select(x => x.BidRequestStatusId).FirstOrDefaultAsync();
                if(isSupplierRegistered == 1 || isSupplierRegistered == 2) return true;
                else return false;
            }
            catch
            {

                throw;
            }
        }

        public async Task<int> GetTenderStatus(long tenderId, long userId)
        {
            try
            {
                int tenderStatus = await meroBoleeDbContexts.BidRequestEntities.Where(x => x.TenderId == tenderId).Where(x => x.UserId == userId).Select(x => x.BidRequestStatusId).FirstOrDefaultAsync();
               
                return tenderStatus;
            }
            catch
            {

                throw;
            }
        }

        public async Task<int> AddTime(long tenderId, int min)
        {
            try
            {
                if(tenderId < 0 || min < 0) return 0;
                TenderEntity tenderEntity = await meroBoleeDbContexts.TenderEntities.Where(x => x.Id == tenderId).FirstOrDefaultAsync();
                tenderEntity.LiveEndDate = tenderEntity.LiveEndDate.AddMinutes(min);
                await unitOfWork.SaveChangesAsync();
                return 1;
            }
            catch
            {

                throw;
            }
        }

        public async Task<int> EndTender(long tenderId)
        {
            try
            {
                if(tenderId < 0) return 0;
                TenderEntity tenderEntity = await meroBoleeDbContexts.TenderEntities.Where(x => x.Id == tenderId).FirstOrDefaultAsync();
                tenderEntity.LiveEndDate = DateTimeNPT.Now;
                await unitOfWork.SaveChangesAsync();
                return 1;
            }
            catch
            {

                throw;
            }
        }

        public async Task<int> EnterBidRoomBidInviter(long tenderId, long comapnyId)
        {
            try
            {
                var tenderEntity = await (from cm in meroBoleeDbContexts.CommunityApprovalEntities
                                                   join t in meroBoleeDbContexts.TenderEntities on cm.TenderId equals t.Id
                                                   where t.Id == tenderId
                                                   select cm.CompanyId).FirstOrDefaultAsync();
                                                   //meroBoleeDbContexts.TenderEntities.Where(x => x.Id == tenderId).FirstOrDefaultAsync();
                if (tenderEntity == comapnyId) return 1;
                else return 0;
            }
            catch
            {

                throw;
            }
        }

        public async Task<List<AlgorithmEntity>> AlgorithmList()
        {
            try 
            {
                return await meroBoleeDbContexts.AlgorithmEntities.ToListAsync();
            }
            catch 
            {
                throw;
            }
        }

        public async Task<List<MaterialCatResDto>> MaterialCategory(long tenderId)
        {
            try 
            {
                List<TenderMaterialEntity> tenderMaterialList = await meroBoleeDbContexts.TenderMaterialEntities.Where(x => x.TenderId == tenderId).ToListAsync();
                var groupedResult = tenderMaterialList.GroupBy(x => new { x.MaterialGroup }).Select(x => new { MaterialGroup = x.Key.MaterialGroup }).OrderBy(x => x.MaterialGroup).ToArray();
                List<MaterialCatResDto> materialCatList = new List<MaterialCatResDto>();
                for (int i = 0; i < groupedResult.Length; i++) {
                    MaterialCatResDto materialCatResDto = new MaterialCatResDto();
                    materialCatResDto.id = i;
                    materialCatResDto.name = groupedResult[i].MaterialGroup;
                    materialCatList.Add(materialCatResDto);
                }
                return materialCatList;
            }
            catch 
            {
                throw;
            }
        }

        public async  Task<List<TenderMaterialSealedResponseDto>> MaterialListCategoryWise(long tenderId, int materialId)
        {
            try 
            {
                List<MaterialCatResDto> materialCatList = await MaterialCategory(tenderId);
                string materialGroup = materialCatList.Where(x => x.id == materialId).Select(x => x.name).FirstOrDefault();
                List<TenderMaterialEntity> tenderMaterialList = await meroBoleeDbContexts.TenderMaterialEntities.Where(x => x.TenderId == tenderId).Where(x => x.MaterialGroup.Equals(materialGroup)).ToListAsync();
                List<TenderMaterialSealedResponseDto> materialListCatWise = new List<TenderMaterialSealedResponseDto>();
                foreach (TenderMaterialEntity tenderMaterialEntity in tenderMaterialList) {
                    TenderMaterialSealedResponseDto tenderMaterialSealedResponseDto = new TenderMaterialSealedResponseDto();
                    tenderMaterialSealedResponseDto.MaterialGroup = tenderMaterialEntity.MaterialGroup;
                    tenderMaterialSealedResponseDto.MaterialId = tenderMaterialEntity.Id;
                    tenderMaterialSealedResponseDto.MaterialName = tenderMaterialEntity.Materials;
                    tenderMaterialSealedResponseDto.Quantity = tenderMaterialEntity.Quantity;
                    tenderMaterialSealedResponseDto.Units = tenderMaterialEntity.Units;
                    materialListCatWise.Add(tenderMaterialSealedResponseDto);
                }
                return materialListCatWise;
            }
            catch 
            {
                throw;
            }
        }

        public async Task<List<TenderMaterialSealedResponseDto>> MaterialListCategoryWiseRetriveData(long tenderId, long materialId, long supplierId)
        {
            try 
            {
                List<MaterialCatResDto> materialCatList = await MaterialCategory(tenderId);
                string materialGroup = materialCatList.Where(x => x.id == materialId).Select(x => x.name).FirstOrDefault();
                List<QuotationSealBidEntity> quotationSealBidList = await meroBoleeDbContexts.QuotationSealBidEntities.Where(x => x.TenderId == tenderId).Where(x => x.MaterialGroup.Equals(materialGroup)).Where(x => x.UserId == supplierId).ToListAsync();
                List<TenderMaterialSealedResponseDto> materialListCatWise = new List<TenderMaterialSealedResponseDto>();
                foreach (QuotationSealBidEntity quotationSealBidEntity in quotationSealBidList) {
                    TenderMaterialSealedResponseDto tenderMaterialSealedResponseDto = new TenderMaterialSealedResponseDto();
                    tenderMaterialSealedResponseDto.MaterialGroup = quotationSealBidEntity.MaterialGroup;
                    tenderMaterialSealedResponseDto.MaterialId = quotationSealBidEntity.MaterialId;
                    tenderMaterialSealedResponseDto.MaterialName = quotationSealBidEntity.MaterialName;
                    tenderMaterialSealedResponseDto.Quantity = quotationSealBidEntity.Quantity;
                    tenderMaterialSealedResponseDto.Units = quotationSealBidEntity.Units;
                    tenderMaterialSealedResponseDto.UnitPrice = quotationSealBidEntity.UnitPrice;
                    tenderMaterialSealedResponseDto.Quotation = Decimal.Parse(cryptoService.Decrypt<string>(quotationSealBidEntity.Quotation));
                    tenderMaterialSealedResponseDto.Remarks = quotationSealBidEntity.Remarks;
                    materialListCatWise.Add(tenderMaterialSealedResponseDto);
                }
                return materialListCatWise;
            }
            catch 
            {
                throw;
            }
        }

        public async Task<decimal> GetSubSectionTotalForUser(long tenderId, long materialId, long supplierId) 
        {
            try 
            {
                List<MaterialCatResDto> materialCatList = await MaterialCategory(tenderId);
                string materialGroup = materialCatList.Where(x => x.id == materialId).Select(x => x.name).FirstOrDefault();
                decimal subsectionTotal = await meroBoleeDbContexts.SealBidSubsectionTotalEntities.Where(x => x.TenderId == tenderId).Where(x => x.UserId == supplierId).Where(x => x.MaterialGroup.Equals(materialGroup)).Select(x => x.subsectionTotal).FirstOrDefaultAsync();
                return subsectionTotal;
            }
            catch 
            {
                throw;
            }
        }

        public async Task<List<SealBidSubsectionTotalEntity>> RetriveSubsectionTotal(long tenderId, long supplierId) 
        {
            try 
            {
                List<SealBidSubsectionTotalEntity> sealBidSubsectionTotalEntities = await meroBoleeDbContexts.SealBidSubsectionTotalEntities.Where(x => x.UserId == supplierId).Where(x => x.TenderId == tenderId).ToListAsync();
                return sealBidSubsectionTotalEntities;
            }
            catch 
            {
                throw;
            }
        }

        public async Task<string> FetchFeedback(long tenderId, long companyId)
        {
           return await meroBoleeDbContexts.TenderCardFeedbacks.Where(x => x.TenderId == tenderId && x.CompanyId == companyId).Select(x => x.Feeback).FirstOrDefaultAsync();
        }

        public List<long> GetBidInviterCompanyList(long tenderId)
        {
            try
            {
                return meroBoleeDbContexts.CommunityApprovalEntities.Where(x => x.TenderId == tenderId).Select(x => x.CompanyId).ToList();
            }
            catch 
            {
                throw;
            }
        }

        public async Task<CommunityApprovalEntity> FindCommunityApprovalByCompanyId(long companyId, long tenderId)
        {
            try
            {
                CommunityApprovalEntity communityApprovalEntity = await meroBoleeDbContexts.CommunityApprovalEntities
                    .Where(x => x.TenderId == tenderId).Where(x => x.CompanyId == companyId).FirstOrDefaultAsync();
                return communityApprovalEntity;
            }
            catch
            {
                throw;
            }
        }
        
        public async Task<bool> UpdateStatusByFeedbackForCommunityApproval(CommunityApprovalEntity dto)
        {
            try
            {
                meroBoleeDbContexts.CommunityApprovalEntities.Update(dto);
                await meroBoleeDbContexts.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<CommunityApprovalEntity>> FetchCommunityApprovalEntity(long tenderId)
        {
            try
            {
                return await meroBoleeDbContexts.CommunityApprovalEntities.Where(x => x.TenderId == tenderId).ToListAsync();
            }
            catch
            {

                throw;
            }
        }

        public async Task<PostBidddingApprovalEntity> UpdatePostBidApprovalStatus(PostBidddingApprovalEntity postBidEntity)
        {
            try
            {
                 meroBoleeDbContexts.PostBidddingApprovalEntities.Update(postBidEntity);
                 await unitOfWork.SaveChangesAsync();
                return postBidEntity;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public async Task<IEnumerable<PostBidddingApprovalEntity>> UpdatePostBidApprovalStatusByTenderId(IEnumerable<PostBidddingApprovalEntity> postBidEntity)
        {
            try
            {
                meroBoleeDbContexts.PostBidddingApprovalEntities.UpdateRange(postBidEntity);
                await unitOfWork.SaveChangesAsync();
                return postBidEntity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PostBidddingApprovalEntity> FindPostBiddingApproval(long tenderId, long companyId)
        {
            try
            {
               return await meroBoleeDbContexts.PostBidddingApprovalEntities.Where(x => x.CompanyId == companyId && x.TenderId == tenderId).FirstOrDefaultAsync();
            }
            catch
            {

                throw;
            }
        }

        public async Task<IEnumerable<PostBidddingApprovalEntity>> FindPostBiddingApprovalByTenderId(long tenderId)
        {
            try
            {
                return await meroBoleeDbContexts.PostBidddingApprovalEntities.Where(x => x.TenderId == tenderId).ToListAsync();
            }
            catch
            {

                throw;
            }
        }

        public  async Task<IEnumerable<PostBidApprovalListDto>> FetchPostBidApprovalList(long tenderId)
        {
            try
            {
                return await (from b in meroBoleeDbContexts.PostBidddingApprovalEntities
                        join c in meroBoleeDbContexts.CompanyEntities on b.CompanyId equals c.CompanyId
                        where b.TenderId == tenderId
                        select new PostBidApprovalListDto
                        {
                            CompanyId = b.CompanyId,
                            StatusId = b.StatusId,
                            CompanyName = b.CompanyEntity.Name,
                            Remarks = (from a in meroBoleeDbContexts.PostBidddingRemarksEntities
                                       where a.TenderPostBiddingApprovalId == b.Id
                                       select new Remarks
                                       {
                                           Id = a.Id,
                                           Message = a.Remarks,
                                           CompanyId=a.CompanyId,
                                           CompanyName = a.CompanyEntity.Name
                                       }).ToList()
                        }).ToListAsync();
            }
            catch 
            {

                throw;
            }
        }

        public async Task<PostBidddingRemarksEntity> InsertIntoPostBidRemarks(PostBidddingRemarksEntity postBidddingRemarksEntity)
        {
            meroBoleeDbContexts.PostBidddingRemarksEntities.Add(postBidddingRemarksEntity);
            await unitOfWork.SaveChangesAsync();
            return postBidddingRemarksEntity;
        }

        public async Task<List<PostBidddingApprovalEntity>> AddPostBid(List<PostBidddingApprovalEntity> postBidEntity)
        {
            meroBoleeDbContexts.PostBidddingApprovalEntities.AddRange(postBidEntity);
            await unitOfWork.SaveChangesAsync();
            return postBidEntity;
        }

        public async Task<bool> CheckStatusInPostBidApproval(long tenderId)
        {
            try
            {

                var statusList = await meroBoleeDbContexts.PostBidddingApprovalEntities.Where(x => x.TenderId == tenderId).Select(x => x.StatusId).ToListAsync();
                foreach (var item in statusList)
                {
                    if (item != 3) return false;
                }
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<PostBidDtoList>> FetchTenderTitleListForBidInviter(long companyId)
        {
            try
            {
                return await (from p in meroBoleeDbContexts.PostBidddingApprovalEntities
                              where p.CompanyId == companyId
                              select new PostBidDtoList
                              {
                                  TenderId = p.TenderId,
                                  TenderTitle = p.TenderEntity.Title,
                                  StatusId = p.StatusId,
                                  Status= p.TenderPostBidStatusEntity.Status,
                                  RemarksStatusId=p.RemarksStatusId
                              }).ToListAsync();
            }
            catch
            {

                throw;
            }
        }

        public async Task<IEnumerable<PostBidApprovalListDto>> FetchPostBidRemarksList(long tenderId, long companyId)
        {
            try
            {
                return await (from b in meroBoleeDbContexts.PostBidddingApprovalEntities
                              where b.TenderId == tenderId && b.CompanyId == companyId
                              select new PostBidApprovalListDto
                              {
                                  CompanyId = b.CompanyId,
                                  StatusId = b.StatusId,
                                  CompanyName = b.CompanyEntity.Name,
                                  Remarks = (from a in meroBoleeDbContexts.PostBidddingRemarksEntities
                                             where a.TenderPostBiddingApprovalId == b.Id
                                             select new Remarks
                                             {
                                                 Id = a.Id,
                                                 Message = a.Remarks,
                                                 CompanyId = a.CompanyId,
                                                 CompanyName = a.CompanyEntity.Name
                                             }).ToList()
                              }).ToListAsync();
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> AddPostBiddingSuperSeed(PostBiddingSuperseedEntity postBiddingSuperseedEntity)
        {
            try
            {
                await meroBoleeDbContexts.PostBiddingSuperseedEntities.AddAsync(postBiddingSuperseedEntity);
                await unitOfWork.SaveChangesAsync();
                return true;
            }
            catch 
            {

                throw;
            }
        }

        public async Task<IEnumerable<TenderProcurementTypeEntity>> GetProcurementList()
        {
            try
            {
                return await meroBoleeDbContexts.TenderProcurementTypeEntities.ToListAsync();
            }
            catch 
            {

                throw;
            }
        }
    }
}
