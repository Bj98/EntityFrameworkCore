using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore.Models;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkCore.Models.StudentModel;

namespace EntityFrameworkCore.Controllers.StudentControllers
{
    public class StudentController : Controller
    {
        public readonly ApplicationDbContext _db;

        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Get
        public IActionResult Index()
        {
            //List<Student> students = new List<Student>();
            var studentList = _db.Students.ToList();
            return View(studentList);
        }

        //Post
        public IActionResult Create()
        {
            return View(new Student());
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(student);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

        //Edit
        public IActionResult Edit(int id)
        {
            Student student = _db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View("Edit", student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Update(student);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public IActionResult Delete(int id)
        {
            Student student=_db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            _db.Students.Remove(student);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }



    }
}
