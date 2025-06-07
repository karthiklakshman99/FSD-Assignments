using AuthenticationService.Exceptions;
using AuthenticationService.Models;
using AuthenticationService.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenGenService _tokenGenService;

        public AuthController(IAuthService authService, ITokenGenService tokenGenService)
        {
            _authService = authService;
            _tokenGenService = tokenGenService;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] User user)
        {
            try
            {
                bool isUserCreated = _authService.RegisterUser(user);

                if (isUserCreated)
                {
                    return StatusCode(StatusCodes.Status201Created, "User created successfully.");
                }

                return StatusCode(StatusCodes.Status409Conflict, "User already exists.");
            }
            catch (UserAlreadyExistsException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public IActionResult LoginUser([FromBody] User user)
        {
            try
            {
                bool isValidUser = _authService.LoginUser(user);

                if (isValidUser)
                {
                    string token = _tokenGenService.GenerateJwtToken(user.UserId);

                    return Ok(new { token });
                }

                return Unauthorized("Invalid credentials.");
            }
            catch (InvalidCredentialsException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
    }
}
