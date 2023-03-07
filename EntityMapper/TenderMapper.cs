using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeroBolee.Utility;

namespace MeroBolee.EntityMapper
{
    public class TenderMapper
    {

        private DateTime GetTenderEndDate(DateTime startDateTime, int tenderDuration, string durationUnit)
        {
            switch (durationUnit.ToLowerInvariant())
            {
                case "minute":
                case "minutes":
                    return startDateTime.AddMinutes(tenderDuration);

                case "day":
                case "days":
                    return startDateTime.AddDays(tenderDuration);

                case "week":
                case "weeks":
                    return startDateTime.AddDays(tenderDuration * 7);

                case "month":
                case "months":
                    return startDateTime.AddMonths(tenderDuration);

                case "year":
                case "years":
                    return startDateTime.AddYears(tenderDuration);

                default:
                    return startDateTime.AddMinutes(tenderDuration);
            }
        }
        public TenderEntity TenderDtoEntity(AddTenderRequestDto tenderDto)
        {
            MeroBoleeDbContext meroboleeDbContext = new MeroBoleeDbContext();
            string algoName = meroboleeDbContext.AlgorithmEntities.Where(x => x.id == tenderDto.Algorithm).Select(x => x.AlgoName).FirstOrDefault();
            if (tenderDto == null)
            {
                return null;
            }
            TenderEntity entity = new TenderEntity
            {
                CompanyId = tenderDto.superId,
                Title = tenderDto.TenderTitle,
                CategoryId = tenderDto.CategoryId,
                LiveInterval = tenderDto.TimeInterval,
                LiveStartDate = tenderDto.LiveStartDate,
                LiveEndDate = tenderDto.LiveEndDate,
                StatusId = 1,
                CreatedBy = tenderDto.CreatedBy,
                PerformanceRequest = tenderDto.PerformanceRequest,
                AdditionalRequest = tenderDto.AdditionalRequest,
                EligibilityCriteria = tenderDto.EligibilityCriteria,
                Location = tenderDto.Location,
                QualityRequest = tenderDto.QualityRequest,
                Price = tenderDto.Price,
                MaxQuotation = tenderDto.MaxQuotation,
                TenderDetailDocTitle = tenderDto.TenderDocTitle,
                RegistrationTill = tenderDto.RegistrationTill,
                Date_created = DateTimeNPT.Now,
                Date_modified = DateTimeNPT.Now,
                IsDeleted = false,
                DateOfExecution = tenderDto.DateOfExecution,
                Product = tenderDto.Product,
                AlgoName = algoName == null ? "" : algoName,
                AlgoId = tenderDto.Algorithm,
                CommunityApprovalStatus=1,
                PostBidStatus=1,
                ProcurementId=tenderDto.ProcurementId
            };
            entity.TenderMaterialEntities = new List<TenderMaterialEntity>();
            foreach (var item in tenderDto.TenderMaterials)
            {
                TenderMaterialEntity obj = new TenderMaterialEntity
                {
                    Materials = item.Name,
                    Quantity = item.Quantity,
                    Units = item.Units,
                    MaterialGroup = item.MaterialGroup == null ? "" : item.MaterialGroup,
                    IsDeleted = false
                };
                entity.TenderMaterialEntities.Add(obj);
            }

            return entity;
        }

        public List<CommunityApprovalEntity> CommunityDtoEntity(long id ,AddTenderRequestDto tenderDto)
        {

            if (tenderDto == null)
            {
                return null;
            }

            var communityApproval=new List<CommunityApprovalEntity>();

            List<int> companyIds = tenderDto.companyIds.Split(',')
                .Select(possibleIntegerAsString => {
                    int parsedInteger = 0;
                    bool isInteger = int.TryParse(possibleIntegerAsString , out parsedInteger);
                    return new {isInteger, parsedInteger};
                })
                .Where(tryParseResult => tryParseResult.isInteger)
                .Select(tryParseResult => tryParseResult.parsedInteger)
                .ToList();
            
            foreach (var item in companyIds)
            {
                CommunityApprovalEntity community = new CommunityApprovalEntity
                {
                    CategoryId = tenderDto.CategoryId,
                    TenderId = id,
                    StatusId = 1,
                    Date_Created = DateTimeNPT.Now,
                    Date_Modified = DateTimeNPT.Now,
                    IsDeleted = false,
                    CompanyId=item
                };

                communityApproval.Add(community);
            }

            return communityApproval;
        }

        public void UpdateTenderEntity(ref TenderEntity entity, UpdateTenderRequestDto dto)
        {
            entity.Title = dto.TenderTitle;
            entity.CategoryId = dto.CategoryId;
            entity.LiveInterval = dto.TimeInterval;
            entity.PerformanceRequest = dto.PerformanceRequest;
            entity.RegistrationTill = dto.RegistrationTill;
            entity.LiveStartDate = dto.LiveStartDate;
            entity.LiveEndDate = dto.LiveEndDate;
            entity.QualityRequest = dto.QualityRequest;
            entity.CompanyId = dto.superId;
            entity.Date_modified = DateTimeNPT.Now;
            entity.AdditionalRequest = dto.AdditionalRequest;
            entity.EligibilityCriteria = dto.EligibilityCriteria;
            entity.Location = dto.Location;
            entity.Price = dto.Price;
            entity.MaxQuotation = dto.MaxQuotation;
            entity.IsDeleted = dto.IsDeleted;
            entity.Product = dto.Product;
            entity.StatusId = 1;
            entity.CommunityApprovalStatus = 1;
            entity.DateOfExecution = dto.DateOfExecution;
            if (dto.TenderMaterials != null)
            {
                foreach (var item in dto.TenderMaterials)
                {
                    var itm = entity.TenderMaterialEntities.Where(x => x.Id == item.Id).FirstOrDefault();
                    if (itm == null)
                    {
                        entity.TenderMaterialEntities.Add(new TenderMaterialEntity
                        {
                            Materials = item.Name,
                            Quantity = item.Quantity,
                            TenderId = entity.Id,
                            Units = item.Units,
                            IsDeleted = false
                        });
                    }
                    else
                    {
                        itm = new TenderMaterialEntity();
                        itm.Materials = item.Name;
                        itm.Quantity = item.Quantity;
                        itm.Units = item.Units;
                        itm.IsDeleted = false;

                    }
                }
            }
        }
        public GetTenderDto TenderEntityToDto(TenderEntity tenderEntity, string baseUrl, bool isRegistered, string userRole)
        {
            if (userRole.Equals("Bid Inviter"))
            {
                if (tenderEntity == null)
                {
                    return null;
                }

                GetTenderDto getTender = new GetTenderDto();
                getTender.TenderId = tenderEntity.Id;
                getTender.CompanyId = tenderEntity.CompanyId;
                getTender.CompanyName = tenderEntity.Company.Name;
                getTender.TenderCode = tenderEntity.Code;
                getTender.TenderTitle = tenderEntity.Title;
                getTender.RegistrationTill = tenderEntity.RegistrationTill;
                getTender.CategoryId = tenderEntity.CategoryId;
                getTender.CategoryName = tenderEntity.CategoryEntity.Category;
                getTender.TenderLiveInterval = tenderEntity.LiveInterval;
                getTender.LiveStartDate = tenderEntity.LiveStartDate;
                getTender.LiveEndDate = tenderEntity.LiveEndDate;// tenderEntity.Live_Start_Date.AddMinutes(tenderEntity.Tender_live_interval);
                getTender.StatusId = tenderEntity.StatusId;
                getTender.Status = tenderEntity.TenderStatusEntity.Status;
                getTender.CancelRemarks = tenderEntity.CancelRemarks;
                getTender.Location = tenderEntity.Location;
                getTender.QualityRequest = tenderEntity.QualityRequest;
                getTender.PerformanceRequest = tenderEntity.PerformanceRequest;
                getTender.EligibilityCriteria = tenderEntity.EligibilityCriteria;
                getTender.AdditionalRequest = tenderEntity.AdditionalRequest;
                getTender.Price = tenderEntity.Price;
                getTender.MaxQuotation = tenderEntity.MaxQuotation;
                getTender.Product = tenderEntity.Product;
                getTender.DateOfExecution = tenderEntity.DateOfExecution;

                getTender.CreatedDate = tenderEntity.Date_created;
                getTender.TenderMaterials = (from me in tenderEntity.TenderMaterialEntities
                                             select new TenderMaterialResponseDto
                                             {
                                                 Id = me.Id,
                                                 MaterialName = me.Materials,
                                                 Quantity = me.Quantity,
                                                 Units = me.Units,
                                                 MaterialGroup = me.MaterialGroup

                                             }).ToList();

                getTender.ExtraDocuments = (from txd in tenderEntity.ExtraDocuments
                                            select new TenderExtraDocumentResponseDto
                                            {
                                                Id = txd.Id,
                                                DocTitle = txd.DocTitle,
                                                DocPath = string.IsNullOrEmpty(txd.DocPath) ? "" :
                                                            $"{baseUrl}{txd.DocPath.Replace("\\", "/")}"
                                            }).ToList();
                getTender.AlgoName = tenderEntity.AlgoName;
                getTender.CommunityApprovalStatus = tenderEntity.CommunityApprovalStatus;
                getTender.AlgoId = tenderEntity.AlgoId;
                return getTender;
            }
            else if (userRole.Equals("Bidder"))
            {
                if (isRegistered == true)
                {

                    if (tenderEntity == null)
                    {
                        return null;
                    }

                    GetTenderDto getTender = new GetTenderDto();
                    getTender.TenderId = tenderEntity.Id;
                    getTender.CompanyId = tenderEntity.CompanyId;
                    getTender.CompanyName = tenderEntity.Company.Name;
                    getTender.TenderCode = tenderEntity.Code;
                    getTender.TenderTitle = tenderEntity.Title;
                    getTender.RegistrationTill = tenderEntity.RegistrationTill;
                    getTender.CategoryId = tenderEntity.CategoryId;
                    getTender.CategoryName = tenderEntity.CategoryEntity.Category;
                    getTender.TenderLiveInterval = tenderEntity.LiveInterval;
                    getTender.LiveStartDate = tenderEntity.LiveStartDate;
                    getTender.LiveEndDate = tenderEntity.LiveEndDate;// tenderEntity.Live_Start_Date.AddMinutes(tenderEntity.Tender_live_interval);
                    getTender.StatusId = tenderEntity.StatusId;
                    getTender.Status = tenderEntity.TenderStatusEntity.Status;
                    getTender.CancelRemarks = tenderEntity.CancelRemarks;
                    getTender.Location = tenderEntity.Location;
                    getTender.QualityRequest = tenderEntity.QualityRequest;
                    getTender.PerformanceRequest = tenderEntity.PerformanceRequest;
                    getTender.EligibilityCriteria = tenderEntity.EligibilityCriteria;
                    getTender.AdditionalRequest = tenderEntity.AdditionalRequest;
                    getTender.Price = tenderEntity.Price;
                    getTender.MaxQuotation = tenderEntity.MaxQuotation;
                    getTender.Product = tenderEntity.Product;
                    getTender.DateOfExecution = tenderEntity.DateOfExecution;

                    getTender.CreatedDate = tenderEntity.Date_created;
                    getTender.TenderMaterials = (from me in tenderEntity.TenderMaterialEntities
                                                 select new TenderMaterialResponseDto
                                                 {
                                                     Id = me.Id,
                                                     MaterialName = me.Materials,
                                                     Quantity = me.Quantity,
                                                     Units = me.Units,
                                                     MaterialGroup = me.MaterialGroup
                                                 }).ToList();

                    getTender.ExtraDocuments = (from txd in tenderEntity.ExtraDocuments
                                                select new TenderExtraDocumentResponseDto
                                                {
                                                    Id = txd.Id,
                                                    DocTitle = txd.DocTitle,
                                                    DocPath = string.IsNullOrEmpty(txd.DocPath) ? "" :
                                                                $"{baseUrl}{txd.DocPath.Replace("\\", "/")}"
                                                }).ToList();
                    getTender.AlgoName = tenderEntity.AlgoName;
                    getTender.AlgoId = tenderEntity.AlgoId;
                    getTender.CommunityApprovalStatus = tenderEntity.CommunityApprovalStatus;
                    return getTender;
                }
                else
                {
                    if (tenderEntity == null)
                    {
                        return null;
                    }

                    GetTenderDto getTender = new GetTenderDto();
                    getTender.TenderId = tenderEntity.Id;
                    getTender.CompanyId = tenderEntity.CompanyId;
                    getTender.CompanyName = tenderEntity.Company.Name;
                    getTender.TenderCode = tenderEntity.Code;
                    getTender.TenderTitle = tenderEntity.Title;
                    getTender.RegistrationTill = tenderEntity.RegistrationTill;
                    getTender.CategoryId = tenderEntity.CategoryId;
                    getTender.CategoryName = tenderEntity.CategoryEntity.Category;
                    getTender.TenderLiveInterval = tenderEntity.LiveInterval;
                    getTender.LiveStartDate = tenderEntity.LiveStartDate;
                    getTender.LiveEndDate = tenderEntity.LiveEndDate;// tenderEntity.Live_Start_Date.AddMinutes(tenderEntity.Tender_live_interval);
                    getTender.StatusId = tenderEntity.StatusId;
                    getTender.Status = tenderEntity.TenderStatusEntity.Status;
                    getTender.CancelRemarks = tenderEntity.CancelRemarks;
                    getTender.Location = tenderEntity.Location;
                    getTender.QualityRequest = tenderEntity.QualityRequest;
                    getTender.PerformanceRequest = tenderEntity.PerformanceRequest;
                    getTender.EligibilityCriteria = tenderEntity.EligibilityCriteria;
                    getTender.AdditionalRequest = tenderEntity.AdditionalRequest;
                    getTender.Price = tenderEntity.Price;
                    getTender.MaxQuotation = tenderEntity.MaxQuotation;
                    getTender.Product = tenderEntity.Product;
                    getTender.DateOfExecution = tenderEntity.DateOfExecution;

                    getTender.CreatedDate = tenderEntity.Date_created;
                    getTender.TenderMaterials = (from me in tenderEntity.TenderMaterialEntities
                                                 select new TenderMaterialResponseDto
                                                 {
                                                     Id = me.Id,
                                                     MaterialName = me.Materials,
                                                     Quantity = me.Quantity,
                                                     Units = me.Units,
                                                     MaterialGroup = me.MaterialGroup

                                                 }).ToList();

                    getTender.ExtraDocuments = null;
                    getTender.AlgoName = tenderEntity.AlgoName;
                    getTender.AlgoId = tenderEntity.AlgoId;
                    getTender.CommunityApprovalStatus = tenderEntity.CommunityApprovalStatus;
                    return getTender;
                }
            } else {
                 if (tenderEntity == null)
                    {
                        return null;
                    }

                    GetTenderDto getTender = new GetTenderDto();
                    getTender.TenderId = tenderEntity.Id;
                    getTender.CompanyId = tenderEntity.CompanyId;
                    getTender.CompanyName = tenderEntity.Company.Name;
                    getTender.TenderCode = tenderEntity.Code;
                    getTender.TenderTitle = tenderEntity.Title;
                    getTender.RegistrationTill = tenderEntity.RegistrationTill;
                    getTender.CategoryId = tenderEntity.CategoryId;
                    getTender.CategoryName = tenderEntity.CategoryEntity.Category;
                    getTender.TenderLiveInterval = tenderEntity.LiveInterval;
                    getTender.LiveStartDate = tenderEntity.LiveStartDate;
                    getTender.LiveEndDate = tenderEntity.LiveEndDate;// tenderEntity.Live_Start_Date.AddMinutes(tenderEntity.Tender_live_interval);
                    getTender.StatusId = tenderEntity.StatusId;
                    getTender.Status = tenderEntity.TenderStatusEntity.Status;
                    getTender.CancelRemarks = tenderEntity.CancelRemarks;
                    getTender.Location = tenderEntity.Location;
                    getTender.QualityRequest = tenderEntity.QualityRequest;
                    getTender.PerformanceRequest = tenderEntity.PerformanceRequest;
                    getTender.EligibilityCriteria = tenderEntity.EligibilityCriteria;
                    getTender.AdditionalRequest = tenderEntity.AdditionalRequest;
                    getTender.Price = tenderEntity.Price;
                    getTender.MaxQuotation = tenderEntity.MaxQuotation;
                    getTender.Product = tenderEntity.Product;
                    getTender.DateOfExecution = tenderEntity.DateOfExecution;
                    getTender.CreatedDate = tenderEntity.Date_created;
                    getTender.TenderMaterials = (from me in tenderEntity.TenderMaterialEntities
                                                 select new TenderMaterialResponseDto
                                                 {
                                                     Id = me.Id,
                                                     MaterialName = me.Materials,
                                                     Quantity = me.Quantity,
                                                     Units = me.Units,
                                                     MaterialGroup = me.MaterialGroup

                                                 }).ToList();

                   

                    getTender.ExtraDocuments = (from txd in tenderEntity.ExtraDocuments
                                            select new TenderExtraDocumentResponseDto
                                            {
                                                Id = txd.Id,
                                                DocTitle = txd.DocTitle,
                                                DocPath = string.IsNullOrEmpty(txd.DocPath) ? "" :
                                                            $"{baseUrl}{txd.DocPath.Replace("\\", "/")}"
                                            }).ToList();
                    getTender.AlgoName = tenderEntity.AlgoName;
                    getTender.AlgoId = tenderEntity.AlgoId;
                    getTender.CommunityApprovalStatus = tenderEntity.CommunityApprovalStatus;
                    return getTender;
            }
        }

        public PostBidddingRemarksEntity PostBidRemarksDtoEntity(TenderApproveDto tenderApprove, PostBidddingApprovalEntity postBidEntity)
        {
            var postBidddingRemarksEntity = new PostBidddingRemarksEntity
            {
                CompanyId = tenderApprove.CompanyId,
                TenderPostBiddingApprovalId = postBidEntity.Id,
                Date_Created = DateTimeNPT.Now,
                TenderId = tenderApprove.TenderId,
                Remarks = tenderApprove.Remarks
            };
            return postBidddingRemarksEntity;
        }

        public TenderDocuments ToTenderDocuments(TenderEntity tenderEntity, string baseUrl)
        {
            TenderDocuments doc = new TenderDocuments
            {
                TenderDetailDocTitle = tenderEntity.TenderDetailDocTitle,
                TenderDetailDocPath = string.IsNullOrEmpty(tenderEntity.TenderDetailDocPath) ? "" :
                                        $"{baseUrl}{tenderEntity.TenderDetailDocPath.Replace("\\", "/")}",
                TermsAndConditionDocPath = string.IsNullOrEmpty(tenderEntity.TermsAndConditionDocPath) ? "" : 
                                        $"{baseUrl}{tenderEntity.TermsAndConditionDocPath.Replace("\\", "/")}"
            };
            return doc;

        }

        public PostBiddingSuperseedEntity PostBiddingSuperseedDtoEntity(SuperSeedDto superSeedDto)
        {
            var obj = new PostBiddingSuperseedEntity
            {
                UserId = superSeedDto.UserId,
                TenderId = superSeedDto.TenderId,
                Date_Created = DateTimeNPT.Now,
                Remarks = superSeedDto.Remarks,
                Bid = "PostBid",
                Status = "Super seed"
            };
            return obj;
        }

        public PostBiddingSuperseedEntity PreBiddingSuperseedDtoEntity(TenderApproveDto tenderApprove)
        {
            var obj = new PostBiddingSuperseedEntity
            {
                UserId = tenderApprove.UserId,
                TenderId = tenderApprove.TenderId,
                Date_Created = DateTimeNPT.Now,
                Remarks = tenderApprove.Remarks,
                Bid="PreBid",
                Status="Super seed"
            };
            return obj;
        }

        public PostBiddingSuperseedEntity BidRejectDtoEntity(TenderApproveDtoByAdmin tenderApprove,string Bid)
        {
            var obj = new PostBiddingSuperseedEntity()
            {
                UserId = tenderApprove.UserId,
                TenderId = tenderApprove.TenderId,
                Date_Created = DateTimeNPT.Now,
                Remarks = tenderApprove.Remarks,
                Bid = Bid,
                Status = "Reject"
            };
            return obj;
        }

        public IEnumerable<GraphDataEntity> GraphDataDtoEntity(GraphDataDto graphDataDto)
        {
            var list = new List<GraphDataEntity>();
            foreach (var item in graphDataDto.graphDatas)
            {
                var obj = new GraphDataEntity
                {
                    Procurement_of_Goods = item.allocatedBudget,
                    Procurement_of_Works = item.fundsUsed,
                    Procurement_of_Consultancy_Service = item.fundsRemaining,
                    Date_Created=DateTimeNPT.Now,
                    Date_Modified = DateTimeNPT.Now,
                    TotalBudget=graphDataDto.TotalBudget
                };
                list.Add(obj);
            }
            return list;
        }

        public List<GraphDataEntity> GraphDataUpdateDtoEntity(GraphDataDto graphDataDto, List<GraphDataEntity> graphDataEntities)
        {
            
            for (int i = 0; i < 3; i++)
            {

                graphDataEntities[i].Procurement_of_Goods = graphDataDto.graphDatas[i].allocatedBudget;
                graphDataEntities[i].Procurement_of_Works = graphDataDto.graphDatas[i].fundsUsed;
                graphDataEntities[i].Procurement_of_Consultancy_Service = graphDataDto.graphDatas[i].fundsRemaining;
                graphDataEntities[i].Date_Modified = DateTimeNPT.Now;
                graphDataEntities[i].TotalBudget = graphDataDto.TotalBudget;
            };
            return graphDataEntities;
        }

        public IEnumerable<BidRequestEntity> UpdateBidRequestEntitiesDto(IEnumerable<BidRequestEntity> bidRequestEntities,string Rank)
        {
            if (Rank == "Qualified")
            {
                foreach (var item in bidRequestEntities)
                {
                    item.IsQualified = false;
                }
            }
            else
            {
                foreach (var item in bidRequestEntities)
                {
                    item.IsWinner = false;
                }
            }
            return bidRequestEntities;
        }

    }
}
