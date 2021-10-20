using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.FAQ
{
    /// <summary>
    /// Interface for FAQ Service
    /// </summary>
    public interface IFAQService
    {

        /// <summary>
        /// Method to add FAQ
        /// </summary>
        /// <param name="FAQ"></param>
        /// <returns></returns>
        FAQResponseDto PostQuestion(FAQAddDto FAQ);

        /// <summary>
        /// Method to get FAQ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FAQResponseDto GetFAQ(int id);

        /// <summary>
        /// Method to get all FAQ
        /// </summary>
        /// <returns></returns>
        IEnumerable<FAQResponseDto> GetAllFAQ();
        /// <summary>
        /// Method to update FAQ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="FAQ"></param>
        /// <returns></returns>
        FAQResponseDto UpdateFAQ(int id, FAQAddDto FAQ);

        /// <summary>
        /// Method to delete FAQ
        /// </summary>
        /// <param name="id"></param>
        void DeleteFAQ(int id);
    }
}
