using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public interface ITechnicalSupportRepository : IRepositoryBase<TechnicalSupportEntity >
    {
        Task<TechnicalSupportEntity>  PostRequest(TechnicalSupportEntity  requestHelp);
    }
}
