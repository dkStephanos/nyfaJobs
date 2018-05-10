using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NYFAJobs.Models
{
    public enum Status
    {
        PENDING, ACCEPTED, REJECTED
    }

    public class Application
    {
        public int ID { get; set; }
        public int JobID { get; set; }
        public int CandidateID { get; set; }
        public Status Status { get; set; }

        public virtual Job Job { get; set; }
        public virtual Candidate Candidate { get; set; }
    }
}