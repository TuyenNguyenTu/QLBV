using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using Project.QLBenhVien.EntityFramework;

namespace Project.QLBenhVien
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(QLBenhVienCoreModule))]
    public class QLBenhVienDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<QLBenhVienDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
