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
    public class ExcursionsController : ControllerBase
    {
        private readonly IExcursionRepository _repo;
        private readonly IMapper _mapper;

        public ExcursionsController(IExcursionRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetExcursions()
        {
            var excursion = await _repo.GetExcursions();
            var dtos = _mapper.Map<IEnumerable<ExcursionDto>>(excursion);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExcursions(int id)
        {
            var excursion = await _repo.GetExcursion(id);
            var dto = _mapper.Map<ExcursionDto>(excursion);
            return Ok(dto);
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateExcursion(ExcursionDto excursionDto)
        {
            var excursion = _mapper.Map<Excursion>(excursionDto);
            _repo.Add(excursion);
            await _repo.SaveAll();
            return Ok();
        }
    }
}
