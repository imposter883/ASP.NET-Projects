using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Vote
    {
        [Key]
        public int VoteId {  get; set; }
        [ForeignKey("Voter")]
        public int VoterId {  get; set; }
        [ForeignKey("Election")]
        public int? ElectionId {  get; set; }
        [ForeignKey("Candidate")]
        public int? CandidateId {  get; set; }
        public DateTime Time { get; set; }

        public virtual Voter Voter { get; set; }
        public virtual Election Election { get; set; }
        public virtual Candidate Candidate { get; set; }
    }
}
