namespace Bioscoop.Api.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Seats { get; set; }
        public int Rows { get; set; }
        public bool WheelchairFriendly { get; set; }
    }
}
