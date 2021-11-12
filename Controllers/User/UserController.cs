using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Service.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.User
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        /// <summary>
        /// To add user by Admin  and status is userStatus
        /// </summary>
        /// <returns></returns>
        [HttpPost("User")]
        public async Task<IActionResult> Add(AddUserDto addUser/*,[FromForm]IFormFile front_Citizenship=null, [FromBody] IFormFile back_Citizenship=null, [FromBody] IFormFile tax_Clearance=null , [FromBody] IFormFile PAN_Registration=null, [FromBody] IFormFile company_Registration=null, [FromBody] IFormFile experienced_Doc=null, [FromBody] IFormFile bank_Credit_letter=null*/)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(new Responses<GetUserDto>(await userService.AddUser(addUser/*,front_Citizenship,back_Citizenship,tax_Clearance,PAN_Registration, company_Registration,experienced_Doc,bank_Credit_letter*/), "200", "Record is successfully added"));
                    //if (((long.TryParse(addUser.Company_Contact1, out _) == true) && (long.TryParse(addUser.Person_contact1, out _) == true)) || (long.TryParse(addUser.Company_Contact2, out _) == true) || (long.TryParse(addUser.Person_contact2, out _) == true))
                    //{

                    //}
                    //else
                    //{
                    //    response.statusCode = "400";
                    //    response.Message = "Contact Number must be numeric";
                    //    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    //}
                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }

            }
            catch (UnauthorizedAccessException)
            {
                response.statusCode = "400";
                response.Message = "Username or Email already exists";
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
            }

            catch (DbUpdateException)
            {
                response.statusCode = "500";
                response.Message = "Internal Server Error";
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));

            }
            catch (SqlException)
            {
                response.statusCode = "500";
                response.Message = "Something went wrong";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
            }
        }

        /// <summary>
        /// To signup user and status is userStatus
        /// </summary>
        /// <returns></returns>
        [HttpPost("SignUpUser")]
        public async Task<IActionResult> SignUp(SignUpDto addUser)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if ((int.TryParse(addUser.CompanyContact, out _) == true) && (ulong.TryParse(addUser.PersonContact, out _) == true))
                    {
                        return Ok(new Responses<GetUserDto>( await userService.SignUp(addUser), "200", "Record is successfully added"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Contact Number must be numeric";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    }
                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
            }
            catch (UnauthorizedAccessException)
            {
                response.statusCode = "400";
                response.Message = "Username or Email already exists";
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
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
        /// To display all user by Admin
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("User")]
        public IActionResult GetAll([FromQuery] PaginationQuery pagination, [FromQuery] string search = null)
        {
            try
            {
                string url = Url.Action("GetAll", null, null, Request.Scheme); //get url for current request
                this.uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<GetUserDto> user = userService.GetUser(search);
                int totalCount = user.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<GetUserDto>>(user, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(user, pagination, totalCount)); // To pass result in object along with pagination info
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
        /// To get individual user detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("UserDetail")]
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
                    GetUserDto getUser = userService.GetUserDetail(id);
                    if (getUser == null)
                    {
                        response.statusCode = "404";
                        response.Message = "Record not found";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    }
                    return Ok(new Responses<GetUserDto>(getUser, "200", "Record found"));
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
        /// To update user info by Admin and status is userStatus
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addUser"></param>
        /// <returns></returns>
        [HttpPut("User")]
        public async Task<IActionResult> Update([FromQuery] int id,[FromQuery] AddUserDto addUser)
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
                        GetUserDto getUser = await userService.UpdateUserByAdmin(id, addUser);
                        if (getUser == null)
                        {
                            response.statusCode = "404";
                            response.Message = "Record not Found";
                            return StatusCode(StatusCodes.Status404NotFound, new ErrorResponse<ResponseMsg>(response));
                        }
                        return Ok(new Responses<GetUserDto>(getUser, "200", "Record is successfully updated"));
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

        /// <summary>
        /// To update user info by User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addUser"></param>
        /// <returns></returns>
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateByUser([FromQuery] int id, [FromBody] SignUpDto addUser)
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
                        GetUserDto getUser =await userService.UpdateUserByUser(id, addUser);
                        if (getUser == null)
                        {
                            response.statusCode = "404";
                            response.Message = "Record not Found";
                            return StatusCode(StatusCodes.Status404NotFound, new ErrorResponse<ResponseMsg>(response));
                        }
                        return Ok(new Responses<GetUserDto>(getUser, "200", "Record is successfully updated"));
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

        private PagedResponse<GetUserDto> ResultAfterPagination(IEnumerable<GetUserDto> getUsers, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<GetUserDto>(getUsers, totalCount);
            }

            var get = getUsers.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

          
}
}
