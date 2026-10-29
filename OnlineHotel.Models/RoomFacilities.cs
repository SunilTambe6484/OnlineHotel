using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineHotel.Models
{
    public class RoomFacilities
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
