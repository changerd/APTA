using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APTA.Models
{
    public class Conference
    {
        public int ConferenceId { get; set; }
        [Required]
        [Display(Name = "Conference Name")]
        public string ConferencenName { get; set; }
        [Required]
        [Display(Name = "Conference Description")]
        public string ConferenceDescription { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        public DateTime ConferenceDateStart { get; set; }
        [Required]
        [Display(Name = "Finish Date")]
        public DateTime ConferenceDateEnd { get; set; }

        [Display(Name = "Co-Hosting Organization")]
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Member> Members { get; set; }

        public Conference()
        {
            Events = new List<Event>();
            Members = new List<Member>();
        }
    }
}