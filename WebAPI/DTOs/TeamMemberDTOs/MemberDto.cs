using Domain.Models;
using System.ComponentModel.DataAnnotations;
using WebAPI.DTOs.JobDTOs;

namespace WebAPI.DTOs.TeamMemberDTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<JobDto> Jobs { get; set; } = new List<JobDto>();
    }
}
