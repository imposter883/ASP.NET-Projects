using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IVoterRepo : IRepo<Voter,int,bool>
    {
        Voter GetByEmail(string email);
        List<Vote> GetVotesByVoter(int vId);
        List<Voter> SearchByName(string name);
    }
}
