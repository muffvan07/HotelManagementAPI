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
    [RoutePrefix("api")]
    public class BookingController : ApiController
    {
        private readonly IBookingBL _bookingBL;
        public BookingController(IBookingBL bookingBL)
        {
            _bookingBL = bookingBL;
        }


        [HttpPost]
        [Route("booking")]
        public IHttpActionResult BookRoomWithDate(BookingVM bookingVM)
        {
            var res = _bookingBL.BookingDetails(bookingVM);
            if (res == true)
                return Ok(res);
            else
                return BadRequest("Invalid HotelName or RoomName");
        }


        [HttpPut]
        [Route("update/date")]
        public IHttpActionResult UpdateBookingDate(BookingVM bookingVM)
        {
            var res = _bookingBL.BookDateById(bookingVM);
            if (res == true)
                return Ok("Booking updated!");
            else
                return BadRequest("Invalid Entry! Check Date or Id!");
        }


        [HttpPut]
        [Route("update/status")]
        public IHttpActionResult UpdateBookingStatus(BookingVM bookingVM)
        {
            var res = _bookingBL.BookDateById(bookingVM);
            if (res == true)
                return Ok("Booking updated!");
            else
                return BadRequest("Invalid Id!");
        }


        [Route("delete/booking")]
        public IHttpActionResult DeleteBooking(int id)
        {
            var res = _bookingBL.DeleteBooking(id);
            if (res != false)
                return Ok("Deleted!");
            else
                return BadRequest("Invalid id!");
        }
    }
}