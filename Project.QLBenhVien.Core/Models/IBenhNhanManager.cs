using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.QLBenhVien.Models
{
   public interface IBenhNhanManager : IDomainService
    {
        IEnumerable<BenhNhan> GetAllList();
        BenhNhan GetBenhNhanByID(long id);
        Task<BenhNhan> Create(BenhNhan entity);
        void Update(BenhNhan entity);
        void Delete(long id);
    }
}
