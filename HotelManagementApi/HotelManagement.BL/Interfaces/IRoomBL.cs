using HotelManagement.Entities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BL.Interfaces
{
    public interface IRoomBL
    {
        List<RoomVM> FilterRooms(int? price, int? pincode, string city, string category);
        bool GetAvailabilityStatus(DateTime date);
    }
}
