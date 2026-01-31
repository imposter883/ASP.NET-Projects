using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Voter
    {
        [Key]
        public int VoterId {  get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string VoterSerial {  get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime DOB {  get; set; }
        public bool HasVoted {  get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }

        public Voter() 
        {
            Votes = new List<Vote>();
            Notifications = new List<Notification>();
        }

    }
}
