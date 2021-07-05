using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System.Collections.Generic;

namespace Services
{
    public interface IProductController : IController<Product>
    {
        Product Find(int id);
        IEnumerable<SelectListItem> GetAllDropdownListSubCategory();
        IEnumerable<SelectListItem> GetAllDropdownListCategory();
    }
}
