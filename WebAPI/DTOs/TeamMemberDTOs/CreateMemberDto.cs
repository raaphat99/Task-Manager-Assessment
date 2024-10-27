using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs.TeamMemberDTOs
{
    public class CreateMemberDto
    {
        [Required, MinLength(3, ErrorMessage = "Member Names must be at least 3 characters long.")]
        public string Name { get; set; }

        [Required, EmailAddress(ErrorMessage = "Please enter a valid email.")]
        public string Email { get; set; }
    }
}
