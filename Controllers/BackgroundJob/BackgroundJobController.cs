using Hangfire;
using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.City
{
    public class BackgroundJobController : Controller
    {
        private readonly IBiddingRequestService bidService;

        public BackgroundJobController(IBiddingRequestService bidService)
        {
            this.bidService = bidService;
        }


        //[HttpGet("/BackgroundJob/MoveBidHistory")]
        public IActionResult MoveRecord()
        {
            try
            {
                string jobId = "Move Live Bid To History";
                RecurringJob.RemoveIfExists(jobId);
                RecurringJob.AddOrUpdate(jobId, () => MoveBidToHistory(), Cron.Hourly());
                
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        public Task MoveBidToHistory()
        {
            return Task.Run(async () =>
            {
                await bidService.MoveBidToHistory();
            });
            
        }

    }
}
