using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Service.CompanyType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.CompanyType
{
    public class CompanyTypeController : Controller
    {
        private readonly ICompanyTypeService CompanyTypeService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;

        public CompanyTypeController(ICompanyTypeService CompanyTypeService)
        {
            this.CompanyTypeService = CompanyTypeService;
        }

        /// <summary>
        /// To add company type by Admin
        /// </summary>
        /// <returns></returns>
        [HttpPost("CompanyType")]
        public IActionResult AddCompanyType([FromBody] AddCompanyTypeDto addCompanyType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(new Responses<GetCompanyTypeDto>(CompanyTypeService.AddCompanyType(addCompanyType), "200", "Record is successfully added"));
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
        /// To display all Company Type by Admin
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="search"></param>>
        /// <returns></returns>
        [HttpGet("CompanyType")]
        public IActionResult GetAllCompanyType([FromQuery] PaginationQuery pagination, [FromQuery] string search = null)
        {
            try
            {
                string url = Url.Action("GetAllCompanyType", null, null, Request.Scheme); //get url for current request
                uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<GetCompanyTypeDto> CompanyType = CompanyTypeService.GetCompanyType(search);
                int totalCount = CompanyType.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<GetCompanyTypeDto>>(CompanyType, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(CompanyType, pagination, totalCount)); // To pass result in object along with pagination info
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
        /// To delete CompanyType record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteCompanyType")]
        public IActionResult DeleteCompanyType([FromQuery] int id)
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
                    CompanyTypeService.DeleteCompanyType(id);
                    response.statusCode = "200";
                    response.Message = "Record is successfully deleted";
                    return StatusCode(StatusCodes.Status200OK, new ErrorResponse<ResponseMsg>(response));
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
        /// To get individual CompanyType detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("CompanyTypeDetail")]
        public IActionResult GetCompanyTypeById([FromQuery] int id)
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
                    GetCompanyTypeDto getCompanyType = CompanyTypeService.GetCompanyTypeDetail(id);
                    if (getCompanyType == null)
                    {
                        return NotFound(new Responses<GetCompanyTypeDto>(getCompanyType, "404", "Record not found"));
                    }
                    return Ok(new Responses<GetCompanyTypeDto>(getCompanyType, "200", "Record found"));
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
        /// To update CompanyType info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addCompanyType"></param>
        /// <returns></returns>
        [HttpPut("CompanyType")]
        public IActionResult UpdateCompanyType([FromQuery] int id, [FromBody] AddCompanyTypeDto addCompanyType)
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
                        GetCompanyTypeDto getCompanyType = CompanyTypeService.UpdateCompanyType(id, addCompanyType);
                        if (getCompanyType == null)
                        {
                            return NotFound(new Responses<GetCompanyTypeDto>(getCompanyType, "404", "Record not found"));
                        }
                        return Ok(new Responses<GetCompanyTypeDto>(getCompanyType, "200", "Record is successfully updated"));
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

        private PagedResponse<GetCompanyTypeDto> ResultAfterPagination(IEnumerable<GetCompanyTypeDto> CompanyType, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<GetCompanyTypeDto>(CompanyType, totalCount);
            }

            var get = CompanyType.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

    }
}
