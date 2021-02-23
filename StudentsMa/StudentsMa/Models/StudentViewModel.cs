using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsManagement_III.Models
{
    public class StudentViewModel
    {
        [Key]
        public int studentID { get; set; }
        [Required(ErrorMessage = "Please add a student name")]
        public string studentName { get; set; }
        [Required(ErrorMessage = "Please add a CIN")]
        public string studentCIN { get; set; }
        [Required(ErrorMessage = "Please add an address")]
        public string studentAddress { get; set; }

        public StudentViewModel()
        {

        }
    }
}
