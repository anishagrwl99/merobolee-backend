using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.Tender
{
    public class TenderController : BaseController
    {
        private readonly ITenderService tenderService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;
        public TenderController(ITenderService tenderService)
        {
            this.tenderService = tenderService;
        }



        /// <summary>
        /// To create a tender by admin (init var: tender)
        /// </summary>
        /// <param name="tender"></param>
        /// <returns></returns>
        [HttpPost("Tender/Admin/Create")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public async Task<IActionResult> Add([FromForm] AddTenderRequestDto tender)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await tenderService.AddTender(tender);
                    return Ok(new Responses<long>(res.Id, "200", "Record is successfully added"));
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
        /// To update tender (init var: tender)
        /// </summary>
        /// <param name="tender"></param>
        /// <returns></returns>
        [HttpPost("Tender/Admin/Update")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public async Task<IActionResult> UpdateTender([FromForm] UpdateTenderRequestDto tender)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TenderEntity resp = await tenderService.UpdateTender(tender);
                    if (resp == null)
                    {
                        response.statusCode = "404";
                        response.Message = "Record not Found";
                        return StatusCode(StatusCodes.Status404NotFound, new ErrorResponse<ResponseMsg>(response));
                    }
                    return Ok(new Responses<long>(resp.Id, "200", "Record is successfully updated"));
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
        /// To get tenders created on behalf of a company. (send companyId = null to load all companies tender)
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="companyId"></param>
        /// /// <param name="statusId"></param>
        /// <returns></returns>
        [HttpPost("Tender/Admin/List")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public async Task<IActionResult> GetTenderList([FromQuery] PaginationQuery pagination, [FromQuery] int statusId, [FromQuery] long? companyId = null)
        {
            try
            {
                string url = Url.Action("GetTenderList", null, new { companyId = companyId ,status=statusId}, Request.Scheme); //get url for current request
                this.uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<TenderCard> tenders = await tenderService.CompanyTendersForAdmin(statusId,companyId);
                int totalCount = tenders.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<TenderCard>>(tenders, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(tenders, pagination, totalCount)); // To pass result in object along with pagination info

            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }



        /// <summary>
        /// Deletes the specific tender by admin.
        /// </summary>
        /// <param name="tenderId">The tender identifier.</param>
        /// <returns></returns>
        [HttpDelete("Tender/Admin/Delete")]
        [Authorize(Roles = "Super Admin")]
        public async Task<IActionResult> DeleteTender([FromBody] long tenderId)
        {
            try
            {
                if (tenderId == 0)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid watchlist id";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
                else
                {
                    bool isDeleted =  await tenderService.DeleteTender(tenderId);
                    if (isDeleted)
                    {
                        response.statusCode = "200";
                        response.Message = "Record is successfully deleted";
                        return Ok(new ErrorResponse<ResponseMsg>(response));
                    }
                    else
                    {
                        return NotFound(new Responses<int>(0, "404", "Record not found to delete"));
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
        /// Get a tender history of a bid inviter company
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="companyId"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("Tender/BidInviter/History")]
        [Authorize(Roles = "Bid Inviter")]
        public async Task<IActionResult> GetBidInviterTenderHistory([FromQuery] PaginationQuery pagination, [FromQuery] long companyId, [FromQuery] string search = "")
        {
            try
            {
                string url = Url.Action("GetBidInviterTenderHistory", null, new { companyId = companyId, search = search }, Request.Scheme); //get url for current request
                this.uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<TenderCard> tenders = await tenderService.GetBidIniviterTenderHistory(companyId, search);
                tenders.OrderByDescending(x => x.LiveEndDate);
                int totalCount = tenders.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<TenderCard>>(tenders, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(tenders, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        /// <summary>
        /// Gat a tender listing of a bid inviter company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet("Tender/BidInviter/Listing")]
        [Authorize(Roles = "Bid Inviter")]
        public async Task<IActionResult> GetBidInviterTenderListing([FromQuery] long companyId)
        {
            try
            {
                if (companyId > 0)
                {
                    string url = Url.Action("GetBidInviterTenderListing", null, new { companyId = companyId }, Request.Scheme); //get url for current request
                    this.uriService = new UriService(url);
                    //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                    BidInviterTenderListing tenders = await tenderService.GetBidInviterTenderListing(companyId);
                    int totalCount = tenders.ActiveTenders.Count() + tenders.PendingTenders.Count();
                    if (totalCount == 0)
                    {
                        return NotFound(new Responses<BidInviterTenderListing>(tenders, "404", "Record not found"));
                    }
                    return Ok(new Responses<BidInviterTenderListing>(tenders, "200", "Record found"));
                }
                return NotFound(new Responses<BidInviterTenderListing>(null, "404", "Record not found"));
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// Approve a tender to show in marketplace
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("Tender/BidInviter/Approve")]
        [Authorize(Roles = "Bid Inviter")]
        public async Task<IActionResult> ApproveTender([FromBody] TenderApproveDto dto)
        {
            try
            {
                if (!isCompanyVerified)
                {
                    response.statusCode = "403";
                    response.Message = "You are forbidden to approve this tender.";
                    response.Data = "Company not verified";
                    return StatusCode(StatusCodes.Status403Forbidden, new ErrorResponse<ResponseMsg>(response));
                }
                if (ModelState.IsValid)
                {
                    TenderApproveDto res = await tenderService.ApproveTenderByBidInviter(dto);
                    return Ok(new Responses<TenderApproveDto>(res, "200", "Record is successfully updated"));
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
        /// To display all tender list by Admin
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("Tender/Marketplace")]
        public async Task<IActionResult> Marketplace([FromQuery] PaginationQuery pagination, [FromQuery] string search = null)
        {
            try
            {
                string url = Url.Action("Marketplace", null, new { search = search }, Request.Scheme); //get url for current request
                this.uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<TenderCard> tenders = await tenderService.GetMarketplaceTender(search);
                int totalCount = tenders.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<TenderCard>>(tenders, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(tenders, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }


        /// <summary>
        /// To display only upcoming tender for bidder
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="companyId"></param>
        /// <param name="isAlert"></param>
        /// <returns></returns>
        [HttpGet("Tender/Bidder/Upcoming")]
        [Authorize(Roles = "Bidder")]
        public async Task<IActionResult> GetUpCommingTender([FromQuery] PaginationQuery pagination, [FromQuery] long companyId, [FromQuery] bool isAlert = true)
        {
            try
            {
                if (companyId > 0)
                {
                    string url = Url.Action("GetUpCommingTender", null, new { companyId = companyId, isAlert = isAlert }, Request.Scheme); //get url for current request
                    this.uriService = new UriService(url);
                    //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                    bool isLiveBidUpcoming = true;
                    IEnumerable<TenderCard> tenders = await tenderService.UpcomingBidderTender(companyId, isAlert, isLiveBidUpcoming);
                    int totalCount = tenders.Count();
                    if (totalCount == 0)
                    {
                        return NotFound(new Responses<IEnumerable<TenderCard>>(tenders, "404", "Record not found"));
                    }
                    return Ok(ResultAfterPagination(tenders, pagination, totalCount)); // To pass result in object along with pagination info
                }
                return NotFound(new Responses<IEnumerable<TenderCard>>(null, "404", "Record not found"));
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }

                /// <summary>
        /// To display only upcoming tender for bidder
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="companyId"></param>
        /// <param name="isAlert"></param>
        /// <returns></returns>
        [HttpGet("Tender/Bidder/Upcoming/Sealed")]
        [Authorize(Roles = "Bidder")]
        public async Task<IActionResult> GetUpCommingTenderSealed([FromQuery] PaginationQuery pagination, [FromQuery] long companyId, [FromQuery] bool isAlert = true)
        {
            try
            {
                if (companyId > 0)
                {
                    string url = Url.Action("GetUpCommingTender", null, new { companyId = companyId, isAlert = isAlert }, Request.Scheme); //get url for current request
                    this.uriService = new UriService(url);
                    //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                    bool isLiveBidUpcoming = false;
                    IEnumerable<TenderCard> tenders = await tenderService.UpcomingBidderTender(companyId, isAlert, isLiveBidUpcoming);
                    int totalCount = tenders.Count();
                    if (totalCount == 0)
                    {
                        return NotFound(new Responses<IEnumerable<TenderCard>>(tenders, "404", "Record not found"));
                    }
                    return Ok(ResultAfterPagination(tenders, pagination, totalCount)); // To pass result in object along with pagination info
                }
                return NotFound(new Responses<IEnumerable<TenderCard>>(null, "404", "Record not found"));
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }


        /// <summary>
        /// To display only upcoming tender alert for bid inviter
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet("Tender/BidInviter/Upcoming")]
        [Authorize(Roles = "Bid Inviter")]
        public async Task<IActionResult> GetUpCommingTenderForBidInviter([FromQuery] PaginationQuery pagination, [FromQuery] long companyId)
        {
            try
            {
                if (companyId > 0)
                {
                    string url = Url.Action("GetUpCommingTenderForBidInviter", null, new { companyId = companyId }, Request.Scheme); //get url for current request
                    this.uriService = new UriService(url);
                    //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                    IEnumerable<TenderCard> tenders = await tenderService.UpcomingBidInviterTender(companyId);
                    int totalCount = tenders.Count();
                    if (totalCount == 0)
                    {
                        return NotFound(new Responses<IEnumerable<TenderCard>>(tenders, "404", "Record not found"));
                    }
                    return Ok(ResultAfterPagination(tenders, pagination, totalCount)); // To pass result in object along with pagination info
                }
                return NotFound(new Responses<IEnumerable<TenderCard>>(null, "404", "Record not found"));
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }



        [HttpGet("Tender/Admin/Upcoming")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public async Task<IActionResult> GetUpCommingTenderForAdmin([FromQuery] PaginationQuery pagination)
        {
            try
            {
                string url = Url.Action("GetUpCommingTenderForAdmin", null,null, Request.Scheme); //get url for current request
                this.uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<TenderCard> tenders = await tenderService.UpcomingTenderForAdmin();
                int totalCount = tenders.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<TenderCard>>(tenders, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(tenders, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }

        [HttpGet("Tender/Admin/LiveBids")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public async Task<IActionResult> LiveMarketplaceForAdmin([FromQuery] PaginationQuery pagination, [FromQuery] string search = null)
        {
            try
            {
                string url = Url.Action("LiveMarketplaceForAdmin", null, new { search = search }, Request.Scheme); //get url for current request
                this.uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<TenderCard> tenders = await tenderService.GetLiveBidMarketplaceTenderForAdmin(search);
                int totalCount = tenders.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<TenderCard>>(tenders, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(tenders, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }

        /// <summary>
        /// To individual detail of tender by tender id
        /// </summary>
        /// <param name="tenderId"></param>
        /// <param name = "userId"></param>
        /// <param name = "companyId"></param>
        /// <param name = "userRole"></param>
        /// <returns></returns>
        [HttpGet("Tender/TenderDetail")]
        public async Task<IActionResult> GetById([FromQuery] long tenderId, [FromQuery] long userId, [FromQuery]  long companyId, [FromQuery] string userRole)
        {
            try
            {
                if (tenderId == 0)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid tender id";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
                else
                {
                    if(userRole.Equals("Bidder")) {
                         bool isRegistered = await tenderService.isSupplierRegistered(tenderId, userId, companyId);
                         
                        GetTenderDto tenderEntity = await tenderService.GetTenderDetail(tenderId, _baseUrl, isRegistered, userRole);
                        if (tenderEntity == null)
                        {
                            response.statusCode = "404";
                            response.Message = "Record not found";
                            return StatusCode(StatusCodes.Status404NotFound, new ErrorResponse<ResponseMsg>(response));
                        }
                        return Ok(new Responses<GetTenderDto>(tenderEntity, "200", "Record found"));

                    }
                    else
                    {
                        GetTenderDto tenderEntity = await tenderService.GetTenderDetail(tenderId, _baseUrl, true, userRole);
                        if (tenderEntity == null)
                        {
                            response.statusCode = "404";
                            response.Message = "Record not found";
                            return StatusCode(StatusCodes.Status404NotFound, new ErrorResponse<ResponseMsg>(response));
                        }
                        return Ok(new Responses<GetTenderDto>(tenderEntity, "200", "Record found"));
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

        [HttpGet("Tender/TenderStatusBidInviter")]
        public async Task<IActionResult> GetTenderDetailBidInviterStatus([FromQuery] long tenderId, [FromQuery] long companyId)
        {
            try
            {
                if (tenderId == 0)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid tender id";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
                else
                {
                    int tenderStatusBidInviter = await tenderService.GetTenderDetailBidInviterStatus(tenderId, companyId);
                    return Ok(new Responses<int>(tenderStatusBidInviter, "200", "Record found"));

                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));

            }
        }
        
        
        [HttpGet("Tender/TenderStatusAdmin")]
        public async Task<IActionResult> TenderStatusForAdmin([FromQuery] long tenderId)
        {
            try
            {
                if (tenderId == 0)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid tender id";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
                else
                {
                    int tenderStatusBidInviter = await tenderService.TenderStatusForAdmin(tenderId);
                    return Ok(new Responses<int>(tenderStatusBidInviter, "200", "Record found"));

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
        /// To get tender documents created by merobolee
        /// </summary>
        /// <param name="tenderId"></param>
        /// <returns></returns>
        [HttpGet("Tender/Admin/TenderDocument")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public async Task<IActionResult> GetTenderDocuments([FromQuery] long tenderId)
        {
            try
            {
                TenderDocuments doc = await tenderService.GetTenderDocuments(tenderId, _baseUrl);
                if (doc == null)
                {
                    response.statusCode = "404";
                    response.Message = "Record not found";
                    return StatusCode(StatusCodes.Status404NotFound, new ErrorResponse<ResponseMsg>(response));
                }
                return Ok(new Responses<TenderDocuments>(doc, "200", "Record found"));
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        /// <summary>
        /// To get tender documents created by merobolee for suppliers
        /// </summary>
        /// <param name="tenderId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet("Tender/Bidder/TenderDocument")]
        [Authorize(Roles = "Bidder")]
        public async Task<IActionResult> GetTenderDocumentsForSupplier([FromQuery] long tenderId, [FromQuery] long companyId)
        {
            try
            {
                TenderDocuments doc = await tenderService.GetTenderDocumentsForSupplier(tenderId, companyId, _baseUrl);
                if (doc == null)
                {
                    response.statusCode = "404";
                    response.Message = "Record not found";
                    return StatusCode(StatusCodes.Status404NotFound, new ErrorResponse<ResponseMsg>(response));
                }
                return Ok(new Responses<TenderDocuments>(doc, "200", "Record found"));
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        [HttpGet("Tender/Bidder/TenderStatus")]
        public async Task<IActionResult> GetTenderStatus([FromQuery] long tenderId, [FromQuery] long userId)
        {
            try
            {
                TenderStatusDto status = await tenderService.GetTenderStatus(tenderId, userId);
                if (status == null)
                {
                    response.statusCode = "404";
                    response.Message = "Record not found";
                    return StatusCode(StatusCodes.Status404NotFound, new ErrorResponse<ResponseMsg>(response));
                }

                return Ok(new Responses<TenderStatusDto>(status, "200", "Record found"));
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        [HttpGet("Tender/AddTime")]
        [Authorize(Roles = "Bid Inviter")]

        public async Task<IActionResult> AddTime([FromQuery] long tenderId, [FromQuery] int min)
        {
            try
            {
                int status = await tenderService.AddTime(tenderId, min);

                return Ok(new Responses<int>(status, "200", $"{min} minute(s) has been added succesfully"));
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        [HttpGet("Tender/EndTender")]
        [Authorize(Roles = "Bid Inviter")]

        public async Task<IActionResult> EndTender([FromQuery] long tenderId)
        {
            try
            {
                int status = await tenderService.EndTender(tenderId);

                return Ok(new Responses<int>(status, "200", $"Tender with tenderId: {tenderId} ended successfully"));
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        [HttpPost("BidInvter/EnterBiddingRoom")]
        [Authorize(Roles = "Bid Inviter")]

        public async Task<IActionResult> EnterBidRoomBidInviter([FromQuery] long tenderId, [FromQuery] long companyId)
        {
            try
            {
                int status = await tenderService.EnterBidRoomBidInviter(tenderId, companyId);
                if(status == 1) {
                    return Ok(new Responses<int>(status, "200", "Bid Inviter allowed to enter bidding room"));
                } else {
                     response.statusCode = "404";
                     response.Message = "Inviter not allowed to enter in bidding room";
                     return StatusCode(StatusCodes.Status404NotFound, new ErrorResponse<ResponseMsg>(response));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        [HttpGet("Admin/Algorithms")]
        [Authorize(Roles = "Super Admin")]
        public async Task<IActionResult> AlgorithmList()
        {
            try 
            {
                List<AlgorithmEntity> algoList = await tenderService.AlgorithmList();
                return Ok(new Responses<List<AlgorithmEntity>>(algoList, "200", "Algorithm List Fetched"));
            } 
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        [HttpGet("Material/Category")]
        [Authorize(Roles = "Super Admin, Bid Inviter, Bidder")]
        public async Task<IActionResult> MaterialCategory([FromQuery] long tenderId)
        {
            try 
            {
                List<MaterialCatResDto> materialCatList = await tenderService.MaterialCategory(tenderId);
                return Ok(new Responses<List<MaterialCatResDto>>(materialCatList, "200", "Material List Fetched"));
            } 
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        [HttpGet("Material/List/CategoryWise")]
        [Authorize(Roles = "Super Admin, Bid Inviter, Bidder")]
        public async Task<IActionResult> MaterialListCategoryWise([FromQuery] long tenderId, [FromQuery] int materialId)
        {
            try 
            {
                List<TenderMaterialSealedResponseDto> materialList = await tenderService.MaterialListCategoryWise(tenderId, materialId);
                return Ok(new Responses<List<TenderMaterialSealedResponseDto>>(materialList, "200", "Material List Fetched Successfully"));
            } 
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        [HttpGet("Material/List/CategoryWise/RetriveData")]
        [Authorize(Roles = "Super Admin, Bid Inviter, Bidder")]
        public async Task<IActionResult> MaterialListCategoryWiseRetriveData([FromQuery] long tenderId, [FromQuery] int materialId, [FromQuery] long supplierId)
        {
            try 
            {
                RetriveDataSealBid retriveDataSealBid = await tenderService.MaterialListCategoryWiseRetriveData(tenderId, materialId, supplierId);
                return Ok(new Responses<RetriveDataSealBid>(retriveDataSealBid, "200", "Data Retrive Successful"));
            } 
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        [HttpGet("Material/CategoryWise/RetriveSubsectionTotal")]
        [Authorize(Roles = "Super Admin, Bid Inviter, Bidder")]
        public async Task<IActionResult> RetriveSubsectionTotal([FromQuery] long tenderId, [FromQuery] long supplierId)
        {
            try 
            {
                RetriveSubSectionDto retriveDataSealBid = await tenderService.RetriveSubsectionTotal(tenderId, supplierId);
                return Ok(new Responses<RetriveSubSectionDto>(retriveDataSealBid, "200", "Data Retrive Successful"));
            } 
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenderApprove"></param>
        /// <returns></returns>
        [HttpPost("Admin/ApproveTender")]
        [Authorize(Roles ="Super Admin")]
        public async Task<IActionResult> CommunityApproval([FromBody] TenderApproveDtoByAdmin tenderApprove)
        {
            try
            {
                TenderEntity tenderEntity = await tenderService.CommunityApproval(tenderApprove);
                if (tenderEntity == null)
                {
                    return NotFound(new Responses<TenderEntity>(tenderEntity, "404", "Record not found"));
                }

                if (tenderEntity != null && tenderApprove.status == true)
                {
                    return Ok(new Responses<TenderEntity>(tenderEntity, "200", "Tender is successfully updated"));
                }
                else
                {
                    response.statusCode = "500";
                    response.Message = "Your request has been process. The tender has been rejected!";
                    return StatusCode(StatusCodes.Status403Forbidden, new ErrorResponse<ResponseMsg>(response));
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
        /// Get the list of companies with their respective statusid in communityapproval table
        /// </summary>
        /// <param name="tenderId"></param>
        /// <returns></returns>
        [HttpGet("Admin/List/CommunityApprovalList")]
        [Authorize(Roles = "Super Admin")]
        public async Task<IActionResult> CommunityApprovalList([FromQuery] long tenderId)
        {
            try
            {
                var communityApprovalEntity = await tenderService.CommunityApprovalList(tenderId);
                if (communityApprovalEntity == null)
                {
                    return NotFound(new Responses<IEnumerable<CommunityApprovalDto>>(communityApprovalEntity, "404", "Record not found"));
                }
                return Ok(new Responses<IEnumerable<CommunityApprovalDto>>(communityApprovalEntity, "200", "Record found"));
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        private PagedResponse<GetTenderDto> ResultAfterPagination(IEnumerable<GetTenderDto> tenders, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<GetTenderDto>(tenders, totalCount);
            }

            var get = tenders.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

        private PagedResponse<TenderCard> ResultAfterPagination(IEnumerable<TenderCard> tenders, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<TenderCard>(tenders, totalCount);
            }

            var get = tenders.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }
    }
}
