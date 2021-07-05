using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class OrderDetail : BaseDomain
    {

        [Required]
        public int OrderHeaderId { get; set; }
        public OrderHeader OrderHeader { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
