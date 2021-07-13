using Common;
using DataAccess;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Services
{
    public class ProductController : IProductController
    {
        private readonly IProductRepository _repo;
        private readonly string _includeProperties = "Category,SubCategory";

        public ProductController(IProductRepository repo) => _repo = repo;

        public bool Delete(int id)
        {
            try
            {
                if (id == 0)
                    return false;

                _repo.Remove(id);
                _repo.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public IEnumerable<SelectListItem> GetAllDropdownListSubCategory() => _repo.GetAllDropdownList(DB.TABLE_SUB_CATEGORY);

        public IEnumerable<SelectListItem> GetAllDropdownListCategory() => _repo.GetAllDropdownList(DB.TABLE_CATEGORY);

        public Product GetFirstOrDefatult(Expression<Func<Product, bool>> expression = null)
        {
            if (expression != null)
                return _repo.FirstOrDefault(expression, includeProperties: _includeProperties);

            return _repo.FirstOrDefault(includeProperties: _includeProperties);
        }

        public Product Find(int id) => _repo.Find(id);

        public IEnumerable<Product> LoadData(Expression<Func<Product, bool>> expression = null)
        {
            if (expression != null)
                return _repo.GetAll(expression, includeProperties: _includeProperties);

            return _repo.GetAll(includeProperties: _includeProperties);
        }

        public bool Save(Product obj)
        {
            try
            {
                _repo.Add(obj);
                _repo.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Update(Product obj)
        {
            try
            {
                var objFromDb = _repo.Find(obj.Id);
                if (objFromDb == null)
                    return false;

                objFromDb.Map(obj);
                _repo.Update(objFromDb);
                _repo.Save();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
