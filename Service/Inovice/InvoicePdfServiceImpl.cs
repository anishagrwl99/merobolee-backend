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
using System.Collections.Generic;

namespace MeroBolee.Service.Inovice
{
    public class InvoicePdfServiceImpl : InovicePdfService
    {
        private IConverter _converter;

        private readonly IBiddingRequestService biddingRequestService;

        public InvoicePdfServiceImpl(IConverter _converter, IBiddingRequestService biddingRequestService) 
        {
            this._converter = _converter;
            this.biddingRequestService = biddingRequestService;
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
                };

                    var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    // HtmlContent = File.ReadAllText(@"C:\Users\Anish\OneDrive\Desktop\verify-email.html"),
                    HtmlContent =  await GetHTMLString(TenderId, UserId),
                    HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
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

        public async Task<byte[]> InvoicePdfGenerateAll(long TenderId)
        {
        
            try 
            {
                MeroBoleeDbContext meroBoleeDbContext = new MeroBoleeDbContext();
                var quotationEntities = meroBoleeDbContext.QuotationEntities.Where(x => x.TenderId == TenderId).ToArray();
                  List<FinalPositionResponseDto> finalPositionResponseDtos = await biddingRequestService.GetFinalBiddingPosition(TenderId);
                var userGroup = finalPositionResponseDtos.GroupBy(o => new { o.userId, o.companyName }).Select(x => new {UserId = x.Key.userId, TenderId = x.Key.companyName}).ToArray();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < userGroup.Length;i++) {
                   
                    string htmlString = await GetHTMLString(TenderId, userGroup[i].UserId);

                    sb.AppendFormat(htmlString);
                    sb.AppendFormat("<div style='page-break-after: always;'></div>");
                }

                var globalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Landscape,
                    PaperSize = PaperKind.A4Plus,
                    Margins = new MarginSettings { Top = 0 },
                    DocumentTitle = String.Format("Tender ID: {0}", TenderId),
                };

                    var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    // HtmlContent = File.ReadAllText(@"C:\Users\Anish\OneDrive\Desktop\verify-email.html"),
                    HtmlContent = sb.ToString(),
                   // HtmlContent =  await GetHTMLString(TenderId, UserId),
                    HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
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

        public async Task<byte[]> InvoicePdfGenerateConsolidateReport(long TenderId)
        {
        
            try 
            {
                // add object settings to the document
                MeroBoleeDbContext meroBoleeDbContext = new MeroBoleeDbContext();
                var quotationEntities = meroBoleeDbContext.QuotationEntities.Where(x => x.TenderId == TenderId).ToArray();
                var materialIdList = quotationEntities.GroupBy(o => new { o.MaterialId, o.TenderId }).Select(x => new {MaterialId = x.Key.MaterialId, TenderId = x.Key.TenderId}).ToArray();
                List<GenerateBillResponseDto> generateBillResponseDtoList = new List<GenerateBillResponseDto>();
                List<FinalPositionResponseDto> finalPositionResponseDtos = await biddingRequestService.GetFinalBiddingPosition(TenderId);
                var userGroup = finalPositionResponseDtos.GroupBy(o => new { o.userId, o.companyName }).Select(x => new {UserId = x.Key.userId, TenderId = x.Key.companyName}).ToArray();
                for (int i = 0; i < userGroup.Length;i++) {
                    GenerateBillResponseDto generateBillResponseDto = await biddingRequestService.GenerateBill(TenderId, userGroup[i].UserId);
                    generateBillResponseDtoList.Add(generateBillResponseDto);
                }
                StringBuilder buildColumnHeader = new StringBuilder();
                buildColumnHeader.AppendFormat("<td><strong>");
                buildColumnHeader.AppendFormat("Material Name");
                buildColumnHeader.AppendFormat("</strong></td>");
                StringBuilder totalValue = new StringBuilder();

                for (int i = 0; i < userGroup.Length;i++) {
                    string companyName = generateBillResponseDtoList.Where(x => x.UserId == userGroup[i].UserId).Select(x => x.CompanyName).FirstOrDefault();
                    string position = generateBillResponseDtoList.Where(x => x.UserId == userGroup[i].UserId).Select(x => x.FinalPosition).FirstOrDefault();

                    buildColumnHeader.AppendFormat("<td><strong>");
                    buildColumnHeader.AppendFormat(companyName + "-" + position);
                    buildColumnHeader.AppendFormat("</strong></td>");
                    totalValue.AppendFormat("<td><strong>");
                    decimal totalAmount = generateBillResponseDtoList.Where(x => x.UserId == userGroup[i].UserId).Select(x => x.TotalQuotation).FirstOrDefault();
                    totalValue.AppendFormat(totalAmount.ToString());
                    totalValue.AppendFormat("</strong></td>");
                }
                StringBuilder rowValues = new StringBuilder();
                for (int i = 0; i < materialIdList.Length; i++)
                {
                    StringBuilder innerRowValue = new StringBuilder();
                    innerRowValue.AppendFormat("<tr>");
                    innerRowValue.AppendFormat("<td>");
                    string MaterialName = meroBoleeDbContext.TenderMaterialEntities.Where(x => x.Id == materialIdList[i].MaterialId).Select(x => x.Materials).FirstOrDefault();
                    innerRowValue.AppendFormat(MaterialName);
                    innerRowValue.AppendFormat("</td>");
                    
                    for (int j = 0; j < userGroup.Length; j++)
                    {
                        List<QuotationResponseDto> QuotationResponseDtoList = generateBillResponseDtoList.Where(x => x.UserId == userGroup[j].UserId).Select(x => x.QuotationResponseDtoList).FirstOrDefault();
                        decimal unitPrice = QuotationResponseDtoList.Where(x => x.MaterialId == materialIdList[i].MaterialId).Select(x => x.UnitPrice).FirstOrDefault();
                        var quantity = QuotationResponseDtoList.Where(x => x.MaterialId == materialIdList[i].MaterialId).Select(x => x.Quantity).FirstOrDefault();
                        string companyName = generateBillResponseDtoList.Where(x => x.UserId == userGroup[j].UserId).Select(x => x.CompanyName).FirstOrDefault();
                        innerRowValue.AppendFormat("<td>");
                        innerRowValue.AppendFormat((unitPrice*quantity).ToString());
                        innerRowValue.AppendFormat("</td>");
                    }
                    innerRowValue.AppendFormat("</tr>");
                    rowValues.AppendFormat(innerRowValue.ToString());
                }

                String invoiceHtml = "";
                using (WebClient web1 = new WebClient())
                {
                    invoiceHtml = web1.DownloadString("https://dev.merobolee.com/Resource/consolidateinvoice.html");
                }
                
                // String invoiceHtml = File.ReadAllText(@"C:\Users\Anish\OneDrive\Desktop\MeroBolee Docs\consolidateinvoice.html");
                if(invoiceHtml.Contains("{ColumnHeader}")) {
                    invoiceHtml = invoiceHtml.Replace("{ColumnHeader}", buildColumnHeader.ToString());
                }
                if(invoiceHtml.Contains("{Date}")) 
                {
                    invoiceHtml = invoiceHtml.Replace("{Date}", "Date: " + DateTimeNPT.Now.ToString("dd-MM-yyyy").Substring(0, 10));
                }
                if(invoiceHtml.Contains("{MaterialList}")) 
                {
                    invoiceHtml = invoiceHtml.Replace("{MaterialList}", rowValues.ToString());
                }
                if(invoiceHtml.Contains("{TotalValues}")) 
                {
                    invoiceHtml = invoiceHtml.Replace("{TotalValues}", totalValue.ToString());
                }
                string tenderName = meroBoleeDbContext.TenderEntities.Where(x => x.Id == TenderId).Select(x => x.Title).FirstOrDefault();
                if(invoiceHtml.Contains("{TenderName}")) 
                {
                    invoiceHtml = invoiceHtml.Replace("{TenderName}", "Tender Title: " + tenderName);
                }
                if(invoiceHtml.Contains("{TenderId}")) 
                {
                    invoiceHtml = invoiceHtml.Replace("{TenderId}", "Tender ID: " + TenderId.ToString());
                }

                var globalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Landscape,
                    PaperSize = PaperKind.A4Plus,
                    Margins = new MarginSettings { Top = 0 },
                    DocumentTitle = String.Format("Tender ID: {0}", TenderId),
                };

                    var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    // HtmlContent = File.ReadAllText(@"C:\Users\Anish\OneDrive\Desktop\verify-email.html"),
                    HtmlContent = invoiceHtml,
                   // HtmlContent =  await GetHTMLString(TenderId, UserId),
                    HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
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
            
                string invoiceHtml = File.ReadAllText(@"C:\HostingSpaces\api.merobolee.com\wwwroot\Resource\Invoice.html");
                var MaterialListSB = new StringBuilder();
                foreach (var generateBillResponse in generateBillResponseDto.QuotationResponseDtoList)
                {
                    string MaterialList = File.ReadAllText(@"C:\HostingSpaces\api.merobolee.com\wwwroot\Resource\tablecontent.html");
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
                    invoiceHtml = invoiceHtml.Replace("{CompanyNameOnly}", generateBillResponseDto.CompanyName);
                }

                String totalAmountInWords = ConvertToWord.ConvertAmount((double)generateBillResponseDto.TotalQuotation);

                if(invoiceHtml.Contains("{TotalAmountInWords}")) 
                {
                    invoiceHtml = invoiceHtml.Replace("{TotalAmountInWords}", totalAmountInWords);
                }

                if(invoiceHtml.Contains("{PanNumber}")) 
                {
                    invoiceHtml = invoiceHtml.Replace("{PanNumber}",  generateBillResponseDto.PanNumber);
                }
                return invoiceHtml;

            }
            catch 
            {
                throw;
            }
        }

        public async Task<byte[]> GenerateSealBidReport(string htmlString)
        {

            try
            {
                var globalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Landscape,
                    PaperSize = PaperKind.A4Plus,
                    Margins = new MarginSettings { Top = 0 },
                    DocumentTitle = String.Format("Tender ID: {0}", ""),
                };

                    var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    // HtmlContent = File.ReadAllText(@"C:\Users\Anish\OneDrive\Desktop\verify-email.html"),
                    HtmlContent =  htmlString,
                    HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
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

    }
}