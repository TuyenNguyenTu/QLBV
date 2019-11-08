using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.QLBenhVien.BenhNhans.DTO
{
   public class UpdateBenhNhanInput
    {
        public long Id { set; get; }
        public string Ho { set; get; }
        public string Ten { set; get; }
        public string CMND { set; get; }
        public string GioiTinh { set; get; }
        public string DiaChi { set; get; }
        public string SoDienThoai { set; get; }
        public DateTime NgaySinh { set; get; }
    }
}
