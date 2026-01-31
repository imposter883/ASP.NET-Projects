using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId {  get; set; }
        [ForeignKey("Voter")]
        public int VoterId {  get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead {  get; set; }

        public virtual Voter Voter { get; set; }
        
    }
}
