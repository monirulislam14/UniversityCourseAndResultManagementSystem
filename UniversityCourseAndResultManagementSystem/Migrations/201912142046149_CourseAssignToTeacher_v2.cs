namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseAssignToTeacher_v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseAssignToTeachers", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.CourseAssignToTeachers", new[] { "DepartmentId" });
            AlterColumn("dbo.CourseAssignToTeachers", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.CourseAssignToTeachers", "DepartmentId");
            AddForeignKey("dbo.CourseAssignToTeachers", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseAssignToTeachers", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.CourseAssignToTeachers", new[] { "DepartmentId" });
            AlterColumn("dbo.CourseAssignToTeachers", "DepartmentId", c => c.Int());
            CreateIndex("dbo.CourseAssignToTeachers", "DepartmentId");
            AddForeignKey("dbo.CourseAssignToTeachers", "DepartmentId", "dbo.Departments", "DepartmentId");
        }
    }
}
