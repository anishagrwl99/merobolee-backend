using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeroBolee.Dto;

namespace MeroBolee.Service
{
    public interface IRequestDemoService
    {
        Task<string> RequestDemo(RequestDemoDto requestDemoDto);
        Task<string> ContactUs(RequestDemoDto requestDemoDto);
    }
}