using System;
namespace JobOpeningsTracker.Models
{
	public class JobInfoWithoutApplicationDto
	{
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime CloseDate { get; set; }
    }
}

