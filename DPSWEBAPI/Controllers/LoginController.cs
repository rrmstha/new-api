using DPSWEBAPI.Data;
using DPSWEBAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPSWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserDbContext _context;
        public LoginController(UserDbContext userDbContext)
        {
            _context = userDbContext;
        }
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var userDetails = _context.userModels.AsQueryable();
            return Ok(userDetails);
        }
        [HttpPost("signup")]
        public IActionResult SignUp([FromBody] UserModel userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            else
            {
                _context.userModels.Add(userObj);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Signup Successfully"
                });
            }
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserModel userObj)
        {
            if (userObj == null)
            {
                return BadRequest();

            }
            else
            {
                var user = _context.userModels.Where(a =>
                a.Username == userObj.Username
                && a.Password == userObj.Password).FirstOrDefault();
                if (user != null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Logged In Successfully",
                        
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "User Not Found"
                    });
                }
            }
        }
    }
}
