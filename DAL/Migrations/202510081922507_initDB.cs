namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        CandidateId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Party = c.String(nullable: false, maxLength: 30),
                        ElectionId = c.Int(),
                    })
                .PrimaryKey(t => t.CandidateId)
                .ForeignKey("dbo.Elections", t => t.ElectionId)
                .Index(t => t.ElectionId);
            
            CreateTable(
                "dbo.Elections",
                c => new
                    {
                        ElectionId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ElectionId);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        VoteId = c.Int(nullable: false, identity: true),
                        VoterId = c.Int(nullable: false),
                        ElectionId = c.Int(),
                        CandidateId = c.Int(),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VoteId)
                .ForeignKey("dbo.Candidates", t => t.CandidateId)
                .ForeignKey("dbo.Elections", t => t.ElectionId)
                .ForeignKey("dbo.Voters", t => t.VoterId, cascadeDelete: true)
                .Index(t => t.VoterId)
                .Index(t => t.ElectionId)
                .Index(t => t.CandidateId);
            
            CreateTable(
                "dbo.Voters",
                c => new
                    {
                        VoterId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        VoterSerial = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        HasVoted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VoterId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.Int(nullable: false, identity: true),
                        VoterId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NotificationId)
                .ForeignKey("dbo.Voters", t => t.VoterId, cascadeDelete: true)
                .Index(t => t.VoterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidates", "ElectionId", "dbo.Elections");
            DropForeignKey("dbo.Votes", "VoterId", "dbo.Voters");
            DropForeignKey("dbo.Notifications", "VoterId", "dbo.Voters");
            DropForeignKey("dbo.Votes", "ElectionId", "dbo.Elections");
            DropForeignKey("dbo.Votes", "CandidateId", "dbo.Candidates");
            DropIndex("dbo.Notifications", new[] { "VoterId" });
            DropIndex("dbo.Votes", new[] { "CandidateId" });
            DropIndex("dbo.Votes", new[] { "ElectionId" });
            DropIndex("dbo.Votes", new[] { "VoterId" });
            DropIndex("dbo.Candidates", new[] { "ElectionId" });
            DropTable("dbo.Notifications");
            DropTable("dbo.Voters");
            DropTable("dbo.Votes");
            DropTable("dbo.Elections");
            DropTable("dbo.Candidates");
        }
    }
}
