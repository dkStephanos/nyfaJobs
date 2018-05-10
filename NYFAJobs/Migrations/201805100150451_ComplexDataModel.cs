namespace NYFAJobs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplexDataModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Application", "JobID", "dbo.Job");
            DropPrimaryKey("dbo.Job");
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Industry = c.String(maxLength: 50),
                        Budget = c.Decimal(nullable: false, storeType: "money"),
                        StartDate = c.DateTime(nullable: false),
                        InterviewerID = c.Int(),
                    })
                .PrimaryKey(t => t.CompanyID)
                .ForeignKey("dbo.Interviewer", t => t.InterviewerID)
                .Index(t => t.InterviewerID);
            
            CreateTable(
                "dbo.Interviewer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        HireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OfficeAssignment",
                c => new
                    {
                        InterviewerID = c.Int(nullable: false),
                        Location = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.InterviewerID)
                .ForeignKey("dbo.Interviewer", t => t.InterviewerID)
                .Index(t => t.InterviewerID);
            
            CreateTable(
                "dbo.JobInterviewer",
                c => new
                    {
                        JobID = c.Int(nullable: false),
                        InterviewerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JobID, t.InterviewerID })
                .ForeignKey("dbo.Job", t => t.JobID, cascadeDelete: true)
                .ForeignKey("dbo.Interviewer", t => t.InterviewerID, cascadeDelete: true)
                .Index(t => t.JobID)
                .Index(t => t.InterviewerID);

            // Create  a company for job to point to.
            Sql("INSERT INTO dbo.Company (Name, Budget, StartDate) VALUES ('Temp', 0.00, GETDATE())");
            //  default value for FK points to company created above.
            AddColumn("dbo.Job", "CompanyID", c => c.Int(nullable: false, defaultValue: 1));
            AlterColumn("dbo.Application", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.Candidate", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Job", "JobID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Job", "Title", c => c.String(maxLength: 50));
            AlterColumn("dbo.Job", "PositionType", c => c.String(maxLength: 50));
            AddPrimaryKey("dbo.Job", "JobID");
            CreateIndex("dbo.Job", "CompanyID");
            AddForeignKey("dbo.Job", "CompanyID", "dbo.Company", "CompanyID", cascadeDelete: true);
            AddForeignKey("dbo.Application", "JobID", "dbo.Job", "JobID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Application", "JobID", "dbo.Job");
            DropForeignKey("dbo.JobInterviewer", "InterviewerID", "dbo.Interviewer");
            DropForeignKey("dbo.JobInterviewer", "JobID", "dbo.Job");
            DropForeignKey("dbo.Job", "CompanyID", "dbo.Company");
            DropForeignKey("dbo.Company", "InterviewerID", "dbo.Interviewer");
            DropForeignKey("dbo.OfficeAssignment", "InterviewerID", "dbo.Interviewer");
            DropIndex("dbo.JobInterviewer", new[] { "InterviewerID" });
            DropIndex("dbo.JobInterviewer", new[] { "JobID" });
            DropIndex("dbo.OfficeAssignment", new[] { "InterviewerID" });
            DropIndex("dbo.Company", new[] { "InterviewerID" });
            DropIndex("dbo.Job", new[] { "CompanyID" });
            DropPrimaryKey("dbo.Job");
            AlterColumn("dbo.Job", "PositionType", c => c.String());
            AlterColumn("dbo.Job", "Title", c => c.String());
            AlterColumn("dbo.Job", "JobID", c => c.Int(nullable: false));
            AlterColumn("dbo.Candidate", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Application", "Status", c => c.Int());
            DropColumn("dbo.Job", "CompanyID");
            DropTable("dbo.JobInterviewer");
            DropTable("dbo.OfficeAssignment");
            DropTable("dbo.Interviewer");
            DropTable("dbo.Company");
            AddPrimaryKey("dbo.Job", "JobID");
            AddForeignKey("dbo.Application", "JobID", "dbo.Job", "JobID", cascadeDelete: true);
        }
    }
}
