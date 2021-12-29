using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.Status
{
    /// <summary>
    /// Status controller
    /// </summary>
    public class StatusController : AuthorizeController
    {
        private readonly IStatusService statusService;
        private readonly ResponseMsg response = new ResponseMsg();



        /// <summary>
        /// Default const
        /// </summary>
        /// <param name="statusService"></param>
        public StatusController(IStatusService statusService)
        {
            this.statusService = statusService;
        }


        /// <summary>
        /// To display all common status
        /// </summary>
        /// <returns></returns>
        [HttpGet("Status/Common")]
        public async Task<IActionResult> CommonStatus()
        {
            try
            {
                IEnumerable<CommonStatus> publishStatuses = await statusService.GetCommonStatuses();
                if (publishStatuses.Count() == 0)
                {
                    return NotFound(new Responses<IEnumerable<CommonStatus>>(publishStatuses, "404", "Record not Found")); // To pass result in object along with pagination info
                }
                return Ok(new Responses<IEnumerable<CommonStatus>>(publishStatuses,"200","Record Found")); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }


        /// <summary>
        /// To display company status
        /// </summary>
        /// <returns></returns>
        [HttpGet("Status/Company")]
        public async Task<IActionResult> CompanyStatus()
        {
            try
            {
                IEnumerable<CompanyStatusEntity> status = await statusService.GetCompanyStatuses();
                if (status.Count() == 0)
                {
                    return NotFound(new Responses<IEnumerable<CompanyStatusEntity>>(status, "404", "Record not Found")); // To pass result in object along with pagination info
                }
                return Ok(new Responses<IEnumerable<CompanyStatusEntity>>(status, "200", "Record Found")); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }

        /// <summary>
        /// To display document status uploaded by company
        /// </summary>
        /// <returns></returns>
        [HttpGet("Status/Document")]
        public async Task<IActionResult> DocumentStatus()
        {
            try
            {
                IEnumerable<DocumentStatusEntity> status = await statusService.GetDocumentStatuses();
                if (status.Count() == 0)
                {
                    return NotFound(new Responses<IEnumerable<DocumentStatusEntity>>(status, "404", "Record not Found")); // To pass result in object along with pagination info
                }
                return Ok(new Responses<IEnumerable<DocumentStatusEntity>>(status, "200", "Record Found")); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }


        /// <summary>
        /// To display tender status
        /// </summary>
        /// <returns></returns>
        [HttpGet("Status/Tender")]
        public async Task<IActionResult> TenderStatus()
        {
            try
            {
                IEnumerable<TenderStatusEntity> status = await statusService.GetTenderStatuses();
                if (status.Count() == 0)
                {
                    return NotFound(new Responses<IEnumerable<TenderStatusEntity>>(status, "404", "Record not Found")); // To pass result in object along with pagination info
                }
                return Ok(new Responses<IEnumerable<TenderStatusEntity>>(status, "200", "Record Found")); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }


        /// <summary>
        /// To display tender submission status
        /// </summary>
        /// <returns></returns>
        [HttpGet("Status/TenderSubmission")]
        public async Task<IActionResult> TenderSubmissionStatus()
        {
            try
            {
                IEnumerable<TenderSubmissionStatus> status = await statusService.GetTenderSubmissionStatuses();
                if (status.Count() == 0)
                {
                    return NotFound(new Responses<IEnumerable<TenderSubmissionStatus>>(status, "404", "Record not Found")); // To pass result in object along with pagination info
                }
                return Ok(new Responses<IEnumerable<TenderSubmissionStatus>>(status, "200", "Record Found")); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }


        /// <summary>
        /// To display all bid status for bidding registration
        /// </summary>
        /// <returns></returns>
        [HttpGet("Status/Bidding/Registration")]
        public async Task<IActionResult> BidRequestStatus()
        {
            try
            {
                IEnumerable<BidRequestStatusEntity> auctionStatuses = await statusService.GetBidRequestStatuses();
                if (auctionStatuses.Count() == 0)
                {
                    return NotFound(new Responses<IEnumerable<BidRequestStatusEntity>>(auctionStatuses, "404", "Record not found")); // To pass result in object along with pagination info

                }
                return Ok(new Responses<IEnumerable<BidRequestStatusEntity>>(auctionStatuses,"200", "Record found")); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }


        /// <summary>
        /// To display all user status
        /// </summary>
        /// <returns></returns>
        [HttpGet("Status/User")]
        public async Task<IActionResult> UserStatus()
        {
            try
            {
                IEnumerable<UserStatusEntity> userStatuses = await statusService.GetUserStatuses();
                if (userStatuses.Count() == 0)
                {
                    return NotFound(new Responses<IEnumerable<UserStatusEntity>>(userStatuses, "404", "Record not found")); // To pass result in object along with pagination info

                }
                return Ok(new Responses<IEnumerable<UserStatusEntity>>(userStatuses,"200","Record found")); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }


        /// <summary>
        /// To display all payment status 
        /// </summary>
        /// <returns></returns>
        [HttpGet("Status/Payment")]
        public async Task<IActionResult> PaymentStatus()
        {
            try
            {
                IEnumerable<PaymentStatusEntity> paymentStatuses = await statusService.GetPaymentStatuses();
                if (paymentStatuses.Count() == 0)
                {
                    return NotFound(new Responses<IEnumerable<PaymentStatusEntity>>(paymentStatuses, "404", "Record not found")); // To pass result in object along with pagination info

                }
                return Ok(new Responses<IEnumerable<PaymentStatusEntity>>(paymentStatuses, "200", "Record found")); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }


        /// <summary>
        /// To display all request help status 
        /// </summary>
        /// <returns></returns>
        [HttpGet("Status/HelpRequest")]
        public async Task<IActionResult> HelpRequestStatus()
        {
            try
            {
                IEnumerable<RequestHelpStatus> requestHelpStatuses = await statusService.GetRequestHelpStatuses();
                if (requestHelpStatuses.Count() == 0)
                {
                    return NotFound(new Responses<IEnumerable<RequestHelpStatus>>(requestHelpStatuses, "404", "Record not found")); // To pass result in object along with pagination info

                }
                return Ok(new Responses<IEnumerable<RequestHelpStatus>>(requestHelpStatuses, "200", "Record found")); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }

    }
}
