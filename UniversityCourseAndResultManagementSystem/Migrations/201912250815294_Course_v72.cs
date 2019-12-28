﻿namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Course_v72 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Courses", new[] { "TeacherId" });
            DropColumn("dbo.Courses", "TeacherId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "TeacherId", c => c.Int());
            CreateIndex("dbo.Courses", "TeacherId");
            AddForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers", "TeacherId");
        }
    }
}