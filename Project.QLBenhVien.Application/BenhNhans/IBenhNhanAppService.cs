using Abp.Application.Services;
using Project.QLBenhVien.BenhNhans.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.QLBenhVien.BenhNhans
{
    public interface IBenhNhanAppService : IApplicationService
    {
        IEnumerable<GetBenhNhanOutput> ListAll();
        Task Create(CreateBenhNhanInput input);
        void Update(UpdateBenhNhanInput input);
        void Delete(DeleteBenhNhanInput input);
        GetBenhNhanOutput GetBenhNhanById(GetBenhNhanInput input);
    }
}
