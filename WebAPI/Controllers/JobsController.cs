using AutoMapper;
using DataAccess.EFCore.Repositories;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTOs.JobDTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public JobsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            try
            {
                var jobs = await _unitOfWork.Jobs.GetAllAsync();
                return Ok(jobs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetJobById(int id)
        {
            var job = await _unitOfWork.Jobs.GetByIdAsync(id);

            if (job == null)
                return NotFound($"No job with the id: {id} found!");

            return Ok(job);
        }


        [HttpPost]
        public async Task<IActionResult> AddJob([FromBody] CreateJobDto createJobDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newJob = new Job
            {
                Name = createJobDto.Name,
                Description = createJobDto.Description,
                Status = createJobDto.Status,
                StartDate = createJobDto.StartDate,
                EndDate = createJobDto.EndDate,
                TeamMemberId = createJobDto.TeamMemberId
            };

            await _unitOfWork.Jobs.AddAsync(newJob);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetJobById), new { id = newJob.Id }, newJob);
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateJob(int id, [FromBody] UpdateJobDto updateJobDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var job = await _unitOfWork.Jobs.GetByIdAsync(id);

            if (job == null)
                return NotFound();

            // Map only the non-null values from updateJobDto to job
            _mapper.Map(updateJobDto, job);

            _unitOfWork.Jobs.Update(job);
            await _unitOfWork.CompleteAsync();

            return Ok(job);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveJob(int id)
        {
            var job = await _unitOfWork.Jobs.GetByIdAsync(id);

            if (job == null)
                return NotFound();

            _unitOfWork.Jobs.Remove(job);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
