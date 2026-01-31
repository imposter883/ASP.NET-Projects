using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ElectionRepo : Repo, IElectionRepo
    {
        public List<Election> ActiveElections()
        {
            var now = DateTime.Now;
            return db.Elections.Where(e=> e.StartDate<=now && e.EndDate>=now).ToList();
        }

        public bool Create(Election obj)
        {
            db.Elections.Add(obj);
            return db.SaveChanges()>0;
        }

        public bool Delete(int Id)
        {
            var ex = Read(Id);
            db.Elections.Remove(ex);
            return db.SaveChanges()>0;
        }

        public Election ElectionWithCandidates(int eId)
        {
            return db.Elections.Include("Candidates").FirstOrDefault(v=> v.ElectionId==eId);
        }

        public bool EndElection(int eId)
        {
            var election = db.Elections.Find(eId);
            if(election == null) return false;
            election.EndDate = DateTime.Now;
            return db.SaveChanges() > 0;
        }

        public List<Election> Read()
        {
            return db.Elections.ToList();
        }

        public Election Read(int Id)
        {
            return db.Elections.Find(Id);
        }

        public List<Election> SearchElection(string title)
        {
            return db.Elections.Where(e=> e.Title.Contains(title)).ToList();
        }

        public bool Update(Election obj)
        {
            var ex = Read(obj.ElectionId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges()>0;
        }
    }
}
