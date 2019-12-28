namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Course_4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CourseDescription", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "CourseDescription", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
    }
}
