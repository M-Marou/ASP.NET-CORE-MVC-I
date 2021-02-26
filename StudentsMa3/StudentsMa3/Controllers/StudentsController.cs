using StudentsMa3.Model;
using StudentsMa3.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsMa3.Controllers
{
    public class StudentsController
    {
        private IYCRepository<StudentsModel> _YCRepository;
        public StudentsController()
        {
            _YCRepository = new StudentsRepository();
        }
        public string index(int id)
        {
            return _YCRepository.Get(id).Name;
        }
    }
}
