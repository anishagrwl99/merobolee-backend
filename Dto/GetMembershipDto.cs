using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetMembershipDto
    {
        private int membership_Id;
        private string membership_Title;
        private int duration;
        private string duration_Type;
        private float membership_fee;
        private float discount;
        private string status;
        private int status_Id;

        public int Membership_Id { get => membership_Id; set => membership_Id = value; }
        public string Membership_Title { get => membership_Title; set => membership_Title = value; }
        public int Duration { get => duration; set => duration = value; }
        public string Duration_Type { get => duration_Type; set => duration_Type = value; }
        public float Membership_fee { get => membership_fee; set => membership_fee = value; }
        public float Discount { get => discount; set => discount = value; }
        public string  Status { get => status; set => status = value; }
        public int Status_Id { get => status_Id; set => status_Id = value; }
    }
}
