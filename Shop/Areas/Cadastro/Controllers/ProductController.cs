using Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System;
using System.IO;

namespace Shop.Controllers
{
    [Area("Cadastro")]
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IProductController _prodRepo;
        public ProductController(IWebHostEnvironment webHostEnvironment, IProductController catRepo)
        {
            _webHostEnvironment = webHostEnvironment;
            _prodRepo = catRepo;
        }

        public IActionResult Index()
        {
            var objList = _prodRepo.LoadData();
            return View(objList);
        }

        //GET - UPSERT
        public IActionResult Upsert(int? id)
        {
            var productVM = new ProductVM
            {
                Product = new Product(),
                ApplicationTypeSelectList = _prodRepo.GetAllDropdownListApplicationType(),
                CategorySelectList = _prodRepo.GetAllDropdownListCategory()
            };

            //this is for create
            if (id == null)
                return View(productVM);

            productVM.Product = _prodRepo.GetFirstOrDefatult(x => x.Id == id.GetValueOrDefault());
            if (productVM.Product == null)
                return NotFound();

            return View(productVM);
        }

        //POST - UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                var webRootPath = _webHostEnvironment.WebRootPath;
                var upload = webRootPath + WC.IMAGE_PATH;
                var fileName = Guid.NewGuid().ToString();
                var extension = Path.GetExtension(files[0]?.FileName);

                if (productVM.Product.Id == 0)
                {
                    //Creating
                    using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                        files[0].CopyTo(fileStream);

                    productVM.Product.Image = fileName + extension;
                    _prodRepo.Save(productVM.Product);
                    TempData[WC.SUCCESS] = "Action completed successfully";
                }
                else
                {
                    var objFromDb = _prodRepo.GetFirstOrDefatult(x => x.Id == productVM.Product.Id);
                    if (files.Count > 0)
                    {
                        var oldFile = Path.Combine(upload, objFromDb.Image);
                        if (System.IO.File.Exists(oldFile))
                            System.IO.File.Delete(oldFile);

                        using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                            files[0].CopyTo(fileStream);

                        productVM.Product.Image = fileName + extension;
                    }
                    else
                        productVM.Product.Image = objFromDb.Image;

                    _prodRepo.Update(productVM.Product);
                    TempData[WC.SUCCESS] = "Action completed successfully";
                }
                return RedirectToAction("Index");
            }
            
            productVM.CategorySelectList = _prodRepo.GetAllDropdownListCategory();
            productVM.ApplicationTypeSelectList = _prodRepo.GetAllDropdownListApplicationType();
            return View(productVM);
        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var obj = _prodRepo.GetFirstOrDefatult(x => x.Id == id.GetValueOrDefault());
            if (obj == null)
                return NotFound();
            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _prodRepo.Find(id.GetValueOrDefault());
            if (obj == null)
                return NotFound();

            var upload = _webHostEnvironment.WebRootPath + WC.IMAGE_PATH;
            var oldFile = Path.Combine(upload, obj.Image);

            if (System.IO.File.Exists(oldFile))
                System.IO.File.Delete(oldFile);

            if (_prodRepo.Delete(id.GetValueOrDefault()))
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
