using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service.Status;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.Status
{
    public class StatusController : Controller
    {
        private readonly IStatusService statusService;
        private readonly ResponseMsg response = new ResponseMsg();

        public StatusController(IStatusService statusService)
        {
            this.statusService = statusService;
        }

        /// <summary>
        /// To display all common status
        /// </summary>
        /// <returns></returns>
        [HttpGet("CommonStatus")]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<PublishStatus> publishStatuses = statusService.GetPublishStatuses();
                if (publishStatuses.Count() == 0)
                {
                    return NotFound(new Responses<IEnumerable<PublishStatus>>(publishStatuses, "404", "Record not Found")); // To pass result in object along with pagination info
                }
                return Ok(new Responses<IEnumerable<PublishStatus>>(publishStatuses,"200","Record Found")); // To pass result in object along with pagination info
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
        /// To display all auction status for auction
        /// </summary>
        /// <returns></returns>
        [HttpGet("AuctionStatus")]
        public IActionResult GetAuctionStatus()
        {
            try
            {
                IEnumerable<AuctionStatusEntity> auctionStatuses = statusService.GetAuctionStatuses();
                if (auctionStatuses.Count() == 0)
                {
                    return NotFound(new Responses<IEnumerable<AuctionStatusEntity>>(auctionStatuses, "404", "Record not found")); // To pass result in object along with pagination info

                }
                return Ok(new Responses<IEnumerable<AuctionStatusEntity>>(auctionStatuses,"200", "Record found")); // To pass result in object along with pagination info
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
        /// To display all admin status for auction by admin
        /// </summary>
        /// <returns></returns>
        [HttpGet("AdminStatus")]
        public IActionResult GetAdminStatus()
        {
            try
            {
                IEnumerable<AdminStatusEntity> adminStatuses = statusService.GetAdminStatuses();
                if (adminStatuses.Count() == 0)
                {
                    return NotFound(new Responses<IEnumerable<AdminStatusEntity>>(adminStatuses, "404", "Record not found")); // To pass result in object along with pagination info

                }
                return Ok(new Responses<IEnumerable<AdminStatusEntity>>(adminStatuses,"200","Record found")); // To pass result in object along with pagination info
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
        /// To display all user status
        /// </summary>
        /// <returns></returns>
        [HttpGet("UserStatus")]
        public IActionResult GetUserStatus()
        {
            try
            {
                IEnumerable<UserStatusEntity> userStatuses = statusService.GetUserStatuses();
                if (userStatuses.Count() == 0)
                {
                    return NotFound(new Responses<IEnumerable<UserStatusEntity>>(userStatuses, "404", "Record not found")); // To pass result in object along with pagination info

                }
                return Ok(new Responses<IEnumerable<UserStatusEntity>>(userStatuses,"200","Record found")); // To pass result in object along with pagination info
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

    }
}
