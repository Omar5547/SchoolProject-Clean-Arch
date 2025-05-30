
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Application.interfaces;
using SchoolApp.Domain.Entities;
using WebApplication2025.ViewModels;

namespace WebApplication2025.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeacherController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task <IActionResult> Index()
        {
            var Teacher = await _unitOfWork.Teachers.GetAllAsync();
            var teacherviewmodel = Teacher.Select(T => new TeacherViewModel
            {
                Id = T.Id,
                Name = T.Name,
                Subject = T.Subject

            }).ToList();
            return View(teacherviewmodel);
        }

        // GET: TeacherController/Details/5
        public async Task <IActionResult> Details(int id)
        {
            var teacher = await _unitOfWork.Teachers.GetByIdAsync(id);
            if (teacher ==null)
            {
                return NotFound();
            }
            var teacherviewmodel = new TeacherViewModel
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Subject = teacher.Subject
            };

            return View(teacherviewmodel);
        }

        // GET: TeacherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create( TeacherViewModel model)
        {
            if (ModelState.IsValid)
            {
                var teacher = new Teacher
                {
                    Name = model.Name,
                    Subject = model.Subject

                };
                await _unitOfWork.Teachers.AddAsync(teacher);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction("Index");
            }
            return View(model);

        }

        // GET: TeacherController/Edit/5
        public async Task <IActionResult> Edit(int id)
        {
            var teacher = await _unitOfWork.Teachers.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            var teacherviewmodel = new TeacherViewModel
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Subject = teacher.Subject
            };

            return View(teacherviewmodel);
        }

        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TeacherViewModel model)
        {
            if (ModelState.IsValid)
            {


                var teacher = await _unitOfWork.Teachers.GetByIdAsync(model.Id);
                if (teacher == null)
                {
                    return NotFound();
                }
                teacher.Name = model.Name;
                teacher.Subject = model.Subject;
                _unitOfWork.Teachers.Update(teacher);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: TeacherController/Delete/5
        public async Task <IActionResult> Delete(int id)
        {
            var teacher = await _unitOfWork.Teachers.GetByIdAsync(id);
            if (teacher == null) 
            {
                return BadRequest();
            }
            var teacherviewModel = new TeacherViewModel
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Subject = teacher.Subject

            };
            return View(teacherviewModel);
        }

        // POST: TeacherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete( TeacherViewModel viewModel, int id)
        {
            var teacher = await _unitOfWork.Teachers.GetByIdAsync(id);
            if (teacher == null)
                return NotFound();
            _unitOfWork.Teachers.Delete(teacher);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("Index");
        }
    }
}
