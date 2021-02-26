using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsMa2.Models.YouCode
{
    public class StudentModel
    {
        [Key]
        public int studentID { get; set; }
        [Required(ErrorMessage = "Please add a student name")]
        public string studentName { get; set; }
        [Required(ErrorMessage = "Please add a CIN")]
        public string studentCIN { get; set; }
        [Required(ErrorMessage = "Please add an address")]
        public string studentAddress { get; set; }

        public string className { get; set; }
        public ClassModel studentClass { get; set; }
    }
}
