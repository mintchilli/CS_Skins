namespace CS_SKINS_ASP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MergeProjets : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ForumViewModels");
        }
        
        public override void Down()
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
    }
}
