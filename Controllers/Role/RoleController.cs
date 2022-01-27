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
using System.Net;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.Role
{
    public class RoleController : AuthorizeController
    {
        private readonly IRoleService roleService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        /// <summary>
        /// To add role by Admin
        /// </summary>
        /// <returns></returns>
        [HttpPost("Role")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public IActionResult AddRole([FromBody] AddRoleDto addRole)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(new Responses<GetRoleDto>(roleService.AddRole(addRole),"200","Record is successfully added"));
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
        /// To update role info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addRole"></param>
        /// <returns></returns>
        [HttpPut("Role")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public IActionResult UpdateRole([FromQuery] int id, [FromBody] AddRoleDto addRole)
        {
            try
            {
                if (id == 0)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid role id";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        GetRoleDto getRole = roleService.UpdateRole(id, addRole);
                        if (getRole == null)
                        {
                            return NotFound(new Responses<GetRoleDto>(getRole, "404", "Record not found"));
                        }
                        return Ok(new Responses<GetRoleDto>(getRole, "200", "Record is successfully updated"));
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
        /// To display all role by Admin
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("Role")]
        public IActionResult GetAllRole([FromQuery] PaginationQuery pagination, [FromQuery] string search = null)
        {
            try
            {
                string url = Url.Action("GetAllRole", null, null, Request.Scheme); //get url for current request
                uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<GetRoleDto> role = roleService.GetAllRole(search);
                int totalCount = role.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<GetRoleDto>>(role, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(role, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }

        

        /// <summary>
        /// To get individual role detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("RoleDetail")]
        public IActionResult GetRoleById([FromQuery] int id)
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
                    GetRoleDto getRole = roleService.GetRoleDetail(id);
                    if (getRole == null)
                    {
                        return NotFound(new Responses<GetRoleDto>(getRole,"404","Record not found"));
                    }
                    return Ok(new Responses<GetRoleDto>(getRole,"200","Record found"));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));

            }
        }
       

        private PagedResponse<GetRoleDto> ResultAfterPagination(IEnumerable<GetRoleDto> role, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<GetRoleDto>(role, totalCount);
            }

            var get = role.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }
    }
}
