namespace CS_SKINS_ASP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageDansAspNetUserInfoSup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUserInfoSups", "ImageNom", c => c.String());
            AddColumn("dbo.AspNetUserInfoSups", "ImageType", c => c.String());
            AddColumn("dbo.AspNetUserInfoSups", "ImageTaille", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUserInfoSups", "ImageData", c => c.Binary());
            DropColumn("dbo.AspNetUserInfoSups", "IdentifiantCSSKINS");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUserInfoSups", "IdentifiantCSSKINS", c => c.String());
            DropColumn("dbo.AspNetUserInfoSups", "ImageData");
            DropColumn("dbo.AspNetUserInfoSups", "ImageTaille");
            DropColumn("dbo.AspNetUserInfoSups", "ImageType");
            DropColumn("dbo.AspNetUserInfoSups", "ImageNom");
        }
    }
}
