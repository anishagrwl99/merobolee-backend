using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.FAQ
{
    public class FAQRepository: RepositoryBase<FAQEntity>, IFAQRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public FAQRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork; 
        }

        public void DeleteFAQ(int id)
        {
            try
            {
                meroBoleeDbContexts.FAQEntities.Remove(GetFAQ(id));
                unitOfWork.SaveChange();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public IEnumerable<FAQEntity> GetAllFAQ()
        {
            try
            {
                meroBoleeDbContexts.StatusEntities.ToList();
                return meroBoleeDbContexts.FAQEntities.ToList();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public IEnumerable<FAQEntity> GetAllPublishFAQ()
        {
            meroBoleeDbContexts.StatusEntities.ToList();
            return meroBoleeDbContexts.FAQEntities.Where(m => m.PublishStatus.Status.ToLower() == "publish").ToList();
        }

        public FAQEntity GetFAQ(int id)
        {
            try
            {
                FAQEntity fAQ = meroBoleeDbContexts.FAQEntities.Find(id);
                if (fAQ == null)
                {
                    return fAQ = null;
                }
                meroBoleeDbContexts.StatusEntities.ToList();
                return fAQ;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public FAQEntity PostQuestion(FAQEntity FAQ)
        {
            try
            {
                meroBoleeDbContexts.FAQEntities.Add(FAQ);
                unitOfWork.SaveChange();
                meroBoleeDbContexts.StatusEntities.ToList();
                return FAQ;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public FAQEntity UpdateFAQ(int id, FAQEntity FAQ)
        {
           
            try
            {
                FAQEntity fAQEntity = GetFAQ(id);
                if (fAQEntity == null)
                {
                    return fAQEntity = null;
                }
                fAQEntity.Question = FAQ.Question;
                fAQEntity.Answer = FAQ.Answer;
                fAQEntity.Status_id = FAQ.Status_id;
                fAQEntity.Date_modified = FAQ.Date_modified;
                //   categoryEntity.Modified_time_stamp = categoryEntity.Modified_time_stamp;
                unitOfWork.SaveChange();
                return fAQEntity;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
