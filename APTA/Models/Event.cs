using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APTA.Models
{
    public class Event
    {
        public int EventId { get; set; }
        [Required]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }
        [Required]
        [Display(Name = "Start Date and Time")]
        public DateTime EventStart { get; set; }
        [Required]
        [Display(Name = "Finish Date and Time")]
        public DateTime EventEnd { get; set; }

        public int ConferenceId { get; set; }
        public virtual Conference Conference { get; set; }
    }
}