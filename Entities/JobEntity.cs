using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JobOpeningsTracker.Models;

namespace JobOpeningsTracker.Entities
{
	public class JobEntity
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public string Local { get; set; }
        [Required]
        public string[] Skills { get; set; }
        [Required]
        public int YearsExperience { get; set; }
        [Required]
        public string EnglishLevel { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime OpeningDate { get; set; }
        public DateTime CloseDate { get; set; }
        public ICollection<JobApplicationEntity> JobAplication { get; set; } = new List<JobApplicationEntity>();

        public JobEntity(string title, string local, string[] skills, int yearsExperience, string englishLevel, string description, DateTime openingDate)
		{
            Title = title;
            Local = local;
            Skills = skills;
            YearsExperience = yearsExperience;
            EnglishLevel = englishLevel;
            Description = description;
            OpeningDate = openingDate;
		}

        // ---- Create the missing fields to Match the DTO Class
	}
}

