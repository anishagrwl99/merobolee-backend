using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service;
using MeroBolee.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using MeroBolee.Settings;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MeroBolee.Controllers
{
    /// <summary>
    /// Tender submission endpoints for bid inviter
    /// </summary>
    public class TenderSubmissionController : BaseController
    {
        private readonly ITenderSubmissionService submissionService;

        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;
        private readonly AppDefaults defaultOption;
        

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="submissionService"></param>
        /// <param name="defaultOpt"></param>
        public TenderSubmissionController(ITenderSubmissionService submissionService, IOptions<AppDefaults> defaultOpt)
        {
            this.submissionService = submissionService;
            this.defaultOption = defaultOpt.Value;
        }


        /// <summary>
        /// Submit Tender submission for tender creation using merobolee default form
        /// </summary>
        /// <param name="tenderSubmission"></param>
        /// <returns></returns>
        [HttpPost("BidInviter/TenderSubmission/MeroboleeForm")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateSubmission([FromForm] TenderSubmissionRequestDto tenderSubmission)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TenderSubmission res = await submissionService.CreateTenderSubmissionByForm(tenderSubmission);
                    if (res != null)
                    {
                        return Ok(new Responses<TenderSubmission>(null, "200", "Record is successfully added"));
                    }
                    else
                    {
                        return Problem(detail: "Couldn't create submission", statusCode: 400, title: "Error");
                    }

                }
                else
                {
                    response.statusCode = "400";
                    response.Message = $"Invalid data";
                    response.Data = ModelState;
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = $"{e.Message} Inner Message: {(e.InnerException != null ? e.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }



        /// <summary>
        /// Update Tender submission for tender creation using merobolee default form
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("BidInviter/TenderSubmission/MeroboleeForm/Update")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateSubmission([FromForm] TenderSubmissionUpdateRequestDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TenderSubmission res = await submissionService.UpdateTenderSubmissionByForm(model);
                    if (res != null)
                    {
                        return Ok(new Responses<TenderSubmission>(null, "200", "Record is successfully updated"));
                    }
                    else
                    {
                        return Problem(detail: "Couldn't create submission", statusCode: 400, title: "Error");
                    }

                }
                else
                {
                    response.statusCode = "400";
                    response.Message = $"Invalid data";
                    response.Data = ModelState;
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = $"{e.Message} Inner Message: {(e.InnerException != null ? e.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// Submit tender submission for tender creation using prepared documents
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("BidInviter/TenderSubmission/ExternalDocument")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateDocumentSubmission([FromForm] TenderSubmissionExternalDocumentRequestDto model)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    TenderSubmission res = await submissionService.CreateTenderSubmissionByDocument(model);
                    if (res != null)
                    {
                        return Ok(new Responses<TenderSubmission>(null, "200", "Record is successfully added"));
                    }
                    else
                    {
                        return Problem(detail: "Couldn't create submission", statusCode: 400, title: "Error");
                    }

                }
                else
                {
                    response.statusCode = "400";
                    response.Message = $"Invalid data";
                    response.Data = ModelState;
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = $"{e.Message} Inner Message: {(e.InnerException != null ? e.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// Update a tender submission by submitting prepared documents
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("BidInviter/TenderSubmission/ExternalDocument/Update")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateDocumentSubmission([FromForm] TenderSubmissionExternalDocumentUpdateRequestDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TenderSubmission res = await submissionService.UpdateTenderSubmissionByDocument(model);
                    if (res != null)
                    {
                        return Ok(new Responses<TenderSubmission>(null, "200", "Record is successfully updated"));
                    }
                    else
                    {
                        return Problem(detail: "Couldn't create submission", statusCode: 400, title: "Error");
                    }

                }
                else
                {
                    response.statusCode = "400";
                    response.Message = $"Invalid data";
                    response.Data = ModelState;
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = $"{e.Message} Inner Message: {(e.InnerException != null ? e.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        /// <summary>
        /// Make a payment so that submission can be processed futher by admin
        /// </summary>
        /// <returns></returns>
        [HttpPost("BidInviter/TenderSubmission/MakePayment")]
        public async Task<IActionResult> MakePayment([FromBody] TenderSubmissionPaymentRequestDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TenderSubmission res = await submissionService.MakePayment(model);
                    if (res != null)
                    {
                        return Ok(new Responses<TenderSubmission>(null, "200", "Record is successfully updated"));
                    }
                    else
                    {
                        return Problem(detail: "Couldn't update payment info", statusCode: 400, title: "Error");
                    }

                }
                else
                {
                    response.statusCode = "400";
                    response.Message = $"Invalid data";
                    response.Data = ModelState;
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = $"{e.Message} Inner Message: {(e.InnerException != null ? e.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// Get all list of tender submissions made by bid inviter company
        /// </summary>
        /// <returns></returns>
        [HttpGet("BidInviter/TenderSubmission")]
        public async Task<IActionResult> GetTenderSubmissions([FromQuery] PaginationQuery pagination, [FromQuery] long companyId, [FromQuery] long userId)
        {
            try
            {
                if (companyId>0 && userId > 0)
                {
                    string url = Url.Action("GetTenderSubmissions", null, new { companyId = companyId, userId = userId }, Request.Scheme); //get url for current request
                    this.uriService = new UriService(url);
                    List<TenderSubmissionCard> res = await submissionService.BidInviterTenderSubmission(companyId, userId);
                    if (res != null && res.Count > 0)
                    {
                        int totalCount = res.Count;
                        return Ok(ResultAfterPagination(res, pagination, totalCount));
                    }
                    else
                    {
                        return NotFound(new Responses<List<TenderSubmissionCard>>(res, "404", "Record not found"));
                    }

                }
                else
                {
                    response.statusCode = "400";
                    response.Message = $"Invalid data";
                    response.Data = ModelState;
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = $"{e.Message} Inner Message: {(e.InnerException != null ? e.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }



        /// <summary>
        /// Get detail of a tender submission
        /// </summary>
        /// <param name="tenderSubmissionId"></param>
        /// <param name="companyId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("BidInviter/TenderSubmission/Detail")]
        public async Task<IActionResult> GetTenderSubmissionDetail([FromQuery] long tenderSubmissionId, [FromQuery] long companyId, [FromQuery] long userId)
        {
            try
            {
                if (tenderSubmissionId == 0 || companyId ==0 || userId == 0)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
                else
                {
                    //string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/";
                     _defaultPic = $"{_baseUrl}{defaultOption.DefaultProfilePicture}";

                    TenderResponseSubmissionDto res = await submissionService.TenderSubmissionDetail(tenderSubmissionId, companyId, userId, _baseUrl, _defaultPic);
                    if (res == null)
                    {
                        response.statusCode = "404";
                        response.Message = "Record not found";
                        return StatusCode(StatusCodes.Status404NotFound, new ErrorResponse<ResponseMsg>(response));
                    }
                    return Ok(new Responses<TenderResponseSubmissionDto>(res, "200", "Record found"));
                }
            }
            catch (Exception ex)
            {
                response.statusCode = "500";
                response.Message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        /// <summary>
        /// Move status of tender listing by admin
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Admin/TenderSubmission/ChangeStatus")]
        public async Task<IActionResult> ChangeSubmissionStatus([FromBody] ChangeSubmissionStatusDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    TenderSubmission res = await submissionService.AdminChangeStatus(model);
                    if (res != null)
                    {
                        return Ok(new Responses<TenderSubmission>(null, "200", "Record is successfully updated"));
                    }
                    else
                    {
                        return Problem(detail: "Couldn't update submission status", statusCode: 400, title: "Error");
                    }

                }
                else
                {
                    response.statusCode = "400";
                    response.Message = $"Invalid data";
                    response.Data = ModelState;
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = $"{e.Message} Inner Message: {(e.InnerException != null ? e.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        /// <summary>
        /// Get all list of tender submissions made by bid inviter companies 
        /// </summary>
        /// <returns></returns>
        [HttpGet("Admin/TenderSubmission")]
        public async Task<IActionResult> GetTenderSubmissionsForAdmin([FromQuery] PaginationQuery pagination)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string url = Url.Action("GetTenderSubmissionsForAdmin", null, null, Request.Scheme); //get url for current request
                    this.uriService = new UriService(url);
                    List<TenderSubmissionCard> res = await submissionService.AdminTenderSubmission();
                    if (res != null && res.Count > 0)
                    {
                        int totalCount = res.Count;
                        return Ok(ResultAfterPagination(res, pagination, totalCount));
                    }
                    else
                    {
                        return NotFound(new Responses<List<TenderSubmissionCard>>(res, "404", "Record not found"));
                    }

                }
                else
                {
                    response.statusCode = "400";
                    response.Message = $"Invalid data";
                    response.Data = ModelState;
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = $"{e.Message} Inner Message: {(e.InnerException != null ? e.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }



        /// <summary>
        /// Get detail of a tender submission
        /// </summary>
        /// <param name="tenderSubmissionId"></param>
        /// <returns></returns>
        [HttpGet("Admin/TenderSubmission/Detail")]
        public async Task<IActionResult> GetTenderSubmissionDetail([FromQuery] long tenderSubmissionId)
        {
            try
            {
                if (tenderSubmissionId == 0)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
                else
                {
                    //string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/";
                     _defaultPic = $"{_baseUrl}{defaultOption.DefaultProfilePicture}";

                    TenderResponseSubmissionDto res = await submissionService.TenderSubmissionDetail(tenderSubmissionId, _baseUrl, _defaultPic);
                    if (res == null)
                    {
                        response.statusCode = "404";
                        response.Message = "Record not found";
                        return StatusCode(StatusCodes.Status404NotFound, new ErrorResponse<ResponseMsg>(response));
                    }
                    return Ok(new Responses<TenderResponseSubmissionDto>(res, "200", "Record found"));
                }
            }
            catch (Exception ex)
            {
                response.statusCode = "500";
                response.Message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        private PagedResponse<TenderSubmissionCard> ResultAfterPagination(IEnumerable<TenderSubmissionCard> records, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<TenderSubmissionCard>(records, totalCount);
            }

            var get = records.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }
    }
}
