namespace CS_SKINS_ASP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reset : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Sujets", "Test");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sujets", "Test", c => c.Int(nullable: false));
        }
    }
}
