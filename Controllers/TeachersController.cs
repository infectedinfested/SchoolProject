using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Data;
using SchoolProject.DTOs;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _repo;
        private readonly IMapper _mapper;

        public TeachersController(ITeacherRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetTeachers()
        {
            var teachers = await _repo.GetTeachers();
            var dtos = _mapper.Map<IEnumerable<TeacherDto>>(teachers);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacher(int id)
        {
            var teacher = await _repo.GetTeacher(id);
            var dto = _mapper.Map<TeacherDto>(teacher);
            return Ok(dto);
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateTeacher(TeacherDto teacherDto)
        {
            var teacher = _mapper.Map<Student>(teacherDto);
            _repo.Add(teacher);
            await _repo.SaveAll();
            return Ok();
        }
    }
}
