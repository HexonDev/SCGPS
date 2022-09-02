namespace SCGPS.Domain.Dto
{
    public class MovieDto : BaseIdDto
    {
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public string Genre { get; set; }
        public string Actors { get; set; }
        public string PosterUrl { get; set; }
        public string Plot { get; set; }
        public string ImdbRating { get; set; }
        public float CurrentRating { get; set; }
        public float MaxRating { get; set; }
    }
}
