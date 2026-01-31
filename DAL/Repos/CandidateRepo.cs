using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CandidateRepo : Repo, ICandidateRepo
    {
        public List<Candidate> CandidatesByElection(int eId)
        {
            return db.Candidates.Where(c=> c.ElectionId == eId).ToList();
        }

        public bool Create(Candidate obj)
        {
            db.Candidates.Add(obj);
            return db.SaveChanges()>0;
        }

        public bool Delete(int Id)
        {
            var ex = Read(Id);
            db.Candidates.Remove(ex);
            return db.SaveChanges()>0;
        }

        public List<Candidate> Read()
        {
            return db.Candidates.ToList();
        }

        public Candidate Read(int Id)
        {
            return db.Candidates.Find(Id);
        }

        public List<Candidate> SearchByName(string keyword)
        {
            return db.Candidates.Where(c=> c.Name.Contains(keyword) || c.Party.Contains(keyword)).ToList();
        }

        public bool Update(Candidate obj)
        {
            var ex = Read(obj.CandidateId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
