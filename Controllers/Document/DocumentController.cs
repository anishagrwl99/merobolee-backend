using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers
{
    /// <summary>
    /// Document endpoint controller
    /// </summary>
    public class DocumentController : AuthorizeController
    {
        private readonly ICompanyDocumentService documentService;
        private readonly IDocumentTypeService docTypeService;
        private readonly PaginationMapper pagination = new();
        private readonly ResponseMsg response = new();
        private IUriService uriService;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="documentService"></param>
        /// <param name="docTypeService"></param>
        public DocumentController(ICompanyDocumentService documentService, IDocumentTypeService docTypeService)
        {
            this.documentService = documentService;
            this.docTypeService = docTypeService;
        }



        /// <summary>
        /// Types of document company can upload
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet("Document/Type")]
        public IActionResult GetDocumentType([FromQuery] PaginationQuery pagination)
        {
            try
            {
                string url = Url.Action("GetDocumentType", null, null, Request.Scheme); //get url for current request
                uriService = new UriService(url);
                //{this.Request.Host}{this.Request.PathBase} // Base Link for pagination
                IEnumerable<DocumentTypeEntity> docTypes = docTypeService.List();
                int totalCount = docTypes.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<DocumentTypeEntity>>(docTypes, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(docTypes, pagination, totalCount)); // To pass result in object along with paginatio
            }
            catch (Exception ex)
            {
                response.statusCode = "500";
                response.Message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// List of all documents company has uploaded along with their respective status and remarks
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet("Document/List")]
        public IActionResult GetCompanyDocument([FromQuery] PaginationQuery pagination, [FromQuery] int companyId)

        {
            try
            {
                string url = Url.Action("GetCompanyDocument", null, new { companyId = companyId}, Request.Scheme); //get url for current request
                uriService = new UriService(url);
                string _baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/";
                IEnumerable<DocumentResponseDto> docs = documentService.GetAllDocument(companyId, _baseUrl);
                int totalCount = docs.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<DocumentResponseDto>>(docs, "404", "Record not found"));
                }
                return Ok(ResultAfterPagination(docs, pagination, totalCount)); // To pass result in object along with paginatio
            }
            catch (Exception ex)
            {
                response.statusCode = "500";
                response.Message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// Upload a document by document type (init var: document)
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        /// 
        [HttpPost("Document/Upload")]
        public async Task<IActionResult> Upload([FromForm] DocumentDto document)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DocumentDto doc = await documentService.AddDocument(document);
                    return Ok(new Responses<DocumentDto>(doc, "200", "Record is successfully added"));
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
                response.Message = $"{ex.Message} {(ex.InnerException != null? ex.InnerException.Message : "")}";//"Something went wrong";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }


        /// <summary>
        /// Change status of a document by an admin
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("Document/ChangeStatus")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Super Admin, Tender Support, Customer Support")]
        public IActionResult ChangeStatus([FromBody] DocumentUpdateStatusDto dto)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    DocumentUpdateStatusDto doc = documentService.ChangeStatus(dto);
                    return Ok(new Responses<DocumentUpdateStatusDto>(doc, "200", "Record is successfully added"));
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
                response.Message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message);//"Something went wrong";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        [HttpDelete("Document/Delete")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Super Admin, Bidder, Bid Inviter")]
        public async Task<IActionResult> DeleteDocument([FromQuery] long documentId)
        {
            try
            {
                if (documentId == 0)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Document Id or Document Not found";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
                else
                {
                    bool isDeleted =  await documentService.DeleteDocument(documentId);
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



        private PagedResponse<DocumentResponseDto> ResultAfterPagination(IEnumerable<DocumentResponseDto> docs, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<DocumentResponseDto>(docs, totalCount);
            }

            var get = docs.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

        private PagedResponse<DocumentStatusEntity> ResultAfterPagination(IEnumerable<DocumentStatusEntity> docStatus, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<DocumentStatusEntity>(docStatus, totalCount);
            }

            var get = docStatus.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

        private PagedResponse<DocumentTypeEntity> ResultAfterPagination(IEnumerable<DocumentTypeEntity> docType, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<DocumentTypeEntity>(docType, totalCount);
            }

            var get = docType.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }

    }
}
