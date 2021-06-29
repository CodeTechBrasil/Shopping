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
        private readonly string _includeProperties = "Category,ApplicationType";

        public ProductController(IProductRepository repo) => _repo = repo;

        public bool Delete(int id)
        {
            try
            {
                var objFromDb = _repo.Find(id);
                if (objFromDb == null)
                    return false;

                _repo.Remove(objFromDb);
                _repo.Save();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public IEnumerable<SelectListItem> GetAllDropdownListApplicationType()
        {
            return _repo.GetAllDropdownList(DB.TABLE_APPLICATION_TYPE);
        }

        public IEnumerable<SelectListItem> GetAllDropdownListCategory()
        {
            return _repo.GetAllDropdownList(DB.TABLE_CATEGORY);
        }

        public Product GetFirstOrDefatult(Expression<Func<Product, bool>> expression = null)
        {
            if (expression != null)
                return _repo.FirstOrDefault(expression, includeProperties: _includeProperties, isTracking: false);

            return _repo.FirstOrDefault(includeProperties: _includeProperties, isTracking: false);
        }

        public Product Find(int id)
        {
            return _repo.Find(id);
        }

        public IEnumerable<Product> LoadData(Expression<Func<Product, bool>> expression = null)
        {
            if (expression != null)
                return _repo.GetAll(expression, includeProperties: _includeProperties, isTracking: false);

            return _repo.GetAll(includeProperties: _includeProperties, isTracking: false);
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
