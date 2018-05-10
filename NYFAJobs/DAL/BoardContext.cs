using NYFAJobs.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NYFAJobs.DAL
{
    public class BoardContext : DbContext
    {

        public BoardContext() : base("BoardContext")
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Interviewer> Interviewers { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Job>()
                .HasMany(c => c.Interviewers).WithMany(i => i.Jobs)
                .Map(t => t.MapLeftKey("JobID")
                    .MapRightKey("InterviewerID")
                    .ToTable("JobInterviewer"));
        }
    }
}