using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service.VendorEnlistment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.VendorEnlistment
{
    public class VendorEnlistmentContoller : BaseController
    {
        private readonly ResponseMsg response = new ResponseMsg();
        private readonly IVendorEnlistmentService vendorEnlistmentService;

        public VendorEnlistmentContoller(IVendorEnlistmentService vendorEnlistmentService)
        {
            this.vendorEnlistmentService = vendorEnlistmentService;
        }

        [HttpPost("VendorEnlistment/Bidder/Add")]
        [Authorize(Roles = "Bidder")]
        public async Task<IActionResult> Add([FromForm] VendorEnlistmentAddDto vendorEnlistmentDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await vendorEnlistmentService.AddVendorEnlistment(vendorEnlistmentDto);
                    if (res == null)
                    {
                        return Conflict(new Responses<VendorEnlistmentAddDto>(res, "409", "Record already exists."));
                    }
                    else if (res.CompanyId == 0)
                    {
                        return NotFound(new Responses<long>(res.CompanyId, "404", "Company Id not found."));
                    }
                    else
                    {
                        return Ok(new Responses<VendorEnlistmentAddDto>(res, "200", "Record is successfully added"));
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

        [HttpGet("VendorEnlistment/ProcurementCategory")]
        [Authorize(Roles = "Bidder,Super Admin,Bid Inviter")]
        public async Task<IActionResult> ProcurementCategory([FromQuery] string id)
        {
            try
            {
                var response = await vendorEnlistmentService.GetProcurementCategory(id);
                if (response.Count() == 0)
                {
                    return NotFound(new Responses<IEnumerable<TenderProcurementCategoryEntity>>(response, "404", "Record not found."));
                }
                else
                {
                    return Ok(new Responses<IEnumerable<TenderProcurementCategoryEntity>>(response, "200", "Records fetched successfully."));

                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        [HttpPost("VendorEnlistment/AddProcurementCategory")]
        [Authorize(Roles = "Bidder,Super Admin")]
        public async Task<IActionResult> AddProcurementCategory([FromBody] ProcurementCategoryDto procurementCategoryDto)
        {
            try
            {
                var response = await vendorEnlistmentService.AddProcurementCategory(procurementCategoryDto);

                return Ok(new Responses<bool>(response, "200", "Records added successfully."));
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        [HttpGet("VendorEnlistment/DocumentType")]
        [Authorize(Roles = "Bidder")]
        public async Task<IActionResult> DocumentType()
        {
            try
            {
                var response = await vendorEnlistmentService.GetDocumentType();
                if (response.Count() == 0)
                {
                    return NotFound(new Responses<IEnumerable<DocumentTypeEntity>>(response, "404", "Record not found."));
                }
                else
                {
                    return Ok(new Responses<IEnumerable<DocumentTypeEntity>>(response, "200", "Records fetched successfully."));

                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        [HttpPost("VendorEnlistment/Admin/VendorEnlistmentForm/EnableOrDisable")]
        [Authorize(Roles = "Super Admin")]
        public async Task<IActionResult> EnableOrDisable([FromBody] VendorListEnableOrDisableDto vendorListEnableOrDisableDto)
        {
            try
            {
                var response = await vendorEnlistmentService.SetEnableOrDisable(vendorListEnableOrDisableDto);
                if (response == null)
                {
                    return NotFound(new Responses<VendorEnlistmentLogEntity>(response, "404", "Record not found."));
                }
                else
                {
                    return Ok(new Responses<VendorEnlistmentLogEntity>(response, "200", "Records added successfully."));

                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        [HttpGet("VendorEnlistment/Detail")]
        [Authorize(Roles = "Bidder,Super Admin,Bid Inviter")]
        public async Task<IActionResult> Detail([FromQuery] long companyId)
        {
            try
            {
                string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/";

                var response = await vendorEnlistmentService.GetVendorEnlistmentDetail(companyId, baseUrl);
                if (response == null)
                {
                    return NotFound(new Responses<VendorEnlistmentDetail>(response, "404", "Record not found."));
                }
                else
                {
                    return Ok(new Responses<VendorEnlistmentDetail>(response, "200", "Records fetched successfully."));

                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

        [HttpPut("VendorEnlistment/Update")]
        [Authorize(Roles = "Bidder,Super Admin")]
        public async Task<IActionResult> Update([FromForm] VendorEnlistmentAddDto vendorEnlistmentDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await vendorEnlistmentService.UpdateVendorEnlistment(vendorEnlistmentDto);
                    return Ok(new Responses<VendorEnlistmentAddDto>(res, "200", "Record is successfully updated"));
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

        [HttpDelete("VendorEnlistment/Document/Delete")]
        [Authorize(Roles = "Bidder")]
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
                    string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/";

                    var res = await vendorEnlistmentService.DeleteDocument(documentId,baseUrl);
                    if (res!=null)
                    {
                        return Ok(new Responses<IEnumerable<VendorEnlistmentDocumentDto>>(res, "200", "Record is successfully deleted"));
                    }
                    else
                    {
                        return NotFound(new Responses<int>(0, "404", "Record not found"));
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

        [HttpDelete("VendorEnlistment/ProcurementCategory/Delete")]
        [Authorize(Roles = "Bidder,Super Admin")]
        public async Task<IActionResult> ProcurementCategoryDelete([FromQuery] long id)
        {
            try
            {
                if (id == 0)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Procurement Category Id or Procurement Category not found";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
                else
                {
                    var res = await vendorEnlistmentService.DeleteProcurementCategory(id);
                    if (res)
                    {
                        return Ok(new Responses<string>("Ok", "200", "Record is successfully deleted"));
                    }
                    else
                    {
                        return NotFound(new Responses<string>("Error", "404", "Record not found"));
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
    }
}
