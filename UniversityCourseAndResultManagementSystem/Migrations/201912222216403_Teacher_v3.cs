namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teacher_v3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "RemainingCredit", c => c.Double(nullable: false));
            DropColumn("dbo.Courses", "RemainingCredit");
            DropColumn("dbo.CourseAssignToTeachers", "RemainingCredit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CourseAssignToTeachers", "RemainingCredit", c => c.Double());
            AddColumn("dbo.Courses", "RemainingCredit", c => c.Double(nullable: false));
            DropColumn("dbo.Teachers", "RemainingCredit");
        }
    }
}
