using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Data.Dtos.CinemaDtos;
using MovieApi.Models;

namespace MovieApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    private readonly MovieDbContext _context;
    private readonly IMapper _mapper;
    public CinemaController(MovieDbContext context, IMapper mapper)
    {
        _context= context;
        _mapper= mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        try
        {
            var cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetId), new { Id = cinema.Id }, cinema);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetId(int id)
    {
        try
        {
            var cinema = await _context.Cinemas.FirstOrDefaultAsync(x => x.Id == id);
            if (cinema == null) return NotFound("Cinema não encontrado");

            var cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            return Ok(cinemaDto);
        }
        catch
        (Exception)
        {
            return StatusCode(500, "Internal server error");
        }

    }

    [HttpGet]
    public async Task<IActionResult> GetCinema(int skip = 0, int take = 10)
    {
        try
        {
            var cinemas = await _context.Cinemas.ToListAsync();
            if (cinemas == null) return NotFound("Nenhum cinema encontrado");

            var cinemaDtos = _mapper.Map<List<ReadCinemaDto>>(cinemas);
            return Ok(cinemaDtos);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        try
        {
            var cinema = await _context.Cinemas.FirstOrDefaultAsync(x => x.Id == id);
            if (cinema == null) return NotFound("Cinema não encontrado");

            _mapper.Map(cinemaDto, cinema);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }
    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchCinema(int id, JsonPatchDocument<UpdateCinemaDto> patch)
    {
        try
        {
            var cinema = await _context.Cinemas.FirstOrDefaultAsync(x => x.Id == id);
            if (cinema == null) return NotFound("Cinema não encontrado");

            var cinemaDto = _mapper.Map<UpdateCinemaDto>(cinema);
            patch.ApplyTo(cinemaDto, ModelState);
            if (!TryValidateModel(cinemaDto)) return ValidationProblem(ModelState);

            _mapper.Map(cinemaDto, cinema);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCinema(int id)
    {
        try
        {
            var cinema = await _context.Cinemas.FirstOrDefaultAsync(x => x.Id == id);
            if (cinema == null) return NotFound("Cinema não encontrado");
            _context.Remove(cinema);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }

}
