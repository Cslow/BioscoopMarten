using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop.Models.Dtos
{
    public class ShowToAddDto
    {
        public int MovieId { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDateTime { get; set; }
    }
}
