using HotelManagement.Entities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BL.Interfaces
{
    public interface IHotelBL
    {
        List<HotelLocationVM> GetHotelAscending();
        List<HotelRoomVM> CreateHotelsAndRooms(List<HotelRoomVM> hotelRoomVM);
    }
}
