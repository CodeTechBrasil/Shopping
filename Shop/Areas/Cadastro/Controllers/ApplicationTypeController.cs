using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Services;
using System.Collections.Generic;

namespace Shop.Controllers
{
    [Area("Cadastro")]
    public class ApplicationTypeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IApplicationTypeController _repo;
        public ApplicationTypeController(IApplicationTypeController repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var objList = _repo.LoadData();
            return View(objList);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }


        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _repo.Save(obj);
                TempData[WC.SUCCESS] = "ApplicationType created successfully";
                return RedirectToAction("Index");
            }
            TempData[WC.ERROR] = "Error while creating category";
            return View(obj);

        }


        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var obj = _repo.GetFirstOrDefatult(x => x.Id ==  id.GetValueOrDefault());
            if (obj == null)
                return NotFound();
            return View(obj);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(obj);
                TempData[WC.SUCCESS] = "Action completed successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var obj = _repo.GetFirstOrDefatult(x => x.Id == id.GetValueOrDefault());
            if (obj == null)
                return NotFound();
            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            if(_repo.DeleteId(id.GetValueOrDefault())) 
                TempData[WC.SUCCESS] = "Action completed successfully";
            else
            {
                TempData[WC.ERROR] = "NOT FOUND";
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
