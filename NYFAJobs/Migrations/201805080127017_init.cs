namespace NYFAJobs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Application",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        JobID = c.Int(nullable: false),
                        CandidateID = c.Int(nullable: false),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidate", t => t.CandidateID, cascadeDelete: true)
                .ForeignKey("dbo.Job", t => t.JobID, cascadeDelete: true)
                .Index(t => t.JobID)
                .Index(t => t.CandidateID);
            
            CreateTable(
                "dbo.Candidate",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(maxLength: 50),
                        FirstName = c.String(maxLength: 50),
                        Degree = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Job",
                c => new
                    {
                        JobID = c.Int(nullable: false),
                        Title = c.String(),
                        PositionType = c.String(),
                        Salary = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.JobID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Application", "JobID", "dbo.Job");
            DropForeignKey("dbo.Application", "CandidateID", "dbo.Candidate");
            DropIndex("dbo.Application", new[] { "CandidateID" });
            DropIndex("dbo.Application", new[] { "JobID" });
            DropTable("dbo.Job");
            DropTable("dbo.Candidate");
            DropTable("dbo.Application");
        }
    }
}
