using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Models
{
    public class Excursion
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TeacherId { get; set; }
        public List<int> StudentIds { get; set; }
        public bool Present { get; set; }
    }
}
