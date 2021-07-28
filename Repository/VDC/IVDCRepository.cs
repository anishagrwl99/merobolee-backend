using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.VDC
{  
    public interface IVDCRepository: IRepositoryBase<VDCEntity>
    {
        VDCEntity AddVDC(VDCEntity vdcEntity);
        IEnumerable<VDCEntity> GetVDC(string search);
        VDCEntity GetVDCDetail(int id);
        VDCEntity UpdateVDC(int id, VDCEntity vdcEntity);
        void DeleteVDC(int id);
        IEnumerable<VDCEntity> CascadeVDC(int id);
    }
}
