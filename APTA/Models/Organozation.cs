using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APTA.Models
{
    public class Organization
    {
        public int OrganizationId { get; set; }
        [Required]
        [Display(Name = "Organization Name")]
        public string OrganizationName { get; set; }
        [Required]
        [Display(Name = "Organization Address")]
        public string OrganizationAddress { get; set; }
        [Required]
        [Display(Name = "Organization Phone")]
        [DataType(DataType.PhoneNumber)]
        public string OrganizationPhone { get; set; }
        [Required]
        [Display(Name = "Organization E-mail")]
        [DataType(DataType.EmailAddress)]
        public string OrganizationEmail { get; set; }

        public virtual ICollection<Conference> Conferences { get; set; }

        public Organization()
        {
            Conferences = new List<Conference>();
        }
    }
}