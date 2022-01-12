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
        /// Gets all request help.
        /// </summary>
        /// <returns><see cref="IEnumerable&lt;TechnicalSupportEntity&gt;"/></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.Exception"></exception>
        public IEnumerable<TechnicalSupportEntity > GetAllRequestHelp()
        {
            try
            {
                meroBoleeDbContexts.TechnicalSupportStatuses.ToList();
                meroBoleeDbContexts.UserEntities.ToList();
                return meroBoleeDbContexts.TechnicalSupportEntities.ToList();
            }
            
            catch (Exception)
            {
                throw ;
            }
        }



        /// <summary>
        /// Gets all request help by bidder.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.Exception"></exception>
        public IEnumerable<TechnicalSupportEntity > GetAllRequestHelpByBidder(int id)
        {
            try
            {
                meroBoleeDbContexts.TechnicalSupportStatuses.ToList();
                meroBoleeDbContexts.UserEntities.ToList();
                return meroBoleeDbContexts.TechnicalSupportEntities.Where(m=>m.UserId==id).ToList();
            }
            catch (Exception)
            {
                throw ;
            }
        }



        /// <summary>
        /// Gets the request help.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public TechnicalSupportEntity  GetRequestHelp(int id)
        {
            try
            {
                meroBoleeDbContexts.TechnicalSupportStatuses.ToList();
                meroBoleeDbContexts.UserEntities.ToList();
                return meroBoleeDbContexts.TechnicalSupportEntities.Where(m => m.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw ;
            }
        }



        /// <summary>
        /// Posts the request.
        /// </summary>
        /// <param name="requestHelp">The request help.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.Exception"></exception>
        public TechnicalSupportEntity  PostRequest(TechnicalSupportEntity  requestHelp)
        {
            try
            {
                meroBoleeDbContexts.TechnicalSupportEntities.Add(requestHelp);
                unitOfWork.SaveChange();
                return requestHelp ;
            }
            catch (Exception)
            {
                throw ;
            }
        }


        /// <summary>
        /// Updates the request help.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestHelp">The request help.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public TechnicalSupportEntity  UpdateRequestHelp(int id, TechnicalSupportEntity  requestHelp)
        {
            try
            {
                TechnicalSupportEntity  requestHelpEntity = GetRequestHelp(id);
                if (requestHelpEntity == null)
                {
                    return requestHelpEntity = null;
                }
                requestHelpEntity.Title = requestHelp.Title;
                requestHelpEntity.Description = requestHelp.Description;
                requestHelpEntity.Date_modified = requestHelpEntity.Date_modified;
                //   categoryEntity.Modified_time_stamp = categoryEntity.Modified_time_stamp;
                unitOfWork.SaveChange();
                return requestHelpEntity;
            }
            catch (Exception)
            {
                throw ;
            }
        }
    }
}
