using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class VoteRepo : Repo, IVoteRepo
    {
        public bool CastVote(int vId, int eId, int cId)
        {
            bool hasVoted = db.Votes.Any(v=> v.VoterId == vId && v.ElectionId == eId);
            if(hasVoted) return false;

            var vote = new Vote
            {
                VoterId = vId,
                ElectionId = eId,
                CandidateId = cId,
                Time = DateTime.Now,
            };
            db.Votes.Add(vote);
            return db.SaveChanges()>0;
        }

        public bool Create(Vote obj)
        {
            db.Votes.Add(obj);
            return db.SaveChanges()>0;
        }

        public bool Delete(int Id)
        {
            var ex = Read(Id);
            db.Votes.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public Dictionary<string, int> GetResult(int eId)
        {
            return db.Votes
                     .Where(v => v.ElectionId == eId)
                     .GroupBy(g => g.Candidate.Name)
                     .ToDictionary(g=> g.Key, g=> g.Count());
        }

        public bool HasVoterVoted(int vId, int eId)
        {
            return db.Votes.Any(v => v.VoterId == vId && v.ElectionId == eId);
        }

        public List<Vote> Read()
        {
            return db.Votes.ToList();
        }

        public Vote Read(int Id)
        {
            return db.Votes.Find(Id);
        }

        public int TotalVotes(int cId)
        {
            return db.Votes.Count(v=> v.CandidateId==cId);
        }

        public bool Update(Vote obj)
        {
            var ex = Read(obj.VoteId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public string Winner(int eId)
        {
            var result = GetResult(eId);
            return result.OrderByDescending(r=>r.Value).FirstOrDefault().Key;
        }
    }
}
