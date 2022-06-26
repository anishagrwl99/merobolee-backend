using System;
using System.Threading.Tasks;
using MeroBolee.Dto;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.IO;
using MeroBolee.Settings;
using Microsoft.Extensions.Options;

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
                string message = "MERCHANTID={merchantId}, APPID={appId}, APPNAME={appName}, TXNID={txnId}, TXNDATE={txnDate}, TXNCRNCY=NPR, TXNAMT={txnAmount}, REFERENCEID={referenceId}, REMARKS={remarks}, PARTICULARS={particulars}, TOKEN=TOKEN";
                string randomTxnNumber = generateTransactionNumber(connectIPSRequestDto);

                message = message.Replace("{merchantId}", paymentValues.MerchantId);
                message = message.Replace("{appId}", paymentValues.AppId);
                message = message.Replace("{appName}", paymentValues.AppName);
                DateTime txnDateTime = DateTimeNPT.Now;
                message = message.Replace("{txnDate}", txnDateTime.ToString());
                message = message.Replace("{txnAmount}", connectIPSRequestDto.TxnAmt.ToString());
                message = message.Replace("{remarks}", connectIPSRequestDto.Remarks);
                message = message.Replace("{particulars}", randomTxnNumber);
                message = message.Replace("{txnId}", "TXN" + randomTxnNumber);
                message = message.Replace("{referenceId}", "REF" + randomTxnNumber);
                string particular = "PART" + randomTxnNumber;
                message = message.Replace("{particulars}", particular);

                string SHA256WithRSASignedString = ComputeSHA256Hash(message);
                ConnectIPSResponseDto connectIPSResponseDto = new ConnectIPSResponseDto();
                connectIPSResponseDto.TxnId = "TXN" + randomTxnNumber;
                connectIPSResponseDto.TxnAmount = connectIPSRequestDto.TxnAmt;
                connectIPSResponseDto.TxnTime = txnDateTime;
                connectIPSResponseDto.TxnCurrency = "NPR";
                connectIPSResponseDto.Remarks = connectIPSRequestDto.Remarks;
                connectIPSResponseDto.Particulars = particular;
                connectIPSResponseDto.ReferenceId = "REF" + randomTxnNumber;
                connectIPSResponseDto.Token = SHA256WithRSASignedString;

                return connectIPSResponseDto;
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
                return DateTimeNPT.Now.ToString().Substring(0, 10).Replace("-", "") + connectIPSRequestDto.CompanyId + connectIPSRequestDto.TxnAmt + connectIPSRequestDto.UserId + (new Random()).Next(1000, 9999);
            }
            catch
            {
                throw;
            }
        }
    }
}