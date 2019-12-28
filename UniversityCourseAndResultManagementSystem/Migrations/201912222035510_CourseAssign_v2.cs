namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseAssign_v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseAssignToTeachers", "RemainingCredit", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseAssignToTeachers", "RemainingCredit");
        }
    }
}
