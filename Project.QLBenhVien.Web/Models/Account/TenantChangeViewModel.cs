using Abp.AutoMapper;
using Project.QLBenhVien.Sessions.Dto;

namespace Project.QLBenhVien.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}