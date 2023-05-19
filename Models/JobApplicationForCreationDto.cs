using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobOpeningsTracker.Models
{
	public class JobApplicationForCreationDto
	{
		public string? Name { get; set; }
		public string? Email { get; set; }
		public int Phone { get; set; }
		//[NotMapped]
		//public IFormFile? Resume { get; set; }
		public string? Referral { get; set; }

		//public JobApplicationDto()
		//{
		//}
	}
}

