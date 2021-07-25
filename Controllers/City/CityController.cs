using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Service.City;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.City
{
    public class CityController : Controller
    {
        private readonly ICityService cityService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;

        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }
        /// <summary>
        /// To add city by Admin
        /// </summary>
        /// <returns></returns>
        [HttpPost("City")]
        public IActionResult Add([FromBody] AddCityDto addCity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GetCityDto getCity = cityService.AddCity(addCity);
                    if (getCity.Id == 0)
                    {
                        response.statusCode = "400";
                        response.Message = "Invalid District";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    }
                    return Ok(new Responses<GetCityDto>(getCity, "200", "Record is successfully added"));
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
        /// To display all city by Admin
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet("City")]
        public IActionResult GetAll([FromQuery] PaginationQuery pagination, [FromQuery] string search = null)
        {
            try
            {
                uriService = new UriService("https://localhost:44332/City");
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<GetCityDto> City = cityService.GetCity(search);
                int totalCount = City.Count();
                if (totalCount == 0)
                {
                    return NotFound(ResultAfterPagination(City, pagination, totalCount));
                }
                return Ok(ResultAfterPagination(City, pagination, totalCount)); // To pass result in object along with pagination info
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
        /// To delete city record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("DeleteCity")]
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
                    cityService.DeleteCity(id);
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
        /// To get individual city detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("CityDetail")]
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
                    GetCityDto getCity = cityService.GetCityDetail(id);
                    if (getCity == null)
                    {
                      return StatusCode(StatusCodes.Status404NotFound,new Responses<GetCityDto>(getCity, "404", "Record not found"));
                    }
                    return Ok(new Responses<GetCityDto>(getCity, "200", "Record found"));
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
        /// To get list of city for cascade dropdown acc. to municipality or vdc
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("CascadeCity")]
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
                    uriService = new UriService("https://localhost:44332/City");
                    //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                    IEnumerable<GetCityDto> City = cityService.CascadeCity(id);
                    int totalCount = City.Count();
                    if (totalCount == 0)
                    {
                        return NotFound(new PagedResponse<GetCityDto>(City, totalCount));
                    }
                    return Ok(new PagedResponse<GetCityDto>(City, totalCount)); // To pass result in object along with pagination info
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
        /// To update city info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addCity"></param>
        /// <returns></returns>
        [HttpPut("City")]
        public IActionResult Update([FromQuery] int id, [FromBody] AddCityDto addCity)
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
                        GetCityDto getCity = cityService.UpdateCity(id,addCity);
                        if (getCity.Id == 0)
                        {
                            response.statusCode = "400";
                            response.Message = "Invalid District";
                            return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                        }
                        if (getCity == null)
                        {
                            response.statusCode = "404";
                            response.Message = "Record not found";
                            return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                        }
                        return Ok(new Responses<GetCityDto>(getCity, "200", "Record is successfully updated"));
                    }
                    else
                    {response.statusCode = "400";
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

        private PagedResponse<GetCityDto> ResultAfterPagination(IEnumerable<GetCityDto> getCity, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<GetCityDto>(getCity, totalCount);
            }

            var get = getCity.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

    }
}
