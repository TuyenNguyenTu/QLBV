using Abp.Application.Services;
using Project.QLBenhVien.BenhNhans.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Project.QLBenhVien.BenhNhans
{
    public interface IBenhNhanAppService : IApplicationService
    {
        [HttpGet]
        IEnumerable<GetBenhNhanOutput> ListAll();
        [HttpPost]
        Task Create(CreateBenhNhanInput input);
        [HttpPut]
        void Update(UpdateBenhNhanInput input);
        [HttpDelete]
        void Delete(DeleteBenhNhanInput input);
        [HttpGet]
        GetBenhNhanOutput GetBenhNhanById(GetBenhNhanInput input);
    }
}
