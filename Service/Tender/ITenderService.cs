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
        Task<IEnumerable<TenderCard>> GetMarketplaceTender(string search,string procurementId, string algoId);
        Task<IEnumerable<TenderCard>> GetLiveBidMarketplaceTenderForAdmin(string search);

        Task<GetTenderDto> GetTenderDetail(long tenderId, string basePath, bool isRegistered, string userRole);
        Task<TenderEntity> CommunityApproval(TenderApproveDtoByAdmin tenderApproveDtoByAdmin);
        Task<bool> PreBidSuperseed(PreBidSuperSeed tenderApproveDto);
        Task<IEnumerable<CommunityApprovalDto>> CommunityApprovalList(long tenderId);
        Task<PostBidDetail> GetPostBidApprovalList(long tenderId);
        Task<IEnumerable<PostBidDtoList>> GetPostBidCompanyList(long companyId);
        Task<IEnumerable<PostBidApprovalListDto>> GetPostBidRemarksList(long tenderId,long companyId);
        Task<TenderDocuments> GetTenderDocuments(long tenderId, string basePath);
        Task<TenderDocuments> GetTenderDocumentsForSupplier(long tenderId, long companyId, string basePath);
        Task<TenderEntity> UpdateTender(UpdateTenderRequestDto tenderDto);
        Task<IEnumerable<TenderCard>> UpcomingBidderTender(long companyId, bool isAlert, bool isLiveBidUpcoming,string procurementId, string algoId);
        Task<IEnumerable<TenderCard>> UpcomingBidInviterTender(long companyId, string procurementId, string algoId);
        Task<IEnumerable<TenderCard>> UpcomingTenderForAdmin();

        Task<IEnumerable<TenderCard>> CompanyTendersForAdmin(int statusId,long? companyId,string procurementId,string algoId);
        Task<IEnumerable<TenderCard>> GetBidIniviterTenderHistory(long companyId, string search, string procurementId, string algoId);
        Task<BidInviterTenderListing> GetBidInviterTenderListing(long companyId,string procurementId,string algoId);

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
        Task<PostBidddingApprovalEntity> PostBidApprove(VerifyOtpDto verifyOtpDto);
        Task<PostBidddingApprovalEntity> PostBidRequestChanges(TenderApproveDto tenderApprove);
        Task<PostBidddingApprovalEntity> GenerateNewRequest(GenerateNewRequestDtoByAdmin tenderApprove);
        Task<bool> PostBidFinalApprove(TenderApproveDtoByAdmin tenderApprove);
        Task<List<PostBidddingApprovalEntity>> AddPostBid(AddPostBidDto postBidDto);
        Task <bool> AddSuperSeed(SuperSeedDto superSeedDto);
        Task<int> CheckPostBidStatus(long tenderId);
        Task<IEnumerable<TenderProcurementTypeEntity>> GetProcurement();
        Task<List<StatDto>> GetAdminDashboard();
        Task<List<StatDto>> GetBidInviterDashboard(long companyId);
        Task<List<StatDto>> GetBidderDashboard(long companyId);
        Task<IEnumerable<GraphDataEntity>> SaveGraphData(GraphDataDto graphDataDto);
        Task<List<BidderInfo>> GetParticipantBidderList(long tenderId,string Rank);
        Task<bool> SaveQulifiedOrWinner(QualifiedOrWinnerDto qualifiedOrWinnerDto);
    }
}
