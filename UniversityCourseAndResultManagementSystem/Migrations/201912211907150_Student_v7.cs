namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Student_v7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "StudentEmail", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "StudentEmail", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
    }
}
