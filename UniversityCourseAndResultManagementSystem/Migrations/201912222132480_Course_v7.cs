namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Course_v7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "RemainingCredit", c => c.Double(nullable: false));
            DropColumn("dbo.Teachers", "RemainingCredit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "RemainingCredit", c => c.Double(nullable: false));
            DropColumn("dbo.Courses", "RemainingCredit");
        }
    }
}
