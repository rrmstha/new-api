using DPSWEBAPI.Data;
using DPSWEBAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPSWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly UserDbContext _context;
        public BookingController(UserDbContext userDbContext)
        {
            _context = userDbContext;
        }
        [HttpPost("add_Booking")]
        public IActionResult AddNewBooking([FromBody ] BookingModel bookingObj)
        {
            if(bookingObj == null)
            {
                return BadRequest();
            }
            else
            {
                _context.bookingModels.Add(bookingObj);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "New Booking Added Successfully"
                });
            }
        }
        [HttpPut("update_booking")]
        public IActionResult UpdateBooking([FromBody] BookingModel bookingObj)
        {
            if(bookingObj == null)
            {
                return BadRequest();
            }
            var user = _context.bookingModels.AsNoTracking().FirstOrDefault(x => x.Id == bookingObj.Id);
            if(user == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "User Not Found"
                });
            }
            else
            {
                _context.Entry(bookingObj).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Booking Update Successfully"
                });
            }
        }
        [HttpDelete("delete_booking/{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var user = _context.bookingModels.Find(id);
            if(user == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "user not found"
                });
            }
            else
            {
                _context.Remove(user);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "BookingAPI Deleted"
                });
            }
        }
        [HttpGet("get_all_booking")]
        public IActionResult GetAllBooking()
        {
            var bookings = _context.bookingModels.AsQueryable();
            return Ok(new
            {
                StatusCode = 200,
                BookingDetails = bookings
            });
        }
        [HttpGet("get_booking/id")]
        public IActionResult GetBooking(int id)
        {
            var booking = _context.bookingModels.Find(id);
            if(booking == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "User Not Found"
                });
            }
            else
            {
                return Ok(new
                {
                    StatusCode = 200,
                    BookingDetail = booking
                });
            }
        }
    }
}
