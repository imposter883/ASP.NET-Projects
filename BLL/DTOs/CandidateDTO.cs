using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CandidateDTO
    {
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public string Party { get; set; }
        public int ElectionId { get; set; }
    }
}
