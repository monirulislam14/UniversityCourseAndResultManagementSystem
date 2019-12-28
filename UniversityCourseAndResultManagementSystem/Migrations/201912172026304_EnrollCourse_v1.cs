namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnrollCourse_v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnrollInACourses",
                c => new
                    {
                        EnrollInACourseId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Status = c.String(),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.EnrollInACourseId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: false)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: false)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnrollInACourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.EnrollInACourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.EnrollInACourses", new[] { "CourseId" });
            DropIndex("dbo.EnrollInACourses", new[] { "StudentId" });
            DropTable("dbo.EnrollInACourses");
        }
    }
}
