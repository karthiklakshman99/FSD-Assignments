using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Exceptions;
using UserService.Models;
using UserService.Service;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult RegisterUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User data is invalid.");
            }

            var existingUser = _userService.GetUserById(user.UserId);
            if (existingUser != null)
            {
                return Conflict("User with the same ID already exists.");
            }

            var registeredUser = _userService.RegisterUser(user);
            return Created("Data Created successfully", $"{registeredUser}");
        }

        [HttpPut]
        [Route("api/user/{userId}")]
        public IActionResult UpdateUser(string userId, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data.");
            }

            var existingReminder = _userService.GetUserById(userId);
            if (existingReminder == null)
            {
                return NotFound($"User with ID {userId} not found.");
            }

            var updated = _userService.UpdateUser(userId, user);
            if (updated)
            {
                return Ok("User updated successfully.");
            }

            return StatusCode(500, "Failed to update user.");
        }

        [HttpDelete]
        [Route("api/user/{id}")]
        public IActionResult DeleteUser(string id)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            var result = _userService.DeleteUser(id);
            if (result)
            {
                return Ok("User deleted successfully.");
            }

            return StatusCode(500, "Failed to delete user.");
        }

        [HttpGet]
        [Route("api/user/{userId}")]
        public IActionResult GetUserById(string userId)
        {
            var user = _userService.GetUserById(userId);

            if (user == null)
            {
                return NotFound($"User with ID {userId} not found.");
            }

            return Ok(user);
        }
    }
}
