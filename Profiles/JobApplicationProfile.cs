using System;
using AutoMapper;
using JobOpeningsTracker.Entities;
using JobOpeningsTracker.Models;

namespace JobOpeningsTracker.Profiles
{
	public class JobApplicationProfiles : Profile
	{
		public JobApplicationProfiles()
		{
			CreateMap<JobApplicationEntity, JobApplicationDto>();
			CreateMap<JobApplicationDto, JobApplicationEntity>();
			CreateMap<JobApplicationForCreationDto, JobApplicationEntity>();
		}
	}
}

