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
    public class FacilityService : IFacilityService
    {
        private IUnitOfWork _unitOfWork;
        ILogger<FacilityService> _iLogger;

        public FacilityService(IUnitOfWork unitOfWork, ILogger<FacilityService> iLogger)
        {
            _unitOfWork = unitOfWork;
            _iLogger = iLogger;
        }

        private List<FacilitiesViewModel> ConvertModelToViewModelList(List<RoomFacilities> Facilities)
        {
            return Facilities.Select(x => new FacilitiesViewModel(x)).ToList();
        }

        public FacilitiesViewModel GetFacility(int Id)
        {
        var facility = _unitOfWork.GenericRepository<RoomFacilities>().GetById(Id);
        var vm = new FacilitiesViewModel(facility);
        return vm;
        }

        public void UpdateFacility(FacilitiesViewModel facility)
        {
            var model = new FacilitiesViewModel().ConvertViewModel(facility);
            _unitOfWork.GenericRepository<RoomFacilities>().Update(model);
            _unitOfWork.Save();
        }

        public void InsertFacility(FacilitiesViewModel facility)
        {

            var model = new FacilitiesViewModel().ConvertViewModel(facility);
            _unitOfWork.GenericRepository<RoomFacilities>().Add(model);
            _unitOfWork.Save();
        }

        public void DeleteFacility(int id)
        {
            var facility = _unitOfWork.GenericRepository<RoomFacilities>().GetById(id);

            _unitOfWork.GenericRepository<RoomFacilities>().Delete(facility);
            _unitOfWork.Save();
        }

        PagedResult<FacilitiesViewModel> IFacilityService.GetAll(int pageNumber, int PageSize)
        {
            var vm = new FacilitiesViewModel();
            int totalCount;
            List<FacilitiesViewModel> vmList = new List<FacilitiesViewModel>();
            try
            {
                int ExcludeRecords = (PageSize * pageNumber) - PageSize;


                var facility = _unitOfWork.GenericRepository<RoomFacilities>().GetAll(includeProperties: "Room")
                    .Skip(ExcludeRecords).Take(PageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<RoomFacilities>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(facility);



            }
            catch (Exception)
            {

                throw;
            }
            var result = new PagedResult<FacilitiesViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = PageSize

            };
            return result;
        }
    }
}
