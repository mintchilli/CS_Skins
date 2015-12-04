namespace CS_SKINS_ASP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajoutImageSkins : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skins", "ImageNom", c => c.String());
            AddColumn("dbo.Skins", "ImageType", c => c.String());
            AddColumn("dbo.Skins", "ImageTaille", c => c.Int(nullable: false));
            AddColumn("dbo.Skins", "ImageData", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skins", "ImageData");
            DropColumn("dbo.Skins", "ImageTaille");
            DropColumn("dbo.Skins", "ImageType");
            DropColumn("dbo.Skins", "ImageNom");
        }
    }
}
