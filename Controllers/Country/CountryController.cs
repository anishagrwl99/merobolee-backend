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

namespace MeroBolee.Controllers.Country
{
    public class CountryController : AuthorizeController
    {
        private readonly ICountryService countryService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;

        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }



        /// <summary>
        /// To add country by Admin
        /// </summary>
        /// <returns></returns>
        [HttpPost("Country")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public IActionResult AddCountry([FromBody]AddCountryDto addCountry)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(new Responses<GetCountryDto>(countryService.AddCountry(addCountry), "200", "Record is successfully added"));
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
                response.Message = e.Message + (e.InnerException == null? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// To update country info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addCountry"></param>
        /// <returns></returns>
        [HttpPut("Country")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public IActionResult UpdateCountry([FromQuery] int id, [FromBody] AddCountryDto addCountry)
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
                        GetCountryDto getCountry = countryService.UpdateCountry(id, addCountry);
                        if (getCountry == null)
                        {
                            return NotFound(new Responses<GetCountryDto>(getCountry, "404", "Record not found"));
                        }
                        return Ok(new Responses<GetCountryDto>(getCountry, "200", "Record is successfully updated"));
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
        /// To display all country by Admin
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("Country")]
        [AllowAnonymous]
        public IActionResult GetAllCountry([FromQuery] PaginationQuery pagination, [FromQuery] string search = null)
        {
            try
            {
                string url = Url.Action("GetAllCountry", null, null, Request.Scheme); //get url for current request
                uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<GetCountryDto> country = countryService.GetCountry(search);
                int totalCount = country.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<GetCountryDto>>(country, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(country, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }



        /// <summary>
        /// To get individual country detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("CountryDetail")]
        [AllowAnonymous]
        public IActionResult GetCountryById([FromQuery] int id)
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
                    GetCountryDto getCountry = countryService.GetCountryDetail(id);
                    if (getCountry == null)
                    {
                        return NotFound(new Responses<GetCountryDto>(getCountry, "404", "Record not found"));
                    }
                    return Ok(new Responses<GetCountryDto>(getCountry, "200", "Record found"));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));

            }
        }


        private PagedResponse<GetCountryDto> ResultAfterPagination(IEnumerable<GetCountryDto> country, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<GetCountryDto>(country, totalCount);
            }

            var get = country.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

    }
}
