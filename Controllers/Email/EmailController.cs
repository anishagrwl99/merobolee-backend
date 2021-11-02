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


        [HttpPost("Email/Send/PreAuction")]
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


        [HttpPost("Email/Send/PostAuction")]
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
