using Entities;
using Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;

namespace KeepNote.Controllers
{
    /*
     * As in this assignment, we are working with creating RESTful web service, hence annotate
     * the class with [ApiController] annotation and define the controller level route as per REST Api standard.
     */
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        /*
         * UserService should  be injected through constructor injection. Please note that we should not create service
         * object using the new keyword
        */
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /*
	     * Define a handler method which will create a specific user by reading the
	     * Serialized object from request body and save the user details in a User table
	     * in the database. This handler method should return any one of the status
	     * messages basis on different situations: 1. 201(CREATED) - If the user created
	     * successfully. 2. 409(CONFLICT) - If the userId conflicts with any existing
	     * user
	     * 
	     * 
	     * This handler method should map to the URL "/api/user/register" using HTTP POST
	     * method
	     */
        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] User user)
        {
            try
            {
                var createdUser = _userService.RegisterUser(user);
                return Created("", createdUser); // 201 Created
            }
            catch (Exception ex)
            {
                return Conflict(new { message = ex.Message }); // 409 Conflict
            }
        }

        /*
         * Define a handler method which will login a specific user by reading the
         * Serialized object from request body and validate the userId and Password
         * from User table in the database. This handler method should return any one of 
         * the status messages basis on different situations: 
         * 1. 200(OK) - If the user successfully logged in. 
         * 2. 404(NOTFOUND) -If the user with specified userId is not found.
         * 
         * This handler method should map to the URL "/api/user/login" using HTTP POST
         * method
         */
        [HttpPost("login")]
        public IActionResult ValidateUser(int userId, string password)
        {
            try
            {
                var isValidUser = _userService.ValidateUser(userId, password);
                if (isValidUser)
                {
                    return Ok(new { message = "User is valid and logged in successfully" });
                }
                return NotFound(new { message = "User not found" });
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /*
         * Define a handler method which will update a specific user by reading the
         * Serialized object from request body and save the updated user details in a
         * user table in database handle exception as well. This handler method should
         * return any one of the status messages basis on different situations: 1.
         * 200(OK) - If the user updated successfully. 2. 404(NOT FOUND) - If the user
         * with specified userId is not found. 
         * 
         * This handler method should map to the URL "/api/user/{id}" using HTTP PUT method.
         */
        [HttpPut("{id}")]
        public IActionResult UpdateUse(int id, [FromBody] User user)
        {
            try
            {
                bool updated = _userService.UpdateUser(id, user);
                if (updated)
                {
                    return Ok(new { message = "User updated successfully" });
                }
                return NotFound(new { message = "User not found" });
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
        /*
         * Define a handler method which will delete a user from a database.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the user deleted successfully from
         * database. 2. 404(NOT FOUND) - If the user with specified userId is not found.
         * 
         * This handler method should map to the URL "/api/user/{id}" using HTTP Delete
         * method" where "id" should be replaced by a valid userId without {}
         */
        [HttpPut("{id}")]
        public IActionResult DeleteUser(int userId)
        {
            try
            {
                var deleted = _userService.DeleteUser(userId);
                if (deleted)
                {
                    return Ok(new { message = "User deleted successfully" });
                }
                return NotFound(new { message = "User not found" });
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new { message = ex.Message }); ;
            }
        }
        /*
         * Define a handler method which will show details of a specific user handle
         * UserNotFoundException as well. This handler method should return any one of
         * the status messages basis on different situations: 1. 200(OK) - If the user
         * found successfully. 2. 404(NOT FOUND) - If the user with specified
         * userId is not found. This handler method should map to the URL "/api/user/{userId}"
         * using HTTP GET method where "id" should be replaced by a valid userId without
         * {}
         */

        [HttpGet("{userId}")]
        public IActionResult GetUserById(int userId)
        {
            try
            {
                User user = _userService.GetUserById(userId);
                return Ok(user);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
