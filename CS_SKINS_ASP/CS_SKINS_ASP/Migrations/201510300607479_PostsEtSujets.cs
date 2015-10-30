namespace CS_SKINS_ASP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostsEtSujets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titre = c.String(),
                        Description = c.String(),
                        DatePublication = c.DateTime(nullable: false),
                        Auteur = c.String(),
                        Dernier = c.String(),
                        NombrePosts = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sujets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titre = c.String(),
                        Description = c.String(),
                        DatePublication = c.DateTime(nullable: false),
                        DateDernierPost = c.DateTime(nullable: false),
                        Auteur = c.String(),
                        Dernier = c.String(),
                        NombrePosts = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sujets");
            DropTable("dbo.Posts");
        }
    }
}
