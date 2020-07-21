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
    public class BookingBL : IBookingBL
    {
        readonly BookingDL bookingDL = new BookingDL();
        public bool BookingDetails(BookingVM bookingVM)
        {
            //check hotel name and room name

            HotelDL hotelDL = new HotelDL();
            RoomDL roomDL = new RoomDL();

            bool isExistHotelName = hotelDL.CheckHotelName(bookingVM.HotelName);
            bool isExistRoomName = roomDL.CheckRoomName(bookingVM.RoomName);

            if (isExistHotelName == true && isExistRoomName == true)
            {
                int hotelId = hotelDL.GetHotelAscending()
                .Where(x => x.HotelName == bookingVM.HotelName)
                .Select(x => x.HotelId)
                .FirstOrDefault(); ;

                int roomId = roomDL.GetRooms()
                    .Where(x => x.RoomName == bookingVM.RoomName && x.HotelId == hotelId)
                    .Select(x => x.RoomId)
                    .FirstOrDefault(); ;

                bookingVM.HotelId = hotelId;
                bookingVM.RoomId = roomId;

                List<BookingVM> bookingVMs = new List<BookingVM>();
                bookingVMs.Add(bookingVM);
                bool saveStatus = bookingDL.SaveBookings(bookingVM);
                return saveStatus;
            }
            return false;
        }

        public bool BookDateById(BookingVM bookingVM)
        {
            int bookingId = bookingVM.BookingId;
            DateTime? updatedBookingDate = bookingVM.BookingDate;
            string updatedBookingStatus = bookingVM.Status;

            if (updatedBookingDate != null)
            {
                var booking = bookingDL.UpdateBookingDetails(bookingId, updatedBookingDate);
                if (booking != false)
                    return true;
            }
            if (updatedBookingStatus != null)
            {
                var booking = bookingDL.UpdateBookingDetails(bookingId, updatedBookingStatus);
                if (booking != false)
                    return true;
            }
            return false;
        }
        public bool DeleteBooking(int id)
        {
            bool respose = bookingDL.DeleteBooking(id);
            if (respose != false)
                return true;
            else
                return false;
        }
    }
}
