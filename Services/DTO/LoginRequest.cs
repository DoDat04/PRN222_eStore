using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace eStore.DTO.MemberDTO.Request
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
