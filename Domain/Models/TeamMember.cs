using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(3, ErrorMessage = "Member Names must be at least 3 characters long.")]
        public string Name { get; set; }

        [Required, EmailAddress(ErrorMessage = "Please enter a valid email.")]
        public string Email { get; set; }

        public ICollection<Job> Jobs { get; set; } = new List<Job>();
    }
}
