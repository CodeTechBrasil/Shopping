using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Models
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> CategorySelectList { get; set; }
        public IEnumerable<SelectListItem> SubCategorySelectList { get; set; }
    }
}
