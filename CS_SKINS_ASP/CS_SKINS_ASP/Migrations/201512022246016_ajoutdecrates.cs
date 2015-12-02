namespace CS_SKINS_ASP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajoutdecrates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Crates", "Nom", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Crates", "Nom");
        }
    }
}
