namespace APTA.Migrations
{
    using APTA.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<APTA.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(APTA.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var organization1 = new Organization()
            {
                OrganizationName = "Asia University",
                OrganizationAddress = "Street 1",
                OrganizationEmail = "asiaun@gmail.com",
                OrganizationPhone = "+3700000777",
            };
            var organization2 = new Organization()
            {
                OrganizationName = "APTA support",
                OrganizationAddress = "Street 2",
                OrganizationEmail = "aptasupport@gmail.com",
                OrganizationPhone = "+370004457",
            };
            var organization3 = new Organization()
            {
                OrganizationName = "Chiang Mai University",
                OrganizationAddress = "Street 3",
                OrganizationEmail = "mai@gmail.com",
                OrganizationPhone = "+3700000457",
            };            

            var member1 = new Member()
            {
                MemberFirstName = "John",
                MemberLastName = "Smith",
                MemberEmail = "jsmith@mail.com",
                MemberPhone = "+143245644",
                MemberRegistrationDate = DateTime.Now,
            };
            var member2 = new Member()
            {
                MemberFirstName = "Sarah",
                MemberLastName = "Jane",
                MemberEmail = "sarahjane@mail.com",
                MemberPhone = "+1452465465",
                MemberRegistrationDate = DateTime.Now,
            };
            var member3 = new Member()
            {
                MemberFirstName = "Rob",
                MemberLastName = "Walter",
                MemberEmail = "rwwwww@mail.com",
                MemberPhone = "+14454644",
                MemberRegistrationDate = DateTime.Now,
            };
            context.Members.Add(member1);
            context.Members.Add(member2);
            context.Members.Add(member3);

            var conference1 = new Conference()
            {
                ConferenceName = "APTA 2018",
                ConferenceDescription = "This APTA 2018",
                ConferenceDateStart = new DateTime(2018, 5, 20),
                ConferenceDateEnd = new DateTime(2018, 5, 25),
                //OrganizationId = organization1.OrganizationId,
            };
            var conference2 = new Conference()
            {
                ConferenceName = "APTA 2019",
                ConferenceDescription = "This APTA 2019",
                ConferenceDateStart = new DateTime(2019, 5, 20),
                ConferenceDateEnd = new DateTime(2019, 5, 25),
                //OrganizationId = organization2.OrganizationId,
            };
            var conference3 = new Conference()
            {
                ConferenceName = "APTA 2020 in Chiang Mai, Thailand",
                ConferenceDescription = "APTA 2020 26th Annual Conference",
                ConferenceDateStart = new DateTime(2020, 7, 1),
                ConferenceDateEnd = new DateTime(2020, 7, 4),
                //OrganizationId = organization3.OrganizationId,
            };

            conference1.Members.Add(member1);
            conference2.Members.Add(member1);
            conference2.Members.Add(member2);
            conference3.Members.Add(member3);
            conference3.Members.Add(member2);
            conference3.Members.Add(member1);            

            var _event1 = new Event()
            {
                EventName = "Registration Desk Open",
                EventStart = new DateTime(2020, 7, 1, 9, 0, 0),
                EventEnd = new DateTime(2020, 7, 1, 18, 30, 0),
                //ConferenceId = conference3.ConferenceId,
            };
            var _event2 = new Event()
            {
                EventName = "Lunch",
                EventStart = new DateTime(2020, 7, 1, 11, 0, 0),
                EventEnd = new DateTime(2020, 7, 1, 13, 0, 0),
                //ConferenceId = conference3.ConferenceId,
            };
            var _event3 = new Event()
            {
                EventName = "TiP (Thesis-in-progress) Session",
                EventStart = new DateTime(2020, 7, 1, 13, 0, 0),
                EventEnd = new DateTime(2020, 7, 1, 14, 30, 0),
                //ConferenceId = conference3.ConferenceId,
            };
            context.Events.Add(_event1);
            context.Events.Add(_event2);
            context.Events.Add(_event3);

            conference3.Events.Add(_event1);
            conference3.Events.Add(_event2);
            conference3.Events.Add(_event3);

            context.Conferences.Add(conference1);
            context.Conferences.Add(conference2);
            context.Conferences.Add(conference3);

            organization1.Conferences.Add(conference1);
            organization2.Conferences.Add(conference2);
            organization3.Conferences.Add(conference3);

            context.Organizations.Add(organization1);
            context.Organizations.Add(organization2);
            context.Organizations.Add(organization3);

            base.Seed(context);
        }
    }
}
