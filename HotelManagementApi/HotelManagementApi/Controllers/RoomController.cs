using HotelManagement.BL.Interfaces;
using HotelManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HotelManagementApi.Controllers
{
    [BasicAuth]

    [RoutePrefix("api")]
    public class RoomController : ApiController
    {
        private readonly IRoomBL _roomBL;

        public RoomController(IRoomBL roomBL)
        {
            _roomBL = roomBL;
        }


        [Route("room")]
        public IHttpActionResult GetAllRoom(int? price = null, int? pincode = null, string city = null, string category = null)
        {
            var res = _roomBL.FilterRooms(price, pincode, city, category);
            if (res == null)
                return BadRequest();
            else
                return Ok(res);
        }


        [HttpGet]
        [Route("room/available")]
        public IHttpActionResult IsRoomAvailable(DateTime date)
        {
            var res = _roomBL.GetAvailabilityStatus(date);
            return Ok(res);
        }
    }
}