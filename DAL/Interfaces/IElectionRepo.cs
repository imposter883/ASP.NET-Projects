using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IElectionRepo : IRepo<Election,int,bool>
    {
        List<Election> ActiveElections();
        bool EndElection(int eId);
        Election ElectionWithCandidates(int eId);
        List<Election> SearchElection(string title);
    }
}
