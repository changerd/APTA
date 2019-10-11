using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APTA.Models
{
    public class ApplicationDbContext: DbContext 
    {
        public ApplicationDbContext()
            : base("ApplicationDbContext") { }

        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Organization> Organizations { get; set; }
    }
}