using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class VoterRepo : Repo, IVoterRepo
    {
        public bool Create(Voter obj)
        {
            db.Voters.Add(obj);
            return db.SaveChanges()>0;
        }

        public bool Delete(int Id)
        {
            var ex = Read(Id);
            db.Voters.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public Voter GetByEmail(string email)
        {
            return db.Voters.FirstOrDefault(x => x.Email == email);
        }

        public List<Vote> GetVotesByVoter(int vId)
        {
            return db.Votes.Where(v => v.VoterId == vId).ToList();
        }

        public List<Voter> Read()
        {
            return db.Voters.ToList();
        }

        public Voter Read(int Id)
        {
            return db.Voters.Find(Id);
        }

        public List<Voter> SearchByName(string name)
        {
            return db.Voters.Where(v=>v.Name.Contains(name)).ToList();
        }

        public bool Update(Voter obj)
        {
            var ex = Read(obj.VoterId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
