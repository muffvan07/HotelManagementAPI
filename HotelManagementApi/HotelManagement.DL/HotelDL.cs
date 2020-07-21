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
    public class HotelDL
    {
        public List<HotelLocationVM> GetHotelAscending()
        {
            List<HotelLocationVM> hotelVMs = new List<HotelLocationVM>();
            HotelLocationVM hotelVM = new HotelLocationVM();
            using (var db = new HotelManagementDbEntities())
            {
                var hotels = db.tbl_Hotel.OrderBy(x => x.HotelName).ToList();
                var mapper = ModelMapping.MappingConfig();

                foreach (var hotel in hotels)
                {
                    hotelVM = mapper.Map<tbl_Hotel, HotelLocationVM>(hotel);
                    hotelVMs.Add(hotelVM);
                }
                return hotelVMs;
            }
        }

        public bool CheckHotelName(string hotelName)
        {
            using (var db = new HotelManagementDbEntities())
            {
                return db.tbl_Hotel.Where(x => x.HotelName == hotelName).Any();
            }
        }

        public List<HotelRoomVM> CreateHotelsAndRooms(List<HotelRoomVM> hotelRooms)
        {
            using (var db = new HotelManagementDbEntities())
            {
                tbl_Hotel hotel = new tbl_Hotel();
                tbl_Room room = new tbl_Room();

                var mapper = ModelMapping.MappingConfig();
                foreach (var hotelRoom in hotelRooms)
                {
                    hotel = mapper.Map<HotelRoomVM, tbl_Hotel>(hotelRoom);
                    db.tbl_Hotel.Add(hotel);
                    db.SaveChanges();

                    foreach (var rooms in hotelRoom.Rooms)
                    {
                        rooms.HotelId = hotel.HotelId;
                        room = mapper.Map<Room, tbl_Room>(rooms);
                        db.tbl_Room.Add(room);
                        db.SaveChanges();
                    }
                }
                hotelRooms.ForEach(x => x.HotelId = hotel.HotelId);
                hotelRooms.ForEach(x => x.Rooms.ForEach(p => p.RoomId = room.RoomId));
                return hotelRooms;
            }
        }
    }
}
