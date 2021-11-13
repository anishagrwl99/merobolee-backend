using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Model;
using MeroBolee.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    /// <summary>
    /// FAQ service implementation
    /// </summary>
    public class FAQService: FAQMapper, IFAQService
    {
        private readonly IFAQRepository fAQRepository;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="fAQRepository"></param>
        public FAQService(IFAQRepository fAQRepository)
        {
            this.fAQRepository = fAQRepository;
        }

        /// <summary>
        /// Delete a FAQ that is no longer required or relevant
        /// </summary>
        /// <param name="id">Id of a FAQ to delete</param>
        public void DeleteFAQ(int id)
        {
            fAQRepository.DeleteFAQ(id);
        }


        /// <summary>
        /// Get all FAQs 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FAQResponseDto> GetAllFAQ()
        {
            return fAQRepository.GetAllFAQ().Select(x=> ToResponseDto(x)).ToList<FAQResponseDto>();
        }

        /// <summary>
        /// Get a FAQ by an ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FAQResponseDto GetFAQ(int id)
        {
            return ToResponseDto(fAQRepository.GetFAQ(id));
        }

        /// <summary>
        /// Add a FAQ into database
        /// </summary>
        /// <param name="FAQ"></param>
        /// <returns></returns>
        public FAQResponseDto PostQuestion(FAQAddDto FAQ)
        {
            return ToResponseDto(fAQRepository.PostQuestion(ToEntity(FAQ)));
        }

        /// <summary>
        /// Update a FAQ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="FAQ"></param>
        /// <returns></returns>
        public FAQResponseDto UpdateFAQ(int id, FAQAddDto FAQ)
        {
            return ToResponseDto(fAQRepository.UpdateFAQ(id, ToEntity(FAQ)));
        }
    }
}
