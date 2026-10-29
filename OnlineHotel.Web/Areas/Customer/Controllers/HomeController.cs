using Microsoft.AspNetCore.Mvc;
using OnlineHotel.Services;
using OnlineHotel.Utility;
using OnlineHotel.ViewModels;

namespace OnlineHotel.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private IRoomService _roomService;
        private IRoomTypeService _roomTypeService;

        public HomeController(IRoomService roomService, 
            IRoomTypeService roomTypeService)
        {
            _roomService = roomService;
            _roomTypeService = roomTypeService;
        }

        public IActionResult Index(int pageNumner = 1, int pageSize = 8)
        {
            PagedResult<RoomViewModel> vm = _roomService.GetAll(pageNumner, pageSize);
            return View(vm);
        }
    }
}
