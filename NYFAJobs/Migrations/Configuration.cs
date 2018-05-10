namespace NYFAJobs.Migrations
{
    using NYFAJobs.Models;
    using NYFAJobs.DAL;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BoardContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BoardContext context)
        {
            var candidates = new List<Candidate>
            {
            new Candidate{FirstName="Carson",LastName="Alexander",Degree="BS"},
            new Candidate{FirstName="Meredith",LastName="Alonso",Degree="BA"},
            new Candidate{FirstName="Arturo",LastName="Anand",Degree="BS"},
            new Candidate{FirstName="Gytis",LastName="Barzdukas",Degree="MFA"},
            new Candidate{FirstName="Yan",LastName="Li",Degree="MPA"},
            new Candidate{FirstName="Peggy",LastName="Justice",Degree="BA"},
            new Candidate{FirstName="Laura",LastName="Norman",Degree="BS"},
            new Candidate{FirstName="Nino",LastName="Olivetto",Degree="MFA"}
            };

            candidates.ForEach(s => context.Candidates.Add(s));
            context.SaveChanges();

            var interviewers = new List<Interviewer>
            {
                new Interviewer { FirstMidName = "Kim",     LastName = "Abercrombie",
                    HireDate = DateTime.Parse("1995-03-11") },
                new Interviewer { FirstMidName = "Fadi",    LastName = "Fakhouri",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Interviewer { FirstMidName = "Roger",   LastName = "Harui",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Interviewer { FirstMidName = "Candace", LastName = "Kapoor",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Interviewer { FirstMidName = "Roger",   LastName = "Zheng",
                    HireDate = DateTime.Parse("2004-02-12") }
            };
            interviewers.ForEach(s => context.Interviewers.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var companies = new List<Company>
            {
                new Company { Name = "Art Gallaries Inc",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InterviewerID  = interviewers.Single( i => i.LastName == "Abercrombie").ID },
                new Company { Name = "Pure Paints", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InterviewerID  = interviewers.Single( i => i.LastName == "Fakhouri").ID },
                new Company { Name = "Creative America", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InterviewerID  = interviewers.Single( i => i.LastName == "Harui").ID },
                new Company { Name = "NYFA",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InterviewerID  = interviewers.Single( i => i.LastName == "Kapoor").ID }
            };

            companies.ForEach(s => context.Companies.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();


            var jobs = new List<Job>
            {
            new Job{JobID=1050,Title="Receptionist",PositionType="Full Time",Salary=40000.0,
            CompanyID = companies.Single( s => s.Name == "Pure Paints").CompanyID,
                  Interviewers = new List<Interviewer>()},
            new Job{JobID=4022,Title="Studio Artist",PositionType="Part Time",Salary=30000.0,
            CompanyID = companies.Single( s => s.Name == "Art Gallaries Inc").CompanyID,
                  Interviewers = new List<Interviewer>()},
            new Job{JobID=4041,Title="Graphic Designer",PositionType="Apprentice",Salary=35000.0,
            CompanyID = companies.Single( s => s.Name == "Creative America").CompanyID,
                  Interviewers = new List<Interviewer>()},
            new Job{JobID=1045,Title="Seamstress",PositionType="Intern",Salary=4000.0,
            CompanyID = companies.Single( s => s.Name == "Creative America").CompanyID,
                  Interviewers = new List<Interviewer>()},
            new Job{JobID=3141,Title="Painting Prof.",PositionType="Tenure",Salary=55000.0,
            CompanyID = companies.Single( s => s.Name == "Pure Paints").CompanyID,
                  Interviewers = new List<Interviewer>()},
            new Job{JobID=2021,Title="Administrator",PositionType="Full Time",Salary=100000.0,
            CompanyID = companies.Single( s => s.Name == "NYFA").CompanyID,
                  Interviewers = new List<Interviewer>()},
            new Job{JobID=2042,Title="Column Writer",PositionType="Freelance",Salary=48000.0,
            CompanyID = companies.Single( s => s.Name == "NYFA").CompanyID,
                  Interviewers = new List<Interviewer>()}
            };
            jobs.ForEach(s => context.Jobs.AddOrUpdate(p => p.JobID, s));
            context.SaveChanges();

            var officeAssignments = new List<OfficeAssignment>
            {
                new OfficeAssignment {
                    InterviewerID = interviewers.Single( i => i.LastName == "Fakhouri").ID,
                    Location = "Smith 17" },
                new OfficeAssignment {
                    InterviewerID = interviewers.Single( i => i.LastName == "Harui").ID,
                    Location = "Gowan 27" },
                new OfficeAssignment {
                    InterviewerID = interviewers.Single( i => i.LastName == "Kapoor").ID,
                    Location = "Thompson 304" },
            };
            officeAssignments.ForEach(s => context.OfficeAssignments.AddOrUpdate(p => p.InterviewerID, s));
            context.SaveChanges();

            AddOrUpdateInterviewer(context, "Receptionist", "Kapoor");
            AddOrUpdateInterviewer(context, "Receptionist", "Harui");
            AddOrUpdateInterviewer(context, "Studio Artist", "Zheng");
            AddOrUpdateInterviewer(context, "Graphic Designer", "Zheng");

            AddOrUpdateInterviewer(context, "Seamstress", "Fakhouri");
            AddOrUpdateInterviewer(context, "Administrator", "Harui");
            AddOrUpdateInterviewer(context, "Painting Prof.", "Abercrombie");
            AddOrUpdateInterviewer(context, "Column Writer", "Abercrombie");

            context.SaveChanges();

            var applications = new List<Application>
            {
                new Application {
                    CandidateID = candidates.Single(s => s.LastName == "Alexander").ID,
                    JobID = jobs.Single(c => c.Title == "Receptionist" ).JobID,
                    Status = Status.ACCEPTED
                },
                 new Application {
                    CandidateID = candidates.Single(s => s.LastName == "Alexander").ID,
                    JobID = jobs.Single(c => c.Title == "Studio Artist" ).JobID,
                    Status = Status.REJECTED
                 },
                 new Application {
                    CandidateID = candidates.Single(s => s.LastName == "Alexander").ID,
                    JobID = jobs.Single(c => c.Title == "Graphic Designer" ).JobID,
                    Status = Status.PENDING
                 },
                 new Application {
                     CandidateID = candidates.Single(s => s.LastName == "Alonso").ID,
                    JobID = jobs.Single(c => c.Title == "Seamstress" ).JobID,
                    Status = Status.PENDING
                 },
                 new Application {
                     CandidateID = candidates.Single(s => s.LastName == "Alonso").ID,
                    JobID = jobs.Single(c => c.Title == "Administrator" ).JobID,
                    Status = Status.REJECTED
                 },
                 new Application {
                    CandidateID = candidates.Single(s => s.LastName == "Alonso").ID,
                    JobID = jobs.Single(c => c.Title == "Column Writer" ).JobID,
                    Status = Status.PENDING
                 },
                 new Application {
                    CandidateID = candidates.Single(s => s.LastName == "Anand").ID,
                    JobID = jobs.Single(c => c.Title == "Painting Prof." ).JobID,
                    Status = Status.PENDING
                 },
                 new Application {
                    CandidateID = candidates.Single(s => s.LastName == "Anand").ID,
                    JobID = jobs.Single(c => c.Title == "Graphic Designer").JobID,
                    Status = Status.REJECTED
                 },
                new Application {
                    CandidateID = candidates.Single(s => s.LastName == "Barzdukas").ID,
                    JobID = jobs.Single(c => c.Title == "Painting Prof.").JobID,
                    Status = Status.REJECTED
                 },
                 new Application {
                    CandidateID = candidates.Single(s => s.LastName == "Li").ID,
                    JobID = jobs.Single(c => c.Title == "Receptionist").JobID,
                    Status = Status.ACCEPTED
                 },
                 new Application {
                    CandidateID = candidates.Single(s => s.LastName == "Justice").ID,
                    JobID = jobs.Single(c => c.Title == "Seamstress").JobID,
                    Status = Status.ACCEPTED
                 }
            };

            foreach (Application e in applications)
            {
                var applicationInDatabase = context.Applications.Where(
                    s =>
                         s.Candidate.ID == e.CandidateID &&
                         s.Job.JobID == e.JobID).SingleOrDefault();
                if (applicationInDatabase == null)
                {
                    context.Applications.Add(e);
                }
            }
            context.SaveChanges();
        }

        void AddOrUpdateInterviewer(BoardContext context, string jobTitle, string interviewerName)
        {
            var jb = context.Jobs.SingleOrDefault(c => c.Title == jobTitle);
            var intv = jb.Interviewers.SingleOrDefault(i => i.LastName == interviewerName);
            if (intv == null)
                jb.Interviewers.Add(context.Interviewers.Single(i => i.LastName == interviewerName));
        }
    }
}