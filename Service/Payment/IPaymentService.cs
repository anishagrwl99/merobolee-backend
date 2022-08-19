using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeroBolee.Dto;
using MeroBolee.Model;

namespace MeroBolee.Service
{
    public interface IPaymentService
    {
        Task<ConnectIPSResponseDto> GenerateTokenConnectIPS(ConnectIPSRequestDto connectIPSRequestDto);

        Task<PaymentValidationResponseDto> ValidatePayment(ValidatePaymentRequestDto validatePaymentRequestDto);

        Task<string> OtherModePayment(OtherModePaymentRequestDto otherModePaymentRequestDto);

        PaymentValidationResponseDto OtherModePaymentValidate(long TenderId, long UserId);
        List<PaymentDetailTenderIdResDto> PaymentDetailsForTenderId(long TenderId);
    }
}