namespace CS_SKINS_ASP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajoutTableSkins : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Skins", "Crate_ID", "dbo.Crates");
            DropIndex("dbo.Skins", new[] { "Crate_ID" });
            RenameColumn(table: "dbo.Skins", name: "Crate_ID", newName: "CrateId");
            AddColumn("dbo.Skins", "Rang", c => c.String());
            AlterColumn("dbo.Skins", "CrateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Skins", "CrateId");
            AddForeignKey("dbo.Skins", "CrateId", "dbo.Crates", "ID", cascadeDelete: true);
            DropColumn("dbo.Skins", "Chance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skins", "Chance", c => c.Single(nullable: false));
            DropForeignKey("dbo.Skins", "CrateId", "dbo.Crates");
            DropIndex("dbo.Skins", new[] { "CrateId" });
            AlterColumn("dbo.Skins", "CrateId", c => c.Int());
            DropColumn("dbo.Skins", "Rang");
            RenameColumn(table: "dbo.Skins", name: "CrateId", newName: "Crate_ID");
            CreateIndex("dbo.Skins", "Crate_ID");
            AddForeignKey("dbo.Skins", "Crate_ID", "dbo.Crates", "ID");
        }
    }
}
