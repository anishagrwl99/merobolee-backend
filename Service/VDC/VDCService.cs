using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Repository.VDC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.VDC
{
    public class VDCService : VDCMapper,IVDCService
    {
        private readonly IVDCRepository vdcRepository;
        public VDCService(IVDCRepository vdcRepository)
        {
            this.vdcRepository = vdcRepository;
        }

        public GetVDCDto AddVDC(AddVDCDto vdcDto)
        {
            return VDCEntityToDto(vdcRepository.AddVDC(VDCDtoEntity(vdcDto)));
        }

        public IEnumerable<GetVDCDto> CascadeVDC(int id)
        {
            return VDCEntityListToDto(vdcRepository.CascadeVDC(id));
        }

        public void DeleteVDC(int id)
        {
            vdcRepository.DeleteVDC(id);
        }

        public GetVDCDto GetVDCDetail(int id)
        {
            return VDCEntityToDto(vdcRepository.GetVDCDetail(id));
        }

        public IEnumerable<GetVDCDto> GetVDC(string search)
        {
            return VDCEntityListToDto(vdcRepository.GetVDC(search));
        }

        public GetVDCDto UpdateVDC(int id, AddVDCDto vdcDto)
        {
            return VDCEntityToDto(vdcRepository.UpdateVDC(id, VDCDtoEntity(vdcDto)));
        }


    }
}
