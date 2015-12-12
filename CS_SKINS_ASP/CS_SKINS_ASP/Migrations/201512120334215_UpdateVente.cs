namespace CS_SKINS_ASP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateVente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ventes", "Vendu", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ventes", "Vendu");
        }
    }
}
