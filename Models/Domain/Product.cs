using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models 
{
    public class Product : BaseDomain
    {

        public Product()
        {
            TempSqFt = 1;
        }

        [Required]
        public string Name { get; set; }

        public string ShortDesc { get; set; }
        public string Description { get; set; }

        [Range(1, int.MaxValue)]
        public decimal Price { get; set; }
        public byte[] Image { get; set; }

        [Display(Name = "Category Type")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Display(Name = "Application Type")]
        public int ApplicationTypeId { get; set; }
        public virtual ApplicationType ApplicationType { get; set; }

        [NotMapped]
        [Range(1, 10000, ErrorMessage = "Sqft must be greater than 0.")]
        public int TempSqFt { get; set; }
    }
}
