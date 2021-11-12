using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class UpdateRequestDto
    {
        private int statusId;
        private string remark;

        public int StatusId { get => statusId; set => statusId = value; }
        public string Remark { get => remark; set => remark = value; }
    }
}
