using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IVoteRepo : IRepo<Vote,int,bool>
    {
        bool CastVote(int vId, int eId, int cId);
        Dictionary<string, int> GetResult(int eId);
        string Winner(int eId);
        int TotalVotes(int cId);
        bool HasVoterVoted(int vId, int eId);
    }
}