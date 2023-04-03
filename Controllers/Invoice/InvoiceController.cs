using MeroBolee.Infrastructure;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
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

        [HttpGet("Invoice/Generate")]
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

        [HttpGet("Invoice/Generate/All")]
        public async Task<IActionResult> InvoicePdfGenerateAll([FromQuery] long TenderId) 
        {
            try 
            {
                
                 byte[] pdfcontent = await inovicePdfService.InvoicePdfGenerateAll(TenderId);
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

        [HttpGet("Invoice/Generate/Consolidate/Report")]
        public async Task<IActionResult> InvoicePdfGenerateConsolidateReport([FromQuery] long TenderId) 
        {
            try 
            {
                
                 byte[] pdfcontent = await inovicePdfService.InvoicePdfGenerateConsolidateReport(TenderId);
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

        [HttpGet("Invoice/Generate/SealBid/Report")]
        public async Task<IActionResult> GenerateSealBidReport([FromQuery] string htmlString) 
        {
            try 
            {
                
                 byte[] pdfcontent = await inovicePdfService.GenerateSealBidReport(htmlString);
                    if (pdfcontent == null)
                    {
                        response.statusCode = "500";
                        response.Message = "Could Not Generate Bill for Tender";
                        return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
                    }
                return File(pdfcontent, "application/pdf", String.Format("Tender ID: {0}"));
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