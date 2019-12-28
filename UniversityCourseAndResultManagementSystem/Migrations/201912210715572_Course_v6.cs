namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Course_v6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CourseCode", c => c.String(nullable: false, maxLength: 15, unicode: false));
            AlterColumn("dbo.Courses", "CourseDescription", c => c.String(nullable: false, maxLength: 150, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "CourseDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "CourseCode", c => c.String(nullable: false, maxLength: 15));
        }
    }
}
