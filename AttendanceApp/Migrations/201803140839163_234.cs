namespace AttendanceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _234 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classes", "Teachers_Id", c => c.Int());
            CreateIndex("dbo.Classes", "Teachers_Id");
            AddForeignKey("dbo.Classes", "Teachers_Id", "dbo.Teachers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "Teachers_Id", "dbo.Teachers");
            DropIndex("dbo.Classes", new[] { "Teachers_Id" });
            DropColumn("dbo.Classes", "Teachers_Id");
        }
    }
}
