using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service.Tender;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.Tender
{
    public class TenderController : Controller
    {
        private readonly ITenderService tenderService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;
        public TenderController(ITenderService tenderService)
        {
            this.tenderService = tenderService;
        }
        /// <summary>
        /// To add tender tender_status_id belong to AuctionStatus
        /// </summary>
        /// <param name="tender"></param>
        /// <returns></returns>
        [HttpPost("Tender")]
        public IActionResult Add([FromBody]AddTenderDto tender)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (tender.Live_Start_Date <= DateTime.Today)
                    {
                        response.statusCode = "400";
                        response.Message = "Start Date must be future date";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    }
                    return Ok(new Responses<GetTenderDto>(tenderService.AddTender(tender), "200", "Record is successfully added"));
                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
        }
            catch (DbUpdateException)
            {
                response.statusCode = "500";
                response.Message = "Internal Server Error";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));

            }

            catch (SqlException)
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
        /// To display all tender list by Admin
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet("Tender")]
        public IActionResult GetAll([FromQuery] PaginationQuery pagination, [FromQuery]string search=null)
        {
            try
            {
                this.uriService = new UriService("https://localhost:44332/Tender");
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<GetTenderDto> tenders = tenderService.GetAllTender(search);
                int totalCount = tenders.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<GetTenderDto>>(tenders, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(tenders, pagination, totalCount)); // To pass result in object along with pagination info
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
        /// To display tender list of bidder's interest by bidder id
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet("InterestTender")]
        public IActionResult GetInterestTender([FromQuery] PaginationQuery pagination, int id, [FromQuery] string search = null)
        {
            try
            {
                this.uriService = new UriService("https://localhost:44332/InterestTender");
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<GetTenderDto> tenders = tenderService.FavouriteTender(id,search);
                int totalCount = tenders.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<GetTenderDto>>(tenders, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(tenders, pagination, totalCount)); // To pass result in object along with pagination info
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
        /// To display all tender list posted by auctioneer by auctioneer id
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet("TenderByAuctioneer")]
        public IActionResult GetTenderByAuctioneer([FromQuery] PaginationQuery pagination, int id, [FromQuery] string search = null)
        {
            try
            {
                this.uriService = new UriService("https://localhost:44332/TenderByAuctioneer");
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<GetTenderDto> tenders = tenderService.GetTenderByAuctioneer(id,search);
                int totalCount = tenders.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<GetTenderDto>>(tenders, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(tenders, pagination, totalCount)); // To pass result in object along with pagination info
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
        /// To display only upcoming tender by bidder
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet("UpcomingTender")]
        public IActionResult GetUpCommingTender([FromQuery] PaginationQuery pagination, [FromQuery] string search = null)
        {
            try
            {
                this.uriService = new UriService("https://localhost:44332/UpComingTender");
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<GetTenderDto> tenders = tenderService.UpcomingTender(search);
                int totalCount = tenders.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<GetTenderDto>>(tenders, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(tenders, pagination, totalCount)); // To pass result in object along with pagination info
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
        /// To display tender list according to tender status id
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet("TenderByStatus")]
        public IActionResult GetTenderByStatus([FromQuery] PaginationQuery pagination, int id, [FromQuery] string search = null)
        {
            try
            {
                this.uriService = new UriService("https://localhost:44332/TenderByStatus");
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<GetTenderDto> tenders = tenderService.TenderByStatus(id,search);
                int totalCount = tenders.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<GetTenderDto>>(tenders, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(tenders, pagination, totalCount)); // To pass result in object along with pagination info
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
        /// To individual detail of tender by tender id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("TenderDetail")]
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
                    GetTenderDto tenderEntity = tenderService.GetTenderDetail(id);
                    if (tenderEntity == null)
                    {
                        response.statusCode = "404";
                        response.Message = "Record not found";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    }
                    return Ok(new Responses<GetTenderDto>(tenderEntity, "200", "Record found"));
                }
            }
            catch (SqlException)
            {
                response.statusCode = "500";
                response.Message = "Something went wrong";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
            catch (ArgumentNullException)
            {
                response.statusCode = "400";
                response.Message = "Invalid Info";
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));

            }
            catch (Exception e)
            {
                response.statusCode = "400";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));

            }
        }

        /// <summary>
        /// To update tender detail
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tender"></param>
        /// <returns></returns>
        [HttpPut("Tender")]
        public IActionResult Update([FromQuery] int id, [FromBody] AddTenderDto tender)
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
                        GetTenderDto tenders = tenderService.UpdateTender(id, tender);
                        if (tenders == null)
                        {
                            response.statusCode = "404";
                            response.Message = "Record not Found";
                            return StatusCode(StatusCodes.Status404NotFound, new ErrorResponse<ResponseMsg>(response));
                        }
                        return Ok(new Responses<GetTenderDto>(tenders, "200", "Record is successfully updated"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Invalid Format";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    }
                }
            }
            catch (SqlException)
            {
                response.statusCode = "500";
                response.Message = "Something went wrong";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));

            }
            catch (ArgumentNullException)
            {
                response.statusCode = "400";
                response.Message = "Invalid Info";
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
            }
            catch (Exception e)
            {
                response.statusCode = "400";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));

            }
        }

        private PagedResponse<GetTenderDto> ResultAfterPagination(IEnumerable<GetTenderDto> tenders, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<GetTenderDto>(tenders, totalCount);
            }

            var get = tenders.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }
    }
}
