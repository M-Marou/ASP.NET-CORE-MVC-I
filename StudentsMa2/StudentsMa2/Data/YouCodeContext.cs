using Microsoft.EntityFrameworkCore;
using StudentsMa2.Models.YouCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsMa2.Data
{
    public class YouCodeContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-StudentsManagement_III-1E032FFB-1303-425C-AEF0-5A24EFCB7CE8;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<ClassModel> StudentClass { get; set; }
        public DbSet<StudentModel> Students { get; set; }
    }
}
