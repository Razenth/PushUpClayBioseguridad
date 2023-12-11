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
    public class TurnoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly BioContext _context;

        public TurnoController(IUnitOfWork unitOfWork, IMapper mapper, BioContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TurnoDto>>> Get()
        {
            var result = await _unitOfWork.Turnos.GetAllAsync();
            return _mapper.Map<List<TurnoDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TurnoDto>> Get(int id)
        {
            var result = await _unitOfWork.Turnos.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<TurnoDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Turno>> Post(TurnoDto TurnoDto)
        {
            var result = _mapper.Map<Turno>(TurnoDto);
            this._unitOfWork.Turnos.Add(result);
            await _unitOfWork.SaveAsync();

            if (result == null)
            {
                return BadRequest();
            }
            TurnoDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = TurnoDto.Id }, TurnoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TurnoDto>> Put(int id, [FromBody] TurnoDto TurnoDto)
        {
            if (TurnoDto.Id == 0)
            {
                TurnoDto.Id = id;
            }

            if(TurnoDto.Id != id)
            {
                return BadRequest();
            }

            if(TurnoDto == null)
            {
                return NotFound();
            }

             // Por si requiero la fecha actual
            /*if (TurnoDto.Fecha == DateTime.MinValue)
            {
                TurnoDto.Fecha = DateTime.Now;
            }*/

            var result = _mapper.Map<Turno>(TurnoDto);
            _unitOfWork.Turnos.Update(result);
            await _unitOfWork.SaveAsync();
            return TurnoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Turnos.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.Turnos.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}