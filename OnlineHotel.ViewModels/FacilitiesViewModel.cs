using OnlineHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineHotel.ViewModels
{
    public class FacilitiesViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public FacilitiesViewModel()
        {

        }
        public FacilitiesViewModel(RoomFacilities model)
        {
            Id = model.Id;
            Title = model.Title;
            RoomId = model.RoomId;
            Room = model.Room;

        }
        public RoomFacilities ConvertViewModel(FacilitiesViewModel model)
        {
            return new RoomFacilities
            {
                Id = model.Id,
                Title = model.Title,
                RoomId = model.RoomId,
                Room = model.Room
        };
        }
    }
}
