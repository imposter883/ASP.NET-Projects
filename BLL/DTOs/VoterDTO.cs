using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class VoterDTO
    {
        public int VoterId { get; set; }
        public string Name { get; set; }
        public string VoterSerial { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public bool HasVoted { get; set; }
    }
}
