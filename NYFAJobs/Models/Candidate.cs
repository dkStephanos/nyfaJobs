using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NYFAJobs.Models
{
    public class Candidate
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Degree { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
    }
}