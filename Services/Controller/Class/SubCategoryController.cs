using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Services
{
    public class SubCategoryController : ISubCategoryController
    {
        private readonly ISubCategoryRepository _repo;

        public SubCategoryController(ISubCategoryRepository repo) => _repo = repo;

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

        public SubCategory GetFirstOrDefatult(Expression<Func<SubCategory, bool>> expression = null)
        {
            if (expression != null)
                return _repo.FirstOrDefault(expression);

            return _repo.FirstOrDefault();
        }

        public IEnumerable<SubCategory> LoadData(Expression<Func<SubCategory, bool>> expression = null)
        {
            if (expression != null)
                return _repo.GetAll(expression);

            return _repo.GetAll();
        }

        public bool Save(SubCategory obj)
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

        public bool Update(SubCategory obj)
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
