using OnlineHotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineHotel.ViewModels
{
    public class RoomTypeViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public RoomTypeViewModel()
        {

        }
        public RoomTypeViewModel(RoomType model)
        {
            Id=model.Id;
            Name = model.Name;
        }
        public RoomType ConvertModel(RoomTypeViewModel vm)
        {
            return new RoomType()
            {
                Id = vm.Id,
                Name = vm.Name
            };
        }
    }
}
