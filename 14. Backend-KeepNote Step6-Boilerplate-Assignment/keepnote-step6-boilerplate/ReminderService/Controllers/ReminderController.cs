using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReminderService.Exceptions;
using ReminderService.Models;
using ReminderService.Service;

namespace ReminderService.Controllers
{
    [ApiController]
    public class ReminderController : Controller
    {
        private readonly IReminderService _reminderService;
        public ReminderController(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }


        [HttpPost]
        [Route("api/reminder")]
        public IActionResult CreateCategory([FromBody] Reminder reminder)
        {
            if (reminder == null)
            {
                return BadRequest("Reminder data is invalid.");
            }

            var existingReminder = _reminderService.GetReminderById(reminder.Id);
            if (existingReminder != null)
            {
                return Conflict("Reminder with the same ID already exists.");
            }

            var createdReminder = _reminderService.CreateReminder(reminder);
            return Created("Data Created successfully", $"{createdReminder}");
        }

        [HttpDelete]
        [Route("api/reminder/{id}")]
        public IActionResult DeleteReminder(int id)
        {
            var category = _reminderService.GetReminderById(id);

            if (category == null)
            {
                return NotFound($"Reminder with ID {id} not found.");
            }

            var result = _reminderService.DeleteReminder(id);
            if (result)
            {
                return Ok("Reminder deleted successfully.");
            }

            return StatusCode(500, "Failed to delete reminder.");
        }

        [HttpPut]
        [Route("api/reminder/{id}")]
        public IActionResult UpdateReminder(int id, [FromBody] Reminder reminder)
        {
            if (reminder == null)
            {
                return BadRequest("Invalid reminder data.");
            }

            var existingReminder = _reminderService.GetReminderById(id);
            if (existingReminder == null)
            {
                return NotFound($"Reminder with ID {id} not found.");
            }

            var updated = _reminderService.UpdateReminder(id, reminder);
            if (updated)
            {
                return Ok("Reminder updated successfully.");
            }

            return StatusCode(500, "Failed to update reminder.");
        }

        [HttpGet]
        [Route("api/reminder/{userId}")]
        public IActionResult GetRemindersByUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID cannot be null or empty.");
            }

            var reminders = _reminderService.GetAllRemindersByUserId(userId);
            if (reminders == null || !reminders.Any())
            {
                return NotFound($"No reminders found for user ID {userId}.");
            }

            return Ok(reminders);
        }


        [HttpGet]
        [Route("api/reminder/{reminderId}")]
        public IActionResult GetReminderById(int reminderId)
        {
            var reminder = _reminderService.GetReminderById(reminderId);

            if (reminder == null)
            {
                return NotFound($"Reminder with ID {reminderId} not found.");
            }

            return Ok(reminder);
        }
    }
}
