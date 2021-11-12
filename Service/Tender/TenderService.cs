using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Model;
using MeroBolee.Repository.Tender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.Tender
{
    public class TenderService: TenderMapper,ITenderService
    {
        private readonly ITenderRepository tenderRepository;
        private readonly IReferenceCodeService referenceCodeService;

        public TenderService(ITenderRepository tenderRepository, IReferenceCodeService referenceCodeService)
        {
            this.tenderRepository = tenderRepository;
            this.referenceCodeService = referenceCodeService;
        }

        public GetTenderDto AddTender(AddTenderDto tenderDto)
        {
            TenderEntity entity = TenderDtoEntity(tenderDto);
            entity.Tender_Code = referenceCodeService.GenerateCode(ReferenceEnum.Tender).Result;
            return TenderEntityToDto(tenderRepository.AddTender(entity));
        }

        public IEnumerable<GetTenderDto> FavouriteTender(int userId, string search)
        {
            return TenderEntityListToDto(tenderRepository.FavouriteTender(userId, search));
        }

        public IEnumerable<TenderCard> GetMarketplaceTender(string search)
        {
            return tenderRepository.GetMarketplaceTender(search);
        }

        public IEnumerable<GetTenderDto> GetMyTenders(long companyId, string search, CompanyTypeEnum companyType)
        {
            return TenderEntityListToDto(tenderRepository.GetMyTender(companyId, search, companyType));
        }

        public IEnumerable<TenderCard> GetBidIniviterTenderHistory(long companyId, string search)
        {
            return tenderRepository.GetBidIniviterTenderHistory(companyId, search);
        }

        public BidInviterTenderListing GetBidInviterTenderListing(long companyId, string search)
        {
            IEnumerable<TenderCard> tenders =  tenderRepository.GetBidIniviterTenderListing(companyId, search);
            BidInviterTenderListing listing = new BidInviterTenderListing
            {
                PendingTenders = tenders.Where(x => x.StatusId == 1).ToList(),
                ActiveTenders = tenders.Where(x=>x.StatusId == 2).ToList()               
            };
            return listing;
        }

        public IEnumerable<GetTenderDto> GetTenderByAuctioneer(int userId, string search)
        {
            return TenderEntityListToDto(tenderRepository.GetTenderByAuctioneer(userId, search));
        }

        public GetTenderDto GetTenderDetail(int id)
        {
            return TenderEntityToDto(tenderRepository.GetTenderDetail(id));
        }

        public IEnumerable<TenderCard> UpcomingTender(string search)
        {
            return tenderRepository.UpcomingTender(search);
        }

        public GetTenderDto UpdateTender(int id, AddTenderDto tenderDto)
        {
            return TenderEntityToDto(tenderRepository.UpdateTender(id, TenderDtoEntity(tenderDto)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenderCode"></param>
        /// <returns><see cref="Tuple{T1, T2}"/></returns>
        public Tuple<long, long> GetTenderIdFromCode(string tenderCode)
        {
            return tenderRepository.GetTenderIdFromCode(tenderCode);
        }


        public Tuple<long, long> GetTenderWinnerIdFromCode(string tenderCode)
        {
            return tenderRepository.GetTenderWinnerIdFromCode(tenderCode);
        }

        public void EndTenderAuction(long tenderId)
        {
            try
            {
                Task.Run(() =>
                {
                    tenderRepository.EndTenderAuction(tenderId);
                });
              
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TenderApproveDto ApproveTenderByBidInviter(TenderApproveDto dto)
        {
            try
            {
                TenderEntity t = tenderRepository.GetTenderDetail(dto.TenderId);
                t.Tender_Status_Id = 2;//Approved
                t.Date_modified = DateTime.Now;
                t.ApprovedBy = dto.UserId;
                tenderRepository.ApproveTenderByBidInviter(t);
                return dto;
            }
            catch
            {

                throw;
            }
        }
    }
}
