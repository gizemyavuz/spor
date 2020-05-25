namespace SporApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _25052020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Programs", "Calories", c => c.Int(nullable: false));
            AddColumn("dbo.Programs", "ImageUrl", c => c.String());
            AddColumn("dbo.Programs", "Link", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Programs", "Link");
            DropColumn("dbo.Programs", "ImageUrl");
            DropColumn("dbo.Programs", "Calories");
        }
    }
}
