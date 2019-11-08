using Project.QLBenhVien.EntityFramework;
using EntityFramework.DynamicFilters;

namespace Project.QLBenhVien.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly QLBenhVienDbContext _context;

        public InitialHostDbBuilder(QLBenhVienDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
