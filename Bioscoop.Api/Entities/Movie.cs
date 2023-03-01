namespace Bioscoop.Api.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string ImageURL { get; set; }
        public int PlayTime { get; set; }
        public int MinimumAge { get; set; }
    }
}
