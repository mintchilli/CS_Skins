namespace CS_SKINS_ASP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suppresiondelignesdanssujet : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Sujets", "DatePublication");
            DropColumn("dbo.Sujets", "DateDernierPost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sujets", "DateDernierPost", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sujets", "DatePublication", c => c.DateTime(nullable: false));
        }
    }
}
