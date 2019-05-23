using AutoMapper;
using LoadFiles.Core.Models;
using LoadFiles.Core.Models.Resources;

namespace LoadFiles.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //  Model => Resource
            CreateMap<User, UserResource>();
            CreateMap<File, FileResource>();

            //  Resource => Model
        }
    }
}