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
    public class CallActionController : Controller
    {
        private readonly ICallActionService emailService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;

        public CallActionController(ICallActionService emailService)
        {
            this.emailService = emailService;
        }


        [HttpPost("CallAction/Send")]
        public IActionResult SendCallAction([FromBody] CallActionRequestDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CallActionRequestResponseDto dtop = emailService.AddCallActionEmail(email);
                    return Ok(new Responses<CallActionRequestResponseDto>(dtop, "200", "Record is successfully added"));
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


        [HttpGet("CallAction/List")]
        public IActionResult GetAllCallAction([FromQuery] PaginationQuery pagination, [FromQuery] bool nested = false)
        {
            try
            {
                string url = Url.Action("GetAllCallAction", null, null, Request.Scheme); //get url for current request
                uriService = new UriService(url);
                List<CallActionResponseDto> email = null;
                if (nested)
                {
                    email = emailService.GetAllCallActionNested();
                }
                else
                {
                    email = emailService.GetAllCallAction();
                }
                int totalCount = email.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<CallActionResponseDto>>(email, "404", "Record not found"));
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

        [HttpGet("CallAction/Detail")]
        public IActionResult GetCallActionDetail([FromQuery] int id)
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
                    CallActionResponseDto email = emailService.GetCallActionDetail(id);
                    if (email == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new Responses<CallActionResponseDto>(email, "404", "Record not found"));
                    }
                    return Ok(new Responses<CallActionResponseDto>(email, "200", "Record found"));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "400";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));

            }
        }

        [HttpPost("CallAction/Read")]
        public IActionResult ReadCallAction([FromQuery] int id)
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
                        ResponseMsg response = emailService.ReadCallActionEmail(id);
                        //if (getCity.Id == 0)
                        //{
                        //    response.statusCode = "400";
                        //    response.Message = "Invalid District";
                        //    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                        //}
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


        private PagedResponse<CallActionResponseDto> ResultAfterPagination(IEnumerable<CallActionResponseDto> emails, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<CallActionResponseDto>(emails, totalCount);
            }

            var get = emails.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

    }
}
