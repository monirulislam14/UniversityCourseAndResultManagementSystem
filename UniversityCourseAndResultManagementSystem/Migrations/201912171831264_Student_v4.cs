namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Student_v4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Date", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Date", c => c.DateTime(nullable: false));
        }
    }
}
