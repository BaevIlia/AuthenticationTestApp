using System.ComponentModel.DataAnnotations;

namespace AuthenticationTestApp.Dtos
{
    public record LoginUserRequest(
        [Required] string Email,
        [Required] string Password);
    
}
