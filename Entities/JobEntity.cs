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
        public string Description { get; set; }
        [Required]
        public DateTime OpeningDate { get; set; }
        public DateTime CloseDate { get; set; }


        public ICollection<JobApplicationEntity> JobAplication { get; set; } = new List<JobApplicationEntity>();

        public JobEntity(string title, string description, DateTime openingDate)
		{
            Title = title;
            Description = description;
            OpeningDate = openingDate;
		}
	}
}

