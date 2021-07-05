using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class SaleHeader :BaseDomain
    {

        [Required]
        public DateTime OrderDate { get; set; }

        public DateTime ShippingDate { get; set; }

        [Required]
        public decimal FinalOrderTotal { get; set; }

        public string OrderStatus { get; set; }

        public DateTime PaymentDate { get; set; }

        public string TransactionId { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string FullName { get; set; }
        public string Email { get; set; }

        public IEnumerable<SaleDetail> ListSaleDetail { get; set; }
    }
}
