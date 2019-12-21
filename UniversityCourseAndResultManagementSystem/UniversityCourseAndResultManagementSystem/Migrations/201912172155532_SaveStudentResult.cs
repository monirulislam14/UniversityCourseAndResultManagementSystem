namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaveStudentResult : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SaveStudentResults",
                c => new
                    {
                        SaveStudentResultId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        GradeId = c.Int(nullable: false),
                        Status = c.String(),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.SaveStudentResultId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: false)
                .ForeignKey("dbo.Grades", t => t.GradeId, cascadeDelete: false)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: false)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.GradeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaveStudentResults", "StudentId", "dbo.Students");
            DropForeignKey("dbo.SaveStudentResults", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.SaveStudentResults", "CourseId", "dbo.Courses");
            DropIndex("dbo.SaveStudentResults", new[] { "GradeId" });
            DropIndex("dbo.SaveStudentResults", new[] { "CourseId" });
            DropIndex("dbo.SaveStudentResults", new[] { "StudentId" });
            DropTable("dbo.SaveStudentResults");
        }
    }
}
