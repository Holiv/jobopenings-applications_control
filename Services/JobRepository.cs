using System;
using JobOpeningsTracker.DbContexts;
using JobOpeningsTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobOpeningsTracker.Services
{
	public class JobRepository : IJobRepository
	{
        private readonly JobsContext _jobsContext;

        public JobRepository(JobsContext jobsContext)
		{
			_jobsContext = jobsContext;
		}

        public async Task AddJobApplicationAsync(int jobId, JobApplicationEntity jobApplicationEntity)
        {
            var job = await GetJobAsync(jobId, false) ?? throw new ArgumentException(null, nameof(jobId));
            job.JobAplication.Add(jobApplicationEntity);

        }

        public async Task AddJobApplicationResume(int jobId, int applicationId, IFormFile resume)
        {
            var jobApplication = await GetJobApplicationAsync(jobId, applicationId);
            byte[] resumeToByte = await ConvertResumeToByte(resume);
            //string resumeDownloadPath = GetDownloadPath(jobId, jobApplication);

            jobApplication.FileResume = resumeToByte;
            //jobApplication.UrlResume = resumeDownloadPath;
        }

        public string GetDownloadPath(int jobId, JobApplicationEntity jobApplication)
        {
            //var applicationId = await GetJobApplicationAsync(jobId);
            var urlResume = jobApplication.UrlResume = $"https://localhost:7242/api/{jobId}/applications/{jobApplication.Id}/resume";
            return urlResume;
        }

        public async Task<JobEntity?> GetJobAsync(int jobId, bool includeApplications)
        {
            if (includeApplications)
            {
                return await _jobsContext.Jobs
                .Include(job => job.JobAplication)
                .Where(job => job.Id == jobId).FirstOrDefaultAsync();
            }
            return await _jobsContext.Jobs.Where(job => job.Id == jobId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<JobEntity>> GetJobsAsync()
        {
            return await _jobsContext.Jobs.Include(job => job.JobAplication).ToListAsync();
        }

        public async Task<byte[]> ConvertResumeToByte(IFormFile resume)
        {
            if (resume.Length < 0) throw new ArgumentNullException(nameof(resume));

            await using var memoryStream = new MemoryStream();
            await resume.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }

        public async Task<IEnumerable<JobApplicationEntity>> GetJobApplicationsAsync(int jobId)
        {
            var jobEntity = await GetJobAsync(jobId, true) ?? throw new ArgumentException(nameof(jobId));
            return jobEntity.JobAplication;
        }

        public async Task SaveChangesAsync()
        {
            await _jobsContext.SaveChangesAsync();
        }

        public async Task<JobApplicationEntity> GetJobApplicationAsync(int jobId, int jobApplicationId)
        {
            return await _jobsContext.JobApplication.Where(jobApp => jobApp.Job.Id == jobId && jobApp.Id == jobApplicationId).FirstOrDefaultAsync()
                ?? throw new ArgumentException();
        }

        public async Task AddJobAsync(JobEntity jobEntity)
        {
            _jobsContext.Add(jobEntity);
            await SaveChangesAsync();
        }

        public void RemoveJobApplication(JobApplicationEntity jobApplication)
        {
            _jobsContext.JobApplication.Remove(jobApplication);

        }
    }
}

