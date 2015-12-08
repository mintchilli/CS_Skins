namespace CS_SKINS_ASP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Crates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prix = c.Single(nullable: false),
                        ImageNom = c.String(),
                        ImageType = c.String(),
                        ImageTaille = c.Int(nullable: false),
                        ImageData = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Skins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CrateId = c.Int(nullable: false),
                        Prix = c.Single(nullable: false),
                        Probabilité = c.Single(nullable: false),
                        Rang = c.String(),
                        ImageNom = c.String(),
                        ImageType = c.String(),
                        ImageTaille = c.Int(nullable: false),
                        ImageData = c.Binary(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Crates", t => t.CrateId, cascadeDelete: true)
                .Index(t => t.CrateId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SujetId = c.Int(nullable: false),
                        Message = c.String(),
                        DatePublication = c.DateTime(nullable: false),
                        Auteur = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sujets", t => t.SujetId, cascadeDelete: true)
                .Index(t => t.SujetId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Sujets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titre = c.String(),
                        Description = c.String(),
                        Auteur = c.String(),
                        Dernier = c.String(),
                        NombrePosts = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserInfoSups",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        DateInscription = c.DateTime(nullable: false),
                        Prenom = c.String(),
                        Nom = c.String(),
                        ImageNom = c.String(),
                        ImageType = c.String(),
                        ImageTaille = c.Int(nullable: false),
                        ImageData = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AspNetUserId = c.String(maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUserInfoSups", t => t.AspNetUserId)
                .Index(t => t.AspNetUserId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "AspNetUserId", "dbo.AspNetUserInfoSups");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "SujetId", "dbo.Sujets");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Skins", "CrateId", "dbo.Crates");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "AspNetUserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Posts", new[] { "SujetId" });
            DropIndex("dbo.Skins", new[] { "CrateId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserInfoSups");
            DropTable("dbo.Sujets");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Posts");
            DropTable("dbo.Skins");
            DropTable("dbo.Crates");
        }
    }
}
