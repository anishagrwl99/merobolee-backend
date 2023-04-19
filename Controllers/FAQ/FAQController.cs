using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeroBolee.Controllers.FAQ
{
    public class FAQController : AuthorizeController
    {
        private readonly IFAQService FAQService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();

        public FAQController(IFAQService FAQService)
        {
            this.FAQService = FAQService;
        }
        /// <summary>
        /// To add FAQ
        /// </summary>
        /// <returns></returns>
        [HttpPost("FAQ")]
        [Authorize(Roles = "Super Admin, Tender Support")]
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
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
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
                    response.Message = "Invalid faq id";
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
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
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
                    response.Message = "Invalid faq id";
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
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }
    }
}
