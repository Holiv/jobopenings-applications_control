using System;
using AutoMapper;
using JobOpeningsTracker.Entities;
using JobOpeningsTracker.Models;

namespace JobOpeningsTracker.Profiles
{
	public class JobProfiles : Profile
	{
		public JobProfiles()
		{
            CreateMap<JobEntity, JobInfoWithoutApplicationDto>();
            CreateMap<JobInfoWithoutApplicationDto, JobEntity>();
            CreateMap<JobEntity, JobInfoDto>();
        }
	}
}

