using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.BiddingRequest
{
    /// <summary>
    /// Bidding request controller
    /// </summary>
    public class BiddingRequestController : BaseController
    {
        private readonly IBiddingRequestService biddingRequestService;
        private readonly IMemoryStreamService streamService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="biddingRequestService"></param>
        /// <param name="streamService"></param>
        public BiddingRequestController(IBiddingRequestService biddingRequestService, IMemoryStreamService streamService)
        {
            this.biddingRequestService = biddingRequestService;
            this.streamService = streamService;
        }


        /// <summary>
        /// Register into a tender for bidding (init var: registration)
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        [HttpPost("Bidding/Register")]
        public async Task<IActionResult> RegisterForTender([FromForm] RegisterForTenderDto registration)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    long bidId = await biddingRequestService.RegisterInTenderBidding(registration);
                    if (bidId > 0)
                    {
                        return Ok(new Responses<long>(bidId, "200", "Registration for bidding successful"));
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status302Found, new Responses<long>(-1, "302", "You have already registered for a tender"));
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
            catch (Exception ex)
            {
                response.statusCode = "500";
                response.Message = $"{ex.Message} Inner Message: {(ex.InnerException != null ? ex.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        /// <summary>
        /// Update registered into a tender for bidding (init var: registration)
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        [HttpPut("Bidding/Register")]
        public async Task<IActionResult> UpdateForTenderRegistration([FromForm] UpdateRegistrationForTenderDto registration)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    long bidId = await biddingRequestService.UpdateRegistration(registration);
                    if (bidId > 0)
                    {
                        return Ok(new Responses<long>(bidId, "200", "Registration for bidding successful"));
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status302Found, new Responses<long>(-1, "302", "You have already registered for a tender"));
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
            catch (Exception ex)
            {
                response.statusCode = "500";
                response.Message = $"{ex.Message} Inner Message: {(ex.InnerException != null ? ex.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        /// <summary>
        /// Bid to a tender
        /// </summary>
        /// <param name="addBiddingRequest"></param>
        /// <returns></returns>
        [HttpPost("Bidding/EnterLiveBiddingRoom")]
        public async Task<IActionResult> EnterLiveBiddingRoom([FromBody] AddBiddingRequestDto addBiddingRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EnterLiveBiddingRoomResponseDto dto = await biddingRequestService.EnterLiveBiddingRoom(addBiddingRequest);
                    if (dto.BidId > 0)
                    {
                        return Ok(new Responses<EnterLiveBiddingRoomResponseDto>(dto, "200", "Record is successfully added"));
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status403Forbidden, new Responses<long>(-1, "403", "You can't enter a live bidding room"));
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
                response.Message = $"{e.Message} Inner Message: {(e.InnerException != null ? e.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// Get a bidding position in a applied tender
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="tenderId"></param>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        [HttpGet("Bidding/Position")]
        public async Task<IActionResult> GetBiddingPosition([FromQuery] PaginationQuery pagination, [FromQuery] int tenderId, [FromQuery] int supplierId)
        {
            string url = Url.Action("GetBiddingPosition", null, null, Request.Scheme); //get url for current request
            this.uriService = new UriService(url);
            LiveBidResponse res = await biddingRequestService.TenderPosition(tenderId, supplierId);
            //int totalCount = res.Count();
            if (res.IsBidSuccess)
            {
                return Ok(new Responses<LiveBidResponse>(res, "200", res.Message));
            }
            else
            {
                return NotFound(new Responses<LiveBidResponse>(null, "404", res.Message));
            }
            //return Ok(ResultAfterPagination(res, pagination, totalCount)); // To pass result in object along with pagination info
        }



        /// <summary>
        /// Submit a bid during live auction time 
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
                    LiveBidResponse res = await biddingRequestService.LiveBid(bidRequest);

                    if (res.IsBidSuccess)
                    {
                        return Ok(new Responses<LiveBidResponse>(res, "200", res.Message));
                    }
                    else
                    {
                        return StatusCode(400, new Responses<LiveBidResponse>(res, "400", res.Message));
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
                response.Message = $"{e.Message} Inner Message: {(e.InnerException != null ? e.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }



        /// <summary>
        /// Get a remaining time interval to bid a tender
        /// </summary>
        /// <param name="tenderId">A tender id whose interval needs to check</param>
        /// <returns></returns>

        [HttpGet("Bidding/CheckBiddingTime")]
        public async Task<IActionResult> CheckBiddingTime([FromQuery] long tenderId)
        {
            try
            {
                ResetBidDto response = await biddingRequestService.CheckBiddingTime(tenderId);
                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound(new Responses<ResetBidDto>(response, "404", "Tender record not found"));
                }

            }
            catch (Exception e)
            {

                response.statusCode = "500";
                response.Message = $"{e.Message} Inner Message: {(e.InnerException != null ? e.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

            //return ResetBidDto;
        }



        /// <summary>
        /// Automatically bid to a tender with a price less than x% of previous price
        /// </summary>
        /// <returns></returns>
        [HttpPost("Bidding/AutoBid")]
        public IActionResult AutoBid([FromBody] TenderAutoBidDto autoBidDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LiveBidResponse response = biddingRequestService.AutoBid(autoBidDto);
                    if (response.IsBidSuccess)
                    {
                        return Ok(new Responses<LiveBidResponse>(response, "200", response.Message));
                    }
                    else
                    {
                        return StatusCode(400, new Responses<LiveBidResponse>(response, "400", response.Message));
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
                response.Message = $"{e.Message} Inner Message: {(e.InnerException != null ? e.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// To display all bids submitted by Bidder
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="supplierCompanyId"></param>
        /// <returns></returns>
        [HttpGet("Bidding/History")]
        public async Task<IActionResult> GetBidderRequest([FromQuery] PaginationQuery pagination, [FromQuery] long supplierCompanyId)
        {
            try
            {
                string url = Url.Action("GetBidderRequest", null, new { supplierCompanyId = supplierCompanyId }, Request.Scheme); //get url for current request
                this.uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<BidHistoryCardDto> BiddingRequest = await biddingRequestService.SupplierBidHistory(supplierCompanyId);
                int totalCount = BiddingRequest.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<BidHistoryCardDto>>(BiddingRequest, "404", "Record not found"));
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
        /// <param name="companyId"></param>
        /// <param name="tenderId"></param>
        /// <returns></returns>
        [HttpGet("Bidding/Bid/Detail")]
        public async Task<IActionResult> GetDetail([FromQuery] long bidId, [FromQuery] long companyId, [FromQuery] long tenderId)
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
                    BidDetailDto getBiddingRequest = await biddingRequestService.BidDetail(bidId, companyId, tenderId, _baseUrl);
                    if (getBiddingRequest == null)
                    {
                        response.statusCode = "404";
                        response.Message = "Record not found";
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    }
                    return Ok(new Responses<BidDetailDto>(getBiddingRequest, "200", "Record found"));
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
        /// Get a auction logs associated with a tender auction from all bidders
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("Bidding/BidInviter/AuctionLog")]
        public async Task<IActionResult> GetAuctionLogForBidInviter([FromQuery] PaginationQuery pagination, [FromQuery] AuctionLogRequestDto dto)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    string url = Url.Action("GetAuctionLogForBidInviter", null, new { CompanyId = dto.CompanyId, TenderId = dto.TenderId }, Request.Scheme); //get url for current request
                    this.uriService = new UriService(url);
                    //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                    List<AuctionLog> logs = await biddingRequestService.GetTenderAuctionLogForBidInviter(dto.TenderId);
                    int totalCount = logs.Count();
                    if (totalCount == 0)
                    {
                        return NotFound(new Responses<List<AuctionLog>>(logs, "404", "Record not found"));
                    }
                    return Ok(ResultAfterPagination(logs, pagination, totalCount)); // To pass result in object along with pagination info
                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid request data";
                    response.Data = ModelState;
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

        /// <summary>
        /// Get a auction logs in a file associated with a tender auction from all bidders
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("Bidding/BidInviter/AuctionLog/Download")]
        public async Task<IActionResult> GetAuctionLogForBidInviterInFile([FromQuery] PaginationQuery pagination, [FromQuery] AuctionLogRequestDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string url = Url.Action("GetAuctionLogForBidInviter", null, new { CompanyId = dto.CompanyId, TenderId = dto.TenderId }, Request.Scheme); //get url for current request
                    this.uriService = new UriService(url);
                    //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                    List<AuctionLog> logs = await biddingRequestService.GetTenderAuctionLogForBidInviter(dto.TenderId);
                    int totalCount = logs.Count();
                    if (totalCount == 0)
                    {
                        return NotFound(new Responses<List<AuctionLog>>(logs, "404", "Record not found"));
                    }
                    byte[] fileContent = streamService.ToArray(logs);
                    return File(fileContent, "text/csv", $"AuctionLog_{logs.FirstOrDefault().TenderId}.csv");
                    //return Ok(ResultAfterPagination(logs, pagination, totalCount)); // To pass result in object along with pagination info
                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid request data";
                    response.Data = ModelState;
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


        /// <summary>
        /// Get a auction logs associated with a tender auction submitted by a specific bidder
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("Bidding/Bidder/AuctionLog")]
        public async Task<IActionResult> GetAuctionLog([FromQuery] PaginationQuery pagination, [FromQuery] AuctionLogRequestDto dto)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    string url = Url.Action("GetAuctionLog", null, new { CompanyId = dto.CompanyId, TenderId = dto.TenderId }, Request.Scheme); //get url for current request
                    this.uriService = new UriService(url);
                    //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                    List<AuctionLog> logs = await biddingRequestService.GetTenderAuctionLog(dto.CompanyId, dto.TenderId);
                    int totalCount = logs.Count();
                    if (totalCount == 0)
                    {
                        return NotFound(new Responses<List<AuctionLog>>(logs, "404", "Record not found"));
                    }
                    return Ok(ResultAfterPagination(logs, pagination, totalCount)); // To pass result in object along with pagination info
                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid request data";
                    response.Data = ModelState;
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

        /// <summary>
        /// Get a auction logs in a file associated with a tender auction submitted by a specific bidder
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("Bidding/Bidder/AuctionLog/Download")]
        public async Task<IActionResult> GetAuctionLogInFile([FromQuery] PaginationQuery pagination, [FromQuery] AuctionLogRequestDto dto)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    string url = Url.Action("GetAuctionLog", null, new { CompanyId = dto.CompanyId, TenderId = dto.TenderId }, Request.Scheme); //get url for current request
                    this.uriService = new UriService(url);
                    //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                    List<AuctionLog> logs = await biddingRequestService.GetTenderAuctionLog(dto.CompanyId, dto.TenderId);
                    int totalCount = logs.Count();
                    if (totalCount == 0)
                    {
                        return NotFound(new Responses<List<AuctionLog>>(logs, "404", "Record not found"));
                    }
                    byte[] fileContent = streamService.ToArray(logs);
                    return File(fileContent, "text/csv", $"AuctionLog_{logs.FirstOrDefault().TenderId}.csv");
                    //return Ok(ResultAfterPagination(logs, pagination, totalCount)); // To pass result in object along with pagination info
                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid request data";
                    response.Data = ModelState;
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


        /// <summary>
        /// List all suppliers who registered for a tender bidding 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="tenderId"></param>
        /// <returns></returns>
        [HttpGet("Bidding/Admin/Registrations")]
        public async Task<IActionResult> Registrations([FromQuery] PaginationQuery pagination, [FromQuery] long tenderId)
        {
            try
            {
                string url = Url.Action("Registrations", null, new { tenderId = tenderId }, Request.Scheme); //get url for current request
                this.uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<BidCardDto> BiddingRequest = await biddingRequestService.ShowAllRegistration(tenderId);
                int totalCount = BiddingRequest.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<BidCardDto>>(BiddingRequest, "404", "Record not found"));
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
        /// To update BiddingRequest info and status is bid status
        /// </summary>
        /// <param name="biID"></param>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        [HttpPut("Bidding/Admin/Registration/ApproveOrDisapprove")]
        public async Task<IActionResult> ApproveOrDisapprove([FromBody] BidUpdateRequestDto updateRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BidCardDto getBiddingRequest = await biddingRequestService.ApproveOrDisapprove(updateRequest);
                    if (getBiddingRequest == null)
                    {
                        response.statusCode = "404";
                        response.Message = "Record not Found";
                        return StatusCode(StatusCodes.Status404NotFound, new ErrorResponse<ResponseMsg>(response));
                    }
                    return Ok(new Responses<BidCardDto>(getBiddingRequest, "200", "Record is successfully updated"));
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
                response.Message = $"{e.Message} Inner Message: {(e.InnerException != null ? e.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));

            }
        }

        /// <summary>
        /// Select a tender winner 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("Bidding/Admin/SetTenderWinner")]
        public async Task<IActionResult> SelectBidWinner([FromBody] BidWinnerRequestDto dto)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    long id = await biddingRequestService.SetTenderWinner(dto);
                    if (id < 0)
                    {
                        response.statusCode = "409";
                        response.Message = "Bid winner already selected";
                        return StatusCode(StatusCodes.Status409Conflict, new ErrorResponse<ResponseMsg>(response));
                    }
                    return Ok(new Responses<long>(id, "200", "Tender winner selected"));
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
                response.Message = $"{e.Message} Inner Message: {(e.InnerException != null ? e.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        private PagedResponse<AuctionLog> ResultAfterPagination(IEnumerable<AuctionLog> logs, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<AuctionLog>(logs, totalCount);
            }

            var get = logs.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

        private PagedResponse<BidCardDto> ResultAfterPagination(IEnumerable<BidCardDto> getBiddingRequest, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<BidCardDto>(getBiddingRequest, totalCount);
            }

            var get = getBiddingRequest.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

        private PagedResponse<BidHistoryCardDto> ResultAfterPagination(IEnumerable<BidHistoryCardDto> getBiddingRequest, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<BidHistoryCardDto>(getBiddingRequest, totalCount);
            }

            var get = getBiddingRequest.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }


        private PagedResponse<LiveBidResponse> ResultAfterPagination(IEnumerable<LiveBidResponse> getBiddingRequest, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<LiveBidResponse>(getBiddingRequest, totalCount);
            }

            var get = getBiddingRequest.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

    }
}
