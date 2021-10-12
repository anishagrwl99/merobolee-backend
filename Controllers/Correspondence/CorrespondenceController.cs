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
    public class CorrespondenceController : Controller
    {
        private readonly ICorrespondenceService emailService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;

        public CorrespondenceController(ICorrespondenceService emailService)
        {
            this.emailService = emailService;
        }


        [HttpPost("Correspondence/Send")]
        public IActionResult SendCorrespondence([FromBody] CorrespondenceRequestDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CorrespondenceRequestResponseDto dtop= emailService.AddCorrespondenceEmail(email);
                    return Ok(new Responses<CorrespondenceRequestResponseDto>(dtop, "200", "Record is successfully added"));
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


        [HttpGet("Correspondence/List")]
        public IActionResult GetAllCorrespondence([FromQuery] PaginationQuery pagination, [FromQuery] int userId)
        {
            try
            {
                string url = Url.Action("GetAllCorrespondence", null, null, Request.Scheme); //get url for current request
                uriService = new UriService(url);
                List<CorrespondenceResponseDto> email = emailService.GetAllCorrespondances(userId);;
                int totalCount = email.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<CorrespondenceResponseDto>>(email, "404", "Record not found"));
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

        [HttpGet("Correspondence/Detail")]
        public IActionResult GetCorrespondenceDetail([FromQuery] int id)
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
                    CorrespondenceResponseDto email = emailService.GetCorrespondanceDetail(id);
                    if (email == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new Responses<CorrespondenceResponseDto>(email, "404", "Record not found"));
                    }
                    return Ok(new Responses<CorrespondenceResponseDto>(email, "200", "Record found"));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "400";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));

            }
        }

        [HttpPost("Correspondence/Read")]
        public IActionResult ReadCorrespondence([FromQuery] int id)
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
                        ResponseMsg response = emailService.ReadCorrespondanceEmail(id);
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


        private PagedResponse<CorrespondenceResponseDto> ResultAfterPagination(IEnumerable<CorrespondenceResponseDto> emails, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<CorrespondenceResponseDto>(emails, totalCount);
            }

            var get = emails.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

    }
}
