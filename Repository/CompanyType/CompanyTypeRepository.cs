using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.CompanyType
{
    public class CompanyTypeRepository : RepositoryBase<CompanyTypeEntity>, ICompanyTypeRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public CompanyTypeRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public CompanyTypeEntity AddCompanyType(CompanyTypeEntity companyTypeEntity)
        {
            try
            { 
            meroBoleeDbContexts.CompanyTypeEntities.Add(companyTypeEntity);
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
            meroBoleeDbContexts.CompanyTypeEntities.Remove(GetCompanyTypeDetail(id));
            unitOfWork.SaveChange();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public IEnumerable<CompanyTypeEntity> GetCompanyType(string search)
        {
            try
            {
                return meroBoleeDbContexts.CompanyTypeEntities.Where(m => (search == null) || (m.Company_type.ToLower().Contains(search.ToLower()))).ToList();
            }
            catch (Exception) { throw new Exception(); }
        }

        public CompanyTypeEntity GetCompanyTypeDetail(int id)
        {
            try 
            { 
            return meroBoleeDbContexts.CompanyTypeEntities.Where(m => m.Company_Type_Id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public CompanyTypeEntity UpdateCompanyType(int id, CompanyTypeEntity companyTypeEntity)
        {
            try
            {
                CompanyTypeEntity companyType = GetCompanyTypeDetail(id);
                if (companyType != null)
                {
                    companyType.Company_type = companyTypeEntity.Company_type;
                    companyType.Date_modified = companyTypeEntity.Date_modified;
                    companyType.Modified_time_stamp = companyType.Modified_time_stamp;
                    unitOfWork.SaveChange();
                }
                return companyType;
            }
            catch (Exception) { throw new Exception(); }
        }
    }
}
