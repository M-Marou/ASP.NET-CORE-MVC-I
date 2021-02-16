using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement2.Models
{
    public class StudentsViewModel
    {
        [Key]
        public int Student_ID { get; set; }
        public string Student_Name { get; set; }
        public string Student_CIN { get; set; }
        public string Student_Address { get; set; }
    }
}
