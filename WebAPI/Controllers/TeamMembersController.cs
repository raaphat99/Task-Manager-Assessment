using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Swashbuckle.AspNetCore.Swagger;
using WebAPI.DTOs.JobDTOs;
using WebAPI.DTOs.TeamMemberDTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMembersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TeamMembersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetMembers()
        {
            try
            {
                var members = await _unitOfWork.TeamMembers.GetAllAsync();
                return Ok(members);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMemberById(int id)
        {
            var member = await _unitOfWork.TeamMembers.GetByIdWithJobsAsync(id);

            if (member == null)
                return NotFound($"No team member with the id: {id} found!");

            var memberDto = new MemberDto
            {
                Id = member.Id,
                Name = member.Name,
                Email = member.Email,
                Jobs = member.Jobs.Select(job => new JobDto
                {
                    Id = job.Id,
                    Name = job.Name,
                    Description = job.Description,
                    Status = job.Status,
                    StartDate = job.StartDate,
                    EndDate = job.EndDate
                }).ToList()
            };

            return Ok(memberDto);
        }


        [HttpPost]
        public async Task<IActionResult> AddMember([FromBody] CreateMemberDto createMemberDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (await _unitOfWork.TeamMembers.EmailExistsAsync(createMemberDto.Email))
                return BadRequest(new { Message = "Email already exists." });

            TeamMember newTeamMember = new TeamMember()
            {
                Name = createMemberDto.Name,
                Email = createMemberDto.Email
            };

            await _unitOfWork.TeamMembers.AddAsync(newTeamMember);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetMemberById), new { id = newTeamMember.Id }, newTeamMember);
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMember(int id, [FromBody] UpdateMemberDto updateMemberDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TeamMember member = await _unitOfWork.TeamMembers.GetByIdAsync(id);

            if (member == null)
                return NotFound();

            // Check if the email is being changed
            if (member.Email != updateMemberDto.Email)
            {
                if (await _unitOfWork.TeamMembers.EmailExistsAsync(updateMemberDto.Email, id))
                {
                    return BadRequest(new { Message = "This email is already in use." });
                }
            }

            member.Name = updateMemberDto.Name;
            member.Email = updateMemberDto.Email;

            _unitOfWork.TeamMembers.Update(member);
            await _unitOfWork.CompleteAsync();

            return Ok(member);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveMember(int id)
        {
            var member = await _unitOfWork.TeamMembers.GetByIdAsync(id);

            if (member == null)
                return NotFound();

            _unitOfWork.TeamMembers.Remove(member);
            await _unitOfWork.CompleteAsync();

            return Ok(new { Message = "Team member is deleted successfully." });
        }
    }
}
