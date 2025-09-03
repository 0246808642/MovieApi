using Microsoft.EntityFrameworkCore;
using MovieApi.Models;

namespace MovieApi.Data;

public class MovieDbContext : DbContext
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Session>().HasKey(x => new { x.MovieId, x.CinemaId });

        modelBuilder.Entity<Session>().HasOne(x=>x.Cinema).WithMany(x=>x.Sessions).HasForeignKey(x=>x.CinemaId);
        modelBuilder.Entity<Session>().HasOne(x=>x.Movie).WithMany(x=>x.Sessions).HasForeignKey(x=>x.MovieId);

        modelBuilder.Entity<Address>().HasOne(x => x.Cinema).WithOne(x => x.Address).OnDelete(DeleteBehavior.Restrict);
    }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Session> Sessions { get; set; }
}
