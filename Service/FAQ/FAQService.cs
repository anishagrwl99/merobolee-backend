using MeroBolee.Model;
using MeroBolee.Repository.FAQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.FAQ
{
    public class FAQService: IFAQService
    {
        private readonly IFAQRepository fAQRepository;
        public FAQService(IFAQRepository fAQRepository)
        {
            this.fAQRepository = fAQRepository;
        }

        public void DeleteFAQ(int id)
        {
            fAQRepository.DeleteFAQ(id);
        }

        public IEnumerable<FAQEntity> GetAllFAQ()
        {
            return fAQRepository.GetAllFAQ();
        }

        public IEnumerable<FAQEntity> GetAllPublishFAQ()
        {
            return fAQRepository.GetAllPublishFAQ();
        }

        public FAQEntity GetFAQ(int id)
        {
            return fAQRepository.GetFAQ(id);
        }

        public FAQEntity PostQuestion(FAQEntity FAQ)
        {
            return fAQRepository.PostQuestion(FAQ);
        }

        public FAQEntity UpdateFAQ(int id, FAQEntity FAQ)
        {
            return fAQRepository.UpdateFAQ(id, FAQ);
        }
    }
}
