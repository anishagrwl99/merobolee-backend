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

namespace MeroBolee.Controllers.FavouriteCategory
{
    [Authorize(Roles = "Bidder")]
    public class FavouriteCategoryController : BaseController
    {
        private readonly IFavouriteCategoryService favouriteCategoryService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;
        public FavouriteCategoryController(IFavouriteCategoryService favouriteCategoryService)
        {
            this.favouriteCategoryService = favouriteCategoryService;
        }

        /// <summary>
        /// To add category as favourite by bidder
        /// </summary>
        /// <returns></returns>
        [HttpPost("FavouriteCategory")]
        public IActionResult Add([FromBody] FavouriteCategoryEntity favourite)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    response.statusCode = "200";
                    response.Message = "Successfully Added";
                    return Ok(new ErrorResponse<ResponseMsg>(response));
                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
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
        /// To display all favourite category by bidder's primary key
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("FavouriteCategory")]
        public IActionResult GetAll([FromQuery] PaginationQuery pagination, int id)
        {
            try
            {
                string url = Url.Action("GetAll", null, null, Request.Scheme); //get url for current request
                this.uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<FavouriteCategoryEntity> category = favouriteCategoryService.GetFavourites(id);
                int totalCount = category.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<FavouriteCategoryEntity>>(category, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(category, pagination, totalCount)); // To pass result in object along with pagination info
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
        private PagedResponse<FavouriteCategoryEntity> ResultAfterPagination(IEnumerable<FavouriteCategoryEntity> getCategory, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<FavouriteCategoryEntity>(getCategory, totalCount);
            }

            var get = getCategory.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

        /// <summary>
        /// To remove category from favourite list by favourite'sprimary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("RemoveFavourite")]
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
                    favouriteCategoryService.RemoveFavourite(id);
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

    }
}
