namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassRoomAlloction_v2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ClassRoomAllocations", name: "SevenDayWeek_DayId", newName: "DayId");
            RenameIndex(table: "dbo.ClassRoomAllocations", name: "IX_SevenDayWeek_DayId", newName: "IX_DayId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ClassRoomAllocations", name: "IX_DayId", newName: "IX_SevenDayWeek_DayId");
            RenameColumn(table: "dbo.ClassRoomAllocations", name: "DayId", newName: "SevenDayWeek_DayId");
        }
    }
}
