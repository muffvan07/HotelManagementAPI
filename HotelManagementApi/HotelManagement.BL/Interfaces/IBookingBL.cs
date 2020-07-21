using HotelManagement.Entities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BL.Interfaces
{
    public interface IBookingBL
    {
        bool BookingDetails(BookingVM bookingVM);
        bool BookDateById(BookingVM bookingVM);
        bool DeleteBooking(int id);
    }
}
