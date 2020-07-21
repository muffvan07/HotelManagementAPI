using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Entities.BusinessEntities
{
    public class BookingVM
    {
        [Key]
        public int BookingId { get; set; }
        public Nullable<System.DateTime> BookingDate { get; set; }
        public int RoomId { get; set; }
        public string Status { get; set; }
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string RoomName { get; set; }
    }
}
