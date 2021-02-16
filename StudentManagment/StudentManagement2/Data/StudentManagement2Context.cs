using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManagement2.Models;

namespace StudentManagement2.Data
{
    public class StudentManagement2Context : DbContext
    {
        public StudentManagement2Context (DbContextOptions<StudentManagement2Context> options)
            : base(options)
        {
        }

        public DbSet<StudentManagement2.Models.StudentsViewModel> StudentsViewModel { get; set; }
    }
}
