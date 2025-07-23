using exercise.models;
using exercise.wwwapi.DTOs.Responses;
using System;
using AutoMapper;
using Profile = AutoMapper.Profile;

namespace exercise.wwwapi.Tools
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<IEnumerable<User>, IEnumerable<UserDTO>>();

        }
    }
}
