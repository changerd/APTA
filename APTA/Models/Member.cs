using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APTA.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string MemberFirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string MemberLastName { get; set; }
        [Required]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string MemberPhone { get; set; }
        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string MemberEmail { get; set; }
        [Display(Name = "Date of Registration")]
        public DateTime MemberRegistrationDate { get; set; }

        public virtual ICollection<Conference> Conferences { get; set; }

        public Member()
        {
            Conferences = new List<Conference>();
        }
    }
}