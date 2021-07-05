using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class OrderHeader: BaseDomain
    {
        public DateTime InquiryDate { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
