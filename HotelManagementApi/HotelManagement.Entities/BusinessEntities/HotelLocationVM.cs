using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Entities.BusinessEntities
{
    public class HotelLocationVM
    {
        [Key]
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string Location { get; set; }
    }
}
