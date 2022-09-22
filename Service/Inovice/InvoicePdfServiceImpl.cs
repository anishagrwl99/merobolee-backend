using System;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using System.IO;
using MeroBolee.Dto;
using MeroBolee.Utility;
using System.Text;
using System.Net;


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
                    Orientation = Orientation.Landscape,
                    PaperSize = PaperKind.A4Plus,
                    Margins = new MarginSettings { Top = 0 },
                    DocumentTitle = String.Format("Tender ID: {0}", TenderId),
                    // Out = @"D:\PDFCreator\Employee_Report.pdf"
                };
                    var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    // HtmlContent = File.ReadAllText(@"C:\Users\Anish\OneDrive\Desktop\verify-email.html"),
                    HtmlContent =  await GetHTMLString(TenderId, UserId),
                    // WebSettings = { DefaultEncoding = "utf-8"},
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
                // string invoiceHtml = File.ReadAllText(@"C:\Users\Anish\OneDrive\Desktop\MeroBolee Docs\Invoice.html");
                var MaterialListSB = new StringBuilder();
                foreach (var generateBillResponse in generateBillResponseDto.QuotationResponseDtoList)
                {
                    string MaterialList = "";
                    using (WebClient web1 = new WebClient())
                    {
                        MaterialList = web1.DownloadString("https://office.merobolee.com/Resource/tablecontent.html");
                    }                    
                    // string MaterialList = File.ReadAllText(@"C:\Users\Anish\OneDrive\Desktop\MeroBolee Docs\tablecontent.html");
                    string remarks = generateBillResponse.Remarks;
                    MaterialList = String.Format(MaterialList, generateBillResponse.MaterialId, generateBillResponse.MaterialName, generateBillResponse.Quantity, generateBillResponse.Units, generateBillResponse.UnitPrice, generateBillResponse.Quotation, remarks);
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

                if(invoiceHtml.Contains("{CompanyNameOnly}")) 
                {
                    invoiceHtml = invoiceHtml.Replace("{CompanyName}", generateBillResponseDto.CompanyName);
                }

                String totalAmountInWords = ConvertToWord.ConvertAmount((double)generateBillResponseDto.TotalQuotation);

                if(invoiceHtml.Contains("{TotalAmountInWords}")) 
                {
                    invoiceHtml = invoiceHtml.Replace("{TotalAmountInWords}", totalAmountInWords);
                }

                MeroBoleeDbContext meroBoleeDbContext = new MeroBoleeDbContext();
                long companyId = meroBoleeDbContext.UserCompanies.Where(x => x.UserId == UserId).Select(x => x.CompanyId).FirstOrDefault();
                string PanNumber = meroBoleeDbContext.CompanyEntities.Where(x => x.CompanyId == companyId).Select(x => x.PANNumber).FirstOrDefault();
                if(invoiceHtml.Contains("{PanNumber}")) 
                {
                    invoiceHtml = invoiceHtml.Replace("{PanNumber}",  PanNumber);
                }
                // if(invoiceHtml.Contains("{Remarks}"))
                // {
                //     invoiceHtml = invoiceHtml.Replace("{Remarks}", "This is a long remark with values xyz for product mnq");
                // }
                return invoiceHtml;

            }
            catch 
            {
                throw;
            }
        }
    }
}