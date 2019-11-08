using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using Project.QLBenhVien.Authorization.Roles;
using Project.QLBenhVien.Authorization.Users;
using Project.QLBenhVien.Models;
using Project.QLBenhVien.MultiTenancy;

namespace Project.QLBenhVien.EntityFramework
{
    public class QLBenhVienDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public virtual IDbSet<BenhNhan> BenhNhans { set; get; }
        public QLBenhVienDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in QLBenhVienDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of QLBenhVienDbContext since ABP automatically handles it.
         */
        public QLBenhVienDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public QLBenhVienDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public QLBenhVienDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
