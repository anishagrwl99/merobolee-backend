using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{


    /// <summary>
    /// Technical Support Repo
    /// </summary>
    /// <seealso cref="MeroBolee.Infrastructure.RepositoryBase&lt;MeroBolee.Model.TechnicalSupportEntity&gt;" />
    /// <seealso cref="MeroBolee.Repository.RequestHelp.ITechnicalSupportpRepository" />
    public class TechnicalSupportRepository : RepositoryBase<TechnicalSupportEntity >, ITechnicalSupportRepository
    {
        private readonly IUnitOfWork unitOfWork;



        /// <summary>
        /// Initializes a new instance of the <see cref="TechnicalSupportRepository"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="dbFactory">The database factory.</param>
        public TechnicalSupportRepository (IUnitOfWork unitOfWork, IDbFactory dbFactory) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Posts the request.
        /// </summary>
        /// <param name="requestHelp">The request help.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.Exception"></exception>
        public async Task<TechnicalSupportEntity>  PostRequest(TechnicalSupportEntity  requestHelp)
        {
            try
            {
                meroBoleeDbContexts.TechnicalSupportEntities.Add(requestHelp);
                await unitOfWork.SaveChangesAsync();
                return requestHelp ;
            }
            catch (Exception ex)
            {
                throw ;
            }
        }

    }
}
