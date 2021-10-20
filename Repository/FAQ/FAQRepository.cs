using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.FAQ
{
    /// <summary>
    /// FAQ repo implementation
    /// </summary>
    public class FAQRepository : RepositoryBase<FAQEntity>, IFAQRepository
    {
        private readonly IUnitOfWork unitOfWork;


        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="dbFactory"></param>
        /// <param name="unitOfWork"></param>
        public FAQRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Delete a FAQ from database
        /// </summary>
        /// <param name="id">A record id that needs to delete</param>
        public void DeleteFAQ(int id)
        {
            try
            {
                meroBoleeDbContexts.FAQEntities.Remove(GetFAQ(id));
                unitOfWork.SaveChange();
            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// Returns all FAQs from database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FAQEntity> GetAllFAQ()
        {
            try
            {
                meroBoleeDbContexts.StatusEntities.ToList();
                return meroBoleeDbContexts.FAQEntities.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get a specific FAQ from database
        /// </summary>
        /// <param name="id">A record id that needs to be retrieved</param>
        /// <returns></returns>
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
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// Add a FAQ into database
        /// </summary>
        /// <param name="FAQ">A FAQ object to add</param>
        /// <returns></returns>
        public FAQEntity PostQuestion(FAQEntity FAQ)
        {
            try
            {
                meroBoleeDbContexts.FAQEntities.Add(FAQ);
                unitOfWork.SaveChange();
                meroBoleeDbContexts.StatusEntities.ToList();
                return FAQ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Update a faq 
        /// </summary>
        /// <param name="id">A FAQ record id which need to be updated</param>
        /// <param name="FAQ">A FAQ object with new details</param>
        /// <returns></returns>
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
                fAQEntity.Date_modified = FAQ.Date_modified;
                unitOfWork.SaveChange();
                return fAQEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
