using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class SaleDetail : BaseDomain
    {

        [Required]
        public int SaleHeaderId { get; set; }
        public SaleHeader SaleHeader { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Sqft { get; set; }
        public decimal PricePerSqFt { get; set; }

      
    }
}
