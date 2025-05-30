
using SchoolApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2025.ViewModels;
using SchoolApp.Application.interfaces;

namespace WebApplication2025.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
    

        // GET: StudentController
        public StudentController(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
           
        }
        public async Task <IActionResult> Index()
        {
         


            var Student = await _unitOfWork.Students.GetAllAsync();
           
            var studentViewModel = Student.Select(s => new StudentViewModel
            {
                id = s.id,
                name =s.name,
                Birthdate=s.Birthdate,
                ClassId = s.ClassId,
                Classes = s.Class?.Name,
                ParentId = s.Parent.Id,
                Parents = s.Parent.Name
            }).ToList();
            return View(studentViewModel);
        }

        // GET: StudentController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            var classes = await _unitOfWork.Classes.GetByIdAsync(student.ClassId);
            var parents = await _unitOfWork.Parents.GetByIdAsync(student.ParentId);

          

            var studentviewmodel = new StudentViewModel
            {
                id = student.id,
                name = student.name,
                Birthdate = student.Birthdate,
                ClassId = classes.Id,
                Classes = classes.Name,
                ParentId = parents.Id,
                Parents = parents.Name
            };

            return View(studentviewmodel);
        }


        // GET: StudentController/Create
        public async Task  <IActionResult> Create()
        {
            var classes = await _unitOfWork.Classes.GetAllAsync();
            ViewBag.Classes = new SelectList(classes, "Id", "Name");
            var parents = await _unitOfWork.Parents.GetAllAsync();

            ViewBag.Parents = new SelectList(parents, "Id", "Name");

            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    name = model.name,
                    Birthdate = model.Birthdate,
                    ClassId = model.ClassId,
                    ParentId = model.ParentId,
                };
                await _unitOfWork.Students.AddAsync(student);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction("Index");
                
            }
            var classes=  await _unitOfWork.Classes.GetAllAsync();
            var parent = await _unitOfWork.Parents.GetAllAsync();
            ViewBag.Classes = new SelectList(classes, "Id", "Name");
            ViewBag.Parents = new SelectList(parent, "Id", "Name");


            return View(model);
            


        }
        // GET: StudentController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(id.Value);

            if (student == null)
            {
                return NotFound();
            }

           
            var classes = await _unitOfWork.Classes.GetByIdAsync(student.ClassId);
            var parents = await _unitOfWork.Parents.GetByIdAsync(student.ParentId);

            var studentviewmodel = new StudentViewModel
            {
                id = student.id,
                name = student.name,
                Birthdate = student.Birthdate,
                ClassId = classes.Id,
                Classes = classes.Name,
                ParentId = parents.Id,
                Parents = parents.Name
            };

            var allParents = await _unitOfWork.Parents.GetAllAsync();
            ViewBag.Parents = new SelectList(allParents, "Id", "Name");

            var allClasses = await _unitOfWork.Classes.GetAllAsync();
            ViewBag.Classes = new SelectList(allClasses, "Id", "Name");



            return View(studentviewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = await _unitOfWork.Students.GetByIdAsync(model.id);

                if (student == null)
                {
                    return NotFound();
                }


                student.name = model.name;
                student.Birthdate = model.Birthdate;
                student.ClassId = model.ClassId;
                student.ParentId = model.ParentId;
                _unitOfWork.Students.Update(student);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction("Index");


              
            }
            var allParents = await _unitOfWork.Parents.GetAllAsync();
            ViewBag.parent = new SelectList(allParents, "Id", "Name");

            var allClasses = await _unitOfWork.Classes.GetAllAsync();
            ViewBag.classes = new SelectList(allClasses, "Id", "Name");


            return View(model);
        }




        // GET: StudentController/Delete/5
        public async Task <IActionResult> Delete(int id)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(id);
            if (student == null)
                return NotFound();
            var classes = await _unitOfWork.Classes.GetByIdAsync(student.ClassId);
            var parents = await _unitOfWork.Parents.GetByIdAsync(student.ParentId);
            var studentviewmodel = new StudentViewModel
            {
                id = student.id,
                name = student.name,
                Birthdate = student.Birthdate,
                ClassId = student.ClassId,
                Classes = student.Class.Name,
                Parents = student.Parent.Name,
                ParentId = student.ParentId


            };

            return View(studentviewmodel);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Delete(int id, IFormCollection collection)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(id);
            if(student == null) 
            {
                return NotFound();
            }
            _unitOfWork.Students.Delete(student);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("Index");
        }
    }
}
