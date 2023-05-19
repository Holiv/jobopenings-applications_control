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

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return Ok("Hello World");
        //}

        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobsEntities = await _jobRepository.GetJobsAsync();

            return Ok(_mapper.Map<IEnumerable<JobInfoDto>>(jobsEntities));
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

