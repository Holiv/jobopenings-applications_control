using System;
namespace JobOpeningsTracker.Models
{
	public class JobInfoWithoutApplicationDto
	{
        public string Title { get; set; } = string.Empty;
        public string? Local { get; set; }
        public string[] Skills { get; set; } = Array.Empty<string>();
        public int YearsExperience { get; set; }
        public string? EnglishLevel { get; set; }
        public string? Description { get; set; }
        public DateTime OpeningDate { get; set; } = DateTime.UtcNow.Date;
        //public DateTime CloseDate { get; set; }

        // ---- Create a constructor to initiate the OpeningDate value
        // ---- Create the missing fields, as Skills and others.

    }
}

