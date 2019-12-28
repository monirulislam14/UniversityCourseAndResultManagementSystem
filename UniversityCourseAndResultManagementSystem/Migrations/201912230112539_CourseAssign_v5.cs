namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseAssign_v5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Credits", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Credits", new[] { "TeacherId" });
            DropTable("dbo.Credits");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Credits",
                c => new
                    {
                        CreditId = c.Int(nullable: false, identity: true),
                        RemainingCredit = c.Double(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CreditId);
            
            CreateIndex("dbo.Credits", "TeacherId");
            AddForeignKey("dbo.Credits", "TeacherId", "dbo.Teachers", "TeacherId", cascadeDelete: true);
        }
    }
}
