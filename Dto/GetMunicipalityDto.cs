namespace MeroBolee.Dto
{
    public class GetMunicipalityDto
    {
        public int Id { get; set; }
        public string Municipality { get; set; }
        public int? DistrictId { get; set; }
        public string District { get; set; }
    }
}
