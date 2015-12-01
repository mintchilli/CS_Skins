namespace CS_SKINS_ASP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cleandeladb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ForumViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titre = c.String(),
                        Description = c.String(),
                        Auteur = c.String(),
                        Dernier = c.String(),
                        NbrPublications = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ForumViewModels");
        }
    }
}
