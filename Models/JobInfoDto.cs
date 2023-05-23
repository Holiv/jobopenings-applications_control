using System;
namespace JobOpeningsTracker.Models
{
	public class JobInfoDto
	{
		// --- Change Id to GUID
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
        public string? Local { get; set; }
        public string[] Skills { get; set; } = Array.Empty<string>();
		public int YearsExperience { get; set; }
		public string? EnglishLevel { get; set; }
		public string? Description { get; set; }
		public DateTime OpeningDate { get; set; }
		public DateTime CloseDate { get; set; }
		public int ApplicationCount
		{
			get => JobAplication.Count;
		}
		public ICollection<JobApplicationDto> JobAplication { get; set; } = new List<JobApplicationDto>();

		// ---- Create missing fileds to match the actual Job fields
	}
}

