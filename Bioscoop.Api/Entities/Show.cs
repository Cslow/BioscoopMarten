namespace Bioscoop.Api.Entities
{
    public class Show
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDateTime { get; set; }
    }
}
