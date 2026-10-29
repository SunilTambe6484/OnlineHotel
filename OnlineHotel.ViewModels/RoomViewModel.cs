
using Microsoft.AspNetCore.Http;
using OnlineHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineHotel.ViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public int StatusId { get; set; }
        public RoomAvail Status { get; set; }
        public decimal RoomPrice { get; set; }
         public string RoomPicture { get; set; }
        public IFormFile RoomPictureFile { get; set; }

        public RoomViewModel()
        {

        }
        public RoomViewModel(Room model)
        {
            Id = model.Id;
            RoomNumber = model.RoomNumber;
            RoomTypeId = model.RoomTypeId;
            Status = model.Status;
            RoomPicture = model.RoomPicture;
            RoomPrice = model.Price;
            RoomType = model.RoomType;
        }
        public Room ConvertModel(RoomViewModel vm)
        {
            return new Room()
            {
                Id = vm.Id,
            RoomNumber = vm.RoomNumber,
            RoomTypeId = vm.RoomTypeId,
            Status = vm.Status,
            RoomPicture = vm.RoomPicture,
            Price = vm.RoomPrice,
            RoomType = vm.RoomType

             };
        }

    }
}
