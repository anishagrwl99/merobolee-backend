using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class ConfirmEmailRequestDto
    {
        public string userId {get; set;}
        public string token { get; set; }
    }
}