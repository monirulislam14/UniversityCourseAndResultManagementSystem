namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Course_v5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CourseCode", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Courses", "CoursName", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.Courses", "CourseDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "CourseDescription", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Courses", "CoursName", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Courses", "CourseCode", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
    }
}
