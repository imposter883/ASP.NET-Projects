using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IVoterRepo VoterData()
        {
            return new VoterRepo();
        }

        public static ICandidateRepo CandidateData()
        {
            return new CandidateRepo();
        }

        public static IElectionRepo ElectionData()
        {
            return new ElectionRepo();
        }

        public static IVoteRepo VoteData()
        {
            return new VoteRepo();
        }

        public static INotificationRepo NotificationData()
        {
            return new NotificationRepo();
        }
    }
}
