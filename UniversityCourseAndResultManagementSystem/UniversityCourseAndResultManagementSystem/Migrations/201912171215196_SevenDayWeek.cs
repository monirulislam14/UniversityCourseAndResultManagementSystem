namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SevenDayWeek : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SevenDayWeeks",
                c => new
                    {
                        DayId = c.Int(nullable: false, identity: true),
                        DayCode = c.String(),
                        DayName = c.String(),
                    })
                .PrimaryKey(t => t.DayId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SevenDayWeeks");
        }
    }
}
