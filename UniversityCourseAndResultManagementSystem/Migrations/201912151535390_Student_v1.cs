namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Student_v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false, maxLength: 8000, unicode: false),
                        StudentEmail = c.String(nullable: false),
                        StudentContactNo = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Date = c.DateTime(nullable: false),
                        StudentAddress = c.String(nullable: false, unicode: false, storeType: "text"),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropTable("dbo.Students");
        }
    }
}
