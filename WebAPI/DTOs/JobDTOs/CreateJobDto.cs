using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs.JobDTOs
{
    public class CreateJobDto
    {
        [Required(ErrorMessage = "Job name is required.")]
        [MinLength(3, ErrorMessage = "Job names should be at least 3 characters long.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Job description is required.")]
        public string Description { get; set; }
        public bool? Status { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public int? TeamMemberId { get; set; }
    }
}
