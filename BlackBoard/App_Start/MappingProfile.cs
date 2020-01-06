using AutoMapper;
using BlackBoard.Core.Dto;
using BlackBoard.Core.Models;
using BlackBoard.Core.Repositories;

namespace BlackBoard.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Student, StudentDto>();
            Mapper.CreateMap<Department, DepartmentDto>();
            Mapper.CreateMap<Teacher, TeacherDto>();
            Mapper.CreateMap<Specialization, SpecializationDto>();
            //Mapper.CreateMap<TeacherFormViewModel, Teacher>();
        }
    }
}