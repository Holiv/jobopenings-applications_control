using System;
namespace JobOpeningsTracker.Models
{
	public class JobResponse
	{
		public IEnumerable<JobInfoDto> JobsList { get; set; }
		public int JobsListCount { get; }
		public JobResponse(IEnumerable<JobInfoDto> jobsList)
		{
			JobsList = jobsList;
			JobsListCount = jobsList.Count();
		}
	}
}

