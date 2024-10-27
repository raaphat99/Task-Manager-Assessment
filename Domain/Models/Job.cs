using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Job name is required.")]
        [MinLength(3, ErrorMessage = "Job names should be at least 3 characters long.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Job description is required.")]
        public string Description { get; set; }
        public bool? Status { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }

        [ForeignKey("TeamMember")]
        public int? TeamMemberId { get; set; }
        public TeamMember TeamMember { get; set; }
    }
}
