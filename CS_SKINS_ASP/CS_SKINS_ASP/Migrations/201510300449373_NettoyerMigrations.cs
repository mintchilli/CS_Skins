namespace CS_SKINS_ASP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NettoyerMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetUserInfoSups",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        DateInscription = c.DateTime(nullable: false),
                        IdentifiantCSSKINS = c.String(),
                        Prenom = c.String(),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.AspNetUsers", "details_ID", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "details_ID");
            AddForeignKey("dbo.AspNetUsers", "details_ID", "dbo.AspNetUserInfoSups", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "details_ID", "dbo.AspNetUserInfoSups");
            DropIndex("dbo.AspNetUsers", new[] { "details_ID" });
            DropColumn("dbo.AspNetUsers", "details_ID");
            DropTable("dbo.AspNetUserInfoSups");
        }
    }
}
