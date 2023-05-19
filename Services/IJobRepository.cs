using System;
using JobOpeningsTracker.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace JobOpeningsTracker.Services
{
	public interface IJobRepository
	{
		Task AddJobAsync(JobEntity jobEntity);
		Task<IEnumerable<JobEntity>> GetJobsAsync();
		Task<JobEntity?> GetJobAsync(int jobId, bool includeJobApplications);
		Task AddJobApplicationAsync(int jobId, JobApplicationEntity jobApplicationEntity);
		Task AddJobApplicationResume(int jobId, int applicationId, IFormFile resume);
        Task<IEnumerable<JobApplicationEntity>> GetJobApplicationsAsync(int jobId);
		Task<JobApplicationEntity> GetJobApplicationAsync(int jobId, int JobApplicationId);
		void RemoveJobApplication(JobApplicationEntity jobApplication);

        Task SaveChangesAsync();
		
	}
}

