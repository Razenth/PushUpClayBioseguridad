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
//1. CarpetaApiNombre
//2. NombreEntidad
//3. Nombre en UnitOfWork, generalmente en plural
{
    public class TipoPersonaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly BioContext _context;

        public TipoPersonaController(IUnitOfWork unitOfWork, IMapper mapper, BioContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoPersonaDto>>> Get()
        {
            var result = await _unitOfWork.TipoPersonas.GetAllAsync();
            return _mapper.Map<List<TipoPersonaDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoPersonaDto>> Get(int id)
        {
            var result = await _unitOfWork.TipoPersonas.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<TipoPersonaDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoPersona>> Post(TipoPersonaDto TipoPersonaDto)
        {
            var result = _mapper.Map<TipoPersona>(TipoPersonaDto);
            this._unitOfWork.TipoPersonas.Add(result);
            await _unitOfWork.SaveAsync();

            if (result == null)
            {
                return BadRequest();
            }
            TipoPersonaDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = TipoPersonaDto.Id }, TipoPersonaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoPersonaDto>> Put(int id, [FromBody] TipoPersonaDto TipoPersonaDto)
        {
            if (TipoPersonaDto.Id == 0)
            {
                TipoPersonaDto.Id = id;
            }

            if(TipoPersonaDto.Id != id)
            {
                return BadRequest();
            }

            if(TipoPersonaDto == null)
            {
                return NotFound();
            }

             // Por si requiero la fecha actual
            /*if (TipoPersonaDto.Fecha == DateTime.MinValue)
            {
                TipoPersonaDto.Fecha = DateTime.Now;
            }*/

            var result = _mapper.Map<TipoPersona>(TipoPersonaDto);
            _unitOfWork.TipoPersonas.Update(result);
            await _unitOfWork.SaveAsync();
            return TipoPersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.TipoPersonas.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.TipoPersonas.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}