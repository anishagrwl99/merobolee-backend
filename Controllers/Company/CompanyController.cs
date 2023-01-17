using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Service;
using MeroBolee.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.City
{
    /// <summary>
    /// 
    /// </summary>
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Bid Inviter, Bidder")]
    public class CompanyController : BaseController
    {
        private readonly ICompanyService companyService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private readonly AppDefaults defaultOption;
        private IUriService uriService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyController"/> class.
        /// </summary>
        /// <param name="companyService">The company service.</param>
        /// <param name="defaultOption">The default option.</param>
        public CompanyController(ICompanyService companyService, IOptions<AppDefaults> defaultOption)
        {
            this.companyService = companyService;
            this.defaultOption = defaultOption.Value;
        }


        /// <summary>
        /// To add new company by bid inviter
        /// </summary>
        /// <returns></returns>
        [HttpPost("Company/BidInviter/Add")]
        [Authorize(Roles = "Bid Inviter")]
        public async Task<IActionResult> AddBidInviterCompany([FromBody] AddCompanyDto addCompany)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AddCompanyResponseDto response = await companyService.AddCompany(addCompany, CompanyTypeEnum.BidInviter);
                    //if (getCity.Id == 0)
                    //{
                    //    response.statusCode = "400";
                    //    response.Message = "Invalid District";
                    //    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    //}
                    if(response != null)
                    {
                        return Ok(new Responses<AddCompanyResponseDto>(response, "200", "Record is successfully added"));
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, new Responses<AddCompanyResponseDto>(null, "500", "Could not add company"));
                    }
                    
                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    response.Data = ModelState;
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
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
        /// To add new company by bidder (supplier)
        /// </summary>
        /// <param name="addCompany">Request payload</param>
        /// <returns></returns>
        [HttpPost("Company/Bidder/Add")]
        [Authorize(Roles = "Bidder")]
        public async Task<IActionResult> AddBidderCompany([FromBody] AddCompanyDto addCompany)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AddCompanyResponseDto response = await companyService.AddCompany(addCompany, CompanyTypeEnum.Bidder);
                    if (response != null)
                    {
                        return Ok(new Responses<AddCompanyResponseDto>(response, "200", "Record is successfully added"));
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, new Responses<AddCompanyResponseDto>(null, "500", "Could not add company"));
                    }

                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    response.Data = ModelState;
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
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
        /// To update registered companies
        /// </summary>
        /// <param name="company">Request payload</param>
        /// <returns></returns>
        [HttpPut("Company/Admin/Update")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public async Task<IActionResult> UpdateBidInviterCompany([FromBody] AddCompanyResponseDto company)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AddCompanyResponseDto resp = await companyService.UpdateCompany(company);
                    if (resp != null)
                    {
                        return Ok(new Responses<AddCompanyResponseDto>(resp, "200", "Record is successfully added"));
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, new Responses<AddCompanyResponseDto>(null, "500", "Could not update company"));
                    }

                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    response.Data = ModelState;
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// To add user in bid inviter company
        /// </summary>
        /// <param name="user">Request payload</param>
        /// <returns></returns>
        [HttpPost("Company/BidInviter/AddUser")]
        [Authorize(Roles = "Bid Inviter")]
        public async Task<IActionResult> AddBidInviterCompanyUser([FromBody] AddUserDto user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AddUserReponseDto response = await companyService.AddUser(user.CompanyId, user,2);
                    if (response != null)
                    {
                        return Ok(new Responses<AddUserReponseDto>(response, "200", "Record is successfully added"));
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, new Responses<AddUserReponseDto>(null, "500", "Could not add company"));
                    }

                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    response.Data = ModelState;
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
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
        /// To add user in bidder (supplier) company
        /// </summary>
        /// <param name="user">Request payload</param>
        /// <returns></returns>
        [HttpPost("Company/Bidder/AddUser")]
        [Authorize(Roles = "Bidder")]
        public async Task<IActionResult> AddBidderCompanyUser([FromBody] AddUserDto user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AddUserReponseDto response = await companyService.AddUser(user.CompanyId, user,3);
                    if (response != null)
                    {
                        return Ok(new Responses<AddUserReponseDto>(response, "200", "Record is successfully added"));
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, new Responses<AddUserReponseDto>(null, "500", "Could not add company"));
                    }

                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    response.Data = ModelState;
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
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
        /// To get all companies by type (0: Bid Inviter, 1: Bidder or Supplier)
        /// </summary>
        /// <param name="pagination">Pagination info</param>
        /// <param name="companyType">Company type info (0 for Bid Inviter, 1 For Supplier)</param>
        /// <param name="search">Search text</param>
        /// <returns></returns>
        [HttpGet("Company/ByType")]
        public async Task<IActionResult> GetAllCompanyByType([FromQuery] PaginationQuery pagination, [FromQuery] CompanyTypeEnum companyType = CompanyTypeEnum.Bidder,  [FromQuery] string search = null)
        {
            try
            {
                string url = Url.Action("GetAllCompanyByType", null, new { companyType = companyType, search = search}, Request.Scheme); //get url for current request
                uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<CompanyCardResponseDto> companies = await companyService.GetCompanyByType(companyType, search);
                int totalCount = companies.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<CompanyCardResponseDto>>(companies, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(companies, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }



        /// <summary>
        /// Gets all company.
        /// </summary>
        /// <param name="pagination">The pagination.</param>
        /// <param name="search">The search.</param>
        /// <returns></returns>
        [HttpGet("Company/All")]
        public async Task<IActionResult> GetAllCompany([FromQuery] PaginationQuery pagination, [FromQuery] string search = null)

        {
            try
            {
                string url = Url.Action("GetAllCompany", null, new {  search = search }, Request.Scheme); //get url for current request
                uriService = new UriService(url);
                IEnumerable<CompanyCardResponseDto> companies = await companyService.GetAllCompany(search);
                int totalCount = companies.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<CompanyCardResponseDto>>(companies, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(companies, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }

        /// <summary>
        /// Get verified bid inviter to create a tender card
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("Company/Verified/BidInviter")]
        public async Task<IActionResult> GetVerifiedBidInviter([FromQuery] PaginationQuery pagination, [FromQuery] string search = null)
        {
            try
            {
                string url = Url.Action("GetVerifiedBidInviter", null, new { search = search }, Request.Scheme); //get url for current request
                uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<CompanyCardResponseDto> companies = await companyService.GetVerifiedCompany(CompanyTypeEnum.BidInviter, search);
                int totalCount = companies.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<CompanyCardResponseDto>>(companies, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(companies, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }
        


        /// <summary>
        /// Get verified bidder
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("Company/Verified/Bidder")]
        public async Task<IActionResult> GetVerifiedBidder([FromQuery] PaginationQuery pagination, [FromQuery] string search = null)
        {
            try
            {
                string url = Url.Action("GetVerifiedBidInviter", null, new { search = search }, Request.Scheme); //get url for current request
                uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<CompanyCardResponseDto> companies = await companyService.GetVerifiedCompany(CompanyTypeEnum.Bidder, search);
                int totalCount = companies.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<CompanyCardResponseDto>>(companies, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(companies, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }

        /// <summary>
        /// To get individual bid company detail
        /// </summary>
        /// <param name="companyId">Company Id of a company whose detail needs to fetch</param>
        /// <returns></returns>
        [HttpGet("Company/Detail")]
        public async Task<IActionResult> GetCompanyDetail([FromQuery] long companyId)
        {
            try
            {
                if (companyId > 0)
                {
                    string _defaultPic = $"{_baseUrl}{defaultOption.DefaultProfilePicture}";

                    CompanyDetailResponse company = await companyService.GetCompanyDetail(companyId, _baseUrl, _defaultPic);
                    if (company == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new Responses<CompanyDetailResponse>(company, "404", $"Record not found"));
                    }
                    else
                    {
                        return Ok(new Responses<CompanyDetailResponse>(company, "200", "Record found"));
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new Responses<CompanyDetailResponse>(null, "404", $"Record not found"));
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
        /// Change the status of a supplier and bid inviter registered company
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("Company/Admin/ChangeStatus")]
        [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
        public async Task<IActionResult> ChangeStatus([FromBody] ChangeCompanyStatusDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ChangeCompanyStatusResponseDto response = await companyService.ChangeCompanyStatus(dto);
                    if (response != null)
                    {
                        return Ok(new Responses<ChangeCompanyStatusResponseDto>(response, "200", "Record is successfully updated"));
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, new Responses<AddUserReponseDto>(null, "500", "Could not change company status"));
                    }

                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    response.Data = ModelState;
                    return StatusCode(StatusCodes.Status400BadRequest, response);
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        private PagedResponse<CompanyCardResponseDto> ResultAfterPagination(IEnumerable<CompanyCardResponseDto> companies, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<CompanyCardResponseDto>(companies, totalCount);
            }

            var get = companies.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

    }
}
