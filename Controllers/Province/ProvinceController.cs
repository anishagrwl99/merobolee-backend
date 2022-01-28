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

namespace MeroBolee.Controllers.Province
{
    public class ProvinceController : AuthorizeController
    {
        private readonly IProvinceService provinceService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;

        public ProvinceController(IProvinceService provinceService)
        {
            this.provinceService = provinceService;
        }
        /// <summary>
        /// To add province by Admin
        /// </summary>
        /// <returns></returns>
        [HttpPost("Province")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public IActionResult Add([FromBody] AddProvinceDto addProvince)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GetProvinceDto getProvince = provinceService.AddProvince(addProvince);
                    if (getProvince ==null || getProvince.Id == 0)
                    {
                        response.statusCode = "400";
                        response.Message = "Invalid Country";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    }
                    return Ok(new Responses<GetProvinceDto>(getProvince, "200", "Record is successfully added"));
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
        /// To update province info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addProvince"></param>
        /// <returns></returns>
        [HttpPut("Province")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public IActionResult Update([FromQuery] int id, [FromBody] AddProvinceDto addProvince)
        {
            try
            {
                if (id == 0)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid province id";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));

                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        GetProvinceDto getProvince = provinceService.UpdateProvince(id, addProvince);
                       
                        if (getProvince == null)
                        {
                            response.statusCode = "404";
                            response.Message = "Record not found";
                            return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                        }
                        else if (getProvince.Id == 0)
                        {
                            response.statusCode = "400";
                            response.Message = "Invalid Country";
                            return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));

                        }
                        return Ok(new Responses<GetProvinceDto>(getProvince, "200", "Record is successfully updated"));
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
        /// To display all province by Admin
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet("Province")]
        [AllowAnonymous]
        public IActionResult GetAll([FromQuery] PaginationQuery pagination)
        {
            try
            {
                string url = Url.Action("GetAll", null, null, Request.Scheme); //get url for current request
                uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<GetProvinceDto> province = provinceService.GetProvinces();
                int totalCount = province.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<GetProvinceDto>>(province, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(province, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }

        

        /// <summary>
        /// To get individual province detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ProvinceDetail")]
        [AllowAnonymous]
        public IActionResult GetById([FromQuery] int id)
        {
            try
            {
                if (id == 0)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid province id";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
                else
                {
                    GetProvinceDto getProvince = provinceService.GetProvinceDetail(id);
                    if (getProvince == null)
                    {
                        return NotFound(new Responses<GetProvinceDto>(getProvince, "404", "Record not found"));
                    }
                    return Ok(new Responses<GetProvinceDto>(getProvince, "200", "Record found"));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));

            }
        }


        private PagedResponse<GetProvinceDto> ResultAfterPagination(IEnumerable<GetProvinceDto> getProvinces, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<GetProvinceDto>(getProvinces, totalCount);
            }

            var get = getProvinces.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }
    }
}
