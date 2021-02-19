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
        public string studentName { get; set; }
        public string studentCIN { get; set; }
        public string studentAddress { get; set; }

        public StudentViewModel()
        {

        }
    }
}
