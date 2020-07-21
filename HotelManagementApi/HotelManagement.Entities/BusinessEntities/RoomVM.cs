using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Entities.BusinessEntities
{
    public class RoomVM
    {
        [Key]
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public int Pincode { get; set; }
        public string City { get; set; }
        public string RoomName { get; set; }
        public string RoomCategory { get; set; }
        public Nullable<int> RoomPrice { get; set; }
    }
}
