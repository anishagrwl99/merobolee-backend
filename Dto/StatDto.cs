using System.Collections.Generic;

namespace MeroBolee.Dto
{
    public class StatDto
    {
        public IEnumerable<CountDto> Count { get; set; }
        public long Total { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProcurementTypeDto> procurementTypeDtos { get; set; }

        public GraphDataDto graphDatas { get; set; }
    }

    public class CountDto
    {
        public int Id { get; set; }
        public long Count { get; set; }
        public string Name { get; set; }
    }

    public class StatusDto
    {
        public int Id { get; set; }
        public long Count { get; set; }
        public string Name { get; set; }
    }

    public class ProcurementTypeDto
    {
        public string Name { get; set; }    
        public IEnumerable<StatusDto> statusDtos { get; set; }
        public long Total { get; set; }
    }
}
