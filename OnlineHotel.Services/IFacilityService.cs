using OnlineHotel.Utility;
using OnlineHotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineHotel.Services
{
    public interface IFacilityService
    {
        PagedResult<FacilitiesViewModel> GetAll(int pageNumber, int PageSize);
        FacilitiesViewModel GetFacility(int Id);
        void UpdateFacility(FacilitiesViewModel facility);
        void InsertFacility(FacilitiesViewModel facility);
        void DeleteFacility(int id);






    }
}
