using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetMembershipDto
    {
        private int membershipId;
        private string membershipTitle;
        private int duration;
        private string durationType;
        private float membershipfee;
        private float discount;
        private string status;
        private int statusId;

        public int MembershipId { get => membershipId; set => membershipId = value; }
        public string MembershipTitle { get => membershipTitle; set => membershipTitle = value; }
        public int Duration { get => duration; set => duration = value; }
        public string DurationType { get => durationType; set => durationType = value; }
        public float Membershipfee { get => membershipfee; set => membershipfee = value; }
        public float Discount { get => discount; set => discount = value; }
        public string  Status { get => status; set => status = value; }
        public int StatusId { get => statusId; set => statusId = value; }
    }
}
