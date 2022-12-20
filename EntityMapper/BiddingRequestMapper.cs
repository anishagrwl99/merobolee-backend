using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeroBolee.Utility;


namespace MeroBolee.EntityMapper
{
    public class BiddingRequestMapper
    {
        /// <summary>
        /// Convert dto to entity
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public BidRequestEntity ToEntity(RegisterForTenderDto dto/*, string companyFolder, IUploadFile file*/)
        {
            BidRequestEntity entity = new BidRequestEntity
            {
                BidRequestStatusId = 1, //Pending approval
                UserId = dto.UserId,
                TenderId = dto.TenderId,
                CompanyId = dto.CompanyId,
                PaymentProvider = dto.PaymentProvider,
                PaymentReferenceCode = dto.PaymentReferenceCode,
                Amount = dto.PaymentAmount,
                Remark = null,
                Date_created = DateTimeNPT.Now,
                Date_modified = DateTimeNPT.Now
            };
            //entity.BidderRequestDocs = new List<BidderRequestDocEntity>();
            //string folder = $"{companyFolder}\\Tender Regiatraion\\{dto.TenderId}";
            //foreach (var item in dto.Documents)
            //{
            //    entity.BidderRequestDocs.Add(new BidderRequestDocEntity
            //    {
            //        DocPath = file.Upload(item.Document, folder).Result,
            //        DocTitle = item.DocTitle
            //    });
            //}
            return entity;
        }

        public List<BidderRequestDocEntity> ToEntity(SubmitDocumentForRegisteredTender dto, long bidRequestId, string companyFolder, IUploadFile file)
        {
            List<BidderRequestDocEntity> documents = new List<BidderRequestDocEntity>();
            string folder = $"{companyFolder}\\Tender Regiatraion\\{dto.TenderId}";
            foreach (var item in dto.Documents)
            {
                documents.Add(new BidderRequestDocEntity
                {
                    DocPath = file.Upload(item.Document, folder).Result,
                    DocTitle = item.DocTitle,
                    BidRequestId = bidRequestId
                });
            }
            return documents;
        }

        /// <summary>
        /// Convert dto to list of entities
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cryptoService"></param>
        /// <param name="batchNo"></param>
        /// <returns></returns>
        public List<LiveBiddingEntity> MaterialBiddingDtoToLiveBiddingEntity(TenderMaterialBiddingDto dto, ICryptoService cryptoService, long batchNo)
        {
            if (dto == null)
            {
                return null;
            }
            List<LiveBiddingEntity> entities = new List<LiveBiddingEntity>();
            foreach (var item in dto.MaterialQuotation)
            {
                entities.Add(new LiveBiddingEntity
                {
                    BiddingRequestId = dto.BiddingId,
                    UserId = dto.SupplierId,
                    TenderId = dto.TenderId,
                    MaterialId = item.MaterialId,
                    UnitPrice = item.UnitPrice,
                    Units = item.Unit,
                    Quantity = item.Quantity,
                // Quotation = item.Quotation.ToString(),
                    Quotation = cryptoService.Encrypt(item.Quotation.ToString()),
                    BidDate = dto.BiddingDate,
                    BatchNo = batchNo,
                    TotalAmount = dto.totalAmount
            });
            }
            return entities;

        }

        public List<SealBidEntity> MaterialBiddingDtoToSealBidEntity(TenderMaterialSealBiddingDto dto, ICryptoService cryptoService, long batchNo)
        {
            if (dto == null)
            {
                return null;
            }
            List<SealBidEntity> entities = new List<SealBidEntity>();
            foreach (var subsectionDto in dto.MaterialQuotation)
            {
                foreach (var subsectionDtoArray in subsectionDto.Value)
                {
                    entities.Add(new SealBidEntity
                    {
                        BiddingRequestId = dto.BiddingId,
                        UserId = dto.SupplierId,
                        TenderId = dto.TenderId,
                        MaterialId = subsectionDtoArray.MaterialId,
                        UnitPrice = subsectionDtoArray.UnitPrice,
                        Units = subsectionDtoArray.Unit,
                        Quantity = subsectionDtoArray.Quantity,
                        // Quotation = item.Quotation.ToString(),
                        Quotation = cryptoService.Encrypt(subsectionDtoArray.Quotation.ToString()),
                        BidDate = dto.BiddingDate,
                                // BatchNo = batchNo,
                        TotalAmount = dto.totalAmount,
                        MaterialGroup = subsectionDto.Key
                    });
                }
            }
                  
            return entities;

        }



        /// <summary>
        /// Convert bidrequestentity to bid card dto
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public BidCardDto BidEntityToCard(BidRequestEntity entity)
        {
            if (entity == null)
            {
                return null;
            }
            else
            {
                return new BidCardDto
                {
                    BidId = entity.Id,
                    TenderId = entity.Tender.Id,
                    CompanyId = entity.CompanyId,
                    CompanyName = entity.Company.Name,
                    UserId = entity.UserId,
                    UserName = $"{entity.User.FirstName} {entity.User.LastName}",
                    Price = entity.Amount,
                    BidDate = entity.Date_created,
                    BidStatus = entity.BidRequestStatus.Status,
                    PaymentProvider = entity.PaymentProvider,
                    TenderCategory = entity.Tender.CategoryEntity.Category,
                    TenderLiveDate = entity.Tender.LiveEndDate,
                    TenderTitle = entity.Tender.Title,
                    TenderCode = entity.Tender.Code,
                    PaymentReferenceCode = entity.PaymentReferenceCode,
                };
            }

        }

        /// <summary>
        /// Convert bidrequestentity to bid history card dto
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public BidHistoryCardDto BidEntityToHistoryCard(BidRequestEntity entity)
        {
            if (entity == null)
            {
                return null;
            }
            else
            {
                return new BidHistoryCardDto
                {
                    BidId = entity.Id,
                    TenderId = entity.Tender.Id,
                    Price = entity.Amount,
                    BidDate = entity.Date_created,
                    BidStatus = entity.BidRequestStatus.Status,
                    PaymentProvider = entity.PaymentProvider,
                    TenderCategory = entity.Tender.CategoryEntity.Category,
                    TenderLiveDate = entity.Tender.LiveEndDate,
                    TenderTitle = entity.Tender.Title,
                    TenderCode = entity.Tender.Code,
                    //CardInfo = (from tc in entity.Tender.TenderCards
                    //            select new TenderCardInfo
                    //            {
                    //                Id = tc.Id,
                    //                Label = tc.Label,
                    //                Value = tc.Value
                    //            }).ToList()
                };
            }

        }

        /// <summary>
        /// Return list of bid card dto from list of bid request entity
        /// </summary>
        /// <param name="bidderRequests"></param>
        /// <returns></returns>
        public IEnumerable<BidCardDto> BidderRequestToDto(IEnumerable<BidRequestEntity> bidderRequests)
        {
            if (bidderRequests == null)
            {
                return null;
            }

            else
            {
                List<BidCardDto> getBiddings = new List<BidCardDto>();
                foreach (BidRequestEntity requestEntity in bidderRequests)
                {
                    getBiddings.Add(BidEntityToCard(requestEntity));
                };
                return getBiddings;

            }

        }

        public IEnumerable<BidHistoryCardDto> ToBidHistory(IEnumerable<BidRequestEntity> bidderRequests, IEnumerable<TenderWinnerEntity> winbids)
        {
            if (bidderRequests == null)
            {
                return null;
            }

            else
            {
                List<BidHistoryCardDto> getBiddings = new List<BidHistoryCardDto>();
                foreach (BidRequestEntity requestEntity in bidderRequests)
                {
                    BidHistoryCardDto c = BidEntityToHistoryCard(requestEntity);
                    c.IsWinner = winbids.Any(x => x.TenderId == requestEntity.TenderId);
                    MeroBoleeDbContext meroBoleeDbContext = new MeroBoleeDbContext();
                    TenderEntity e = meroBoleeDbContext.TenderEntities.Where(x => x.Id == c.TenderId).FirstOrDefault();
                    c.Product = e.Product;
                    c.LiveEndDate = e.LiveEndDate;
                    c.LiveStartDate = e.LiveStartDate;
                    c.RegistrationTill = e.RegistrationTill;
                    c.Location = e.Location;
                    getBiddings.Add(c);
                };
                return getBiddings;

            }
        }


        /// <summary>
        /// Convert entity to detail dto
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="basePath"></param>
        /// <returns></returns>
        public BidDetailDto ToDetailDto(BidRequestEntity entity, string basePath)
        {
            if (entity == null) return null;

            BidDetailDto dto = new BidDetailDto
            {
                BidId = entity.Id,
                RegisterDate = entity.Date_created,
                Remarks = entity.Remark,
                TenderId = entity.TenderId,
                BidStatus = entity.BidRequestStatus.Status,
                Price = entity.Amount,
                PaymentProvider = entity.PaymentProvider,
                PaymentReferenceCode = entity.PaymentReferenceCode,
                BidDate = entity.Date_created,
                CompanyId = entity.CompanyId,
                CompanyName = entity.Company.Name,
                TenderCategory = entity.Tender.CategoryEntity.Category,
                TenderCode = entity.Tender.Code,
                TenderLiveDate = entity.Tender.LiveStartDate,
                TenderTitle = entity.Tender.Title,
                UserId = entity.UserId,
                UserName = $"{entity.User.FirstName} {entity.User.LastName}"
            };

            dto.Documents = (from d in entity.BidderRequestDocs
                             select new DocResponseDto
                             {
                                 Id = d.Id,
                                 DocTitle = d.DocTitle,
                                 DocPath = $"{basePath}{d.DocPath.Replace("\\", "/")}"
                             }).ToList();

            dto.BidHistories = (from h in entity.BiddingHistories
                                select new BidHistory
                                {
                                    BatchNo = h.BatchNo,
                                    BidId = h.BiddingRequestId,
                                    BidTime = h.BidDate,
                                    Material = h.TenderMaterialEntity.Materials,
                                    Quotation = h.Quotation,
                                    TenderId = h.TenderId,
                                    Position = h.FinalPosition
                                }).ToList();

            return dto;
        }


        public TenderWinnerEntity ToWinnerEntity(BidWinnerRequestDto dto)
        {
            return new TenderWinnerEntity
            {
                TenderId = dto.TenderId,
                WinnerCompanyId = dto.CompanyId,
                Date_created = DateTimeNPT.Now,
                Date_modified = DateTimeNPT.Now
            };
        }
    }
}
