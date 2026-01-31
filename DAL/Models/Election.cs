using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Election
    {
        [Key]
        public int ElectionId { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public bool IsActive 
        {
            get
            {
                return DateTime.Now >= StartDate && DateTime.Now <= EndDate;
            }
        }

        public virtual ICollection<Vote> Votes { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }

        public Election() 
        {
            Votes = new List<Vote>();
            Candidates = new List<Candidate>();
        }
    }
}
