namespace CS_SKINS_ASP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TBLAspNetUserInfoSup : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "details_ID", newName: "AspNetUserId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_details_ID", newName: "IX_AspNetUserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_AspNetUserId", newName: "IX_details_ID");
            RenameColumn(table: "dbo.AspNetUsers", name: "AspNetUserId", newName: "details_ID");
        }
    }
}
