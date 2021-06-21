using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Services;
using System.Collections.Generic;

namespace Shop.Controllers
{
    [Area("Cadastro")]
    public class CategoryController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ICategoryController _catRepo;
        public CategoryController(ICategoryController catRepo)
        {
            _catRepo = catRepo;
        }

        public IActionResult Index()
        {
            var objList = _catRepo.LoadData();
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
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _catRepo.Save(obj);
                TempData[WC.SUCCESS] = "Category created successfully";
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

            var obj = _catRepo.GetFirstOrDefatult(x => x.Id ==  id.GetValueOrDefault());
            if (obj == null)
                return NotFound();
            return View(obj);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _catRepo.Update(obj);
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

            var obj = _catRepo.GetFirstOrDefatult(x => x.Id == id.GetValueOrDefault());
            if (obj == null)
                return NotFound();
            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _catRepo.GetFirstOrDefatult(x => x.Id == id.GetValueOrDefault());
            if (obj == null)
                return NotFound();

            TempData[WC.SUCCESS] = "Action completed successfully";
            _catRepo.Delete(obj);
            return RedirectToAction("Index");
        }
    }
}
