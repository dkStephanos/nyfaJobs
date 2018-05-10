using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NYFAJobs.Models
{
    public class Job
    {
        public int JobID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string PositionType { get; set; }

        [Range(0, 1000000)]
        public double Salary { get; set; }

        public int CompanyID { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
        public virtual Company Companies { get; set; }
        public virtual ICollection<Interviewer> Interviewers { get; set; }
    }
}