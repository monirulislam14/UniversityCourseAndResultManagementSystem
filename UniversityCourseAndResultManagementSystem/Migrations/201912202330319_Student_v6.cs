﻿namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Student_v6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "StudentName", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Students", "StudentEmail", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Students", "StudentContactNo", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Students", "Date", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Students", "StudentRegNo", c => c.String(maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "StudentRegNo", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Students", "Date", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.Students", "StudentContactNo", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.Students", "StudentEmail", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "StudentName", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
    }
}
