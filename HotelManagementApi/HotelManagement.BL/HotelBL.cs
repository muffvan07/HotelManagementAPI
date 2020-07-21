using HotelManagement.BL.Interfaces;
using HotelManagement.DL;
using HotelManagement.Entities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BL
{
    public class HotelBL : IHotelBL
    {
        readonly HotelDL hotelDL = new HotelDL();

        public List<HotelLocationVM> GetHotelAscending()
        {
            var hotels = hotelDL.GetHotelAscending();
            return hotels;
        }
        public List<HotelRoomVM> CreateHotelsAndRooms(List<HotelRoomVM> hotelRoomVM)
        {
            hotelRoomVM.ForEach(x => x.CreatedDate = DateTime.Now);
            hotelRoomVM.ForEach(x => x.Rooms.ForEach(p => p.CreatedDate = DateTime.Now));
            return hotelDL.CreateHotelsAndRooms(hotelRoomVM);
        }
    }
}
