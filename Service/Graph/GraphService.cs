using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.EntityMapper;
using MeroBolee.Model;
using MeroBolee.Repository;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MeroBolee.Settings;
using System.Text;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeroBolee.Service
{

    /// <summary>
    /// Signup service interface
    /// </summary>
    public interface IGraphService
    {
        Task<SupplierGraphDto> GetSupplierTendersGraph(GraphRequestDto dto);
        Task<BidInviterGraphDto> GetInviterTenderGraph(GraphRequestDto dto);
    }

    /// <summary>
    /// Signup service implementation
    /// </summary>
    public class GraphService : GraphMapper, IGraphService
    {
        private readonly IGraphRepository graphRepository;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="graphRepository"></param>
        public GraphService(IGraphRepository graphRepository)
        {
            this.graphRepository = graphRepository;
        }

        public async Task<BidInviterGraphDto> GetInviterTenderGraph(GraphRequestDto dto)
        {
            List<CommunityApprovalEntity> result = await graphRepository.GetInviterTenderSubmissions(dto.CompanyId);
            BidInviterGraphDto responseDto = ToBidInviterGraph(result);
            return responseDto;
        }

        public async Task<SupplierGraphDto> GetSupplierTendersGraph(GraphRequestDto dto)
        {
            List<TenderEntity> registeredTenders = await graphRepository.GetSupplierRegisteredTenders(dto.CompanyId);
            List<TenderEntity> wonTenders = await graphRepository.GetSupplierWonTenders(dto.CompanyId);
            return ToSupplierGraph(registeredTenders, wonTenders);
        }

    }
}
