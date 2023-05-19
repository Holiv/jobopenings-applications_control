using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JobOpeningsTracker.Entities;
using JobOpeningsTracker.Models;
using JobOpeningsTracker.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobOpeningsTracker.Controllers
{
    [ApiController]
    [Route("api/{jobId}/applications")]
    public class JobApplicationController : Controller
    {
        public readonly IJobRepository _jobRepository;
        public readonly IMapper _mapper;

        public JobApplicationController(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobApplicationDto>>> GetAllJobApplication(int jobId)
        {
            var jobsEntities = await _jobRepository.GetJobApplicationsAsync(jobId);
            return Ok(_mapper.Map<IEnumerable<JobApplicationDto>>(jobsEntities));
        }

        [Route("/{applicationId}")]
        [HttpGet]
        public async Task<ActionResult<JobApplicationDto>> GetJobApplication(int jobId, int applicationId)
        {
            var jobEntity = await _jobRepository.GetJobApplicationAsync(jobId, applicationId);
            return Ok(_mapper.Map<JobApplicationDto>(jobEntity));
        }

        [Route("/{applicationId}/resume")]
        [HttpGet]
        public async Task<ActionResult<int>> GetApplicationResume(int jobId, int applicationId)
        {
            var job = await _jobRepository.GetJobApplicationAsync(jobId, applicationId);
            byte[]? byteFile = job.FileResume;
            string fileType = "application/pdf";

            return File(byteFile, fileType, $"{job.Name}_resume");
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobApplication(int jobId, JobApplicationForCreationDto jobApplicationDto)
        {
            var jobApplicationEntity = _mapper.Map<JobApplicationEntity>(jobApplicationDto);
            await _jobRepository.AddJobApplicationAsync(jobId, jobApplicationEntity);
            await _jobRepository.SaveChangesAsync();

            return Ok();
        }

        [Route("/{applicationId}")]
        [HttpPost]
        public async Task<IActionResult> IncludeApplicationResume(int jobId, int applicationId, IFormFile resume)
        {
            await _jobRepository.AddJobApplicationResume(jobId, applicationId, resume);
            await _jobRepository.SaveChangesAsync();

            return Ok();
        }

        [Route("/{applicationId}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteJobApplication(int jobId, int applicationId)
        {
            var jobApplicationEntity = await _jobRepository.GetJobApplicationAsync(jobId, applicationId);
            _jobRepository.RemoveJobApplication(jobApplicationEntity);
            await _jobRepository.SaveChangesAsync();

            return NoContent();

        }
    }
}

