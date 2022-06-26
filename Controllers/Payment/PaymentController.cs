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


namespace MeroBolee.Controllers.Payment
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService paymentService;
        private readonly ResponseMsg response = new ResponseMsg();


        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpPost("Payment")]
        public async Task<IActionResult> GenerateTokenConnectIPS([FromBody] ConnectIPSRequestDto connectIPSRequestDto)
        {
            try
            {
                ConnectIPSResponseDto connectIPSResponseDto = await paymentService.GenerateTokenConnectIPS(connectIPSRequestDto);
                if (connectIPSResponseDto != null)
                {
                    return Ok(new Responses<ConnectIPSResponseDto>(connectIPSResponseDto, "200", "Token Successfully Generated"));

                }
                else
                {
                    response.statusCode = "503";
                    response.Message = "unable to make payment";
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
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