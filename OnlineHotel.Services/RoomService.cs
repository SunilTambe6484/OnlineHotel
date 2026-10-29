using Microsoft.Extensions.Logging;
using OnlineHotel.BLL.Repository;
using OnlineHotel.Models;
using OnlineHotel.Utility;
using OnlineHotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineHotel.Services
{
    public class RoomService : IRoomService
    {
        private IUnitOfWork _unitOfWork;
        ILogger<RoomService> _iLogger;

        public RoomService(IUnitOfWork unitOfWork, ILogger<RoomService> iLogger)
        {
            _unitOfWork = unitOfWork;
            _iLogger = iLogger;
        }

        public void DeleteRoom(int id)
        {
            var room = _unitOfWork.GenericRepository<Room>().GetById(id);

            _unitOfWork.GenericRepository<Room>().Delete(room);
            _unitOfWork.Save();
        }

        public PagedResult<RoomViewModel> GetAll(int pageNumber, int PageSize)
        {
            var vm = new RoomViewModel();
            int totalCount;
            List<RoomViewModel> vmList = new List<RoomViewModel>();
            try
            {
                int ExcludeRecords = (PageSize * pageNumber) - PageSize;


                var rooms = _unitOfWork.GenericRepository<Room>().GetAll(includeProperties: "RoomType")
                    .Skip(ExcludeRecords).Take(PageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Room>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(rooms);



            }
            catch (Exception)
            {

                throw;
            }
            var result = new PagedResult<RoomViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = PageSize

            };
            return result;
        }

        private List<RoomViewModel> ConvertModelToViewModelList(List<Room> rooms)
        {
            return rooms.Select(x => new RoomViewModel(x)).ToList();
        }

        public RoomViewModel GetRoom(int Id)
        {
            var room = _unitOfWork.GenericRepository<Room>().GetById(Id);
            var vm = new RoomViewModel(room);
            return vm;
        }

        public void InsertRoom(RoomViewModel room)
        {
            var model = new RoomViewModel().ConvertModel(room);
            _unitOfWork.GenericRepository<Room>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateRoom(RoomViewModel room)
        {
            var model = new RoomViewModel().ConvertModel(room);
            _unitOfWork.GenericRepository<Room>().Update(model);
            _unitOfWork.Save();
        }

        public IEnumerable<RoomViewModel> GetAllRoom()
        {
           
            
            List<RoomViewModel> vmList = new List<RoomViewModel>();
            try
            {
               
                var rooms = _unitOfWork.GenericRepository<Room>().GetAll()
                    .ToList();
                vmList = ConvertModelToViewModelList(rooms);
            }
            catch (Exception)
            {

                throw;
            }
            return vmList;
        }
    }
}
