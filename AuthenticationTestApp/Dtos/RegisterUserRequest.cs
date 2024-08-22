using System.ComponentModel.DataAnnotations;

namespace AuthenticationTestApp.Dtos
{
    public record RegisterUserRequest(
        [Required] string UserName,
        [Required] string Password,
        [Required] string Email);
    
    
}
