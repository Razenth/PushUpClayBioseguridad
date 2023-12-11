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
    public class PersonaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly BioContext _context;

        public PersonaController(IUnitOfWork unitOfWork, IMapper mapper, BioContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> Get()
        {
            var result = await _unitOfWork.Personas.GetAllAsync();
            return _mapper.Map<List<PersonaDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonaDto>> Get(int id)
        {
            var result = await _unitOfWork.Personas.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<PersonaDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Persona>> Post(PersonaDto PersonaDto)
        {
            var result = _mapper.Map<Persona>(PersonaDto);
            this._unitOfWork.Personas.Add(result);
            await _unitOfWork.SaveAsync();

            if (result == null)
            {
                return BadRequest();
            }
            PersonaDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = PersonaDto.Id }, PersonaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonaDto>> Put(int id, [FromBody] PersonaDto PersonaDto)
        {
            if (PersonaDto.Id == 0)
            {
                PersonaDto.Id = id;
            }

            if(PersonaDto.Id != id)
            {
                return BadRequest();
            }

            if(PersonaDto == null)
            {
                return NotFound();
            }

             // Por si requiero la fecha actual
            /*if (PersonaDto.Fecha == DateTime.MinValue)
            {
                PersonaDto.Fecha = DateTime.Now;
            }*/

            var result = _mapper.Map<Persona>(PersonaDto);
            _unitOfWork.Personas.Update(result);
            await _unitOfWork.SaveAsync();
            return PersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Personas.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.Personas.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}