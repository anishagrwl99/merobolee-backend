using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service.SMTPMail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.DisplayMail
{
    public class DisplayMailController : Controller
    {
        private readonly IDisplayMailService displayService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;
        public DisplayMailController(IDisplayMailService displayMailService)
        {
            this.displayService = displayMailService;
        }

        /// <summary>
        /// To show reply from merobolee to bidder
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("Clarificaiton")]
        public IActionResult GetAll([FromQuery] PaginationQuery pagination, [FromBody] string email)
        {
            try
            {
                string url = Url.Action("GetAll", null, null, Request.Scheme); //get url for current request
                this.uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<MailEntity> mail = displayService.ShowReceiveMail(email);
                int totalCount = mail.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<MailEntity>>(mail, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(mail, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (SqlException)
            {
                response.statusCode = "500";
                response.Message = "Something went wrong";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
            catch (InvalidOperationException)
            {
                response.statusCode = "500";
                response.Message = "Something went wrong";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
            catch (Exception e)
            {
                response.statusCode = "400";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
            }

        }

        /// <summary>
        /// To sent mail from bidder to merobolee
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("Correspondence")]
        public IActionResult GetSentByBidder([FromQuery] PaginationQuery pagination, [FromBody] string email)
        {
            try
            {
                string url = Url.Action("GetSentByBidder", null, null, Request.Scheme); //get url for current request
                this.uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<MailEntity> mail = displayService.ShowSentMail(email);
                int totalCount = mail.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<MailEntity>>(mail, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(mail, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (SqlException)
            {
                response.statusCode = "500";
                response.Message = "Something went wrong";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
            catch (InvalidOperationException)
            {
                response.statusCode = "500";
                response.Message = "Something went wrong";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
            catch (Exception e)
            {
                response.statusCode = "400";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
            }

        }

        /// <summary>
        /// To sent mail from bidder to merobolee
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("CallForAction")]
        public IActionResult CallForAction([FromQuery] PaginationQuery pagination, [FromBody] string email)
        {
            try
            {
                string url = Url.Action("CallForAction", null, null, Request.Scheme); //get url for current request
                this.uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<MailEntity> mail = displayService.CallForAction(email);
                int totalCount = mail.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<MailEntity>>(mail, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(mail, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (SqlException)
            {
                response.statusCode = "500";
                response.Message = "Something went wrong";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
            catch (InvalidOperationException)
            {
                response.statusCode = "500";
                response.Message = "Something went wrong";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
            catch (Exception e)
            {
                response.statusCode = "400";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
            }

        }

        /// <summary>
        /// To show reply from merobolee to bidder
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet("AllSentMail")]
        public IActionResult GetSentMail([FromQuery] PaginationQuery pagination)
        {
            try
            {
                string url = Url.Action("GetSentMail", null, null, Request.Scheme); //get url for current request
                this.uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<MailEntity> mail = displayService.ShowSendMail();
                int totalCount = mail.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<MailEntity>>(mail, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(mail, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (SqlException)
            {
                response.statusCode = "500";
                response.Message = "Something went wrong";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
            catch (InvalidOperationException)
            {
                response.statusCode = "500";
                response.Message = "Something went wrong";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
            catch (Exception e)
            {
                response.statusCode = "400";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
            }

        }

        private PagedResponse<MailEntity> ResultAfterPagination(IEnumerable<MailEntity> getCategory, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<MailEntity>(getCategory, totalCount);
            }

            var get = getCategory.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

    }
}
