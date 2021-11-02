using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.Correspondence
{
    public class EmailController : Controller
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
        /// Send an email before tender goes to auction. Email sent by bidder
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Bidder/PreAuction/Send")]
        public IActionResult SendPreAuctionEmail([FromBody] SendEmailDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isTenderFound = false;

                    EmailResponseDto res = emailService.SendPreAuctionEmail(email, out isTenderFound);
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
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }



        /// <summary>
        /// Reply to a pre auction email. Reply is done by admin only
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Admin/PreAuction/Reply")]
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
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }



        /// <summary>
        /// Reply to a pre auction email. Reply is done by bidder on admin reply email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Bidder/PreAuction/Reply")]
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
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        /// <summary>
        /// Email draft composed by bidder.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Bidder/PreAuction/Draft/Save")]
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
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// Send draft email composed by bidder.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Bidder/PreAuction/Draft/Send")]
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
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }



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
                    EmailResponseDto res = null;// emailService.ReplyPreAuctionEmail(email);
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
        public IActionResult SendDraftPreAuctionEmailAdmin([FromBody] SendEmailDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmailResponseDto res = null;// emailService.ReplyPreAuctionEmail(email);
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
        /// Send an email after tender goes to auction and won by bidder. Email sent by Bidder
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Bidder/PostAuction/Send")]
        public IActionResult SendPostAuctionEmail([FromBody] SendEmailDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isTenderFound = false;
                    EmailResponseDto res = emailService.SendPostAuctionEmail(email, out isTenderFound);
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
        /// Email draft composed by bidder
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Bidder/PostAuction/Draft/Save")]
        public IActionResult SaveDraftPostAuctionEmailBidder([FromBody] SendEmailDto email)
        {
            throw new NotImplementedException();
            try
            {
                if (ModelState.IsValid)
                {
                    bool isTenderFound = false;
                    EmailResponseDto res = emailService.SendPostAuctionEmail(email, out isTenderFound);
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
        /// Email draft composed by bidder
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Bidder/PostAuction/Draft/Send")]
        public IActionResult SendDraftPostAuctionEmailBidder([FromBody] SendEmailDto email)
        {
            throw new NotImplementedException();
            try
            {
                if (ModelState.IsValid)
                {
                    bool isTenderFound = false;
                    EmailResponseDto res = emailService.SendPostAuctionEmail(email, out isTenderFound);
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
        /// Send an email after tender goes to auction and won by bidder. Email sent by Bid Inviter
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/BidInviter/PostAuction/Send")]
        public IActionResult SendPostAuctionEmailByBidInviter([FromBody] SendEmailDto email)
        {
            throw new NotImplementedException();
            try
            {
                if (ModelState.IsValid)
                {
                    bool isTenderFound = false;
                    EmailResponseDto res = emailService.SendPostAuctionEmail(email, out isTenderFound);
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
        /// Reply to a email after auction by a bid inviter
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/BidInviter/PostAuction/Reply")]
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
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// Email draft composed by bid inviter
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/BidInviter/PostAuction/Draft/Save")]
        public IActionResult SaveDraftPostAuctionEmailByTenderAdmin([FromBody] ReplyEmailDto email)
        {
            throw new NotImplementedException();
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
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }



        /// <summary>
        /// Send draft email composed by bid inviter
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/BidInviter/PostAuction/Draft/Send")]
        public IActionResult SendDraftPostAuctionEmailByTenderAdmin([FromBody] ReplyEmailDto email)
        {
            throw new NotImplementedException();
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
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }




        /// <summary>
        /// Send an email after tender goes to auction and won by bidder. Email sent by Admin
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Admin/PostAuction/Send")]
        public IActionResult SendPostAuctionEmailByAdmin([FromBody] SendEmailDto email)
        {
            throw new NotImplementedException();
            try
            {
                if (ModelState.IsValid)
                {
                    bool isTenderFound = false;
                    EmailResponseDto res = emailService.SendPostAuctionEmail(email, out isTenderFound);
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
        /// Reply to a email after acution by an admin
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Admin/PostAuction/Reply")]
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
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// Email draft composed by admin
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Admin/PostAuction/Draft/Save")]
        public IActionResult SaveDraftPostAuctionEmailByAdmin([FromBody] ReplyEmailDto email)
        {
            throw new NotImplementedException();
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
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// Send draft email coposed by admin
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Email/Admin/PostAuction/Draft/Send")]
        public IActionResult SendDraftPostAuctionEmailByAdmin([FromBody] ReplyEmailDto email)
        {
            throw new NotImplementedException();
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
                response.Message = e.Message;
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
               
                int totalCount = email.Count();
                if (email == null || totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<EmailResponseDto>>(email, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(email, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
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

                int totalCount = email.Count();
                if (email == null || totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<EmailResponseDto>>(email, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(email, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }



        /// <summary>
        /// Email detail
        /// </summary>
        /// <param name="emaiId"></param>
        /// <returns></returns>
        [HttpGet("Email/Detail")]
        public IActionResult GetEmailDetail([FromQuery] long emaiId)
        {
            try
            {
                if (emaiId == 0)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
                else
                {
                    EmailResponseDto email = emailService.GetEmailDetail(emaiId);
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
                response.Message = e.Message;
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
                    response.Message = "Invalid Format";
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
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    }
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
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

    }
}
