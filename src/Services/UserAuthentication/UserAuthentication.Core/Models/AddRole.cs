using System.ComponentModel.DataAnnotations;

namespace amznStore.Services.UserAuthentication.Core.Models
{
    public class AddRole
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
