using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Service.Municipality;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.Municipality
{
    public class MunicipalityController : Controller
    {
        private readonly IMunicipalityService municipalityService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;

        public MunicipalityController(IMunicipalityService municipalityService)
        {
            this.municipalityService = municipalityService;
        }
        /// <summary>
        /// To add Municipality by Admin
        /// </summary>
        /// <returns></returns>
        [HttpPost("Municipality")]
        public IActionResult Add([FromBody] AddMunicipalityDto addMunicipality)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GetMunicipalityDto getMunicipality = municipalityService.AddMunicipality(addMunicipality);
                    if (getMunicipality.Id == 0)
                    {
                        response.statusCode = "400";
                        response.Message = "Invalid District";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    }
                    return Ok(new Responses<GetMunicipalityDto>(getMunicipality, "200", "Record is successfully added"));
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
        /// To display all Municipality by Admin
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet("Municipality")]
        public IActionResult GetAll([FromQuery] PaginationQuery pagination, [FromQuery] string search = null)
        {
            try
            {
                uriService = new UriService("https://localhost:44332/Municipality");
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<GetMunicipalityDto> Municipality = municipalityService.GetMunicipality(search);
                int totalCount = Municipality.Count();
                if (totalCount == 0)
                {
                    return NotFound(ResultAfterPagination(Municipality, pagination, totalCount));
                }
                return Ok(ResultAfterPagination(Municipality, pagination, totalCount)); // To pass result in object along with pagination info
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
        /// To delete Municipality record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("DeleteMunicipality")]
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
                    municipalityService.DeleteMunicipality(id);
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
        /// To get individual Municipality detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("MunicipalityDetail")]
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
                    GetMunicipalityDto getMunicipality = municipalityService.GetMunicipalityDetail(id);
                    if (getMunicipality == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new Responses<GetMunicipalityDto>(getMunicipality, "404", "Record not found"));
                    }
                    return Ok(new Responses<GetMunicipalityDto>(getMunicipality, "200", "Record found"));
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
        /// To get list of Municipality for cascade dropdown acc. to municipality or vdc
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("CascadeMunicipality")]
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
                    uriService = new UriService("https://localhost:44332/Municipality");
                    //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                    IEnumerable<GetMunicipalityDto> Municipality = municipalityService.CascadeMunicipality(id);
                    int totalCount = Municipality.Count();
                    if (totalCount == 0)
                    {
                        return NotFound(new PagedResponse<GetMunicipalityDto>(Municipality, totalCount));
                    }
                    return Ok(new PagedResponse<GetMunicipalityDto>(Municipality, totalCount)); // To pass result in object along with pagination info
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
        /// To update Municipality info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addMunicipality"></param>
        /// <returns></returns>
        [HttpPut("Municipality")]
        public IActionResult Update([FromQuery] int id, [FromBody] AddMunicipalityDto addMunicipality)
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
                        GetMunicipalityDto getMunicipality = municipalityService.UpdateMunicipality(id, addMunicipality);
                        if (getMunicipality.Id == 0)
                        {
                            response.statusCode = "400";
                            response.Message = "Invalid District";
                            return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                        }
                        if (getMunicipality == null)
                        {
                            response.statusCode = "404";
                            response.Message = "Record not found";
                            return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                        }
                        return Ok(new Responses<GetMunicipalityDto>(getMunicipality, "200", "Record is successfully updated"));
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

        private PagedResponse<GetMunicipalityDto> ResultAfterPagination(IEnumerable<GetMunicipalityDto> getMunicipality, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<GetMunicipalityDto>(getMunicipality, totalCount);
            }

            var get = getMunicipality.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

    }
}
