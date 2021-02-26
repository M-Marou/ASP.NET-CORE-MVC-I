using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsMa3.Model.Repositories
{
    public class StudentsRepository : IYCRepository<StudentsModel>
    {
        List<StudentsModel> students;

        public StudentsRepository()
        {
            students = new List<StudentsModel>();
            students.Add(new StudentsModel() { Id = 1, Name = "MarOne", CIN = "HA214559", Email = "mar@mar.com", ClassName = "C#" });
            students.Add(new StudentsModel() { Id = 2, Name = "Saad", CIN = "HA510151", Email = "saad@saad.com", ClassName = "JS" });
        }

        public StudentsModel Get(int id)
        {
            return students.SingleOrDefault(st => st.Id == id);
        }
    }
}
