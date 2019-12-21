namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseAssignToTeacher_v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseAssignToTeachers",
                c => new
                {
                    CourseAssignId = c.Int(nullable: false, identity: true),
                    DepartmentId = c.Int(),
                    Status = c.String(maxLength: 50, unicode: false),
                    TeacherId = c.Int(nullable: false),
                    CourseId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.CourseAssignId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: false)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: false)
                .Index(t => t.DepartmentId)
                .Index(t => t.TeacherId)
                .Index(t => t.CourseId);

        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CourseAssigns",
                c => new
                    {
                        CourseAssignId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(),
                        Status = c.String(maxLength: 50, unicode: false),
                        TeacherId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseAssignId);
            
            DropForeignKey("dbo.CourseAssignToTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.CourseAssignToTeachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.CourseAssignToTeachers", "CourseId", "dbo.Courses");
            DropIndex("dbo.CourseAssignToTeachers", new[] { "CourseId" });
            DropIndex("dbo.CourseAssignToTeachers", new[] { "TeacherId" });
            DropIndex("dbo.CourseAssignToTeachers", new[] { "DepartmentId" });
            DropTable("dbo.CourseAssignToTeachers");
        }
    }
}
