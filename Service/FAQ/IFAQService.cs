using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.FAQ
{
    public interface IFAQService
    {
        FAQEntity PostQuestion(FAQEntity FAQ);
        FAQEntity GetFAQ(int id);
        IEnumerable<FAQEntity> GetAllFAQ();
        IEnumerable<FAQEntity> GetAllPublishFAQ();
        FAQEntity UpdateFAQ(int id, FAQEntity FAQ);

        void DeleteFAQ(int id);
    }
}
