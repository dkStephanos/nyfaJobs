using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using NYFAJobs.Models;

namespace NYFAJobs.DAL
{
    public class BoardInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BoardContext>
    {
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
            var jobs = new List<Job>
            {
            new Job{JobID=1050,Title="Receptionist",PoisitionType="Full Time",Salary=40000.0},
            new Job{JobID=4022,Title="Studio Artist",PoisitionType="Part Time",Salary=30000.0,},
            new Job{JobID=4041,Title="Graphic Designer",PoisitionType="Apprentice",Salary=35000.0,},
            new Job{JobID=1045,Title="Seamstress",PoisitionType="Intern",Salary=4000.0,},
            new Job{JobID=3141,Title="Painting Prof.",PoisitionType="Tenure",Salary=55000.0,},
            new Job{JobID=2021,Title="Administrator",PoisitionType="Full Time",Salary=100000.0,},
            new Job{JobID=2042,Title="Column Writer",PoisitionType="Freelance",Salary=48000.0,}
            };
            jobs.ForEach(s => context.Jobs.Add(s));
            context.SaveChanges();
            var applications = new List<Application>
            {
            new Application{CandidateID=1,JobID=1050,Status=Status.PENDING},
            new Application{CandidateID=1,JobID=4022,Status=Status.ACCEPTED},
            new Application{CandidateID=1,JobID=4041,Status=Status.PENDING},
            new Application{CandidateID=2,JobID=1045,Status=Status.REJECTED},
            new Application{CandidateID=2,JobID=3141,Status=Status.REJECTED},
            new Application{CandidateID=2,JobID=2021,Status=Status.PENDING},
            new Application{CandidateID=3,JobID=1050},
            new Application{CandidateID=4,JobID=1050,},
            new Application{CandidateID=4,JobID=4022,Status=Status.PENDING},
            new Application{CandidateID=5,JobID=4041,Status=Status.PENDING},
            new Application{CandidateID=6,JobID=1045},
            new Application{CandidateID=7,JobID=3141,Status=Status.REJECTED},
            };
            applications.ForEach(s => context.Applications.Add(s));
            context.SaveChanges();
        }
    }
}