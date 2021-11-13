using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.City
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Bid Inviter, Bidder")]
    public class CompanyController : BaseController
    {
        private readonly ICompanyService companyService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }
        /// <summary>
        /// To add new company by bid inviter
        /// </summary>
        /// <returns></returns>
        [HttpPost("Company/BidInviter/Add")]
        public IActionResult AddBidInviterCompany([FromBody] AddCompanyDto addCompany)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AddCompanyResponseDto response = companyService.AddCompany(addCompany, CompanyTypeEnum.BidInviter);
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
                    
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// To add new company by bidder (supplier)
        /// </summary>
        /// <param name="addCompany">Request payload</param>
        /// <returns></returns>
        [HttpPost("Company/Bidder/Add")]
        public IActionResult AddBidderCompany([FromBody] AddCompanyDto addCompany)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AddCompanyResponseDto response = companyService.AddCompany(addCompany, CompanyTypeEnum.Bidder);
                    //if (getCity.Id == 0)
                    //{
                    //    response.statusCode = "400";
                    //    response.Message = "Invalid District";
                    //    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    //}
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

                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// To update bid inviter company
        /// </summary>
        /// <param name="company">Request payload</param>
        /// <returns></returns>
        [HttpPut("Company/BidInviter/Update")]
        public IActionResult UpdateBidInviterCompany([FromBody] AddCompanyResponseDto company)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AddCompanyResponseDto response = companyService.UpdateCompany(company.CompanyId, company, CompanyTypeEnum.BidInviter);
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

                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
            }
        }



        /// <summary>
        /// To update bidder (supplier) company
        /// </summary>
        /// <param name="company">Request payload</param>
        /// <returns></returns>
        [HttpPut("Company/Bidder/Update")]
        public IActionResult UpdateBidderCompany([FromBody] AddCompanyResponseDto company)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AddCompanyResponseDto response = companyService.UpdateCompany(company.CompanyId, company, CompanyTypeEnum.Bidder);
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

                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
            }
        }



        /// <summary>
        /// To add user in bid inviter company
        /// </summary>
        /// <param name="user">Request payload</param>
        /// <returns></returns>
        [HttpPost("Company/BidInviter/AddUser")]
        public IActionResult AddBidInviterCompanyUser([FromBody] AddUserDto user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AddUserReponseDto response = companyService.AddUser(user.CompanyId, user,2);
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

                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
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
        /// To add user in bidder (supplier) company
        /// </summary>
        /// <param name="user">Request payload</param>
        /// <returns></returns>
        [HttpPost("Company/Bidder/AddUser")]
        public IActionResult AddBidderCompanyUser([FromBody] AddUserDto user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AddUserReponseDto response = companyService.AddUser(user.CompanyId, user,3);
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

                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
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
        /// To display all company by Admin
        /// </summary>
        /// <param name="pagination">Pagination info</param>
        /// <param name="search">Search text</param>
        /// <returns></returns>
        [HttpGet("Company")]
        public IActionResult GetAll([FromQuery] PaginationQuery pagination, [FromQuery] string search = null)
        {
            try
            {
                string url = Url.Action("GetAll", null, null, Request.Scheme); //get url for current request
                uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<AddCompanyResponseDto> companies = companyService.GetCompany(search);
                int totalCount = companies.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<AddCompanyResponseDto>>(companies, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(companies, pagination, totalCount)); // To pass result in object along with pagination info
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }


        /// <summary>
        /// To get individual bid inviter company detail
        /// </summary>
        /// <param name="id">Company id</param>
        /// <returns></returns>
        [HttpGet("Company/BidInviter/Detail")]
        public IActionResult GetBidInviterById([FromQuery] long id)
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
                    CompanyDetailResponse company = companyService.GetCompanyDetail(id, CompanyTypeEnum.BidInviter);
                    if (company == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new Responses<CompanyDetailResponse>(company, "404", "Record not found"));
                    }
                    return Ok(new Responses<CompanyDetailResponse>(company, "200", "Record found"));
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
        /// To get individual company detail
        /// </summary>
        /// <param name="id">Company id</param>
        /// <returns></returns>
        [HttpGet("Company/Bidder/Detail")]
        public IActionResult GetBidderCompanyById([FromQuery] long id)
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
                    CompanyDetailResponse company = companyService.GetCompanyDetail(id, CompanyTypeEnum.Bidder);
                    if (company == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new Responses<CompanyDetailResponse>(company, "404", "Record not found"));
                    }
                    return Ok(new Responses<CompanyDetailResponse>(company, "200", "Record found"));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));

            }
        }


        private PagedResponse<AddCompanyResponseDto> ResultAfterPagination(IEnumerable<AddCompanyResponseDto> companies, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<AddCompanyResponseDto>(companies, totalCount);
            }

            var get = companies.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

    }
}
