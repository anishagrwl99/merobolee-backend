using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service;
using MeroBolee.Service.SupplierPerformanceTracking;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.SupplierPerformanceTracking
{
    public class SupplierPerformanceTrackingController : BaseController
    {
        private readonly ResponseMsg response = new ResponseMsg();
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ISupplierPerformanceTrackingService supplierPerformanceTrackingService;
        private IUriService uriService;

        public SupplierPerformanceTrackingController(ISupplierPerformanceTrackingService supplierPerformanceTrackingService)
        {
            this.supplierPerformanceTrackingService = supplierPerformanceTrackingService;
        }


        [HttpPost("SupplierPerformanceTracking/SetQuestion")]
        [Authorize(Roles = "Super Admin")]
        public async Task<IActionResult> SetQuestion([FromBody] SetQuestionDto setQuestionDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await supplierPerformanceTrackingService.SetQuestion(setQuestionDto);
                    if (!response)
                    {
                        return NotFound(new Responses<bool>(response, "500", "Record cannot be added."));
                    }
                    else
                    {
                        return Ok(new Responses<bool>(response, "200", "Records added successfully."));

                    }
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

        [HttpPost("SupplierPerformanceTracking/Admin/SetRating")]
        [Authorize(Roles = "Super Admin,Bid Inviter")]
        public async Task<IActionResult> SetRating([FromBody] SetRating setRating)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await supplierPerformanceTrackingService.SetRating(setRating);
                    if (!response)
                    {
                        return NotFound(new Responses<bool>(response, "500", "Record cannot be added."));
                    }
                    else
                    {
                        return Ok(new Responses<bool>(response, "200", "Records added successfully."));

                    }
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

        [HttpGet("SupplierPerformanceTracking/BidderCriteria")]
        [Authorize(Roles = "Super Admin,Bid Inviter,Bidder")]
        public async Task<IActionResult> BidderCriteria([FromQuery] long tenderId, [FromQuery] long companyId)
        {
            try
            {
                var response = await supplierPerformanceTrackingService.GetBidderCriteria(tenderId, companyId);
                if (response.Count()==0)
                {
                    return NotFound(new Responses<string>("Error", "500", "Record not found."));
                }
                else
                {
                    return Ok(new Responses<IEnumerable<SupplierPerformanceTrackingEntity>>(response, "200", "Records fetched successfully."));

                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        [HttpGet("SupplierPerformanceTracking/TenderRating")]
        [Authorize(Roles = "Super Admin,Bid Inviter")]
        public async Task<IActionResult> TenderRating([FromQuery] long tenderId)
        {
            try
            {
                var response = await supplierPerformanceTrackingService.GetTenderRating(tenderId);
                if (response == 0)
                {
                    return NotFound(new Responses<string>("Error", "500", "Record cannot be added."));
                }
                else
                {
                    return Ok(new Responses<double>(response, "200", "Records added successfully."));

                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        [HttpGet("SupplierPerformanceTracking/OverallRating")]
        [Authorize(Roles = "Super Admin,Bidder,Bid Inviter")]
        public async Task<IActionResult> OverallRating([FromQuery] long tenderId, [FromQuery] long companyId)
        {
            try
            {
                var response = await supplierPerformanceTrackingService.GetOverallRating(tenderId, companyId);
                if (response == 0)
                {
                    return NotFound(new Responses<string>("Error", "500", "Record cannot be added."));
                }
                else
                {
                    return Ok(new Responses<double>(response, "200", "Records added successfully."));

                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        [HttpGet("SupplierPerformanceTracking/TenderList")]
        [Authorize(Roles = "Super Admin")]
        public async Task<IActionResult> TenderList([FromQuery] PaginationQuery pagination, [FromQuery] string search = null)
        {
            try
            {
                string url = Url.Action("TenderList", null, null, Request.Scheme); //get url for current request
                this.uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<TenderListDto> tender = await supplierPerformanceTrackingService.GetTenderList(search);
                int totalCount = tender.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<TenderListDto>>(tender, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(tender, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception ex)
            {
                response.statusCode = "500";
                response.Message = $"{ex.Message} Inner Message: {(ex.InnerException != null ? ex.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        [HttpGet("SupplierPerformanceTracking/TenderCriteria")]
        [Authorize(Roles = "Super Admin")]
        public async Task<IActionResult> TenderCriteria([FromQuery] long tenderId)
        {
            try
            {
                var response = await supplierPerformanceTrackingService.GetTenderCriteria(tenderId);
                if (response.Count()==0)
                {
                    return NotFound(new Responses<string>("Error", "500", "Criterias not found."));
                }
                else
                {
                    return Ok(new Responses<IEnumerable<CriteriaDto>>(response, "200", "Criterias fetched successfully."));

                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        [HttpPut("SupplierPerformanceTracking/Criteria/Edit")]
        [Authorize(Roles ="Super Admin")]
        public async Task<IActionResult> Edit([FromBody] CriteriaEditDto criteriaEditDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await supplierPerformanceTrackingService.EditCriteria(criteriaEditDto);
                    if (!response)
                    {
                        return NotFound(new Responses<string>("Error", "500", "Record cannot be updated."));
                    }
                    else
                    {
                        return Ok(new Responses<bool>(response, "200", "Record updated successfully."));

                    }
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

        [HttpDelete("SupplierPerformanceTracking/Criteria/Delete")]
        [Authorize(Roles = "Super Admin")]
        public async Task<IActionResult> Delete([FromQuery] long id)
        {
            try
            {
                var response = await supplierPerformanceTrackingService.DeleteCriteria(id);
                if (!response)
                {
                    return NotFound(new Responses<string>("Error", "500", "Record cannot be deleted."));
                }
                else
                {
                    return Ok(new Responses<bool>(response, "200", "Record deleted successfully."));

                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        [HttpPost("SupplierPerformanceTracking/Criteria/Add")]
        [Authorize(Roles ="Super Admin")]
        public async Task<IActionResult> Add([FromBody] CriteraiAddDto criteraiAddDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await supplierPerformanceTrackingService.AddCriteria(criteraiAddDto);
                    if (!response)
                    {
                        return NotFound(new Responses<string>("Error", "500", "Record cannot be addedd."));
                    }
                    else
                    {
                        return Ok(new Responses<bool>(response, "200", "Record added successfully."));

                    }
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

        private PagedResponse<TenderListDto> ResultAfterPagination(IEnumerable<TenderListDto> tender, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<TenderListDto>(tender, totalCount);
            }

            var get = tender.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }
    }
}
