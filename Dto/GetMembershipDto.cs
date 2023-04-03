namespace MeroBolee.Dto
{
    public class GetMembershipDto
    {
        public int MembershipId { get; set; }
        public string MembershipTitle { get; set; }
        public int Duration { get; set; }
        public string DurationType { get; set; }
        public float Membershipfee { get; set; }
        public float Discount { get; set; }
        public string  Status { get; set; }
        public int StatusId { get; set; }
    }
}
