using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.FAQ
{
    public class FAQController : Controller
    {
        private readonly IFAQService FAQService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;

        public FAQController(IFAQService FAQService)
        {
            this.FAQService = FAQService;
        }
        /// <summary>
        /// To add FAQ
        /// </summary>
        /// <returns></returns>
        [HttpPost("FAQ")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public IActionResult Add([FromBody] FAQAddDto addFAQ)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    return Ok(new Responses<FAQResponseDto>(FAQService.PostQuestion(addFAQ), "200", "Record is successfully added"));
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
        /// To update FAQ info and status is commonStatus
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addFAQ"></param>
        /// <returns></returns>
        [HttpPut("FAQ")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public IActionResult Update([FromBody] FAQAddDto addFAQ, [FromQuery] int id)
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
                        FAQResponseDto getFAQ = FAQService.UpdateFAQ(id, addFAQ);
                        if (getFAQ == null)
                        {
                            response.statusCode = "404";
                            response.Message = "Record not Found";
                            return StatusCode(StatusCodes.Status404NotFound, new ErrorResponse<ResponseMsg>(response));
                        }
                        return Ok(new Responses<FAQResponseDto>(getFAQ, "200", "Record is successfully updated"));
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
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));

            }
        }



        /// <summary>
        /// To delete FAQ record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteFAQ")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public IActionResult Delete([FromQuery] int id)
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
                    FAQService.DeleteFAQ(id);
                    response.statusCode = "200";
                    response.Message = "Record is successfully deleted";
                    return Ok(new ErrorResponse<ResponseMsg>(response));
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
        /// To display all FAQ by Admin
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet("FAQ")]
        public IActionResult GetAll([FromQuery] PaginationQuery pagination)
        {
            try
            {
                string url = Url.Action("GetAll", null, null, Request.Scheme); //get url for current request
                this.uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<FAQResponseDto> FAQ = FAQService.GetAllFAQ();
                int totalCount = FAQ.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<FAQResponseDto>>(FAQ, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(FAQ, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }


        /// <summary>
        /// To get individual FAQ detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("FAQDetail")]
        public IActionResult GetById([FromQuery] int id)
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
                    FAQResponseDto getFAQ = FAQService.GetFAQ(id);
                    if (getFAQ == null)
                    {
                        response.statusCode = "404";
                        response.Message = "Record not found";
                        return StatusCode(StatusCodes.Status404NotFound, new ErrorResponse<ResponseMsg>(response));
                    }
                    return Ok(new Responses<FAQResponseDto>(getFAQ, "200", "Record found"));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));

            }
        }


        private PagedResponse<FAQResponseDto> ResultAfterPagination(IEnumerable<FAQResponseDto> getFAQ, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<FAQResponseDto>(getFAQ, totalCount);
            }

            var get = getFAQ.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }
    }
}
