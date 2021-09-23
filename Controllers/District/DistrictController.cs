using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Service.District;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.District
{
    public class DistrictController : Controller
    {
        private readonly IDistrictService districtService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;

        public DistrictController(IDistrictService districtService)
        {
            this.districtService = districtService;
        }
        /// <summary>
        /// To add district by Admin
        /// </summary>
        /// <returns></returns>
        [HttpPost("District")]
        public IActionResult Add([FromBody] AddDistrictDto addDistrict)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GetDistrictDto getDistrict = districtService.AddDistrict(addDistrict);
                    if (getDistrict.Id == 0)
                    {
                        response.statusCode = "400";
                        response.Message = "Invalid Province";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));

                    }
                    return Ok(new Responses<GetDistrictDto>(districtService.AddDistrict(addDistrict), "200", "Record is successfully added"));
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
        /// To display all district by Admin
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet("District")]
        public IActionResult GetAll([FromQuery] PaginationQuery pagination, [FromQuery] string search = null)
        {
            try
            {
                string url = Url.Action("GetAll", null, null, Request.Scheme); //get url for current request
                uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<GetDistrictDto> district = districtService.GetDistricts(search);
                int totalCount = district.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<GetDistrictDto>>(district, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(district, pagination, totalCount)); // To pass result in object along with pagination info
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
        /// To delete district record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteDistrict")]
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
                    districtService.DeleteDistrict(id);
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
        /// To get individual district detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("DistrictDetail")]
        public IActionResult GetById([FromQuery] int id)
        {
            try
            {
                if (id == 0)
                {response.statusCode = "400";
                    response.Message = "Invalid Format";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
                else
                {
                    GetDistrictDto getDistrict = districtService.GetDistrictDetail(id);
                    if (getDistrict == null)
                    {
                        return NotFound(new Responses<GetDistrictDto>(getDistrict, "404", "Record not found"));
                    }
                    return Ok(new Responses<GetDistrictDto>(getDistrict, "200", "Record found"));
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
        /// To get list of district for cascade dropdown by province_id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("CascadeDistrict")]
        public IActionResult GetCascade([FromQuery] int id)
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
                    string url = Url.Action("GetCascade", null, null, Request.Scheme); //get url for current request
                    uriService = new UriService(url);
                    //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                    IEnumerable<GetDistrictDto> district = districtService.CascadeDistrict(id);
                    int totalCount = district.Count();
                    if (totalCount == 0)
                    {
                        return NotFound(new PagedResponse<GetDistrictDto>(district, totalCount));
                    }
                    return Ok(new PagedResponse<GetDistrictDto>(district, totalCount)); // To pass result in object along with pagination info
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
        /// To update district info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addDistrict"></param>
        /// <returns></returns>
        [HttpPut("District")]
        public IActionResult Update([FromQuery] int id, [FromBody] AddDistrictDto addDistrict)
        {
            try
            {
                if (id == 0)
                {response.statusCode = "400";
                    response.Message = "Invalid Format";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        GetDistrictDto getDistrict = districtService.UpdateDistrict(id,addDistrict);
                        if (getDistrict.Id == 0)
                        {
                            response.statusCode = "400";
                            response.Message = "Invalid Province";
                            return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                        }
                        if (getDistrict == null)
                        {
                            response.statusCode = "404";
                            response.Message = "Record not found";
                            return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                        }
                        return Ok(new Responses<GetDistrictDto>(getDistrict, "200", "Record is successfully updated"));
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

        private PagedResponse<GetDistrictDto> ResultAfterPagination(IEnumerable<GetDistrictDto> getDistricts, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<GetDistrictDto>(getDistricts, totalCount);
            }

            var get = getDistricts.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

    }
}
