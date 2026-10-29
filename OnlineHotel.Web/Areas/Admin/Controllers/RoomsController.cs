using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineHotel.Services;
using OnlineHotel.Utility;
using OnlineHotel.ViewModels;

namespace OnlineHotel.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomsController : Controller
    {
        IWebHostEnvironment env;

        private IRoomService _roomService;
        private IRoomTypeService _roomTypeService;


        public RoomsController(IRoomService roomService, IWebHostEnvironment env, IRoomTypeService roomTypeService)
        {
            _roomService = roomService;
            this.env = env;
            _roomTypeService = roomTypeService;
        }
        public IActionResult Index(int pageNumner = 1, int pageSize = 10)
        {
            PagedResult<RoomViewModel> vm = _roomService.GetAll(pageNumner, pageSize);
            return View(vm);
            
        }


        public IActionResult Edit(int id)
        {
            var viewModel = _roomService.GetRoom(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(RoomViewModel vm)
        {
            _roomService.UpdateRoom(vm);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Create()
        {
           
            ViewBag.RoomTypes = new SelectList(_roomTypeService.AllRoomTypes(), "Id", "Name");
            return View();
        }
        [HttpPost]

        public IActionResult Create(RoomViewModel vm)
        {
            if (vm.RoomPictureFile!=null)
            {
                ImageOperations image = new ImageOperations(env);
                string ImageFileName = image.UploadImage(vm);
                vm.RoomPicture = ImageFileName;

            }
            else
            {
                vm.RoomPicture = "~/Images/Hoteldemo.jpg";
            }

            _roomService.InsertRoom(vm);
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            _roomService.DeleteRoom(id);
            return RedirectToAction("Index");
        }
    }
}
