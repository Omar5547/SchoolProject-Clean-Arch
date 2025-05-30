
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolApp.Application.interfaces;
using SchoolApp.Domain.Entities;
using WebApplication2025.ViewModels;

namespace WebApplication2025.Controllers
{
    public class ClassController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        // GET: ClassController1

        public ClassController(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var classes = await _unitOfWork.Classes.GetAllAsync();
            var teachers = await _unitOfWork.Teachers.GetAllAsync();


            var classviewmodel = classes.Select(C => new ClassViewModel
            {
                Id = C.Id,
                Name = C.Name,
                TeacherId = C.TeacherId,
                TeacherName = C.Teacher.Name



            }).ToList();
          
            return View(classviewmodel);
        }
        // GET: ClassController1/Details/5
        public async Task <IActionResult> Details(int id)
        {
            var classes = await _unitOfWork.Classes.GetByIdAsync(id);
            if (classes == null)
            {
                return NotFound();
            }
            var teacher = await _unitOfWork.Teachers.GetByIdAsync(classes.TeacherId);
            var classviewmodel = new ClassViewModel
            {
                Id = classes.Id,
                Name = classes.Name,
                TeacherId = classes.TeacherId,
                TeacherName = classes.Teacher.Name
                

            };
       
            return View(classviewmodel);
        }

        // GET: ClassController1/Create
        public async Task <IActionResult> Create()
        {
            var teachers = await _unitOfWork.Teachers.GetAllAsync();
            ViewBag.Teachers = new SelectList(teachers, "Id", "Name");
            return View();
        }

        // POST: ClassController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(ClassViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var classes = new Class
                {
                    Name = model.Name,
                    TeacherId = model.TeacherId

                };
                await _unitOfWork.Classes.AddAsync(classes);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction("Index");

               


            }
            var teachers = await _unitOfWork.Teachers.GetAllAsync();
            ViewBag.Teachers = new SelectList(teachers, "Id", "Name");
            return View(model);
        }

        // GET: ClassController1/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var classes = await _unitOfWork.Classes.GetByIdAsync(id);
            if (classes == null)
            {
                return NotFound();
            }

            //var teacher = await _unitOfWork.Teachers.GetByIdAsync(classes.TeacherId);

            var classviewModel = new ClassViewModel
            {
                Id = classes.Id,
                Name = classes.Name,
                TeacherId = classes.TeacherId,
                //TeacherName = teacher.Name
            };
            var allTeachers = await _unitOfWork.Teachers.GetAllAsync();
            ViewBag.Teachers = new SelectList(allTeachers, "Id", "Name", classes.TeacherId);

            return View(classviewModel);
        }


        // POST: ClassController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(ClassViewModel model)
        {
            if (ModelState.IsValid)
            {
                var Classes = await _unitOfWork.Classes.GetByIdAsync(model.Id);
                if (Classes == null) 
                {
                    return NotFound();
                }
                Classes.Name = model.Name;
                Classes.TeacherId = model.TeacherId;
                _unitOfWork.Classes.Update(Classes);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction("Index");
            }
            var allTeachers = await _unitOfWork.Teachers.GetAllAsync();
            ViewBag.Teachers = new SelectList(allTeachers, "Id", "Name", model.TeacherId);


            return View(model);

        }

        // GET: ClassController1/Delete/5
        public async Task <IActionResult> Delete(int id)
        {
            var classes = await _unitOfWork.Classes.GetByIdAsync(id);
            if (classes==null)
            {
                return NotFound();
            }
            var teacher = await _unitOfWork.Teachers.GetByIdAsync(classes.TeacherId);

            var classviewmodel = new ClassViewModel
            {
                Id = classes.Id,
                Name = classes.Name,
                TeacherId = classes.TeacherId,
                TeacherName = teacher.Name
            };
            return View(classviewmodel);
        }

        // POST: ClassController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Delete(int id, ClassViewModel model)
        {
            var classes = await _unitOfWork.Classes.GetByIdAsync(id);
            if (classes == null)
            {
                return NotFound();
            }
             _unitOfWork.Classes.Delete(classes);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("Index");
        }
    }
}
