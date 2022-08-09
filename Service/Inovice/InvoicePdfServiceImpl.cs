using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;
using MeroBolee.Service;
using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Repository;
using Microsoft.Extensions.Caching.Memory;
using MeroBolee.Utility;
using System.Text;

namespace MeroBolee.Service.Inovice
{
    public class InvoicePdfServiceImpl : InovicePdfService
    {
        private IConverter _converter;
        // private IBidderRequestRepository bidRequestRepository;
        // private IMemoryCache memoryCache;
        // private ICryptoService cryptoService;
        // private readonly ITenderService tenderService;
        // private readonly IUploadFile fileService;
        // private readonly ICompanyDocumentRepository companyDocumentRepository;

        private readonly IBiddingRequestService biddingRequestService;

        public InvoicePdfServiceImpl(IConverter _converter, IBiddingRequestService biddingRequestService) 
        {
            this._converter = _converter;
            this.biddingRequestService = biddingRequestService;
            // this.bidRequestRepository = bidRequestRepository;
            // memoryCache = cache;
            // this.cryptoService = cryptoService;
            // this.tenderService = tenderService;
            // this.fileService = fileService;
            // this.companyDocumentRepository = companyDocumentRepository;
        }


        public async Task<byte[]> InvoicePdfGenerate(long TenderId, long UserId) 
        {
            try 
            {
                var globalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 10 },
                    DocumentTitle = String.Format("Tender ID: {0}", TenderId),
                    // Out = @"D:\PDFCreator\Employee_Report.pdf"
                };
                    var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    // HtmlContent = File.ReadAllText(@"C:\Users\Anish\OneDrive\Desktop\verify-email.html"),
                    HtmlContent =  await GetHTMLString(TenderId, UserId),
                    WebSettings = { DefaultEncoding = "utf-8"},
                    HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                    FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Thank You for using Mero Bolee!" }
                };
                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };
                var file = _converter.Convert(pdf);
                return file;
            }
            catch 
            {
                throw;
            }

        }

        public async Task<string> GetHTMLString(long TenderId, long UserId)
        {
            try
            {
                GenerateBillResponseDto generateBillResponseDto = await biddingRequestService.GenerateBill(TenderId, UserId);
                string invoiceHtml = "";
                using (WebClient web1 = new WebClient())
                {
                    invoiceHtml = web1.DownloadString("https://office.merobolee.com/Resource/Invoice.html");
                }
                // string invoiceHtml = File.ReadAllText(@"C:\Users\Anish\OneDrive\Desktop\Invoice.html");
                var MaterialListSB = new StringBuilder();
                foreach (var generateBillResponse in generateBillResponseDto.QuotationResponseDtoList)
                {
                    string MaterialList = "";
                    using (WebClient web1 = new WebClient())
                    {
                        MaterialList = web1.DownloadString("https://office.merobolee.com/Resource/tablecontent.html");
                    }                    
                    // string MaterialList = File.ReadAllText(@"C:\Users\Anish\OneDrive\Desktop\tablecontent.html");
                    MaterialList = String.Format(MaterialList, generateBillResponse.MaterialId, generateBillResponse.MaterialName, generateBillResponse.Quantity, generateBillResponse.Units, generateBillResponse.UnitPrice, generateBillResponse.Quotation);
                    MaterialListSB.Append(MaterialList);
                }
                if(invoiceHtml.Contains("{MaterialList}")) 
                {
                    invoiceHtml = invoiceHtml.Replace("{MaterialList}", MaterialListSB.ToString());
                }
                if(invoiceHtml.Contains("{Position}")) 
                {
                    invoiceHtml = invoiceHtml.Replace("{Position}", "Final Position:" + generateBillResponseDto.FinalPosition);
                }
                if(invoiceHtml.Contains("{TotalAmount}")) 
                {
                    invoiceHtml = invoiceHtml.Replace("{TotalAmount}", generateBillResponseDto.TotalQuotation.ToString());
                }
                if(invoiceHtml.Contains("{Date}")) 
                {
                    invoiceHtml = invoiceHtml.Replace("{Date}", "Date: " + DateTimeNPT.Now.ToString("dd-MM-yyyy").Substring(0, 10));
                }
                if(invoiceHtml.Contains("{CompanyName}")) 
                {
                    invoiceHtml = invoiceHtml.Replace("{CompanyName}", "Company Name: " + generateBillResponseDto.CompanyName);
                }
                MeroBoleeDbContext meroBoleeDbContext = new MeroBoleeDbContext();
                long companyId = meroBoleeDbContext.UserCompanies.Where(x => x.UserId == UserId).Select(x => x.CompanyId).FirstOrDefault();
                string PanNumber = meroBoleeDbContext.CompanyEntities.Where(x => x.CompanyId == companyId).Select(x => x.PANNumber).FirstOrDefault();
                if(invoiceHtml.Contains("{PanNumber}")) 
                {
                    invoiceHtml = invoiceHtml.Replace("{PanNumber}",  PanNumber);
                }
                return invoiceHtml;

            }
            catch 
            {
                throw;
            }
        }
    }
}