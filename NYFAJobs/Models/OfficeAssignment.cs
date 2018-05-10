using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NYFAJobs.Models
{
    public class OfficeAssignment
    {
        [Key]
        [ForeignKey("Interviewer")]
        public int InterviewerID { get; set; }
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }

        public virtual Interviewer Interviewer { get; set; }
    }
}