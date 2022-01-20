using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    public class WatchListMapper
    {
        public WatchListEntity WatchListDtoToEntity(AddWatchList addWatchList)
        {
            return new WatchListEntity
            {
                UserId = addWatchList.UserId,
                TenderId = addWatchList.TenderId,
                CompanyId = addWatchList.CompanyId
            };
        }

        public IEnumerable<GetWatchListDto> WatchListEntityToDto(IEnumerable<WatchListEntity> watch)
        {
            List<GetWatchListDto> getWatches = new List<GetWatchListDto>();
            foreach (var item in watch)
            {
                getWatches.Add(new GetWatchListDto
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    Tender_Detail = TenderEntityToDto(item.TenderEntity),
                    CompanyId = item.CompanyId
                }
                );

            }
            return getWatches;
        }

        private TenderWatchlistDto TenderEntityToDto(TenderEntity tender)
        {
            if (tender == null)
            {
                return null;
            }
            return new TenderWatchlistDto
            {
                TenderId = tender.Id,
                TenderCode = tender.Code,
                TenderTitle = tender.Title,
                LiveStartDate = tender.LiveStartDate,
                LiveEndDate = tender.LiveEndDate,
                PublishDate = tender.Date_created,
                CategoryId = tender.CategoryId,
                Category = CategoryTODto(tender.CategoryEntity)
            };

        }

        private WatchCategoryDto CategoryTODto(CategoryEntity category)
        {
            if (category == null)
            {
                return null;
            }
            return new WatchCategoryDto
            {
                Id = category.Id,
                Categgory = category.Category
            };
        }
    }
}
