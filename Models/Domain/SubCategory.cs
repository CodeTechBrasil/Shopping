using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class SubCategory : BaseDomain
    {
        [Required]
        public string Name { get; set; }

        public IEnumerable<Product> ListProduct { get; set; }
    }
}
