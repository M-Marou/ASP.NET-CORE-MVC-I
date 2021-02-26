using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsMa2.Models.YouCode
{
    public class ClassModel
    {
        [Key]
        public string className { get; set; }
        public List<StudentModel> Students { get; set; }
    }
}
