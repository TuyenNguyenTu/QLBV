using Abp.AutoMapper;
using Project.QLBenhVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.QLBenhVien.BenhNhans.DTO
{
    [AutoMapTo(typeof(BenhNhan))]
    public class GetBenhNhanInput
    {
        public long Id { set; get; }
    }
}
