using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.Tender
{
    public class TenderListingFeedbackController : BaseController
    {
        private readonly ITenderCardFeedbackService feedbackService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;
        public TenderListingFeedbackController(ITenderCardFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }



        /// <summary>
        /// Give feedback on tender created by merobolee
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns></returns>
        [HttpPost("TenderListing" +
                  "/Feedback/Send")]
        [Authorize(Roles = "Bid Inviter")]
        public async Task<IActionResult> SendFeedback([FromBody] TenderCardFeedbackDto feedback)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TenderCardFeedbackDto response = await feedbackService.AddFeedback(feedback);
                    if (response == null)
                    {
                        return NotFound(new Responses<string>("Error", "404", "Record not found"));
                    }
                    else if (response.Feedback == "Conflict")
                    {
                        return Conflict(new Responses<string>("Conflict", "409", "Action can't be performed."));
                    }
                    else
                    {
                        return Ok(new Responses<string>("Ok", "200", "Request successfully sent."));
                    }
                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    response.Data = ModelState;
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// Gat all feedback provided on a tender card
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="tenderId"></param>
        /// <returns></returns>
        [HttpGet("TenderListing/Feedback/List")]
        [Authorize(Roles = "Bid Inviter, Super Admin, Tender Support, Customer Support")]
        public async Task<IActionResult> GetTenderFeedbaks([FromQuery] long companyId, [FromQuery] long tenderId)
        {
            try
            {
                string url = Url.Action("GetTenderFeedbaks", null, new { companyId = companyId, tenderId = tenderId }, Request.Scheme); //get url for current request
                this.uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                List<TenderCardFeedbackResponseDto> feedbacks = await feedbackService.ListTenderFeedback(companyId, tenderId);
                int totalCount = feedbacks.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<List<TenderCardFeedbackResponseDto>>(feedbacks, "404", "Record not found"));
                }
                return Ok(new Responses<List<TenderCardFeedbackResponseDto>>(feedbacks, "200", "Record found"));
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }



    }
}
