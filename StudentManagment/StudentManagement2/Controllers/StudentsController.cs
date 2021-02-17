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
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("spStudents_ViewAll", sqlConnection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.Fill(dataTable);
            }
                return View(dataTable);
        }

        // GET: Students/AddOrEdit/
        public IActionResult AddOrEdit(int? id)
        {
            StudentsViewModel studentsViewModel = new StudentsViewModel();
            if (id > 0)
                studentsViewModel = FetchStudentByID(id);
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
            StudentsViewModel studentsViewModel = FetchStudentByID(id);
            return View(studentsViewModel);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlConnection.Open();
                SqlCommand sqlCMD = new SqlCommand("spStudents_DeleteByID", sqlConnection);
                sqlCMD.CommandType = CommandType.StoredProcedure;
                sqlCMD.Parameters.AddWithValue("StudentID",id);
                sqlCMD.ExecuteNonQuery();
            }
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public StudentsViewModel FetchStudentByID(int? id)
        {
            DataTable dataTable = new DataTable();

            StudentsViewModel studentsViewModel = new StudentsViewModel();

            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("spStudents_ViewByID", sqlConnection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.AddWithValue("StudentID", id);
                dataAdapter.Fill(dataTable);
                if(dataTable.Rows.Count == 1)
                {
                    studentsViewModel.Student_ID = Convert.ToInt32(dataTable.Rows[0]["Student_ID"].ToString());
                    studentsViewModel.Student_Name = dataTable.Rows[0]["Student_Name"].ToString();
                    studentsViewModel.Student_CIN = dataTable.Rows[0]["Student_CIN"].ToString();
                    studentsViewModel.Student_Address = dataTable.Rows[0]["Student_Address"].ToString();
                }
                return studentsViewModel;
            }
        }
    }
}
