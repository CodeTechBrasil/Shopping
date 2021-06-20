using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System.Collections.Generic;

namespace DataAccess
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
        IEnumerable<SelectListItem> GetAllDropdownList(string obj);
    }
}
