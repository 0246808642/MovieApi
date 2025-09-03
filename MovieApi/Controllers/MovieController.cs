using AutoMapper;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Data.Dtos.MovieDtos;
using MovieApi.Models;

namespace MovieApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly MovieDbContext _context;
    private readonly IMapper _mapper;
  
    public MovieController(MovieDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
    {
        Movie movie = _mapper.Map<Movie>(movieDto);
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetId), new { id = movie.Id }, movie);

    }

    [HttpGet]
    public async Task<IActionResult> ListMovies(int skip = 0, int take = 10, [FromQuery] string? NameCinema = null)
    {
        if (NameCinema == null)
        {
           var name = _mapper.Map<List<ReadMovieDto>>(_context.Movies.Skip(skip).Take(take).ToList());
            return Ok(name);
        }
        var names =_mapper.Map<List<ReadMovieDto>>(_context.Movies.Skip(skip).Take(take).Where(x=>x.Sessions.Any(x=>x.Cinema.Name == NameCinema)).ToListAsync());
        return Ok(names);
    }

    [HttpGet("{id}")]
    public IActionResult GetId(int id)
    {
       var movieId = _context.Movies.FirstOrDefault(x=>x.Id==id);
        if (movieId == null) return NotFound("Não encontrado");
        var movieDto = _mapper.Map<ReadMovieDto>(movieId);
        return Ok(movieDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto movieDto)
    {
        var movieId = _context.Movies.FirstOrDefault(x=>x.Id == id);
        if(movieId == null)
        {
            return NotFound("Filme não encontrado");
        }
        _mapper.Map(movieDto, movieId);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateMovieParse(int id, JsonPatchDocument<UpdateMovieDto> path)
    {
        var movieId = _context.Movies.FirstOrDefault(x => x.Id == id);
        if (movieId == null)
        {
            return NotFound("Filme não encontrado");
        }

        var movieUpdate = _mapper.Map<UpdateMovieDto>(movieId);
        path.ApplyTo(movieUpdate, ModelState);

        if (!TryValidateModel(movieUpdate))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(movieUpdate, movieId);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        var movieId = _context.Movies.FirstOrDefault(x => x.Id == id);
        if (movieId == null)
        {
            return NotFound("Filme não encontrado");
        }
        _context.Remove(movieId);
        _context.SaveChanges();
        return NoContent();
    }
}
