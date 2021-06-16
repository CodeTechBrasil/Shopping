using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ApplicationType : BaseDomain
    {
        [Required]
        public string Name { get; set; }
    }
}
