using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Project.QLBenhVien.EntityFramework;

namespace Project.QLBenhVien.Migrator
{
    [DependsOn(typeof(QLBenhVienDataModule))]
    public class QLBenhVienMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<QLBenhVienDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}