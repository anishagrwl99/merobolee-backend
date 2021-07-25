using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Service.VDC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.VDC
{
    public class VDCController : Controller
    {
        private readonly IVDCService vdcService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;

        public VDCController(IVDCService vdcService)
        {
            this.vdcService = vdcService;
        }
        /// <summary>
        /// To add VDC by Admin
        /// </summary>
        /// <returns></returns>
        [HttpPost("VDC")]
        public IActionResult Add([FromBody] AddVDCDto addVDC)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GetVDCDto getVDC = vdcService.AddVDC(addVDC);
                    if (getVDC.Id == 0)
                    {
                        response.statusCode = "400";
                        response.Message = "Invalid District";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    }
                    return Ok(new Responses<GetVDCDto>(getVDC, "200", "Record is successfully added"));
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
        /// To display all VDC by Admin
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet("VDC")]
        public IActionResult GetAll([FromQuery] PaginationQuery pagination, [FromQuery] string search = null)
        {
            try
            {
                uriService = new UriService("https://localhost:44332/VDC");
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<GetVDCDto> VDC = vdcService.GetVDC(search);
                int totalCount = VDC.Count();
                if (totalCount == 0)
                {
                    return NotFound(ResultAfterPagination(VDC, pagination, totalCount));
                }
                return Ok(ResultAfterPagination(VDC, pagination, totalCount)); // To pass result in object along with pagination info
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
        /// To delete VDC record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("DeleteVDC")]
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
                    vdcService.DeleteVDC(id);
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
        /// To get individual VDC detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("VDCDetail")]
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
                    GetVDCDto getVDC = vdcService.GetVDCDetail(id);
                    if (getVDC == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new Responses<GetVDCDto>(getVDC, "404", "Record not found"));
                    }
                    return Ok(new Responses<GetVDCDto>(getVDC, "200", "Record found"));
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
        /// To get list of VDC for cascade dropdown acc. to municipality or vdc
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("CascadeVDC")]
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
                    uriService = new UriService("https://localhost:44332/VDC");
                    //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                    IEnumerable<GetVDCDto> VDC = vdcService.CascadeVDC(id);
                    int totalCount = VDC.Count();
                    if (totalCount == 0)
                    {
                        return NotFound(new PagedResponse<GetVDCDto>(VDC, totalCount));
                    }
                    return Ok(new PagedResponse<GetVDCDto>(VDC, totalCount)); // To pass result in object along with pagination info
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
        /// To update VDC info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addVDC"></param>
        /// <returns></returns>
        [HttpPut("VDC")]
        public IActionResult Update([FromQuery] int id, [FromBody] AddVDCDto addVDC)
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
                        GetVDCDto getVDC = vdcService.UpdateVDC(id, addVDC);
                        if (getVDC.Id == 0)
                        {
                            response.statusCode = "400";
                            response.Message = "Invalid District";
                            return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                        }
                        if (getVDC == null)
                        {
                            response.statusCode = "404";
                            response.Message = "Record not found";
                            return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                        }
                        return Ok(new Responses<GetVDCDto>(getVDC, "200", "Record is successfully updated"));
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

        private PagedResponse<GetVDCDto> ResultAfterPagination(IEnumerable<GetVDCDto> getVDC, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<GetVDCDto>(getVDC, totalCount);
            }

            var get = getVDC.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

    }
}
