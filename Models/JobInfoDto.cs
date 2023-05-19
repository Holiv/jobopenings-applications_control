using System;
namespace JobOpeningsTracker.Models
{
	public class JobInfoDto
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string? Description { get; set; }
		public DateTime OpeningDate { get; set; }
		public DateTime CloseDate { get; set; }
		public int ApplicationCount
		{
			get => JobAplication.Count;
		}
		public ICollection<JobApplicationDto> JobAplication { get; set; } = new List<JobApplicationDto>();

		//public JobInfoDto()
		//{
		//}
	}
}

