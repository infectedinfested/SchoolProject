using AutoMapper;
using SchoolProject.DTOs;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();

            CreateMap<Excursion, ExcursionDto>();
            CreateMap<ExcursionDto, Excursion>();

            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherDto, Teacher>();
            //CreateMissingTypeMaps = true;
        }
    }
}
