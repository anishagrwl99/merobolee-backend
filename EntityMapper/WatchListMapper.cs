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
            User_Id= addWatchList.User_Id,
            Tender_Id= addWatchList.Tender_Id
            };
        }

        public IEnumerable<GetWatchListDto> WatchListEntityToDto(IEnumerable<WatchListEntity> watch)
        {
            List<GetWatchListDto> getWatches = new List<GetWatchListDto>();
            foreach (var item in watch)
            {
                getWatches.Add(new GetWatchListDto
                { 
                 Id= item.Id,
                 User_id= item.User_Id,
                 Tender_Detail=TenderEntityToDto(item.TenderEntity)
                
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
                Tender_Id = tender.Tender_Id,
                Tender_Code = tender.Tender_Code,
                Tender_Title = tender.Tender_Title,
                Tender_Description = tender.Tender_Description,
                Tender_Duration = tender.Tender_Duration,
                Live_Start_Date = tender.Live_Start_Date,
                Live_End_Date = tender.Live_End_Date,
                Publish_Date = tender.Date_created,
                Category_Id= tender.Category_Id,
                Category=CategoryTODto(tender.CategoryEntity)
            
            
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
            Id= category.Category_Id,
            Categgory= category.Category
            };
        }
    }
}
