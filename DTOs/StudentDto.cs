using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; } 
        public string Class { get; set; }
        public Guid QrCode { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
