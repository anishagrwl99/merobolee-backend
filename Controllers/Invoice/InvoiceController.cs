using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using MeroBolee.Service.Inovice;

namespace MeroBolee.Controllers.Invoice
{
    public class InvoiceController : AuthorizeController 
    {
        private readonly ResponseMsg response = new ResponseMsg();
        private readonly InovicePdfService inovicePdfService;

        public InvoiceController (InovicePdfService inovicePdfService) 
        {
            this.inovicePdfService = inovicePdfService;
        }

        [HttpPost("Invoice/Generate")]
        public async Task<IActionResult> InvoicePdfGenerate([FromQuery] long TenderId, [FromQuery] long UserId) 
        {
            try 
            {
                
                 byte[] pdfcontent = await inovicePdfService.InvoicePdfGenerate(TenderId, UserId);
                    if (pdfcontent == null)
                    {
                        response.statusCode = "500";
                        response.Message = "Could Not Generate Bill for Tender";
                        return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
                    }
                return File(pdfcontent, "application/pdf", String.Format("Tender ID: {0}", TenderId));
            }
            catch(Exception e) 
            {
                response.statusCode = "500";
                response.Message = $"{e.Message} Inner Message: {(e.InnerException != null ? e.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

    }

}