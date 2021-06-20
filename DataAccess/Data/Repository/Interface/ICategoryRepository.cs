using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System.Collections.Generic;

namespace DataAccess
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
        IEnumerable<SelectListItem> GetAllDropDownList(Category objeto);
    }
}
