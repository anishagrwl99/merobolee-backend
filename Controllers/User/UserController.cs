using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Service;
using MeroBolee.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.User
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MeroBolee.Controllers.BaseController" />
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        private readonly AppDefaults defaultOption;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;



        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        /// <param name="defaultOption">The default option.</param>
        public UserController(IUserService userService, IOptions<AppDefaults> defaultOption)
        {
            this.userService = userService;
            this.defaultOption = defaultOption.Value;
        }


        /// <summary>
        /// To display all user by Admin
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet("User")]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery pagination, [FromQuery] long companyId)
        {
            try
            {
                if (companyId > 0)
                {
                    string url = Url.Action("GetAll", null, null, Request.Scheme); //get url for current request
                    this.uriService = new UriService(url);
                    string _defaultPic = $"{_baseUrl}{defaultOption.DefaultProfilePicture}";
                    IEnumerable<GetUserDto> user = await userService.GetUser(companyId, _baseUrl, _defaultPic);
                    int totalCount = user.Count();
                    if (totalCount == 0)
                    {
                        return NotFound(new Responses<IEnumerable<GetUserDto>>(user, "404", "Record not found"));
                    }
                    return Ok(ResultAfterPagination(user, pagination, totalCount)); // To pass result in object along with pagination info
                }
                else
                {
                    return NotFound(new Responses<IEnumerable<GetUserDto>>(null, "404", "Record not found"));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }
        
        
        /// <summary>
        /// To get individual user detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("UserDetail")]
        public async Task<IActionResult> GetById([FromQuery] long id)
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
                    string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/";
                    string _defaultPic = $"{baseUrl}{defaultOption.DefaultProfilePicture}";

                    UserDetailDto getUser = await userService.GetUserDetail(id, baseUrl, _defaultPic);
                    if (getUser == null)
                    {
                        response.statusCode = "404";
                        response.Message = "Record not found";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    }
                    return Ok(new Responses<UserDetailDto>(getUser, "200", "Record found"));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));

            }
        }

        /// <summary>
        /// To update user info by User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateByUser([FromBody] UpdateUserDto user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GetUserDto getUser = await userService.UpdateUserByUser(user);
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
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));

            }
        }

        [HttpGet("/User/Profile")]
        public async Task<IActionResult> UserProfile([FromQuery] long userId, [FromQuery] long companyId)
        {
            try
            {
                string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/";
                string _defaultPic = $"{baseUrl}{defaultOption.DefaultProfilePicture}";

                UserProfileDto profile = await userService.GetUserProfile(userId, companyId, _defaultPic, baseUrl);
                if (profile == null)
                {
                    response.statusCode = "404";
                    response.Message = "Record not Found";
                    return StatusCode(StatusCodes.Status404NotFound, new ErrorResponse<ResponseMsg>(response));
                }
                return Ok(new Responses<UserProfileDto>(profile, "200", "Record found"));

            }
            catch (Exception ex)
            {
                response.statusCode = "500";
                response.Message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        [HttpPost("/User/ChangeProfilePicture")]
        public async Task<IActionResult> UpdateProfilePicture([FromForm] ProfilePictureDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/";
                    ProfilePictureResponseDto res = await userService.UpdateProfilePicture(model, baseUrl);
                    if (res == null)
                    {
                        response.statusCode = "400";
                        response.Message = "Couldn't update profile picture";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    }

                    return Ok(new Responses<ProfilePictureResponseDto>(res, "200", "Profile picture changed"));
                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
            }
            catch (Exception ex)
            {
                response.statusCode = "500";
                response.Message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        [HttpPost("/User/ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool res = await userService.ChangeUserPassword(model);
                    if (res == false)
                    {
                        response.statusCode = "400";
                        response.Message = "Couldn't update password";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    }
                    return Ok(new Responses<ProfilePictureResponseDto>(null, "200", "User password changed"));
                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    response.Data = ModelState;
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
            }
            catch (Exception ex)
            {
                response.statusCode = "500";
                response.Message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
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
