using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.Inovice
{
    public interface InovicePdfService
    {
        Task<byte[]> InvoicePdfGenerate(long TenderId, long UserId);

        Task<byte[]> InvoicePdfGenerateAll(long TenderId);

        Task<byte[]> InvoicePdfGenerateConsolidateReport(long TenderId);

    }
}