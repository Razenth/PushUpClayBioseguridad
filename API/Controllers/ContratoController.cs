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
    public class ContratoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly BioContext _context;

        public ContratoController(IUnitOfWork unitOfWork, IMapper mapper, BioContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ContratoDto>>> Get()
        {
            var result = await _unitOfWork.Contratos.GetAllAsync();
            return _mapper.Map<List<ContratoDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContratoDto>> Get(int id)
        {
            var result = await _unitOfWork.Contratos.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<ContratoDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Contrato>> Post(ContratoDto ContratoDto)
        {
            var result = _mapper.Map<Contrato>(ContratoDto);
            this._unitOfWork.Contratos.Add(result);
            await _unitOfWork.SaveAsync();

            if (result == null)
            {
                return BadRequest();
            }
            ContratoDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = ContratoDto.Id }, ContratoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContratoDto>> Put(int id, [FromBody] ContratoDto ContratoDto)
        {
            if (ContratoDto.Id == 0)
            {
                ContratoDto.Id = id;
            }

            if(ContratoDto.Id != id)
            {
                return BadRequest();
            }

            if(ContratoDto == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<Contrato>(ContratoDto);
            _unitOfWork.Contratos.Update(result);
            await _unitOfWork.SaveAsync();
            return ContratoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Contratos.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.Contratos.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}