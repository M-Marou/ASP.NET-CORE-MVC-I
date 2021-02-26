using StudentsMa2.Models.YouCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsMa2.Data
{
    public class DummyData
    {
        public static System.Collections.Generic.List<ClassModel> GetClasses()
        {
            List<ClassModel> classes = new List<ClassModel>
            {
                new ClassModel ()
                {
                    className="C#"
                },

                new ClassModel ()
                {
                    className="JavaScript"
                },
                new ClassModel ()
                {
                    className="FEBE"
                },
            };

            return classes;
        }


        public List<StudentModel> GetStudents(YouCodeContext context)
        {
            List<StudentModel> students = new List<StudentModel>
            {
                new StudentModel ()
                {
                    studentName="Marouane Moumni",
                    studentCIN="HA212559",
                    studentAddress="mar@mar.com",
                    className= context.StudentClass.Find("C#").className               
                },
                new StudentModel ()
                {
                    studentName="Saad H",
                    studentCIN="CN652481",
                    studentAddress="saad@saad.com",
                    className= context.StudentClass.Find("C#").className
                },
                                new StudentModel ()
                {
                    studentName="Ahmed Med",
                    studentCIN="HA124872",
                    studentAddress="ahmed@ahmed.com",
                    className= context.StudentClass.Find("JavaScript").className
                },
            };

            return students;
        }

    }
}
