using MeroBolee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.VDC
{
    public interface IVDCService
    {
        GetVDCDto AddVDC(AddVDCDto VDCDto);
        IEnumerable<GetVDCDto> GetVDC(string search);
        GetVDCDto GetVDCDetail(int id);
        GetVDCDto UpdateVDC(int id, AddVDCDto VDCDto);
        void DeleteVDC(int id);
        IEnumerable<GetVDCDto> CascadeVDC(int id);
    }
}
