using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service.WatchList;
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
    public class WatchListController : Controller
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
        public async Task<IActionResult> Add(AddWatchList watchListEntity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    watchListService.AddWatchList(watchListEntity);
                    response.statusCode = "200";
                    response.Message = "Sucessfully added in watchlist";
                     return StatusCode(StatusCodes.Status200OK, new ErrorResponse<ResponseMsg>(response));
                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }

            }
            catch (UnauthorizedAccessException)
            {
                response.statusCode = "400";
                response.Message = "Username or Email already exists";
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
            }

            catch (DbUpdateException)
            {
                response.statusCode = "500";
                response.Message = "Internal Server Error";
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));

            }
            catch (SqlException)
            {
                response.statusCode = "500";
                response.Message = "Something went wrong";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
            }
        }

        /// <summary>
        /// To show interest bid of bidder
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet("Tender/WatchLists")]
        public IActionResult GetAll([FromQuery] PaginationQuery pagination, [FromQuery] int supplierId )
        {
            try
            {
                if (supplierId == 0)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
                string url = Url.Action("GetAll", null, null, Request.Scheme); //get url for current request
                this.uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<GetWatchListDto> watchList = watchListService.GetAllWatchList(supplierId);
                int totalCount = watchList.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<GetWatchListDto>>(watchList, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(watchList, pagination, totalCount)); // To pass result in object along with pagination info
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
        /// To remove bid from watchlist by watchlist'sprimary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Tender/RemoveFromWatchList")]
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
                    watchListService.RemoveWatchList(id);
                    response.statusCode = "200";
                    response.Message = "Record is successfully deleted";
                    return Ok(new ErrorResponse<ResponseMsg>(response));
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

        private PagedResponse<GetWatchListDto> ResultAfterPagination(IEnumerable<GetWatchListDto> watchListDtos, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<GetWatchListDto>(watchListDtos, totalCount);
            }

            var get = watchListDtos.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }
    }
}
