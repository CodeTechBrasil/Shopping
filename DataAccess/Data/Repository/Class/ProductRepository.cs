using Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db): base(db) => _db = db;

        public IEnumerable<SelectListItem> GetAllDropdownList(string obj)
        {
            if (obj == DB.TABLE_CATEGORY)
            {
                return _db.Category.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            }
            if (obj == DB.TABLE_SUB_CATEGORY)
            {
                return _db.SubCategory.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            }
            return null;
        }

        public void Update(Product obj)
        {
            _db.Product.Update(obj);
        }
    }
}
