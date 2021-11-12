using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddMemeberShipDto
    {
        private string membershipTitle;
        private int duration;
        private string durationType;
        private float membershipfee;
        private float discount;
        private int statusId;


        public string MembershipTitle { get => membershipTitle; set => membershipTitle = value; }
        public int Duration { get => duration; set => duration = value; }
        public string DurationType { get => durationType; set => durationType = value; }
        public float Membershipfee { get => membershipfee; set => membershipfee = value; }
        public float Discount { get => discount; set => discount = value; }
        public int StatusId { get => statusId; set => statusId = value; }
    }
}
