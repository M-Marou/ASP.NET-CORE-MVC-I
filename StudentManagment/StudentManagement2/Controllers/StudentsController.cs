using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagement2.Data;
using StudentManagement2.Models;

namespace StudentManagement2.Controllers
{
    public class StudentsController : Controller
    {
        public StudentsController()
        {
        }

        // GET: Students
        public IActionResult Index()
        {
            return View();
        }

        // GET: Students/Edit/5
        public IActionResult AddOrEdit(int? id)
        {
            return View();
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
