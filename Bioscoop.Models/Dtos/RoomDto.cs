using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop.Models.Dtos
{
    public class RoomDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Seats { get; set; }
        public int Rows { get; set; }
        public bool WheelchairFriendly { get; set; }
    }
}
