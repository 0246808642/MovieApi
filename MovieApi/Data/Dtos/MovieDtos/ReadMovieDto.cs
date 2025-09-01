using System.ComponentModel.DataAnnotations;

namespace MovieApi.Data.Dtos.MovieDtos;

public class ReadMovieDto
{

    public string Title { get; set; }
    public string Genre { get; set; }
    public int Duration { get; set; }
    public DateTime HourConsult { get; set; } = DateTime.Now;
}
