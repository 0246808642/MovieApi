using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Data.Dtos.SessionDtos;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly IMapper _mapper;

        public SessionController(MovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var sessions = await _context.Sessions.ToListAsync();
            if (sessions == null || !sessions.Any())
            {
                return NotFound("Não tem sessãoes.");
            }
            var sessionDtos = _mapper.Map<List<ReadSessionDto>>(sessions);
            return Ok(sessionDtos);
        }

        [HttpGet("{movieId}/{cinemaId}")]
        public async Task<IActionResult> GetId(int movieId, int cinemaId)
        {
            var session = await _context.Sessions.FirstOrDefaultAsync(x=>x.MovieId == movieId && x.CinemaId == cinemaId);
            if (session == null) return NotFound("Sessão não encontrada.");
            var sessionDto = _mapper.Map<ReadSessionDto>(session);
            return Ok(sessionDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSessionDto create)
        {
            var session = _mapper.Map<Session>(create);
            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetId), new { movieId = session.MovieId , cinemaId = session.CinemaId }, session);
        }

   
    }
}
