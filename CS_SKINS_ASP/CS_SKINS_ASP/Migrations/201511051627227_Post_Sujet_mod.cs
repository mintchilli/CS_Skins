namespace CS_SKINS_ASP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Post_Sujet_mod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "SujetId", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "Message", c => c.String());
            CreateIndex("dbo.Posts", "SujetId");
            AddForeignKey("dbo.Posts", "SujetId", "dbo.Sujets", "Id", cascadeDelete: true);
            DropColumn("dbo.Posts", "Titre");
            DropColumn("dbo.Posts", "Description");
            DropColumn("dbo.Posts", "Dernier");
            DropColumn("dbo.Posts", "NombrePosts");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "NombrePosts", c => c.String());
            AddColumn("dbo.Posts", "Dernier", c => c.String());
            AddColumn("dbo.Posts", "Description", c => c.String());
            AddColumn("dbo.Posts", "Titre", c => c.String());
            DropForeignKey("dbo.Posts", "SujetId", "dbo.Sujets");
            DropIndex("dbo.Posts", new[] { "SujetId" });
            DropColumn("dbo.Posts", "Message");
            DropColumn("dbo.Posts", "SujetId");
        }
    }
}
