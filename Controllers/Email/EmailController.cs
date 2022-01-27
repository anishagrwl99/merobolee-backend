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

namespace MeroBolee.Controllers.Correspondence
{
    public class EmailController : BaseController
    {
        private readonly IEmailService emailService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;

        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }


        /// <summary>
        /// Reply to a pre auction email. Reply is done by admin only
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Admin/PreAuction/Reply")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public IActionResult ReplyToPreAuctionEmail([FromBody] ReplyEmailDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmailResponseDto res = emailService.ReplyPreAuctionEmailByAdmin(email);
                    if (res != null)
                    {
                        return Ok(new Responses<EmailResponseDto>(res, "200", "Email is successfully sent"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Tender code is invalid";
                        response.Data = ModelState;
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
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
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }



        /// <summary>
        /// Send an email before tender goes to auction. Email sent by bidder
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Bidder/PreAuction/Send")]
        [Authorize(Roles = "Bidder")]
        public IActionResult SendPreAuctionEmail([FromBody] SendEmailDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmailResponseDto res = emailService.SendPreAuctionEmailBidder(email,  false);
                    if (res != null)
                    {
                        return Ok(new Responses<EmailResponseDto>(res, "200", "Email is successfully sent"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Tender code is invalid";
                        response.Data = ModelState;
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
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
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }



        /// <summary>
        /// Reply to a pre auction email. Reply is done by bidder on admin reply email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Bidder/PreAuction/Reply")]
        [Authorize(Roles = "Bidder")]
        public IActionResult ReplyToPreAuctionEmailBidder([FromBody] ReplyEmailDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmailResponseDto res = emailService.ReplyPreAuctionEmailByBidder(email);
                    if (res != null)
                    {
                        return Ok(new Responses<EmailResponseDto>(res, "200", "Email is successfully sent"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Tender code is invalid";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
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
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        /// <summary>
        /// Email draft composed by bidder.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Bidder/PreAuction/Draft/Save")]
        [Authorize(Roles = "Bidder")]
        public IActionResult SaveDraftPreAuctionEmailBidder([FromBody] SendEmailDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmailResponseDto res = emailService.SaveDraftPreAuctionEmailBidder(email);
                    if (res != null)
                    {
                        return Ok(new Responses<EmailResponseDto>(res, "200", "Email is successfully sent"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Tender code is invalid";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
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
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// Send draft email composed by bidder.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Bidder/PreAuction/Draft/Send")]
        [Authorize(Roles = "Bidder")]
        public IActionResult SendDraftPreAuctionEmailBidder([FromBody] ReplyEmailDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmailResponseDto res =  emailService.SendDraftEmail(email);
                    if (res != null)
                    {
                        return Ok(new Responses<EmailResponseDto>(res, "200", "Email is successfully sent"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Tender code is invalid";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
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
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        /*

        /// <summary>
        /// Email draft composed by admin.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Admin/PreAuction/Draft/Save")]
        public IActionResult SaveDraftPreAuctionEmailAdmin([FromBody] SendEmailDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmailResponseDto res =  emailService.SaveDraftPreAuctionEmailAdmin(email);
                    if (res != null)
                    {
                        return Ok(new Responses<EmailResponseDto>(res, "200", "Email is successfully sent"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Tender code is invalid";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
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
        /// Send draft email composed by admin.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Admin/PreAuction/Draft/Send")]
        public IActionResult SendDraftPreAuctionEmailAdmin([FromBody] ReplyEmailDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmailResponseDto res =  emailService.SendDraftEmail(email);
                    if (res != null)
                    {
                        return Ok(new Responses<EmailResponseDto>(res, "200", "Email is successfully sent"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Tender code is invalid";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
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

        */

        /// <summary>
        /// Send an email after tender goes to auction and won by bidder. Email sent by Bidder
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Bidder/PostAuction/Send")]
        [Authorize(Roles = "Bidder")]
        public IActionResult SendPostAuctionEmailBidder([FromBody] SendEmailDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmailResponseDto res = emailService.SavePostAuctionEmailBidder(email, false);
                    if (res != null)
                    {
                        return Ok(new Responses<EmailResponseDto>(res, "200", "Email is successfully sent"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Tender code is invalid";
                        response.Data = ModelState;
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
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
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        /// <summary>
        /// Email draft composed by bidder
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Bidder/PostAuction/Draft/Save")]
        [Authorize(Roles = "Bidder")]
        public IActionResult SaveDraftPostAuctionEmailBidder([FromBody] SendEmailDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmailResponseDto res = emailService.SavePostAuctionEmailBidder(email, true);
                    if (res != null)
                    {
                        return Ok(new Responses<EmailResponseDto>(res, "200", "Email is successfully sent"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Tender code is invalid";
                        response.Data = ModelState;
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
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
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// Email draft composed by bidder
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Bidder/PostAuction/Draft/Send")]
        [Authorize(Roles = "Bidder")]
        public IActionResult SendDraftPostAuctionEmailBidder([FromBody] ReplyEmailDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmailResponseDto res = emailService.SendDraftEmail(email);
                    if (res != null)
                    {
                        return Ok(new Responses<EmailResponseDto>(res, "200", "Email is successfully sent"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Tender code is invalid";
                        response.Data = ModelState;
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
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
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// Send an email after tender goes to auction and won by bidder. Email sent by Bid Inviter
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/BidInviter/PostAuction/Send")]
        [Authorize(Roles = "Bid Inviter")]
        public IActionResult SendPostAuctionEmailByBidInviter([FromBody] SendEmailDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmailResponseDto res = emailService.SendPostAuctionEmailBidInviter(email, false);
                    if (res != null)
                    {
                        return Ok(new Responses<EmailResponseDto>(res, "200", "Email is successfully sent"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Tender code is invalid or tender winner is not decided yet";
                        response.Data = ModelState;
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
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
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        /// <summary>
        /// Reply to a email after auction by a bid inviter
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/BidInviter/PostAuction/Reply")]
        [Authorize(Roles = "Bid Inviter")]
        public IActionResult ReplyToPostAuctionEmailByTenderAdmin([FromBody] ReplyEmailDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmailResponseDto res = emailService.ReplyPostAuctionEmailByBidInviter(email);
                    if (res != null)
                    {
                        return Ok(new Responses<EmailResponseDto>(res, "200", "Email is successfully sent"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Tender code is invalid";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
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
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// Email draft composed by bid inviter
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/BidInviter/PostAuction/Draft/Save")]
        [Authorize(Roles = "Bid Inviter")]
        public IActionResult SaveDraftPostAuctionEmailByTenderAdmin([FromBody] SendEmailDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmailResponseDto res = emailService.SendPostAuctionEmailBidInviter(email, true);
                    if (res != null)
                    {
                        return Ok(new Responses<EmailResponseDto>(res, "200", "Email is successfully sent"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Tender code is invalid";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
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
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }



        /// <summary>
        /// Send draft email composed by bid inviter
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/BidInviter/PostAuction/Draft/Send")]
        [Authorize(Roles = "Bid Inviter")]
        public IActionResult SendDraftPostAuctionEmailByTenderAdmin([FromBody] ReplyEmailDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmailResponseDto res = emailService.SendDraftEmail(email);
                    if (res != null)
                    {
                        return Ok(new Responses<EmailResponseDto>(res, "200", "Email is successfully sent"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Tender code is invalid";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
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
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }




        /// <summary>
        /// Send an email after tender goes to auction and won by bidder. Email sent by Admin
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Admin/PostAuction/Send")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public IActionResult SendPostAuctionEmailByAdmin([FromBody] SendEmailDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmailResponseDto res = emailService.SendPostAuctionEmailAdmin(email, false);
                    if (res != null)
                    {
                        return Ok(new Responses<EmailResponseDto>(res, "200", "Email is successfully sent"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Tender code is invalid";
                        response.Data = ModelState;
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
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
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// Reply to a email after acution by an admin
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Admin/PostAuction/Reply")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public IActionResult ReplyToPostAuctionEmailByAdmin([FromBody] ReplyEmailDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmailResponseDto res = emailService.ReplyPostAuctionEmailByAdmin(email);
                    if (res != null)
                    {
                        return Ok(new Responses<EmailResponseDto>(res, "200", "Email is successfully sent"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Tender code is invalid";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
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
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// Email draft composed by admin
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Admin/PostAuction/Draft/Save")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public IActionResult SaveDraftPostAuctionEmailByAdmin([FromBody] SendEmailDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmailResponseDto res = emailService.SendPostAuctionEmailAdmin(email,true);
                    if (res != null)
                    {
                        return Ok(new Responses<EmailResponseDto>(res, "200", "Email is successfully sent"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Tender code is invalid";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
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
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// Send draft email coposed by admin
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Admin/PostAuction/Draft/Send")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public IActionResult SendDraftPostAuctionEmailByAdmin([FromBody] ReplyEmailDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmailResponseDto res = emailService.SendDraftEmail(email);
                    if (res != null)
                    {
                        return Ok(new Responses<EmailResponseDto>(res, "200", "Email is successfully sent"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Tender code is invalid";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
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
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        /// <summary>
        /// All email inbox for a user
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet("Email/Inbox")]
        public IActionResult GetInbox([FromQuery] PaginationQuery pagination, [FromQuery] long userId, [FromQuery] long companyId)
        {
            try
            {
                string url = Url.Action("GetInbox", null, new { userId = userId, companyId=companyId}, Request.Scheme); //get url for current request
                uriService = new UriService(url);
                List<EmailResponseDto> email = emailService.GetInbox(userId);
               
                int totalCount = email == null? 0 : email.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<EmailResponseDto>>(email, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(email, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        /// <summary>
        /// All technical support email inbox for a user
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet("Email/Inbox/TechnicalSupport")]
        public IActionResult GetTechnicalSupportInbox([FromQuery] PaginationQuery pagination, [FromQuery] long userId, [FromQuery] long companyId)
        {
            try
            {
                string url = Url.Action("GetTechnicalSupportInbox", null, new { userId = userId, companyId = companyId }, Request.Scheme); //get url for current request
                uriService = new UriService(url);
                List<TechnicalSupportEmailResponseDto> email = emailService.GetTechnicalSupportInbox(userId);

                int totalCount = email == null ? 0 : email.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<TechnicalSupportEmailResponseDto>>(email, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(email, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }



        /// <summary>
        /// Email outbox for a user
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet("Email/Outbox")]
        public IActionResult Outbox([FromQuery] PaginationQuery pagination, [FromQuery] long userId, [FromQuery] long companyId)
        {
            try
            {
                string url = Url.Action("Outbox", null, new { userId = userId, companyId = companyId }, Request.Scheme); //get url for current request
                uriService = new UriService(url);
                List<EmailResponseDto> email = emailService.GetOutbox(userId);

                int totalCount = email == null? 0:  email.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<EmailResponseDto>>(email, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(email, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        /// <summary>
        /// Get Technical Support email outbox for a user
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet("Email/Outbox/TechnicalSupport")]
        public IActionResult TechnicalSupportOutbox([FromQuery] PaginationQuery pagination, [FromQuery] long userId, [FromQuery] long companyId)
        {
            try
            {
                string url = Url.Action("TechnicalSupportOutbox", null, new { userId = userId, companyId = companyId }, Request.Scheme); //get url for current request
                uriService = new UriService(url);
                List<TechnicalSupportEmailResponseDto> email = emailService.GetTechnicalSupportOutbox(userId);

                int totalCount = email == null ? 0 : email.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<TechnicalSupportEmailResponseDto>>(email, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(email, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }



        /// <summary>
        /// Email drafts of a user
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet("Email/Draft")]
        public IActionResult Draft([FromQuery] PaginationQuery pagination, [FromQuery] long userId, [FromQuery] long companyId)
        {
            try
            {
                string url = Url.Action("Draft", null, new { userId = userId, companyId = companyId }, Request.Scheme); //get url for current request
                uriService = new UriService(url);
                List<EmailResponseDto> email = emailService.GetDraft(userId);

                int totalCount = email == null? 0:  email.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<EmailResponseDto>>(email, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(email, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// Email detail
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
        [HttpGet("Email/Detail")]
        public IActionResult GetEmailDetail([FromQuery] long emailId)
        {
            try
            {
                if (emailId == 0)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid email id";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
                else
                {
                    EmailResponseDto email = emailService.GetEmailDetail(emailId);
                    if (email == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new Responses<EmailResponseDto>(email, "404", "Record not found"));
                    }
                    return Ok(new Responses<EmailResponseDto>(email, "200", "Record found"));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));

            }
        }


        /// <summary>
        /// Email detail
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
        [HttpGet("Email/Detail/TechnicalSupport")]
        public IActionResult GetTechnicalSupportEmailDetail([FromQuery] long emailId)
        {
            try
            {
                if (emailId == 0)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid email id";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
                else
                {
                    TechnicalSupportEmailResponseDto email = emailService.GetTechnicalSupportEmailDetail(emailId);
                    if (email == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new Responses<TechnicalSupportEmailResponseDto>(email, "404", "Record not found"));
                    }
                    return Ok(new Responses<TechnicalSupportEmailResponseDto>(email, "200", "Record found"));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));

            }
        }


        /// <summary>
        /// Mark email as a read
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpPost("Email/Read")]
        public IActionResult ReadEmail([FromQuery] long emailId, [FromQuery] long userId, [FromQuery] long companyId)
        {
            try
            {
                if (emailId == 0 || userId == 0)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid email id or user id";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        bool res = emailService.ReadEmail(emailId, userId);
                        if (!res)
                        {
                            response.statusCode = "404";
                            response.Message = "Record not found";
                            return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                        }

                        return Ok(new Responses<ResponseMsg>(null, "200", "Email status set to read"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Invalid Format";
                        response.Data = ModelState;
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    }
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));

            }
        }

        /// <summary>
        /// Mark email as a read
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpPost("Email/Read/TechnicalSupport")]
        public IActionResult ReadTechnicalSupportEmail([FromQuery] long emailId, [FromQuery] long userId, [FromQuery] long companyId)
        {
            try
            {
                if (emailId == 0 || userId == 0)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid email id or user id";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        bool res = emailService.ReadTechnicalSupportEmail(emailId, userId);
                        if (!res)
                        {
                            response.statusCode = "404";
                            response.Message = "Record not found";
                            return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                        }

                        return Ok(new Responses<ResponseMsg>(null, "200", "Email status set to read"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Invalid Format";
                        response.Data = ModelState;
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    }
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));

            }
        }


        private PagedResponse<EmailResponseDto> ResultAfterPagination(IEnumerable<EmailResponseDto> emails, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<EmailResponseDto>(emails, totalCount);
            }

            var get = emails.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

        private PagedResponse<TechnicalSupportEmailResponseDto> ResultAfterPagination(IEnumerable<TechnicalSupportEmailResponseDto> emails, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<TechnicalSupportEmailResponseDto>(emails, totalCount);
            }

            var get = emails.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

    }
}
