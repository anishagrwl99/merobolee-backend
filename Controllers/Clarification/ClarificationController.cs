using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers
{
    public class ClarificationController : Controller
    {
        private readonly IClarificationService emailService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;

        public ClarificationController(IClarificationService emailService)
        {
            this.emailService = emailService;
        }


        [HttpPost("Clarification/Send")]
        public IActionResult SendClarification([FromBody] ClarificationRequestDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ClarificationRequestResponseDto dto = emailService.AddClarificationEmail(email);
                    return Ok(new Responses<ClarificationRequestResponseDto>(dto, "200", "Record is successfully added"));
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
                response.statusCode = "400";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
            }
        }


        [HttpGet("Clarification/List")]
        public IActionResult GetAllClarification([FromQuery] PaginationQuery pagination, [FromQuery] int userId)
        {
            try
            {
                string url = Url.Action("GetAllClarification", null, null, Request.Scheme); //get url for current request
                uriService = new UriService(url);
                List<ClarificationResponseDto> email = emailService.GetAllClarification(userId);;
                int totalCount = email.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<ClarificationResponseDto>>(email, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(email, pagination, totalCount)); // To pass result in object along with pagination info
            }            
            catch (Exception e)
            {
                response.statusCode = "400";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
            }
        }

        [HttpGet("Clarification/Detail")]
        public IActionResult GetClarificationDetail([FromQuery] int id)
        {
            try
            {
                if (id == 0)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
                else
                {
                    ClarificationResponseDto email = emailService.GetClarificationDetail(id);
                    if (email == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new Responses<ClarificationResponseDto>(email, "404", "Record not found"));
                    }
                    return Ok(new Responses<ClarificationResponseDto>(email, "200", "Record found"));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "400";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));

            }
        }

        [HttpPost("Clarification/Read")]
        public IActionResult ReadClarification([FromQuery] int id)
        {
            try
            {
                if (id == 0)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        ResponseMsg response = emailService.ReadClarificationEmail(id);
                        if (response == null)
                        {
                            response.statusCode = "404";
                            response.Message = "Record not found";
                            return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                        }
                        return Ok(new Responses<ResponseMsg>(null, "200", response.Message));
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
                response.statusCode = "400";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));

            }
        }


        private PagedResponse<ClarificationResponseDto> ResultAfterPagination(IEnumerable<ClarificationResponseDto> emails, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<ClarificationResponseDto>(emails, totalCount);
            }

            var get = emails.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

    }
}
