// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using MeroBolee.Dto;
// using MeroBolee.Infrastructure;
// using MeroBolee.Model;
// using MeroBolee.Service;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;

// namespace MeroBolee.Controllers.TenderPB
// {
//     public class PBController : AuthorizeController
//     {
//         private readonly ResponseMsg response = new ResponseMsg();
//         private IUriService uriService;

//         private readonly IPBTenderService pBTenderService;
//         public PBController(IPBTenderService pBTenderService) {
//             this.pBTenderService = pBTenderService;
//         }

//         [HttpGet("")]
//     }
// }