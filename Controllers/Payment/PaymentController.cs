using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace MeroBolee.Controllers.Payment
{
    public class PaymentController : AuthorizeController
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

        [HttpPost("Payment/Validate")]
        public async Task<IActionResult> ValidatePayment([FromBody] ValidatePaymentRequestDto validatePaymentRequestDto)
        {
            try
            {
                PaymentValidationResponseDto paymentValidationResponseDto = await paymentService.ValidatePayment(validatePaymentRequestDto);
                if (paymentValidationResponseDto != null)
                {
                    return Ok(new Responses<PaymentValidationResponseDto>(paymentValidationResponseDto, "200", "Payment Status Fetched Successfully"));

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

        [HttpPost("Payment/Other-Mode/AddDetail")]
        [Authorize(Roles = "Super Admin")]
        public async Task<IActionResult> OtherModePayment([FromBody] OtherModePaymentRequestDto otherModePaymentRequestDto)
        {
            try
            {
                string transactionAddResponse = await paymentService.OtherModePayment(otherModePaymentRequestDto);
                if (transactionAddResponse != null)
                {
                    return Ok(new Responses<string>(transactionAddResponse, "200", "Details Added Successfully"));

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

        [HttpGet("Payment/Other-Mode/Validate")]
        public IActionResult OtherModePaymentValidate([FromQuery] long TenderId, [FromQuery] long UserId)
        {
            try
            {
                PaymentValidationResponseDto validatePaymentOtherMode = paymentService.OtherModePaymentValidate(TenderId, UserId);
                if (validatePaymentOtherMode != null)
                {
                    return Ok(new Responses<PaymentValidationResponseDto>(validatePaymentOtherMode, "200", "Other Mode Payment Validation Successful" ));

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

        [HttpGet("Payment/Details")]
        [Authorize(Roles = "Super Admin")]
        public IActionResult PaymentDetailsForTenderId([FromQuery] long TenderId)
        {
            try
            {
                List<PaymentDetailTenderIdResDto> paymentList = paymentService.PaymentDetailsForTenderId(TenderId);
                if (paymentList != null)
                {
                    return Ok(new Responses<List<PaymentDetailTenderIdResDto>>(paymentList, "200", "Payment Details Fetched Succesfully" ));

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