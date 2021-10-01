using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service.BidderReuest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.BiddingRequest
{
    public class BiddingRequestController : Controller
    {
        private readonly IBiddingRequestService biddingRequestService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;

        public BiddingRequestController(IBiddingRequestService biddingRequestService)
        {
            this.biddingRequestService = biddingRequestService;
        }


        /// <summary>
        /// Bid to a tender
        /// </summary>
        /// <param name="addBiddingRequest"></param>
        /// <returns></returns>
        [HttpPost("Bidding/EnterLiveBiddingRoom")]
        public async Task<IActionResult> Add([FromBody] AddBiddingRequestDto addBiddingRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GetBiddingRequestDto dto = await biddingRequestService.SendRequest(addBiddingRequest);
                    if (dto == null)
                    {
                        return NotFound(new Responses<GetBiddingRequestDto>(dto, "404", "Tender you bid for doesn't exist anymore."));
                    }
                    else
                    {
                        return Ok(new Responses<GetBiddingRequestDto>(dto, "200", "Record is successfully added"));
                    }
                    
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
                response.statusCode = "400";
                response.Message = $"{e.Message} Inner Message: {(e.InnerException != null ? e.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
            }
        }



        /// <summary>
        /// Submit a live bid (incomplete) Need to add more business rules. You can bid but validation won't happen
        /// </summary>
        /// <param name="bidRequest"></param>
        /// <returns></returns>
        [HttpPost("Bidding/LiveBid")]
        public async Task<IActionResult> LiveBid([FromBody] TenderMaterialBiddingDto bidRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    return Ok(new Responses<TenderMaterialBiddingDto>(await biddingRequestService.LiveBid(bidRequest), "200", "Record is successfully added"));
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
                response.statusCode = "400";
                response.Message = $"{e.Message} Inner Message: {(e.InnerException != null ? e.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
            }
        }

        /// <summary>
        /// To display all bids Request by Admin
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet("Bidding/All")]
        public IActionResult GetAll([FromQuery] PaginationQuery pagination)
        {
            try
            {
                string url = Url.Action("GetAll", null, null, Request.Scheme); //get url for current request
                this.uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<GetBiddingRequestDto> BiddingRequest = biddingRequestService.ShowAllRequest();
                int totalCount = BiddingRequest.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<GetBiddingRequestDto>>(BiddingRequest, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(BiddingRequest, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = $"{e.Message} Inner Message: {(e.InnerException != null ? e.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
            }

        }

        /// <summary>
        /// To display all bids submitted by Bidder
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        [HttpGet("Bidding/History")]
        public IActionResult GetBidderRequest([FromQuery] PaginationQuery pagination, [FromQuery] int supplierId)
        {
            try
            {
                string url = Url.Action("GetBidderRequest", null, null, Request.Scheme); //get url for current request
                this.uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<GetBiddingRequestDto> BiddingRequest = biddingRequestService.AllRequestByBidder(supplierId);
                int totalCount = BiddingRequest.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<GetBiddingRequestDto>>(BiddingRequest, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(BiddingRequest, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = $"{e.Message} Inner Message: {(e.InnerException != null ? e.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
            }

        }

        /// <summary>
        /// To get individual bid detail
        /// </summary>
        /// <param name="bidId"></param>
        /// <returns></returns>
        [HttpGet("Bidding/Bid/Detail")]
        public IActionResult GetById([FromQuery] int bidId)
        {
            try
            {
                if (bidId == 0)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
                else
                {
                    GetBiddingRequestDto getBiddingRequest = biddingRequestService.ShowRequest(bidId);
                    if (getBiddingRequest == null)
                    {
                        response.statusCode = "404";
                        response.Message = "Record not found";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    }
                    return Ok(new Responses<GetBiddingRequestDto>(getBiddingRequest, "200", "Record found"));
                }
            }

            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = $"{e.Message} Inner Message: {(e.InnerException != null ? e.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));

            }
        }

        /// <summary>
        /// To update BiddingRequest info and status is commonStatus
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        [HttpPut("Bidding/Update")]
        public IActionResult Update([FromQuery] int id, [FromBody] UpdateRequestDto updateRequest)
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
                        GetBiddingRequestDto getBiddingRequest = biddingRequestService.UpdateRequest(id, updateRequest);
                        if (getBiddingRequest == null)
                        {
                            response.statusCode = "404";
                            response.Message = "Record not Found";
                            return StatusCode(StatusCodes.Status404NotFound, new ErrorResponse<ResponseMsg>(response));
                        }
                        return Ok(new Responses<GetBiddingRequestDto>(getBiddingRequest, "200", "Record is successfully updated"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Invalid Format";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    }
                }
            }
            catch (Exception e)
            {
                response.statusCode = "400";
                response.Message = $"{e.Message} Inner Message: {(e.InnerException != null ? e.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));

            }
        }

        private PagedResponse<GetBiddingRequestDto> ResultAfterPagination(IEnumerable<GetBiddingRequestDto> getBiddingRequest, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<GetBiddingRequestDto>(getBiddingRequest, totalCount);
            }

            var get = getBiddingRequest.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

    }
}
