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
    public class EstadoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly BioContext _context;

        public EstadoController(IUnitOfWork unitOfWork, IMapper mapper, BioContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EstadoDto>>> Get()
        {
            var result = await _unitOfWork.Estados.GetAllAsync();
            return _mapper.Map<List<EstadoDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoDto>> Get(int id)
        {
            var result = await _unitOfWork.Estados.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<EstadoDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Estado>> Post(EstadoDto EstadoDto)
        {
            var result = _mapper.Map<Estado>(EstadoDto);
            this._unitOfWork.Estados.Add(result);
            await _unitOfWork.SaveAsync();

            if (result == null)
            {
                return BadRequest();
            }
            EstadoDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = EstadoDto.Id }, EstadoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoDto>> Put(int id, [FromBody] EstadoDto EstadoDto)
        {
            if (EstadoDto.Id == 0)
            {
                EstadoDto.Id = id;
            }

            if(EstadoDto.Id != id)
            {
                return BadRequest();
            }

            if(EstadoDto == null)
            {
                return NotFound();
            }

             // Por si requiero la fecha actual
            /*if (EstadoDto.Fecha == DateTime.MinValue)
            {
                EstadoDto.Fecha = DateTime.Now;
            }*/

            var result = _mapper.Map<Estado>(EstadoDto);
            _unitOfWork.Estados.Update(result);
            await _unitOfWork.SaveAsync();
            return EstadoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Estados.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.Estados.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}