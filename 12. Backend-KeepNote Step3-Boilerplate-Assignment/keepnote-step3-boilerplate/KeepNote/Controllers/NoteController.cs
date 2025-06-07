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
    [Route("api/note")]
    public class NoteController : ControllerBase
    {

        /*
        * NoteService should  be injected through constructor injection. Please note that we should not create service
        * object using the new keyword
        */
        private readonly INoteService _noteService;
        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        /*
         * Define a handler method which will create a specific note by reading the
         * Serialized object from request body and save the note details in a Note table
         * in the database.Handle ReminderNotFoundException and
         * CategoryNotFoundException as well. please note that the userID
         * should be taken as the createdBy for the note.This handler method should
         * return any one of the status messages basis on different situations: 1.
         * 201(CREATED) - If the note created successfully. 2. 409(CONFLICT) - If the
         * noteId conflicts with any existing user
         * 
         * This handler method should map to the URL "/api/note" using HTTP POST method
         */

        [HttpPost]
        public IActionResult CreateReminder([FromBody] Note note)
        {
            try
            {
                var createdNote = _noteService.CreateNote(note);
                return Created("", createdNote); // 201 Created
            }
            catch (Exception ex)
            {
                return Conflict(new { message = ex.Message }); // 409 Conflict
            }
        }

        /*
         * Define a handler method which will delete a note from a database.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the note deleted successfully from
         * database. 2. 404(NOT FOUND) - If the note with specified noteId is not found.
         * 
         * This handler method should map to the URL "/api/note/{id}" using HTTP Delete
         * method" where "id" should be replaced by a valid noteId without {}
         */

        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            var deleted = _noteService.DeleteNote(id);
            if (deleted)
            {
                return Ok(new { message = "Note deleted successfully" });
            }
            return NotFound(new { message = "Note not found" });
        }

        /*
         * Define a handler method which will update a specific note by reading the
         * Serialized object from request body and save the updated note details in a
         * note table in database handle ReminderNotFoundException,
         * NoteNotFoundException, CategoryNotFoundException as well. please note that
         * the userID should be taken as the createdBy for the note. This
         * handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the note updated successfully. 2.
         * 404(NOT FOUND) - If the note with specified noteId is not found.
         * This handler method should map to the URL "/api/note/{id}" using HTTP PUT method.
         */

        [HttpPut("{id}")]
        public IActionResult UpdateNote(int id, [FromBody] Note note)
        {
            try
            {
                bool updated = _noteService.UpdateNote(id, note);
                if (updated)
                {
                    return Ok(new { message = "Note updated successfully" });
                }
                return NotFound(new { message = "Note not found" });
            }
            catch (NoteNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /*
         * Define a handler method which will get us the notes by a userId.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the note found successfully.
         * 
         * This handler method should map to the URL "/api/note/{userId}" using HTTP GET method
         */

        [HttpGet("{userId}")]
        public IActionResult GetAllNotesByUserId(int userId)
        {
            List<Note> notes = _noteService.GetAllNotesByUserId(userId);
            return Ok(notes);
        }
    }
}
