
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using SchoolApp.Application.interfaces;
using SchoolApp.Domain.Entities;
using WebApplication2025.ViewModels;

namespace WebApplication2025.Controllers
{
    public class ParentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ParentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: ParentController
        public async Task < IActionResult> Index()
        {
            var parent = await _unitOfWork.Parents.GetAllAsync();
            var parentviewmodel = parent.Select(P => new ParentViewModel
            {
                 Id = P.Id,
                Name = P.Name,
                Email = P.Email,
                PhoneNumber = P.PhoneNumber

            }).ToList();
            return View(parentviewmodel);
        }

        // GET: ParentController/Details/5
        public async Task <IActionResult> Details(int id)
        {
            var parent = await _unitOfWork.Parents.GetByIdAsync(id);
            if(parent == null) 
            {
                return NotFound();
            }
            var parentviewmodel = new ParentViewModel
            {
                Id = parent.Id,
                Name = parent.Name,
                Email = parent.Email,
                PhoneNumber = parent.PhoneNumber
            };
            return View(parentviewmodel);
        }

        // GET: ParentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(ParentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var parent = new Parent
                {
                    Name = model.Name,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };
               await _unitOfWork.Parents.AddAsync(parent);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: ParentController/Edit/5
        public async Task <IActionResult> Edit(int id)
        {
            var parent = await _unitOfWork.Parents.GetByIdAsync(id);
            if (parent == null)
            {
                return NotFound();
            }
            var parentviewmodel = new ParentViewModel
            {
                Id = parent.Id,
                Name = parent.Name,
                Email = parent.Email,
                PhoneNumber = parent.PhoneNumber

            };
            return View(parentviewmodel);
        }

        // POST: ParentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(ParentViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var Parent = await _unitOfWork.Parents.GetByIdAsync(model.Id);
            if (Parent == null)
            {
                return NotFound();
            }
             Parent.Name = model.Name;
             Parent.Email = model.Email;
                Parent.PhoneNumber = model.PhoneNumber;
                await _unitOfWork.CompleteAsync();
                return RedirectToAction("Index");

            }
            return View(model);
        }



        // GET: ParentController/Delete/5
        public async Task <IActionResult> Delete(int id)
        {
            var parent = await _unitOfWork.Parents.GetByIdAsync(id);
            if (parent == null)
            {
                return NotFound();
            }
            var parentviewmodel = new ParentViewModel
            {
                Id = parent.Id,
                Name = parent.Name,
                Email = parent.Email,
                PhoneNumber = parent.PhoneNumber,


            };

            return View(parentviewmodel);
        }

        // POST: ParentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Delete(int id, ParentViewModel model)
        {
            var parent = await _unitOfWork.Parents.GetByIdAsync(id);
            if (parent == null) 
            {
                return NotFound();
            }
            _unitOfWork.Parents.Delete(parent);
             await _unitOfWork.CompleteAsync();
            return RedirectToAction("Index");
        }
    }
}
