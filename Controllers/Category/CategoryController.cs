using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers
{
   
    public class CategoryController : AuthorizeController
    {
        private readonly ICategoryService categoryService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }


        /// <summary>
        /// To add category by Admin and status is commonStatus
        /// </summary>
        /// <returns></returns>
        [HttpPost("Category")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public IActionResult Add([FromBody] AddCategoryDto addCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    return Ok(new Responses<GetCategoryDto>(categoryService.AddCategory(addCategory), "200", "Record is successfully added"));
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
        /// To update Category info and status is commonStatus
        /// </summary>
        /// <param name="updateCategory"></param>
        /// <returns></returns>
        [HttpPut("Category")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public IActionResult Update([FromBody] UpdateCategoryDto updateCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GetCategoryDto getCategory = categoryService.UpdateCategory(updateCategory);
                    if (getCategory == null)
                    {
                        response.statusCode = "404";
                        response.Message = "Record not Found";
                        return StatusCode(StatusCodes.Status404NotFound, new ErrorResponse<ResponseMsg>(response));
                    }
                    return Ok(new Responses<GetCategoryDto>(getCategory, "200", "Record is successfully updated"));
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
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));

            }
        }

        /// <summary>
        /// To delete category record (var: id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteCategory")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public IActionResult Delete([FromBody] int id)
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
                    categoryService.DeleteCategory(id);
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


        /// <summary>
        /// To display all category by Admin
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("Category")]
        public IActionResult GetAll([FromQuery] PaginationQuery pagination, [FromQuery] string search = null)
        {
            try
            {
                string url = Url.Action("GetAll", null, null, Request.Scheme); //get url for current request
                this.uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<GetCategoryDto> category = categoryService.GetCategory(search);
                int totalCount = category.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<GetCategoryDto>>(category, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(category, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }



        /// <summary>
        /// To get individual category detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("CategoryDetail")]
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
                    GetCategoryDto getCategory = categoryService.GetCategoryDetail(id);
                    if (getCategory == null)
                    {
                        response.statusCode = "404";
                        response.Message = "Record not found";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    }
                    return Ok(new Responses<GetCategoryDto>(getCategory, "200", "Record found"));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));

            }
        }



        private PagedResponse<GetCategoryDto> ResultAfterPagination(IEnumerable<GetCategoryDto> getCategory, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<GetCategoryDto>(getCategory, totalCount);
            }

            var get = getCategory.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

    }
}
