namespace APTA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conferences",
                c => new
                    {
                        ConferenceId = c.Int(nullable: false, identity: true),
                        ConferencenName = c.String(nullable: false),
                        ConferenceDescription = c.String(nullable: false),
                        ConferenceDateStart = c.DateTime(nullable: false),
                        ConferenceDateEnd = c.DateTime(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConferenceId)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventName = c.String(nullable: false),
                        EventStart = c.DateTime(nullable: false),
                        EventEnd = c.DateTime(nullable: false),
                        ConferenceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Conferences", t => t.ConferenceId, cascadeDelete: true)
                .Index(t => t.ConferenceId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        MemberFirstName = c.String(nullable: false),
                        MemberLastName = c.String(nullable: false),
                        MemberPhone = c.String(nullable: false),
                        MemberEmail = c.String(nullable: false),
                        MemberRegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MemberId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        OrganizationId = c.Int(nullable: false, identity: true),
                        OrganizationName = c.String(nullable: false),
                        OrganizationAddress = c.String(nullable: false),
                        OrganizationPhone = c.String(nullable: false),
                        OrganizationEmail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OrganizationId);
            
            CreateTable(
                "dbo.MemberConferences",
                c => new
                    {
                        Member_MemberId = c.Int(nullable: false),
                        Conference_ConferenceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Member_MemberId, t.Conference_ConferenceId })
                .ForeignKey("dbo.Members", t => t.Member_MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Conferences", t => t.Conference_ConferenceId, cascadeDelete: true)
                .Index(t => t.Member_MemberId)
                .Index(t => t.Conference_ConferenceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Conferences", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.MemberConferences", "Conference_ConferenceId", "dbo.Conferences");
            DropForeignKey("dbo.MemberConferences", "Member_MemberId", "dbo.Members");
            DropForeignKey("dbo.Events", "ConferenceId", "dbo.Conferences");
            DropIndex("dbo.MemberConferences", new[] { "Conference_ConferenceId" });
            DropIndex("dbo.MemberConferences", new[] { "Member_MemberId" });
            DropIndex("dbo.Events", new[] { "ConferenceId" });
            DropIndex("dbo.Conferences", new[] { "OrganizationId" });
            DropTable("dbo.MemberConferences");
            DropTable("dbo.Organizations");
            DropTable("dbo.Members");
            DropTable("dbo.Events");
            DropTable("dbo.Conferences");
        }
    }
}
