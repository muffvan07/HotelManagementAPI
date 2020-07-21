using HotelManagement.BL.Interfaces;
using HotelManagement.Entities.BusinessEntities;
using HotelManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HotelManagementApi.Controllers
{
    [BasicAuth]
    public class HotelController : ApiController
    {
        private readonly IHotelBL _hotelBL;
        public HotelController(IHotelBL hotelBL)
        {
            _hotelBL = hotelBL;
        }


        public IHttpActionResult GetHotelAscending()
        {
            var hotels = _hotelBL.GetHotelAscending();
            if (hotels == null)
                return BadRequest();
            else
                return Ok(hotels);
        }


        [HttpPost]
        public IHttpActionResult AddHotelsWithDifferentRooms(List<HotelRoomVM> hotelRoomVM)
        {
            var res = _hotelBL.CreateHotelsAndRooms(hotelRoomVM);
            return Ok(res);
        }
    }
}