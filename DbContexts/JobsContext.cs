using System;
using JobOpeningsTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobOpeningsTracker.DbContexts
{
	public class JobsContext : DbContext
	{
		protected readonly IConfiguration Configuration;

		public JobsContext(IConfiguration _configuration)
		{
			Configuration = _configuration;
		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

		public DbSet<JobEntity> Jobs { get; set; } = null!;
		public DbSet<JobApplicationEntity> JobApplication { get; set; } = null!;
    }
}

