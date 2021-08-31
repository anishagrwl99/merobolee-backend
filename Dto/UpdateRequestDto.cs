using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class UpdateRequestDto
    {
        private int status_Id;
        private string remark;

        public int Status_Id { get => status_Id; set => status_Id = value; }
        public string Remark { get => remark; set => remark = value; }
    }
}
