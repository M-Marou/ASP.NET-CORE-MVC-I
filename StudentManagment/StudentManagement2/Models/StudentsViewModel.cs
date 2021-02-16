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
        [Required(ErrorMessage = "Please add a student name")]
        public string Student_Name { get; set; }
        [Required(ErrorMessage = "Please add a CIN")]
        public string Student_CIN { get; set; }
        [Required(ErrorMessage = "Please add an address")]
        public string Student_Address { get; set; }
    }
}
