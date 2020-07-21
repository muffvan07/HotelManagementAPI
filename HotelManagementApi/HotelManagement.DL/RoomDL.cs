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
    public class RoomDL
    {
        public List<RoomVM> GetRooms()
        {
            List<RoomVM> roomVMs = new List<RoomVM>();
            var roomVM = new RoomVM();
            using (var db = new HotelManagementDbEntities())
            {
                var rooms = db.tbl_Room.OrderBy(x => x.RoomPrice).ToList();
                var mapper = ModelMapping.MappingConfig();
                foreach (var room in rooms)
                {
                    roomVM = mapper.Map<tbl_Room, RoomVM>(room);
                    roomVMs.Add(roomVM);
                }
                return roomVMs;
            }
        }

        public bool CheckRoomName(string roomName)
        {
            using (var db = new HotelManagementDbEntities())
            {
                return db.tbl_Room.Where(x => x.RoomName == roomName).Any();
            }
        }

        //if isActive is true, returns false (room not available because it is active)
        //else returns true
        public bool? IsRoomAvailable(List<int> ids)
        {
            using (var db = new HotelManagementDbEntities())
            {
                bool isAvailable = false;
                foreach (var id in ids)
                {

                    isAvailable = db.tbl_Room.Where(x => x.RoomId == id && x.IsActive == false).Any();
                    if (isAvailable)
                        return true;
                }
                return false;
            }
        }
    }
}
