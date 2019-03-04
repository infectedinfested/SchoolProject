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
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _repo;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _repo.GetStudents();
            var dtos = _mapper.Map<IEnumerable<StudentDto>>(students);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _repo.GetStudent(id);
            var dto = _mapper.Map<StudentDto>(student);
            return Ok(dto);
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateStudent(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            _repo.Add(student);
            await _repo.SaveAll();
            return Ok();
        }
    }
}
