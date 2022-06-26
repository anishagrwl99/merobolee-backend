using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeroBolee.Dto;

namespace MeroBolee.Service
{
    public interface IPaymentService
    {
        Task<ConnectIPSResponseDto> GenerateTokenConnectIPS(ConnectIPSRequestDto connectIPSRequestDto);
    }
}