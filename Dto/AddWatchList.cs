using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddWatchList
    {
        private int user_Id;
        private int tender_Id;

        public int User_Id { get => user_Id; set => user_Id = value; }
        public int Tender_Id { get => tender_Id; set => tender_Id = value; }
    }
}
