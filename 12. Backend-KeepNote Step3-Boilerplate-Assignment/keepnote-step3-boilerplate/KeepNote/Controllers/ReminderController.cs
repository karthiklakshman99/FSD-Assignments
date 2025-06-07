using Entities;
using Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;

namespace KeepNote.Controllers
{
    /*
    * As in this assignment, we are working with creating RESTful web service, hence annotate
    * the class with [ApiController] annotation and define the controller level route as per REST Api standard.
    */
    [ApiController]
    [Route("api/reminder")]
    public class ReminderController : ControllerBase
    {
        private readonly IReminderService _reminderService;
        /*
       * ReminderService should  be injected through constructor injection. Please note that we should not create service
       * object using the new keyword
       */
        public ReminderController(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        /*
	     * Define a handler method which will create a reminder by reading the
	     * Serialized reminder object from request body and save the reminder in
	     * reminder table in database. Please note that the reminderId has to be unique
	     * and userID should be taken as the reminderCreatedBy for the
	     * reminder. This handler method should return any one of the status messages
	     * basis on different situations: 1. 201(CREATED - In case of successful
	     * creation of the reminder 2. 409(CONFLICT) - In case of duplicate reminder ID
	     * 
	     * This handler method should map to the URL "/api/reminder" using HTTP POST
	     * method".
	     */

        [HttpPost]
        public IActionResult CreateReminder([FromBody] Reminder reminder)
        {
            try
            {
                var createdReminder = _reminderService.CreateReminder(reminder);
                return Created("", createdReminder); // 201 Created
            }
            catch (Exception ex)
            {
                return Conflict(new { message = ex.Message }); // 409 Conflict
            }
        }

        /*
         * Define a handler method which will delete a reminder from a database.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the reminder deleted successfully from
         * database. 2. 404(NOT FOUND) - If the reminder with specified reminderId is
         * not found. 
         * 
         * This handler method should map to the URL "/api/reminder/{id}" using HTTP Delete
         * method" where "id" should be replaced by a valid reminderId without {}
         */

        [HttpDelete("{id}")]
        public IActionResult DeleteReminder(int id)
        {
            var deleted = _reminderService.DeleteReminder(id);
            if (deleted)
            {
                return Ok(new { message = "Reminder deleted successfully" });
            }
            return NotFound(new { message = "Reminder not found" });
        }


        /*
         * Define a handler method which will update a specific reminder by reading the
         * Serialized object from request body and save the updated reminder details in
         * a reminder table in database handle ReminderNotFoundException as well.
         * This handler method should return any one of the status
         * messages basis on different situations: 1. 200(OK) - If the reminder updated
         * successfully. 2. 404(NOT FOUND) - If the reminder with specified reminderId
         * is not found. 
         * 
         * This handler method should map to the URL "/api/reminder/{id}" using HTTP PUT
         * method.
         */

        [HttpPut("{id}")]
        public IActionResult UpdateReminder(int id, [FromBody] Reminder reminder)
        {
            try
            {
                bool updated = _reminderService.UpdateReminder(id, reminder);
                if (updated)
                {
                    return Ok(new { message = "Reminder updated successfully" });
                }
                return NotFound(new { message = "Reminder not found" });
            }
            catch (ReminderNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /*
         * Define a handler method which will get us the reminders by a userId.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the reminder found successfully.
         * 
         * This handler method should map to the URL "/api/reminder/{userId}" using HTTP GET method
         */
        [HttpGet("{userId}")]
        public IActionResult GetAllRemindersByUserId(int userId)
        {
            List<Reminder> reminders = _reminderService.GetAllRemindersByUserId(userId);
            return Ok(reminders);
        }

        /*
         * Define a handler method which will show details of a specific reminder handle
         * ReminderNotFoundException as well. This handler method should return any one
         * of the status messages basis on different situations: 1. 200(OK) - If the
         * reminder found successfully. 2. 404(NOT FOUND) - If the reminder
         * with specified reminderId is not found. This handler method should map to the
         * URL "/api/reminder/{id}" using HTTP GET method where "id" should be replaced by a
         * valid reminderId without {}
         */

        [HttpGet("{reminder}")]
        public IActionResult GetReminderById(int reminderId)
        {
            try
            {
                Reminder reminder = _reminderService.GetReminderById(reminderId);
                return Ok(reminder);
            }
            catch (ReminderNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
