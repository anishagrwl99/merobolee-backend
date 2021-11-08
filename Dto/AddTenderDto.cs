using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddTenderDto
    {
        private string tenderTitle;
        private int categoryId;
        private string tenderDescription;
        private int tenderliveinterval;
        private DateTime liveStartDate;
        private int tenderDuration;
        private string durationType;
        private int postedBy;
        private int tenderStatusId;
        private ICollection<TenderMaterialDto> tenderMaterialEntities;
        private long companyid;
        private string termsAndCondition;

        public long CompanyId { get => companyid; set => companyid = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public string TenderTitle { get => tenderTitle; set => tenderTitle = value; }       
        public string TenderDescription { get => tenderDescription; set => tenderDescription = value; }
        public int Tenderliveinterval { get => tenderliveinterval; set => tenderliveinterval = value; }
        public DateTime LiveStartDate { get => liveStartDate; set => liveStartDate = value; }
        public int TenderDuration { get => tenderDuration; set => tenderDuration = value; }
        public string DurationType { get => durationType; set => durationType = value; }
        public int CreatedBy { get => postedBy; set => postedBy = value; }
        public int TenderStatusId { get => tenderStatusId; set => tenderStatusId = value; }
        public ICollection<TenderMaterialDto> TenderMaterial { get => tenderMaterialEntities; set => tenderMaterialEntities = value; }
        public string TermsAndCondition { get => termsAndCondition; set => termsAndCondition = value; }

    }


    public class TenderMaterialDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public List<MaterialFeatureDto> Features { get; set; }
    }

    public class MaterialFeatureDto
    {
        public string FeatureName { get; set; }
        public string FeatureValue { get; set; }
    }
}
