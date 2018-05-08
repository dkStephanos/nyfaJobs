using System;
using System.ComponentModel.DataAnnotations;

namespace NYFAJobs.ViewModels
{
    public class ApplicationGroup
    {
        [DataType(DataType.Text)]
        public string JobTitle { get; set; }

        public int ApplicationCount { get; set; }
    }
}