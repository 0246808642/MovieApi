namespace MovieApi.Data.Dtos.CinemaDtos
{
    public class ReadCinemaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LastHourConsult { get; set; }= DateTime.Now;
    }
}
