using HotelManagement.DL.Mapping;
using HotelManagement.Entities.BusinessEntities;
using HotelManagement.Entities.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DL
{
    public class BookingDL
    {
        public bool SaveBookings(BookingVM bookingVMs)
        {
            tbl_Bookings booking = new tbl_Bookings();
            using (var db = new HotelManagementDbEntities())
            {
                if (bookingVMs.Status == null)
                {
                    bookingVMs.Status = "Optional";
                }
                var mapper = ModelMapping.MappingConfig();
                var booked = mapper.Map<BookingVM, tbl_Bookings>(bookingVMs);
                db.tbl_Bookings.Add(booked);
                db.SaveChanges();
                return true;
            }
        }

        public List<int> GetRoomIds(DateTime date)
        {
            using (var db = new HotelManagementDbEntities())
            {
                return db.tbl_Bookings.Where(x => x.BookingDate == date).Select(x => x.RoomId).ToList();
            }
        }

        public bool UpdateBookingDetails(int id, DateTime? updatedBookingDate)
        {
            using (var db = new HotelManagementDbEntities())
            {
                var exisitingBookingDetails = db.tbl_Bookings.Where(x => x.BookingId == id).FirstOrDefault();
                if (exisitingBookingDetails != null)
                {
                    exisitingBookingDetails.BookingDate = updatedBookingDate;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool UpdateBookingDetails(int id, string updatedBookingSatus)
        {
            using (var db = new HotelManagementDbEntities())
            {
                var exisitingBookingStatus = db.tbl_Bookings.Where(x => x.BookingId == id).FirstOrDefault();
                if (exisitingBookingStatus != null)
                {
                    exisitingBookingStatus.Status = updatedBookingSatus;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool DeleteBooking(int id)
        {
            using (var db = new HotelManagementDbEntities())
            {
                var booking = db.tbl_Bookings.Where(x => x.BookingId == id).FirstOrDefault();
                if (booking != null)
                {
                    booking.Status = "Deleted";
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
