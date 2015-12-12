namespace CS_SKINS_ASP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Venteskins : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ventes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImageNom = c.String(),
                        ImageType = c.String(),
                        ImageTaille = c.Int(nullable: false),
                        ImageData = c.Binary(),
                        NomSkin = c.String(),
                        Prix = c.Single(nullable: false),
                        ContactInfo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ventes");
        }
    }
}
