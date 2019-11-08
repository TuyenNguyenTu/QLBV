using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.QLBenhVien.Models
{
    [Table("tbl_BenhNhan")]
    public class BenhNhan : FullAuditedEntity<long>
    {
        public string Ho { set; get; }
        public string Ten { set; get; }
        public string CMND { set; get; }
        public string GioiTinh { set; get; }
        public string DiaChi { set; get; }
        public string SoDienThoai { set; get; }
        public DateTime NgaySinh { set; get; }
    }
}
