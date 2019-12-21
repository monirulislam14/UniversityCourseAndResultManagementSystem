namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseAndCourseAssignToTeacher : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "CourseAssignId", "dbo.CourseAssignToTeachers");
            DropForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Courses", new[] { "TeacherId" });
            DropIndex("dbo.Courses", new[] { "CourseAssignId" });
            CreateIndex("dbo.CourseAssignToTeachers", "CourseId");
            AddForeignKey("dbo.CourseAssignToTeachers", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: false);
            DropColumn("dbo.Courses", "TeacherId");
            DropColumn("dbo.Courses", "CourseAssignId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "CourseAssignId", c => c.Int());
            AddColumn("dbo.Courses", "TeacherId", c => c.Int());
            DropForeignKey("dbo.CourseAssignToTeachers", "CourseId", "dbo.Courses");
            DropIndex("dbo.CourseAssignToTeachers", new[] { "CourseId" });
            CreateIndex("dbo.Courses", "CourseAssignId");
            CreateIndex("dbo.Courses", "TeacherId");
            AddForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers", "TeacherId");
            AddForeignKey("dbo.Courses", "CourseAssignId", "dbo.CourseAssignToTeachers", "CourseAssignId");
        }
    }
}
