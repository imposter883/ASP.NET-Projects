using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICandidateRepo : IRepo<Candidate,int,bool>
    {
        List<Candidate> SearchByName(string keyword);
        List<Candidate> CandidatesByElection(int eId);
    }
}
