using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class EmailRequestdto
    {
        public string toEmailId {get; set;}

        public string token {get; set;}
        public string id {get; set;}

        public string confirmationLink { get; set; }

        public string role { get; set;}
    }
}