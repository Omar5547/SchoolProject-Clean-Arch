
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolApp.Application.interfaces;
using SchoolApp.Domain.Entities;
using WebApplication2025.ViewModels;

namespace WebApplication2025.Controllers
{
    public class GradeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        // GET: GradeController
        public GradeController(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }
        public async Task <IActionResult> Index()
        {
            var grades = await _unitOfWork.Grades.GetAllAsync();
            var students = await _unitOfWork.Students.GetAllAsync();
            var gradeviewmodel = grades.Select(g => new GradeViewModel
            {
                Id = g.Id,
               Subject = g.Subject,
               Score = g.Score,
                Students = g.Student.name




            }).ToList();

            return View(gradeviewmodel);
        }

        // GET: GradeController/Details/5
        public async Task <IActionResult> Details(int id)
        {
            var grade = await _unitOfWork.Grades.GetByIdAsync(id);
            if (grade == null) 
            {
                return NotFound();
            }
            var student = await _unitOfWork.Students.GetByIdAsync(grade.StudentId);
            var gradeviewmodel = new GradeViewModel
            {
                Id = grade.Id,
                Subject = grade.Subject,
                Score = grade.Score,
                Students = student.name

            };
            return View(gradeviewmodel);
        }

        // GET: GradeController/Create
        public async Task <IActionResult> Create()
        {
            var students = await _unitOfWork.Students.GetAllAsync();
            ViewBag.Students = new SelectList(students, "id", "name");

            return View();
        }

        // POST: GradeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(GradeViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var grade = new Grade
                {
                    Subject = model.Subject,
                    Score = model.Score,
                    StudentId = model.StudentId
                };
                await _unitOfWork.Grades.AddAsync(grade);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction("Index");


            }
            var Students = await _unitOfWork.Students.GetAllAsync();
            ViewBag.Students = new SelectList(Students, "id", "name");
            return View(model);
        }

        // GET: GradeController/Edit/5
        public async Task <IActionResult> Edit(int? id)
        {
            var grade = await _unitOfWork.Grades.GetByIdAsync(id.Value);
            if (grade == null)
            {
                return NotFound();
            }
            var students = await _unitOfWork.Students.GetByIdAsync(grade.StudentId);
            var gradeviewmodel = new GradeViewModel
            {
                Id = grade.Id,
                Subject = grade.Subject,
                Score = grade.Score,
                StudentId = grade.StudentId

            };
            var allstudents = await _unitOfWork.Students.GetAllAsync();
            ViewBag.Students = new SelectList(allstudents, "id", "name");
            return View(gradeviewmodel);
        }

        // POST: GradeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(int id, GradeViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var grade = await _unitOfWork.Grades.GetByIdAsync(id);
                if (grade == null)
                {
                    return NotFound();
                }
                grade.Subject = model.Subject;
                grade.Score = model.Score;
                grade.StudentId = model.StudentId;
                _unitOfWork.Grades.Update(grade);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction("Index");



            }
            var allstudents = await _unitOfWork.Students.GetAllAsync();
            ViewBag.Students = new SelectList(allstudents, "id", "name");
            return View(model);
        }

        // GET: GradeController/Delete/5
        public async Task <IActionResult> Delete(int id)
        {
            var grade = await _unitOfWork.Grades.GetByIdAsync(id);
            if (grade == null)
            {
                return NotFound();
            }
            var student = await _unitOfWork.Students.GetByIdAsync(grade.StudentId);
            var gradeviewmodel = new GradeViewModel
            {
                Id = grade.Id,
                Subject = grade.Subject,
                Score = grade.Score,
                Students = student.name

            };
            return View(gradeviewmodel);

          
        }

        // POST: GradeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task  <IActionResult> Delete(int id,GradeViewModel model)
        {
            var grade = await _unitOfWork.Grades.GetByIdAsync(id);
            if(grade == null) 
            {
                return NotFound();
            }
            _unitOfWork.Grades.Delete(grade);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("Index");

        }
    }
}
