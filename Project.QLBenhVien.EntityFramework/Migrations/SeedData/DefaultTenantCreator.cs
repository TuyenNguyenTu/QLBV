using System.Linq;
using Project.QLBenhVien.EntityFramework;
using Project.QLBenhVien.MultiTenancy;

namespace Project.QLBenhVien.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly QLBenhVienDbContext _context;

        public DefaultTenantCreator(QLBenhVienDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
