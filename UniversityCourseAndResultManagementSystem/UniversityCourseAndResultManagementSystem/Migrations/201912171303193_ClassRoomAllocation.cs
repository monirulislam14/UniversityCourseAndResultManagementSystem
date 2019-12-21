namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassRoomAllocation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassRoomAllocations",
                c => new
                    {
                        ClassRoomAllocationId = c.Int(nullable: false, identity: true),
                        TimeFrom = c.String(nullable: false, maxLength: 50, unicode: false),
                        TimeTo = c.String(nullable: false, maxLength: 50, unicode: false),
                        Status = c.String(maxLength: 50, unicode: false),
                        DepartmentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        SevenDayWeek_DayId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassRoomAllocationId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: false)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: false)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: false)
                .ForeignKey("dbo.SevenDayWeeks", t => t.SevenDayWeek_DayId, cascadeDelete: false)
                .Index(t => t.DepartmentId)
                .Index(t => t.CourseId)
                .Index(t => t.RoomId)
                .Index(t => t.SevenDayWeek_DayId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassRoomAllocations", "SevenDayWeek_DayId", "dbo.SevenDayWeeks");
            DropForeignKey("dbo.ClassRoomAllocations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.ClassRoomAllocations", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.ClassRoomAllocations", "CourseId", "dbo.Courses");
            DropIndex("dbo.ClassRoomAllocations", new[] { "SevenDayWeek_DayId" });
            DropIndex("dbo.ClassRoomAllocations", new[] { "RoomId" });
            DropIndex("dbo.ClassRoomAllocations", new[] { "CourseId" });
            DropIndex("dbo.ClassRoomAllocations", new[] { "DepartmentId" });
            DropTable("dbo.ClassRoomAllocations");
        }
    }
}
