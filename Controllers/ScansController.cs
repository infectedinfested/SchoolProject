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
    public class ScansController : ControllerBase
    {
        private readonly IScanRepository _repo;
        private readonly IMapper _mapper;

        public ScansController(IScanRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetScans()
        {
            var scan = await _repo.GetScans();
            var dtos = _mapper.Map<IEnumerable<ScanDto>>(scan);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetScan(int id)
        {
            var scan = await _repo.GetScan(id);
            var dto = _mapper.Map<ScanDto>(scan);
            return Ok(dto);
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateScan(ScanDto scanDto)
        {
            var scan = _mapper.Map<Scan>(scanDto);
            _repo.Add(scan);
            await _repo.SaveAll();
            return Ok();
        }

    }
}
