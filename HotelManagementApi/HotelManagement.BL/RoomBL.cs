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
    public class RoomBL : IRoomBL
    {
        readonly RoomDL roomDL = new RoomDL();

        public List<RoomVM> FilterRooms(int? price, int? pincode, string city, string category)
        {
            var rooms = roomDL.GetRooms(); //returns list of rooms orderby price
            var querableRooms = rooms.AsQueryable();

            if (price != null && category != null && pincode != null && city != null)
            {
                querableRooms = querableRooms.Where(x => x.RoomPrice >= price && x.RoomCategory == category && x.Pincode == pincode && x.City == city);
            }
            else if (price == null && category != null && pincode != null && city != null)
            {
                querableRooms = querableRooms.Where(x => x.RoomCategory == category && x.Pincode == pincode && x.City == city);
            }
            else if (price != null && category == null && pincode != null && city != null)
            {
                querableRooms = querableRooms.Where(x => x.RoomPrice >= price && x.Pincode == pincode && x.City == city);
            }
            else if (price != null && category != null && pincode == null && city != null)
            {
                querableRooms = querableRooms.Where(x => x.RoomPrice >= price && x.RoomCategory == category && x.City == city);
            }
            else if (price != null && category != null && pincode != null && city == null)
            {
                querableRooms = querableRooms.Where(x => x.RoomPrice >= price && x.RoomCategory == category && x.Pincode == pincode);
            }
            else if (price == null && category == null && pincode != null && city != null)
            {
                querableRooms = querableRooms.Where(x => x.Pincode == pincode && x.City == city);
            }
            else if (price != null && category == null && pincode == null && city != null)
            {
                querableRooms = querableRooms.Where(x => x.RoomPrice >= price && x.City == city);
            }
            else if (price != null && category != null && pincode == null && city == null)
            {
                querableRooms = querableRooms.Where(x => x.RoomPrice >= price && x.RoomCategory == category);
            }
            else if (price == null && category != null && pincode == null && city != null)
            {
                querableRooms = querableRooms.Where(x => x.RoomCategory == category && x.City == city);
            }
            else if (price != null && category == null && pincode != null && city == null)
            {
                querableRooms = querableRooms.Where(x => x.RoomPrice >= price && x.Pincode == pincode);
            }
            else if (price == null && category != null && pincode != null && city == null)
            {
                querableRooms = querableRooms.Where(x => x.RoomCategory == category && x.Pincode == pincode);
            }
            else if (price == null && category == null && pincode == null && city != null)
            {
                querableRooms = querableRooms.Where(x => x.City == city);
            }
            else if (price != null && category == null && pincode == null && city == null)
            {
                querableRooms = querableRooms.Where(x => x.RoomPrice >= price);
            }
            else if (price == null && category != null && pincode == null && city == null)
            {
                querableRooms = querableRooms.Where(x => x.RoomCategory == category);
            }
            else if (price == null && category == null && pincode != null && city == null)
            {
                querableRooms = querableRooms.Where(x => x.Pincode == pincode);
            }

            rooms = querableRooms.ToList();
            return rooms;
        }

        public bool GetAvailabilityStatus(DateTime date)
        {
            BookingDL bookingDL = new BookingDL();
            List<int> roomId = bookingDL.GetRoomIds(date);
            bool? availableStatus = roomDL.IsRoomAvailable(roomId);
            if (availableStatus != false)
            {
                return true;
            }
            return false;
        }
    }
}
