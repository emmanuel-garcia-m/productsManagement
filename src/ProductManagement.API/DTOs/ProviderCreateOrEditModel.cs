using System.ComponentModel.DataAnnotations;

namespace ProductManagement.API.DTOs
{
    public class ProviderCreateOrEditModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [Required]
        [StringLength(16)]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
