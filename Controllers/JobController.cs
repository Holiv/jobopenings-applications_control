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
    [Route("api/jobs")]
    public class JobController : Controller
    {
        public readonly IJobRepository _jobRepository;
        public readonly IMapper _mapper;

        public JobController(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        [Route("{jobId}")]
        [HttpGet]
        public async Task<ActionResult<JobInfoDto>> GetJob(int jobId)
        {
            var job = _mapper.Map<JobInfoDto>(await _jobRepository.GetJobAsync(jobId, false));
            return Ok(job);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobInfoDto>>> GetAllJobs()
        {
            var jobsEntities = await _jobRepository.GetJobsAsync();
            ICollection<JobInfoDto> jobsDto = _mapper.Map<ICollection<JobInfoDto>>(jobsEntities);

            var jobsResponse = new JobResponse(jobsDto); 

            return Ok(jobsResponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob(JobInfoWithoutApplicationDto jobInfoDto)
        {
            var jobEntity = _mapper.Map<JobEntity>(jobInfoDto);
            await _jobRepository.AddJobAsync(jobEntity);

            return Ok();
        }
    }
}

