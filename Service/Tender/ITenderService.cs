using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public interface ITenderService
    {
        Task<TenderEntity> AddTender(AddTenderRequestDto tenderDto);
        Task<IEnumerable<TenderCard>> GetMarketplaceTender(string search);
        Task<IEnumerable<TenderCard>> GetLiveBidMarketplaceTenderForAdmin(string search);

        Task<GetTenderDto> GetTenderDetail(long tenderId, string basePath, bool isRegistered, string userRole);
        Task<TenderEntity> CommunityApproval(TenderApproveDtoByAdmin tenderApproveDtoByAdmin);
        Task<IEnumerable<CommunityApprovalDto>> CommunityApprovalList(long tenderId);
        Task<IEnumerable<PostBidApprovalListDto>> GetPostBidApprovalList(long tenderId,long companyId);
        Task<TenderDocuments> GetTenderDocuments(long tenderId, string basePath);
        Task<TenderDocuments> GetTenderDocumentsForSupplier(long tenderId, long companyId, string basePath);
        Task<TenderEntity> UpdateTender(UpdateTenderRequestDto tenderDto);
        Task<IEnumerable<TenderCard>> UpcomingBidderTender(long companyId, bool isAlert, bool isLiveBidUpcoming);
        Task<IEnumerable<TenderCard>> UpcomingBidInviterTender(long companyId);
        Task<IEnumerable<TenderCard>> UpcomingTenderForAdmin();

        Task<IEnumerable<TenderCard>> CompanyTendersForAdmin(int statusId,long? companyId);
        Task<IEnumerable<TenderCard>> GetBidIniviterTenderHistory(long companyId, string search);
        Task<BidInviterTenderListing> GetBidInviterTenderListing(long companyId);

        Task<bool> isSupplierRegistered(long tenderId, long userId, long companyId);

        Task<TenderStatusDto> GetTenderStatus(long tenderId, long userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenderCode"></param>
        /// <returns><see cref="Tuple{TenderId, UserId}"/> where T1 is TenderId and T2 is UserId who created a tender</returns>
        Tuple<long, List<long>> GetTenderIdFromCode(string tenderCode);


        /// <summary>
        /// Get a supplier who won the tender by a tender code
        /// </summary>
        /// <param name="tenderCode"></param>
        /// <returns></returns>
        Tuple<long, List<long>> GetTenderWinnerIdFromCode(string tenderCode);



        /// <summary>
        /// End live tender auction if there is no bid is done
        /// </summary>
        /// <param name="tenderId"></param>
        void EndTenderAuction(long tenderId);

        /// <summary>
        /// Approve a tender for listing by bid inviter once listing is done by admin
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<TenderApproveDto> ApproveTenderByBidInviter(TenderApproveDto dto);

        Tuple<decimal, DateTime, DateTime> GetMaxQuotationAllowed(long tenderId);

        Task UpdateTenderMaxQuotation(decimal maxQuotation, long tenderId);

        Task<bool> DeleteTender(long tenderId);

        Task<int> GetTenderDetailBidInviterStatus(long tenderId,long companyId);

        Task<int> AddTime(long tenderId, int min);

        Task<int> EndTender(long tenderId);

        Task<int> EnterBidRoomBidInviter(long tenderId, long comapnyId);

        Task<List<AlgorithmEntity>> AlgorithmList();

        Task<List<MaterialCatResDto>> MaterialCategory(long tenderId);

        Task<List<TenderMaterialSealedResponseDto>> MaterialListCategoryWise(long tenderId, int materialId);

        Task<RetriveDataSealBid> MaterialListCategoryWiseRetriveData(long tenderId, long materialId, long supplierId);

        Task<RetriveSubSectionDto> RetriveSubsectionTotal(long tenderId, long supplierId);
        
        Task<int> TenderStatusForAdmin(long tenderId);
        Task<PostBidddingApprovalEntity> PostBidApprove(long tenderId, long companyId);
        Task<PostBidddingApprovalEntity> PostBidRequestChanges(PostBidApproveDDtoByBidInviter tenderApprove);
        Task<PostBidddingApprovalEntity> GenerateNewRequest(GenerateNewRequestDtoByAdmin tenderApprove);
        Task<TenderEntity> PostBidFinalApprove(TenderApproveDtoByAdmin tenderApprove);
        Task<List<PostBidddingApprovalEntity>> AddPostBid(long tenderId);
    }
}
