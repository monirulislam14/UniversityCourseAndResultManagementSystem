﻿namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Course_v3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "TeacherId", c => c.Int());
            CreateIndex("dbo.Courses", "TeacherId");
            AddForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers", "TeacherId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Courses", new[] { "TeacherId" });
            DropColumn("dbo.Courses", "TeacherId");
        }
    }
}
