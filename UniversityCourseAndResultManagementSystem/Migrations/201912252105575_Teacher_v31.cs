namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teacher_v31 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CourseAssignToTeachers", "RemainingCredit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CourseAssignToTeachers", "RemainingCredit", c => c.Double(nullable: false));
        }
    }
}
