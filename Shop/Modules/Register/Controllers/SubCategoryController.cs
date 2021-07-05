using Common;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Shop.Controllers
{
    [Area("Register")]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryController _repo;
        public SubCategoryController(ISubCategoryController repo)
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
        public IActionResult Create(SubCategory obj)
        {
            if (ModelState.IsValid)
            {
                _repo.Save(obj);
                TempData[WC.SUCCESS] = "SubCategory created successfully";
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
        public IActionResult Edit(SubCategory obj)
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
            if(_repo.Delete(id.GetValueOrDefault())) 
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
