namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseAssign_v4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseAssignToTeachers", "RemainingCredit", c => c.Double(nullable: false));
            DropColumn("dbo.Teachers", "RemainingCredit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "RemainingCredit", c => c.Double(nullable: false));
            DropColumn("dbo.CourseAssignToTeachers", "RemainingCredit");
        }
    }
}
