using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobOpeningsTracker.Entities
{
	public class JobApplicationEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public int Phone { get; set; }
        public byte[] FileResume { get; set; } = Array.Empty<byte>();
        public string UrlResume { get; set; } = string.Empty;
        [Required]
        public string Referral { get; set; }

        [ForeignKey("JobEntity")]
        public JobEntity Job { get; set; }
        public int JobEntityId { get; set; }



        public JobApplicationEntity(string name, string? email, int phone, string referral)
		{
            Name = name;
            Email = email;
            Phone = phone;
            Referral = referral;
		}
	}
}

