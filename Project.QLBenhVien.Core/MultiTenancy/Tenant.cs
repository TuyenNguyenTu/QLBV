using Abp.MultiTenancy;
using Project.QLBenhVien.Authorization.Users;

namespace Project.QLBenhVien.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}