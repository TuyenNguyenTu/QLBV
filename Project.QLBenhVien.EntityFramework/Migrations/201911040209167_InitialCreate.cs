namespace Project.QLBenhVien.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_BenhNhan",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Ho = c.String(),
                        Ten = c.String(),
                        CMND = c.String(),
                        GioiTinh = c.String(),
                        DiaChi = c.String(),
                        SoDienThoai = c.String(),
                        NgaySinh = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BenhNhan_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.tbl_BenhNhan", new[] { "IsDeleted" });
            DropTable("dbo.tbl_BenhNhan",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BenhNhan_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
