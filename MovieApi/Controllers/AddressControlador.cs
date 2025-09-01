using AutoMapper;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Data.Dtos.AddressDtos;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressControlador : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly IMapper _mapper;

        public AddressControlador(MovieDbContext context, IMapper mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var address = await _context.Addresses.ToListAsync();
                if (address == null) return NotFound("Lista de Endereços vazia");

                var addressDto = _mapper.Map<List<ReadAddressDto>>(address);
                return Ok(addressDto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var address = await _context.Cinemas.FirstOrDefaultAsync(x => x.Id == id);
                if (address == null) return NotFound("Endereço não encontrado");

                var addressDto = _mapper.Map<ReadAddressDto>(address);
                return Ok(addressDto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAddressDto addressDto)
        {
            try
            {
                var address = _mapper.Map<Address>(addressDto);
                await _context.Addresses.AddAsync(address);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { Id = address.Id }, address);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateAddressDto addressDto)
        {
            try
            {
                var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);
                if (address == null) return NotFound("Endereço não encontrado");

                _mapper.Map(addressDto, address);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);
                if (address == null) return NotFound("Endereço não encontrado");

                _context.Remove(address);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch (int id, JsonPatchDocument<UpdateAddressDto> patch)
        {
            try
            {
                var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);
                if (address == null) return NotFound("Endereço não encontrado");

                var addressDto = _mapper.Map<UpdateAddressDto>(address);
                patch.ApplyTo(addressDto, ModelState);
                if (!TryValidateModel(addressDto))
                {
                    return ValidationProblem(ModelState);
                }
                _mapper.Map(addressDto, address);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
