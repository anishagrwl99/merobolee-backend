using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeroBolee.Dto
{
    public class SetQuestionDto
    {
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid TenderId")]
        public long TenderId { get; set; }
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid CompanyId")]
        public long CompanyId { get; set; }
        [Required]
        public List<CriteriaDto> Criterias { get; set; }
    }

    public class SetRating
    {
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid TenderId")]
        public long TenderId { get; set; }
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid CompanyId")]
        public long CompanyId { get; set; }
        [Required]
        public IEnumerable<Ratings> Ratings { get; set; }
    }

    public class Ratings
    {
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid Id")]
        public long Id { get; set; }
        [Required]
        public int Rating { get; set; }
        public string Remarks { get; set; }
    }

    public class CriteriaEditDto
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Criteria { get; set; }
    }

    public class CriteraiAddDto
    {
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid TenderId")]
        public long TenderId { get; set; }
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid CompanyId")]
        public long CompanyId { get; set; }

        [Required]
        public string Criteria { get; set; }
    }

    public class TenderListDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
    }

    public class CriteriaDto
    {
        [Required]
        public string Criteria { get; set; }
    }
}
