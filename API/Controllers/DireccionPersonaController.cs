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
    public class DireccionPersonaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly BioContext _context;

        public DireccionPersonaController(IUnitOfWork unitOfWork, IMapper mapper, BioContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DireccionPersonaDto>>> Get()
        {
            var result = await _unitOfWork.DireccionPersonas.GetAllAsync();
            return _mapper.Map<List<DireccionPersonaDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DireccionPersonaDto>> Get(int id)
        {
            var result = await _unitOfWork.DireccionPersonas.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<DireccionPersonaDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DireccionPersona>> Post(DireccionPersonaDto DireccionPersonaDto)
        {
            var result = _mapper.Map<DireccionPersona>(DireccionPersonaDto);
            this._unitOfWork.DireccionPersonas.Add(result);
            await _unitOfWork.SaveAsync();

            if (result == null)
            {
                return BadRequest();
            }
            DireccionPersonaDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = DireccionPersonaDto.Id }, DireccionPersonaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DireccionPersonaDto>> Put(int id, [FromBody] DireccionPersonaDto DireccionPersonaDto)
        {
            if (DireccionPersonaDto.Id == 0)
            {
                DireccionPersonaDto.Id = id;
            }

            if(DireccionPersonaDto.Id != id)
            {
                return BadRequest();
            }

            if(DireccionPersonaDto == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<DireccionPersona>(DireccionPersonaDto);
            _unitOfWork.DireccionPersonas.Update(result);
            await _unitOfWork.SaveAsync();
            return DireccionPersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.DireccionPersonas.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.DireccionPersonas.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}