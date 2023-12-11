using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using Persistence.Data;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    public class ContactoPersonaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly BioContext _context;

        public ContactoPersonaController(IUnitOfWork unitOfWork, IMapper mapper, BioContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ContactoPersonaDto>>> Get()
        {
            var result = await _unitOfWork.ContactoPersonas.GetAllAsync();
            return _mapper.Map<List<ContactoPersonaDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactoPersonaDto>> Get(int id)
        {
            var result = await _unitOfWork.ContactoPersonas.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<ContactoPersonaDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactoPersona>> Post(ContactoPersonaDto ContactoPersonaDto)
        {
            var result = _mapper.Map<ContactoPersona>(ContactoPersonaDto);
            this._unitOfWork.ContactoPersonas.Add(result);
            await _unitOfWork.SaveAsync();

            if (result == null)
            {
                return BadRequest();
            }
            ContactoPersonaDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = ContactoPersonaDto.Id }, ContactoPersonaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactoPersonaDto>> Put(int id, [FromBody] ContactoPersonaDto ContactoPersonaDto)
        {
            if (ContactoPersonaDto.Id == 0)
            {
                ContactoPersonaDto.Id = id;
            }

            if(ContactoPersonaDto.Id != id)
            {
                return BadRequest();
            }

            if(ContactoPersonaDto == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<ContactoPersona>(ContactoPersonaDto);
            _unitOfWork.ContactoPersonas.Update(result);
            await _unitOfWork.SaveAsync();
            return ContactoPersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.ContactoPersonas.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.ContactoPersonas.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}