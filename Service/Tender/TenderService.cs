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

        public TenderService(ITenderRepository tenderRepository)
        {
            this.tenderRepository = tenderRepository;
        }

        public GetTenderDto AddTender(AddTenderDto tenderDto)
        {
            return TenderEntityToDto(tenderRepository.AddTender(TenderDtoEntity(tenderDto)));
        }

        public IEnumerable<GetTenderDto> FavouriteTender(int id, string search)
        {
            return TenderEntityListToDto(tenderRepository.FavouriteTender(id, search));
        }

        public IEnumerable<GetTenderDto> GetAllTender(string search)
        {
            return TenderEntityListToDto(tenderRepository.GetAllTender(search));
        }

        public IEnumerable<GetTenderDto> GetTenderByAuctioneer(int id, string search)
        {
            return TenderEntityListToDto(tenderRepository.GetTenderByAuctioneer(id, search));
        }

        public GetTenderDto GetTenderDetail(int id)
        {
            return TenderEntityToDto(tenderRepository.GetTenderDetail(id));
        }

        public IEnumerable<GetTenderDto> TenderByStatus(int id, string search)
        {
            return TenderEntityListToDto(tenderRepository.TenderByStatus(id, search));
        }

        public IEnumerable<GetTenderDto> UpcomingTender(string search)
        {
            return TenderEntityListToDto(tenderRepository.UpcomingTender(search));
        }

        public GetTenderDto UpdateTender(int id, AddTenderDto tenderDto)
        {
            return TenderEntityToDto(tenderRepository.UpdateTender(id, TenderDtoEntity(tenderDto)));
        }
    }
}
