using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class VoteDTO
    {
        public int VoteId { get; set; }
        public int VoterId { get; set; }
        public int ElectionId { get; set; }
        public int CandidateId { get; set; }
        public DateTime Time { get; set; }
    }
}
