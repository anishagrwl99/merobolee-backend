using System;
using System.Threading.Tasks;
using MeroBolee.Dto;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.IO;
using MeroBolee.Settings;
using Microsoft.Extensions.Options;
using System.Net;
using MeroBolee.Utility;
using MeroBolee.Model;
using System.Linq;
using System.Collections.Generic;


namespace MeroBolee.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly PaymentValues paymentValues;

        public PaymentService(IOptions<PaymentValues> paymentValues)
        {
            this.paymentValues = paymentValues.Value;
        }
        public async Task<ConnectIPSResponseDto> GenerateTokenConnectIPS(ConnectIPSRequestDto connectIPSRequestDto)
        {
            try
            {
                string message = "MERCHANTID={merchantId},APPID={appId},APPNAME={appName},TXNID={txnId},TXNDATE={txnDate},TXNCRNCY=NPR,TXNAMT={txnAmount},REFERENCEID={referenceId},REMARKS={remarks},PARTICULARS={particulars},TOKEN=TOKEN";
                string randomTxnNumber = generateTransactionNumber(connectIPSRequestDto);

                message = message.Replace("{merchantId}", paymentValues.MerchantId);
                message = message.Replace("{appId}", paymentValues.AppId);
                message = message.Replace("{appName}", paymentValues.AppName);
                string txnDateTime = DateTimeNPT.Now.ToString("dd-MM-yyyy").Substring(0, 10);
                message = message.Replace("{txnDate}", txnDateTime.ToString().Substring(0, 10));
                message = message.Replace("{txnAmount}", connectIPSRequestDto.TxnAmt.ToString());
                message = message.Replace("{remarks}", connectIPSRequestDto.Remarks);
                message = message.Replace("{particulars}", randomTxnNumber);
                message = message.Replace("{txnId}", "TXN" + randomTxnNumber);
                message = message.Replace("{referenceId}", "REF" + randomTxnNumber);
                message = message.Replace("{particulars}", randomTxnNumber);
                string SHA256WithRSASignedString = ComputeSHA256Hash(message);
                ConnectIPSResponseDto connectIPSResponseDto = new ConnectIPSResponseDto();
                connectIPSResponseDto.TxnId = "TXN" + randomTxnNumber;
                connectIPSResponseDto.TxnAmount = connectIPSRequestDto.TxnAmt;
                connectIPSResponseDto.TxnTime = txnDateTime;
                connectIPSResponseDto.TxnCurrency = "NPR";
                connectIPSResponseDto.Remarks = connectIPSRequestDto.Remarks;
                connectIPSResponseDto.Particulars = randomTxnNumber;
                connectIPSResponseDto.ReferenceId = "REF" + randomTxnNumber;
                connectIPSResponseDto.Token = SHA256WithRSASignedString;
                connectIPSResponseDto.AppId = paymentValues.AppId;
                connectIPSResponseDto.AppName = paymentValues.AppName;
                connectIPSResponseDto.MerchantId = paymentValues.MerchantId;

                SaveToDataBase(connectIPSRequestDto, connectIPSResponseDto);

                return connectIPSResponseDto;
            }
            catch
            {
                throw;
            }

        }

        public async Task<PaymentValidationResponseDto> ValidatePayment(ValidatePaymentRequestDto validatePaymentRequestDto) 
        {
            try 
            {
                string validateTxnUrl = paymentValues.ValidateTxnUrl;
                string getTxnDetailsUrl = paymentValues.GetTxnDetailsUrl;

                PaymentValidationResponseDto paymentValidationResponseDto= await callExternalAPIValidateTxn(validateTxnUrl, getTxnDetailsUrl, validatePaymentRequestDto.txnId, validatePaymentRequestDto.landingPage);

                return paymentValidationResponseDto;
            }
            catch 
            {
                throw;
            }

        }

        public string ComputeSHA256Hash(string text)
        {
            try
            {
                // string path = @"C:\Users\Anish\Downloads\CREDITOR.pfx";
                string path = @"C:\HostingSpaces\merobolee\office.merobolee.com\wwwroot\Resource\NHCL\CREDITOR.pfx";
                byte[] certificate = File.ReadAllBytes(path);
                X509Certificate2 cert2 = new X509Certificate2(certificate, "123", X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);
                SHA256Managed shHash = new SHA256Managed();
                byte[] computedHash = shHash.ComputeHash(Encoding.Default.GetBytes(text));

                RSA certifiedRSACryptoServiceProvider = (RSA)cert2.PrivateKey;
                (cert2.PrivateKey as RSACng)?.Key.SetProperty(new CngProperty("Export Policy", BitConverter.GetBytes((int)CngExportPolicies.AllowPlaintextExport), CngPropertyOptions.Persist));

                RSACryptoServiceProvider defaultRSACryptoServiceProvider = new RSACryptoServiceProvider();
                defaultRSACryptoServiceProvider.ImportParameters(certifiedRSACryptoServiceProvider.ExportParameters(true));
                byte[] signedHashValue = defaultRSACryptoServiceProvider.SignHash(computedHash, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                string signature = Convert.ToBase64String(signedHashValue);
                Console.WriteLine("Signature : {0}", signature);

                bool validSignature = certifiedRSACryptoServiceProvider.VerifyHash(hash: computedHash,
                                            signature: signedHashValue,
                                            hashAlgorithm: HashAlgorithmName.SHA256,
                                            padding: RSASignaturePadding.Pkcs1);
                Console.WriteLine("Verification result : {0}", validSignature);
                if (validSignature == true) return signature;
                else return "";
            }
            catch
            {
                throw;
            }
        }

        public static string generateTransactionNumber(ConnectIPSRequestDto connectIPSRequestDto)
        {
            try
            {
                Random randomNumberGenerator = new Random();
                randomNumberGenerator.Next(1000);
                return DateTimeNPT.Now.ToString("dd-MM-yyyy").Substring(0, 10).Replace("-", "").Replace("/", "").Replace(" ", "") + connectIPSRequestDto.CompanyId  + connectIPSRequestDto.UserId + (new Random()).Next(1000, 9999);
            }
            catch
            {
                throw;
            }
        }
        public async Task<string> OtherModePayment(OtherModePaymentRequestDto otherModePaymentRequestDto) 
        {
            try 
            {
                MeroBoleeDbContext meroBoleeDbContext = new MeroBoleeDbContext();
                PaymentDetailEntity paymentDetailEntity = new PaymentDetailEntity();
                ConnectIPSRequestDto connectIPSRequestDto = new ConnectIPSRequestDto();
                connectIPSRequestDto.TxnAmt = otherModePaymentRequestDto.TxnAmount;
                connectIPSRequestDto.CompanyId = otherModePaymentRequestDto.CompanyId;
                connectIPSRequestDto.UserId = meroBoleeDbContext.UserCompanies.Where(x => x.CompanyId == otherModePaymentRequestDto.CompanyId).Select(x => x.UserId).FirstOrDefault();
                connectIPSRequestDto.TenderId = otherModePaymentRequestDto.TenderId;
                string txnId = "TXN" + generateTransactionNumber(connectIPSRequestDto);
                paymentDetailEntity.TxnId = txnId;
                paymentDetailEntity.CompanyId = otherModePaymentRequestDto.CompanyId;
                paymentDetailEntity.UserId = meroBoleeDbContext.UserCompanies.Where(x => x.CompanyId == otherModePaymentRequestDto.CompanyId).Select(x => x.UserId).FirstOrDefault();
                paymentDetailEntity.PaymentChanel = otherModePaymentRequestDto.PaymentChannel;
                paymentDetailEntity.TenderId = otherModePaymentRequestDto.TenderId;
                paymentDetailEntity.TxnSts = TransactionEnum.SUCCESS.ToString();
                paymentDetailEntity.TxnDate = DateTimeNPT.Now;
                paymentDetailEntity.TxnAmt = otherModePaymentRequestDto.TxnAmount;
                meroBoleeDbContext.PaymentDetailEntities.Add(paymentDetailEntity);
                await meroBoleeDbContext.SaveChangesAsync();

                return "SUCCESSFULLY ADDED TRANSACTION DETAILS";
            }
            catch 
            {
                throw;
            }
        }

        public PaymentValidationResponseDto OtherModePaymentValidate(long TenderId, long UserId) 
        {
            try 
            {
                MeroBoleeDbContext meroBoleeDbContext = new MeroBoleeDbContext();
                PaymentDetailEntity paymentDetailEntity = meroBoleeDbContext.PaymentDetailEntities.Where(x => x.TenderId == TenderId).Where(x => x.UserId == UserId).Where(x => x.TxnSts == TransactionEnum.SUCCESS.ToString()).FirstOrDefault();
                PaymentValidationResponseDto paymentValidationResponseDto = new PaymentValidationResponseDto();
                paymentValidationResponseDto.TenderId = TenderId;
                paymentValidationResponseDto.TxnAmount = paymentDetailEntity.TxnAmt;
                paymentValidationResponseDto.txnId = paymentDetailEntity.TxnId;
                paymentValidationResponseDto.txnStatus = paymentDetailEntity.TxnSts;
                paymentValidationResponseDto.CompanyId = paymentDetailEntity.CompanyId;
                paymentValidationResponseDto.UserId = paymentDetailEntity.UserId;
                paymentValidationResponseDto.PaymentChannel = paymentDetailEntity.PaymentChanel;

                return paymentValidationResponseDto;
            }
            catch 
            {
                throw;
            }

        }

        public async Task<PaymentValidationResponseDto> callExternalAPIValidateTxn(string vaidateTxnUrl, string getTxnDetailUrl, string txnId, string landingPage) 
        {
            try
            {
                string urlFormat = String.Format(vaidateTxnUrl); //here I have the correct url for my API
                HttpWebRequest requestObj = (HttpWebRequest)WebRequest.Create(vaidateTxnUrl);
                MeroBoleeDbContext meroBoleeDbContext = new MeroBoleeDbContext();
                PaymentDetailEntity paymentDetailEntity = meroBoleeDbContext.PaymentDetailEntities.Where(x => x.TxnId == txnId).FirstOrDefault();
                NhclValidateTxnReq nhclValidateTxnReq = new NhclValidateTxnReq();
                nhclValidateTxnReq.appId = paymentValues.AppId;
                nhclValidateTxnReq.merchantId = paymentValues.MerchantId;
                nhclValidateTxnReq.txnAmt = (paymentDetailEntity.TxnAmt * 100).ToString();
                nhclValidateTxnReq.referenceId = txnId;
                string message = "MERCHANTID={merchantId},APPID={appId},REFERENCEID={referenceId},TXNAMT={txnAmount}";
                message = message.Replace("{merchantId}", paymentValues.MerchantId);
                message = message.Replace("{appId}", paymentValues.AppId);
                message = message.Replace("{referenceId}", txnId);
                message = message.Replace("{txnAmount}", (paymentDetailEntity.TxnAmt * 100).ToString());
                nhclValidateTxnReq.token = ComputeSHA256Hash(message);
                string json =  Newtonsoft.Json.JsonConvert.SerializeObject(nhclValidateTxnReq);
                requestObj.ContentType = paymentValues.ContentType;
                requestObj.Method = TransactionEnum.POST.ToString();
                requestObj.Headers[TransactionEnum.Authorization.ToString()] = TransactionEnum.Basic.ToString() + " " + Convert.ToBase64String(Encoding.Default.GetBytes(paymentValues.BasicUsername + ":" + paymentValues.BasicPassword));
                requestObj.PreAuthenticate = true;
                using (var streamWriter = new StreamWriter(requestObj.GetRequestStream()))
                {
                    streamWriter.Write(json);
                }
                HttpWebResponse responseObj = null;
                responseObj = (HttpWebResponse)requestObj.GetResponse();
                string strresult = null;
                using (Stream stream = responseObj.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    strresult = sr.ReadToEnd();
                    sr.Close();
                }
                ValidateTxnResponse validateTxnResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ValidateTxnResponse>(strresult);
                PaymentValidationResponseDto paymentValidationResponseDto = new PaymentValidationResponseDto();
                GetTxnDetailResponse getTxnDetailResponse = GetTxnDetailRes(getTxnDetailUrl, txnId);
                if(validateTxnResponse.status.Equals(TransactionEnum.SUCCESS.ToString()) && landingPage.Equals("success") && (getTxnDetailResponse.creditStatus.Equals("000") || getTxnDetailResponse.creditStatus.Equals("DEFER")) && getTxnDetailResponse.status.Equals(TransactionEnum.SUCCESS.ToString())) 
                {
                    paymentDetailEntity.TxnSts = TransactionEnum.SUCCESS.ToString();
                    paymentValidationResponseDto.txnStatus = TransactionEnum.SUCCESS.ToString();
                    await meroBoleeDbContext.SaveChangesAsync();
                } 
                else if(validateTxnResponse.status.Equals(TransactionEnum.FAILED.ToString()) || landingPage.Equals("failure")) 
                {
                    paymentDetailEntity.TxnSts = TransactionEnum.FAILURE.ToString();
                    paymentValidationResponseDto.txnStatus = TransactionEnum.FAILURE.ToString();
                    await meroBoleeDbContext.SaveChangesAsync();
                }
                paymentValidationResponseDto.TenderId = paymentDetailEntity.TenderId;
                paymentValidationResponseDto.txnId = paymentDetailEntity.TxnId;
                paymentValidationResponseDto.TxnAmount = paymentDetailEntity.TxnAmt;
                paymentValidationResponseDto.CompanyId = paymentDetailEntity.CompanyId;
                paymentValidationResponseDto.UserId = paymentDetailEntity.UserId;
                paymentValidationResponseDto.PaymentChannel = paymentDetailEntity.PaymentChanel;
                return paymentValidationResponseDto;
            }
            catch 
            {
                throw;
            }

        }

        public GetTxnDetailResponse GetTxnDetailRes(string getTxnDetailUrl, string txnId) 
        {
            try 
            {
               string urlFormat = String.Format(getTxnDetailUrl); //here I have the correct url for my API
                HttpWebRequest requestObj = (HttpWebRequest)WebRequest.Create(getTxnDetailUrl);
                MeroBoleeDbContext meroBoleeDbContext = new MeroBoleeDbContext();
                PaymentDetailEntity paymentDetailEntity = meroBoleeDbContext.PaymentDetailEntities.Where(x => x.TxnId == txnId).FirstOrDefault();
                NhclValidateTxnReq nhclValidateTxnReq = new NhclValidateTxnReq();
                nhclValidateTxnReq.appId = paymentValues.AppId;
                nhclValidateTxnReq.merchantId = paymentValues.MerchantId;
                nhclValidateTxnReq.txnAmt = (paymentDetailEntity.TxnAmt * 100).ToString();
                nhclValidateTxnReq.referenceId = txnId;
                string message = "MERCHANTID={merchantId},APPID={appId},REFERENCEID={referenceId},TXNAMT={txnAmount}";
                message = message.Replace("{merchantId}", paymentValues.MerchantId);
                message = message.Replace("{appId}", paymentValues.AppId);
                message = message.Replace("{referenceId}", txnId);
                message = message.Replace("{txnAmount}", (paymentDetailEntity.TxnAmt * 100).ToString());
                nhclValidateTxnReq.token = ComputeSHA256Hash(message);
                string json =  Newtonsoft.Json.JsonConvert.SerializeObject(nhclValidateTxnReq);
                requestObj.ContentType = paymentValues.ContentType;
                requestObj.Method = TransactionEnum.POST.ToString();
                requestObj.Headers[TransactionEnum.Authorization.ToString()] = TransactionEnum.Basic.ToString() + " " + Convert.ToBase64String(Encoding.Default.GetBytes(paymentValues.BasicUsername + ":" + paymentValues.BasicPassword));
                requestObj.PreAuthenticate = true;
                using (var streamWriter = new StreamWriter(requestObj.GetRequestStream()))
                {
                    streamWriter.Write(json);
                }
                HttpWebResponse responseObj = null;
                responseObj = (HttpWebResponse)requestObj.GetResponse();
                string strresult = null;
                using (Stream stream = responseObj.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    strresult = sr.ReadToEnd();
                    sr.Close();
                }
                
                GetTxnDetailResponse getTxnDetailResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<GetTxnDetailResponse>(strresult);

                return getTxnDetailResponse;

            }
            catch 
            {
                throw;
            }
        }

        public void SaveToDataBase(ConnectIPSRequestDto connectIPSRequestDto, ConnectIPSResponseDto connectIPSResponseDto)
        {
            try
            {
                MeroBoleeDbContext meroBoleeDbContext = new MeroBoleeDbContext();
                PaymentDetailEntity paymentDetailEntity = new PaymentDetailEntity();
                paymentDetailEntity.TxnAmt = connectIPSRequestDto.TxnAmt / 100;
                paymentDetailEntity.TxnId = connectIPSResponseDto.TxnId;
                paymentDetailEntity.CompanyId = connectIPSRequestDto.CompanyId;
                paymentDetailEntity.UserId = connectIPSRequestDto.UserId;
                paymentDetailEntity.TxnDate = DateTimeNPT.Now;
                paymentDetailEntity.TxnSts = "IN PROGRESS";
                paymentDetailEntity.TenderId = connectIPSRequestDto.TenderId;
                paymentDetailEntity.PaymentChanel = "CONNECT IPS";
                meroBoleeDbContext.PaymentDetailEntities.Add(paymentDetailEntity);
                meroBoleeDbContext.SaveChangesAsync();
            }
            catch 
            {
                throw;
            }
        }

        public List<PaymentDetailTenderIdResDto> PaymentDetailsForTenderId(long TenderId) 
        {
            try 
            {
                MeroBoleeDbContext meroBoleeDbContext = new MeroBoleeDbContext();
                List<PaymentDetailEntity> paymentList = meroBoleeDbContext.PaymentDetailEntities.Where(x => x.TenderId == TenderId).ToList();
                List<PaymentDetailTenderIdResDto> paymentListWithCompanyName = new List<PaymentDetailTenderIdResDto>();
                foreach(PaymentDetailEntity entity in paymentList) 
                {
                    PaymentDetailTenderIdResDto paymentDetailTenderIdResDto = new PaymentDetailTenderIdResDto();
                    paymentDetailTenderIdResDto.TxnAmt = entity.TxnAmt;
                    paymentDetailTenderIdResDto.TxnDate = entity.TxnDate;
                    paymentDetailTenderIdResDto.TxnSts = entity.TxnSts;
                    paymentDetailTenderIdResDto.TxnId = entity.TxnId;
                    paymentDetailTenderIdResDto.PaymentChanel = entity.PaymentChanel;
                    paymentDetailTenderIdResDto.CompanyName = meroBoleeDbContext.CompanyEntities.Where(x => x.CompanyId == entity.CompanyId).Select(x => x.Name).FirstOrDefault();
                    paymentListWithCompanyName.Add(paymentDetailTenderIdResDto);
                }
                return paymentListWithCompanyName;
            }
            catch 
            {
                throw;
            }
        }

    }
}