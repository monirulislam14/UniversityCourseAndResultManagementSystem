namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teacher_V4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "TeacherRemainingCredit", c => c.Double(nullable: false));
            DropColumn("dbo.Teachers", "RemainingCredit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "RemainingCredit", c => c.Double(nullable: false));
            DropColumn("dbo.Teachers", "TeacherRemainingCredit");
        }
    }
}
