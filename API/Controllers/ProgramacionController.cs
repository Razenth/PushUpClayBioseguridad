using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;

namespace API.Controller
{
    public class ProgramacionController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly BioContext _context;

        public ProgramacionController(IUnitOfWork unitOfWork, IMapper mapper, BioContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProgramacionDto>>> Get()
        {
            var result = await _unitOfWork.Programaciones.GetAllAsync();
            return _mapper.Map<List<ProgramacionDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProgramacionDto>> Get(int id)
        {
            var result = await _unitOfWork.Programaciones.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<ProgramacionDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Programacion>> Post(ProgramacionDto ProgramacionDto)
        {
            var result = _mapper.Map<Programacion>(ProgramacionDto);
            this._unitOfWork.Programaciones.Add(result);
            await _unitOfWork.SaveAsync();

            if (result == null)
            {
                return BadRequest();
            }
            ProgramacionDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = ProgramacionDto.Id }, ProgramacionDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProgramacionDto>> Put(int id, [FromBody] ProgramacionDto ProgramacionDto)
        {
            if (ProgramacionDto.Id == 0)
            {
                ProgramacionDto.Id = id;
            }

            if(ProgramacionDto.Id != id)
            {
                return BadRequest();
            }

            if(ProgramacionDto == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<Programacion>(ProgramacionDto);
            _unitOfWork.Programaciones.Update(result);
            await _unitOfWork.SaveAsync();
            return ProgramacionDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Programaciones.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.Programaciones.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}