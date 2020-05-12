namespace SporApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserPrograms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProgramId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ScheduleTime = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        Description = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProgramId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(nullable: false),
                        Phone = c.String(),
                        Password = c.String(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        Weight = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPrograms", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserPrograms", "ProgramId", "dbo.Programs");
            DropIndex("dbo.UserPrograms", new[] { "UserId" });
            DropIndex("dbo.UserPrograms", new[] { "ProgramId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserPrograms");
            DropTable("dbo.Programs");
        }
    }
}
