using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    /// <summary>
    /// interface for FAQ
    /// </summary>
    public interface IFAQRepository : IRepositoryBase<FAQEntity>
    {
        /// <summary>
        /// Method to add FAQ into database
        /// </summary>
        /// <param name="FAQ"></param>
        /// <returns></returns>
        FAQEntity PostQuestion(FAQEntity FAQ);


        /// <summary>
        /// Method to get particular FAQ from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FAQEntity GetFAQ(int id);


        /// <summary>
        /// Method to get All FAQs from database
        /// </summary>
        /// <returns></returns>
        IEnumerable<FAQEntity> GetAllFAQ();


        /// <summary>
        /// Method to update particular FAQ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="FAQ"></param>
        /// <returns></returns>
        FAQEntity UpdateFAQ(int id, FAQEntity FAQ);


        /// <summary>
        /// Method to delete a FAQ from database
        /// </summary>
        /// <param name="id"></param>
        void DeleteFAQ(int id);
    }
}
