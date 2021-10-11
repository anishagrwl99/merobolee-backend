using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.CompanyType
{
    public class CompanyTypeRepository : RepositoryBase<CompanyTypeLookupEntity>, ICompanyTypeRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public CompanyTypeRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public CompanyTypeLookupEntity AddCompanyType(CompanyTypeLookupEntity companyTypeEntity)
        {
            try
            { 
            meroBoleeDbContexts.CompanyTypeLookupEntities.Add(companyTypeEntity);
            unitOfWork.SaveChange();
            return companyTypeEntity;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void DeleteCompanyType(int id)
        {
            try 
            { 
            meroBoleeDbContexts.CompanyTypeLookupEntities.Remove(GetCompanyTypeDetail(id));
            unitOfWork.SaveChange();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public IEnumerable<CompanyTypeLookupEntity> GetCompanyType(string search)
        {
            try
            {
                return meroBoleeDbContexts.CompanyTypeLookupEntities.Where(m => (search == null) || (m.Company_type.ToLower().Contains(search.ToLower()))).ToList();
            }
            catch (Exception) { throw new Exception(); }
        }

        public CompanyTypeLookupEntity GetCompanyTypeDetail(int id)
        {
            try 
            { 
            return meroBoleeDbContexts.CompanyTypeLookupEntities.Where(m => m.Company_Type_Id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public CompanyTypeLookupEntity UpdateCompanyType(int id, CompanyTypeLookupEntity companyTypeEntity)
        {
            try
            {
                CompanyTypeLookupEntity companyType = GetCompanyTypeDetail(id);
                if (companyType != null)
                {
                    companyType.Company_type = companyTypeEntity.Company_type;
                    companyType.Date_modified = companyTypeEntity.Date_modified;
                 //   companyType.Modified_time_stamp = companyType.Modified_time_stamp;
                    unitOfWork.SaveChange();
                }
                return companyType;
            }
            catch (Exception) { throw new Exception(); }
        }
    }
}
