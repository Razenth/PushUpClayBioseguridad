using Persistence.Data;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Controllers;

namespace API.Controller
{
    public class CategoriaPersonaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly BioContext _context;

        public CategoriaPersonaController(IUnitOfWork unitOfWork, IMapper mapper, BioContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CategoriaPersonaDto>>> Get()
        {
            var result = await _unitOfWork.CategoriaPersonas.GetAllAsync();
            return _mapper.Map<List<CategoriaPersonaDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoriaPersonaDto>> Get(int id)
        {
            var result = await _unitOfWork.CategoriaPersonas.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<CategoriaPersonaDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaPersona>> Post(CategoriaPersonaDto CategoriaPersonaDto)
        {
            var result = _mapper.Map<CategoriaPersona>(CategoriaPersonaDto);
            this._unitOfWork.CategoriaPersonas.Add(result);
            await _unitOfWork.SaveAsync();

            if (result == null)
            {
                return BadRequest();
            }
            CategoriaPersonaDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = CategoriaPersonaDto.Id }, CategoriaPersonaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoriaPersonaDto>> Put(int id, [FromBody] CategoriaPersonaDto CategoriaPersonaDto)
        {
            if (CategoriaPersonaDto.Id == 0)
            {
                CategoriaPersonaDto.Id = id;
            }

            if (CategoriaPersonaDto.Id != id)
            {
                return BadRequest();
            }

            if (CategoriaPersonaDto == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<CategoriaPersona>(CategoriaPersonaDto);
            _unitOfWork.CategoriaPersonas.Update(result);
            await _unitOfWork.SaveAsync();
            return CategoriaPersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.CategoriaPersonas.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.CategoriaPersonas.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}