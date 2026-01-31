namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EvotingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EvotingContext context)
        {


            Random random = new Random();

            for (int i = 1; i <= 30; i++)
            {
                context.Voters.AddOrUpdate(new Models.Voter
                {
                    VoterId = i,
                    Name = Guid.NewGuid().ToString().Substring(0, 10),
                    VoterSerial = "Voter" + i,
                    Email = "Voter" + i + "@gmail.com",
                    DOB = new DateTime(
                        random.Next(1980, 2005),
                        random.Next(1, 13),
                        random.Next(1, 31)
                        ),
                    HasVoted = false,
                });
            }

            for (int i = 1; i <= 5; i++)
            {
                context.Candidates.AddOrUpdate(new Models.Candidate
                {
                    CandidateId = i,
                    Name = "Candidate" + i,
                    Party = "Parti" + i,
                    ElectionId = random.Next(1, 11),

                });
            }

            for (int i = 1; i <= 10; i++)
            {
                context.Elections.AddOrUpdate(new Models.Election
                {
                    ElectionId = i,
                    Title = "This is Election" + i,
                    StartDate = DateTime.Now.AddDays(-1),
                    EndDate = DateTime.Now.AddDays(2),
                });
            }

            for (int i = 1; i <= 30; i++)
            {
                context.Votes.AddOrUpdate(new Models.Vote
                {
                    VoteId = i,
                    VoterId = random.Next(1, 31),
                    CandidateId = random.Next(1, 6),
                    ElectionId = random.Next(1, 11),
                    Time = DateTime.Now,
                });
            }

            for (int i = 1; i <= 100; i++)
            {
                context.Notifications.AddOrUpdate(new Models.Notification
                {
                    NotificationId = i,
                    VoterId = random.Next(1, 31),
                    CreatedAt = DateTime.Now,
                    IsRead = true,
                });
            }
        }
    }
}
