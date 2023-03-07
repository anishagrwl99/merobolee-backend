using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.WatchList
{
    [Authorize(Roles = "Bidder")]
    public class WatchListController : BaseController
    {
        private readonly IWatchListService watchListService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;

        public WatchListController(IWatchListService watchListService)
        {
            this.watchListService = watchListService;
        }

        /// <summary>
        /// To add upcoming bid in watch list
        /// </summary>
        /// <returns></returns>
        [HttpPost("Tender/AddToWatchList")]
        public IActionResult Add([FromBody]AddWatchList watchListEntity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AddWatchList wl =  watchListService.AddWatchList(watchListEntity);
                    if (wl != null)
                    {
                        response.statusCode = "200";
                        response.Message = "Sucessfully added in watchlist";
                        response.Data = wl; 
                        return StatusCode(StatusCodes.Status200OK, new ErrorResponse<ResponseMsg>(response));
                    }
                    else
                    {
                        response.statusCode = "208";
                        response.Message = "Tender already added into watchlist";
                        response.Data = ModelState;
                        return StatusCode(StatusCodes.Status208AlreadyReported, new ErrorResponse<ResponseMsg>(response));
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
        /// To show interest bid of bidder
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        /// <param name="procurementId"></param>
        /// <param name="algoId"></param>
        /// <returns></returns>
        [HttpGet("Tender/WatchLists")]
        public IActionResult GetAll([FromQuery] PaginationQuery pagination, [FromQuery] long userId, [FromQuery] long companyId, [FromQuery] string procurementId, [FromQuery] string algoId)
        {
            try
            {
                if (userId == 0)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
                string url = Url.Action("GetAll", null, new { userId = userId }, Request.Scheme); //get url for current request
                this.uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<TenderWatchListCard> watchList = watchListService.GetAllWatchList(userId, companyId,procurementId,algoId);
                int totalCount = watchList.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<TenderWatchListCard>>(watchList, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(watchList, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }

        /// <summary>
        /// To remove bid from watchlist by watchlist'sprimary key
        /// </summary>
        /// <param name="watchlistId"></param>
        /// <returns></returns>
        [HttpDelete("Tender/RemoveFromWatchList")]
        public IActionResult Delete([FromQuery] int watchlistId)
        {
            try
            {
                if (watchlistId == 0)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid watchlist id";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
                else
                {
                    watchListService.RemoveWatchList(watchlistId);
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

        private PagedResponse<TenderWatchListCard> ResultAfterPagination(IEnumerable<TenderWatchListCard> watchListDtos, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<TenderWatchListCard>(watchListDtos, totalCount);
            }

            var get = watchListDtos.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }
    }
}
