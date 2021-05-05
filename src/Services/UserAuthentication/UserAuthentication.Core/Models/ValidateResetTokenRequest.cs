using System.ComponentModel.DataAnnotations;

namespace amznStore.Services.UserAuthentication.Core.Models
{
    public class ValidateResetTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
