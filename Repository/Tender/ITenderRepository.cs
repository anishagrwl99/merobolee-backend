using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
   public interface ITenderRepository: IRepositoryBase<TenderEntity>
   {
        TenderEntity AddTender(TenderEntity tenderEntity);
        List<CommunityApprovalEntity> AddCommunityApproval(List<CommunityApprovalEntity> communityApprovalEntity);
        //TenderSubmission UpdateTenderSubmissionStatus(TenderSubmission tenderSubmission);
        //TenderSubmission FindTenderSubmissionEntity(long companyId);
        Task<IEnumerable<TenderCard>> GetMarketplaceTender(string search,List<int> procurementId, List<int> algoId);
        
        Task<IEnumerable<TenderCard>> GetLiveBidMarketplaceTenderForAdmin(string search);
        
         //  IEnumerable<TenderEntity> GetTenderByBidder();
         Task<TenderEntity> GetTenderDetail(long id);
         Task<CommunityApprovalEntity> GetTenderDetailBidInviterStatus(long id,long companyid);
         // Task<TenderEntity> GetTenderDetailForApproval(long id, string userRole);
         Task<TenderEntity> FindTenderToUpdate(long id);

        Task<TenderEntity> GetTenderDetailNew(long id);
        Task<TenderEntity> UpdateTender(TenderEntity tenderEntity);
        Task<TenderEntity> UpdateTenderStatus(TenderEntity tenderEntity);
        Task<IEnumerable<CommunityApprovalDto>> FindCommunityApprovalEntityByTenderId(long tenderId);
        Task<List<TenderCardFeedbackEntity>> GetTenderCardFeedback(long tenderId);
        /// <summary>
        /// Adds the tender documents.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        Task<List<TenderExtraDocumentEntity>> AddTenderDocuments(List<TenderExtraDocumentEntity> entities);

        /// <summary>
        /// Upcoming tenders within 7 days
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="isAlert"></param>
        /// <param name="isLiveBidUpcoming"></param>
        /// <param name="procurementId"></param>
        /// <param name="algoId"></param>
        /// <returns></returns>
        Task<IEnumerable<TenderCard>> UpcomingBidderTender(long companyId, bool isAlert, bool isLiveBidUpcoming,List<int> procurementId,List<int> algoId);

        /// <summary>
        /// Get bid inviter upcoming tender
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="procurementId"></param>
        /// <param name="algoId"></param>
        /// <returns></returns>
        Task<IEnumerable<TenderCard>> UpcomingBidInviterTender(long companyId, List<int> procurementId, List<int> algoId);
        Task<IEnumerable<TenderCard>> CompanyTendersForAdmin(int statusId, long? companyId,List<int> procurementId, List<int> algoId);
        Task<IEnumerable<TenderCard>> UpcomingTenderForAdmin();

        Task<IEnumerable<TenderCard>> GetBidIniviterTenderHistory(long companyId ,string search, List<int> procurementId, List<int> algoId);
        Task<IEnumerable<TenderCard>> GetBidIniviterTenderListing(long companyId, List<int> procurementId, List<int> algoId);
        Tuple<long, List<long>> GetTenderIdFromCode(string tenderCode);

        Tuple<long, List<long>> GetTenderWinnerIdFromCode(string tenderCode);

        /// <summary>
        /// End tender auction if bidding is not received
        /// </summary>
        /// <param name="tenderId"></param>
        bool EndTenderAuction(long tenderId);

        /// <summary>
        /// Approve a tender by a bid inviter for listing
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        CommunityApprovalEntity ApproveTenderByBidInviter(CommunityApprovalEntity ent);

        
        Task SetTenderStatusToFeedback(TenderEntity tenderEntity);

        Tuple<decimal, DateTime, DateTime>  GetMaxQuotationAllowed(long tenderId);
        Task<TenderEntity> GetTenderEntityOnly(long tenderId);
        Task<CommunityApprovalEntity> GetTenderEntityOfCompany(long tenderId,long companyId);
        Task<bool> CheckStatusInCommunityApproval(long tenderId);
        Task<bool> CheckStatusInPostBidApproval(long tenderId);

        Task<TenderEntity> GetTenderEntityOnly(long tenderId, long companyId);

        Task<bool> DeleteTender(TenderEntity entity);

        Task<bool> isSupplierRegistered(long tenderId, long userId, long companyId);

        Task<int> GetTenderStatus(long tenderId, long userId);

        Task<int> AddTime(long tenderId, int min);

        Task<int> EndTender(long tenderId);
        Task<int> EnterBidRoomBidInviter(long tenderId, long companyId);

        Task<List<AlgorithmEntity>> AlgorithmList();

        Task<List<MaterialCatResDto>> MaterialCategory(long tenderId);

        Task<List<TenderMaterialSealedResponseDto>> MaterialListCategoryWise(long tenderId, int materialId);

        Task<List<TenderMaterialSealedResponseDto>> MaterialListCategoryWiseRetriveData(long tenderId, long materialId, long supplierId);

        Task<decimal> GetSubSectionTotalForUser(long tenderId, long materialId, long supplierId);

        Task<List<SealBidSubsectionTotalEntity>> RetriveSubsectionTotal(long tenderId, long supplierId);
        Task<string> FetchFeedback(long tenderId, long companyId);
        List<long> GetBidInviterCompanyList(long tenderId);
        Task<CommunityApprovalEntity> FindCommunityApprovalByCompanyId(long companyId, long tenderId);
        Task<bool> UpdateStatusByFeedbackForCommunityApproval(CommunityApprovalEntity dto);
        Task<List<CommunityApprovalEntity>> FetchCommunityApprovalEntity(long tenderId);
        Task<PostBidddingApprovalEntity> UpdatePostBidApprovalStatus(PostBidddingApprovalEntity postBidEntity);
        Task<IEnumerable<PostBidddingApprovalEntity>> UpdatePostBidApprovalStatusByTenderId(IEnumerable<PostBidddingApprovalEntity> postBidEntity);
        Task<PostBidddingApprovalEntity> FindPostBiddingApproval(long tenderId, long companyId);
        Task<IEnumerable<PostBidddingApprovalEntity>> FindPostBiddingApprovalByTenderId(long tenderId);
        Task<IEnumerable<PostBidList>> FetchPostBidApprovalList(long tenderId);
        Task<IEnumerable<PostBidDtoList>> FetchTenderTitleListForBidInviter(long companyId);
        Task<PostBidddingRemarksEntity> InsertIntoPostBidRemarks(PostBidddingRemarksEntity postBidddingRemarksEntity);
        Task<List<PostBidddingApprovalEntity>> AddPostBid(List<PostBidddingApprovalEntity> postBidEntity);
        Task<IEnumerable<PostBidApprovalListDto>> FetchPostBidRemarksList(long tenderId, long companyId);
        Task <bool> AddPostBiddingSuperSeed(PostBiddingSuperseedEntity postBiddingSuperseedEntity);
        Task<IEnumerable<TenderProcurementTypeEntity>> GetProcurementList();
        Task<IEnumerable<TenderStatusEntity>> GetTenderStatusList();
        Task<long> GetOngoingPostBiddingCountBidInviter(long companyId,int id);
        Task<IEnumerable<BidRequestStatusEntity>> GetBidderStatus();
        Task<IEnumerable<GraphDataEntity>> AddGraphData(IEnumerable<GraphDataEntity> graphDataEntity);
        Task<List<GraphDataEntity>> CheckGraphData();
        IEnumerable<GraphDataEntity> UpdateGraphData(IEnumerable<GraphDataEntity> graphDataEntity);
        Task<List<GraphData>> GetGraphData();
        Task<List<BidderInfo>> FetchParticipantBidderList(long tenderId);
        Task<long> GetGraphDataTotalBudget();
        Task<BidRequestEntity> GetBidRequestEntity(long companyId, long tenderId);
        Task<BidRequestEntity> UpdateQualifiedStatusinBidRequest(BidRequestEntity bidRequestEntity);
        Task <IEnumerable<BidRequestEntity>> GetBidRequestEntityByTenderId(long tenderId);
        Task UpdateWholeQualifiedStatusinBidRequest(IEnumerable<BidRequestEntity> updateBidRequestEntitiesDto);
        Task<List<BidderInfo>> GetQualifiedBidderList(long tenderId);
        Task<List<BidderInfo>> GetWinnerBidderList(long tenderId);
        Task<IEnumerable<CommunityApprovalEntity>> FindPendingCommunityApprovalEntity(long tenderId);
        Task<bool> UpdateCommunityApprovalStatuses(IEnumerable<CommunityApprovalEntity> preBidddingApprovalEntity);
        Task<PostBiddingSuperseedEntity> FetchPostBidRemarks(long tenderId,string Bid);
        Task<List<long>> GetPostBidCompanyList(long tenderId);
        Task<long> FetchUserIdFromCompanyId(long v);
        Task<IEnumerable<TenderEntity>> GetAllTender();
        Task<IEnumerable<CommunityApprovalEntity>> GetAllCommunityApproval(long companyId);
        Task<IEnumerable<BidRequestEntity>> GetBidRequestEntities(long companyId);
    }
}