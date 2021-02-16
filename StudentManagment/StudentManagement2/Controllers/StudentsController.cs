using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentManagement2.Data;
using StudentManagement2.Models;

namespace StudentManagement2.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IConfiguration _configuration;

        public StudentsController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        // GET: Students
        public IActionResult Index()
        {
            return View();
        }

        // GET: Students/AddOrEdit/
        public IActionResult AddOrEdit(int? id)
        {
            StudentsViewModel studentsViewModel = new StudentsViewModel();
            return View(studentsViewModel);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, [Bind("Student_ID,Student_Name,Student_CIN,Student_Address")] StudentsViewModel studentsViewModel)
        {

            if (ModelState.IsValid)
            {
                using(SqlConnection  sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection"))){
                    sqlConnection.Open();
                    SqlCommand sqlCMD = new SqlCommand("spStudents_AddOrEdit", sqlConnection);
                    sqlCMD.CommandType = CommandType.StoredProcedure;
                    sqlCMD.Parameters.AddWithValue("StudentID", studentsViewModel.Student_ID);
                    sqlCMD.Parameters.AddWithValue("StudentName", studentsViewModel.Student_Name);
                    sqlCMD.Parameters.AddWithValue("StudentCIN", studentsViewModel.Student_CIN);
                    sqlCMD.Parameters.AddWithValue("StudentAddress", studentsViewModel.Student_Address);
                    sqlCMD.ExecuteNonQuery();
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Students/Delete/5
        public IActionResult Delete(int? id)
        {
            return View();
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
