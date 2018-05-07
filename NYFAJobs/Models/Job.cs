using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NYFAJobs.Models
{
    public class Job
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JobID { get; set; }
        public string Title { get; set; }
        public string PoisitionType { get; set; }
        public double Salary { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
    }
}