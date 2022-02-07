using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeroBolee.Dto
{
  
    public class AdvanceSearch
    {
        public List<SearchField> CompanyFields { get; set; }
        public List<SearchField> UserFields { get; set; }
        public List<SearchField> TenderFields { get; set; }
    }


    public class SearchField
    {
        [Required(ErrorMessage = "Search key is required")]
        [MaxLength(100)]
        public string Key { get; set; }

        [Required(ErrorMessage = "Search value is required")]
        [MaxLength(50)]
        public string Value { get; set; }
    }
}
