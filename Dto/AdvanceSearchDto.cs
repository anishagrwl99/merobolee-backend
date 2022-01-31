using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AdvanceSearchDto
    {
        public List<TenderCard> Tenders { get; set; }

        public List<UserResponseDto> Users { get; set; }
        
        public List<CompanyDto> Companies { get; set; }
    }
}
