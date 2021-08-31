using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.RequestHelp
{
    public class RequestHelpRepository: RepositoryBase<RequestHelpEntity>, IRequestHelpRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public RequestHelpRepository(IUnitOfWork unitOfWork, IDbFactory dbFactory) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<RequestHelpEntity> GetAllRequestHelp()
        {
            try
            {
                meroBoleeDbContexts.RequestHelpStatuses.ToList();
                meroBoleeDbContexts.UserEntities.ToList();
                return meroBoleeDbContexts.RequestHelpEntities.ToList();
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

        public IEnumerable<RequestHelpEntity> GetAllRequestHelpByBidder(int id)
        {
            try
            {
                meroBoleeDbContexts.RequestHelpStatuses.ToList();
                meroBoleeDbContexts.UserEntities.ToList();
                return meroBoleeDbContexts.RequestHelpEntities.Where(m=>m.User_id==id).ToList();
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

        public RequestHelpEntity GetRequestHelp(int id)
        {
            try
            {
                meroBoleeDbContexts.RequestHelpStatuses.ToList();
                meroBoleeDbContexts.UserEntities.ToList();
                return meroBoleeDbContexts.RequestHelpEntities.Where(m => m.Request_help_id == id).FirstOrDefault();
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

        public RequestHelpEntity PostRequest(RequestHelpEntity requestHelp)
        {
            try
            {
                meroBoleeDbContexts.RequestHelpEntities.Add(requestHelp);
                unitOfWork.SaveChange();
                return requestHelp ;
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

        public RequestHelpEntity UpdateRequestHelp(int id, RequestHelpEntity requestHelp)
        {
            try
            {
                RequestHelpEntity requestHelpEntity = GetRequestHelp(id);
                if (requestHelpEntity == null)
                {
                    return requestHelpEntity = null;
                }
                requestHelpEntity.Problem_title = requestHelp.Problem_title;
                requestHelpEntity.Description = requestHelp.Description;
                requestHelpEntity.Remark = requestHelp.Remark;
                requestHelpEntity.Help_status_id = requestHelp.Help_status_id;
                requestHelpEntity.Date_modified = requestHelpEntity.Date_modified;
                //   categoryEntity.Modified_time_stamp = categoryEntity.Modified_time_stamp;
                unitOfWork.SaveChange();
                return requestHelpEntity;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
