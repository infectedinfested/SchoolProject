using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.DTOs
{
    public class ScanDto
    {
        public int Id { get; set; }
        public int ExcursionId { get; set; }
        public DateTime Time { get; set; }
        public int StudentId { get; set; }
    }
}
