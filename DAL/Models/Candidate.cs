using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        public string Party { get; set; }
        [ForeignKey("Election")]
        public int? ElectionId { get; set; }

        public virtual Election Election { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public Candidate() 
        {
            Votes = new List<Vote>();
        }
    }
}
