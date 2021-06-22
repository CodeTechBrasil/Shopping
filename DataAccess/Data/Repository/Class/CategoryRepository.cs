using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetAllDropDownList(Category objeto)
        {
            return _db.Category.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Category obj)
        {
            _db.Category.Update(obj);
        }
    }
}
