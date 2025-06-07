using System;
using Microsoft.AspNetCore.Mvc;
using NoteService.Exceptions;
using NoteService.Models;
using NoteService.Service;
using System.Collections.Generic;
using System.Linq;

namespace NoteService.Controllers
{
    [ApiController]
    [Route("api/note")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _service;

        public NotesController(INoteService service)
        {
            _service = service;
        }

        [HttpPost("{userId}")]
        public ActionResult CreateNote(string userId, [FromBody] Note note)
        {
            try
            {
                bool created = _service.CreateNote(note);

                if (created)
                {
                    return CreatedAtAction(nameof(GetNoteById), new { userId = userId, noteId = note.Id }, note);
                }
                else
                {
                    return Conflict("Note could not be created.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{userId}/{noteId}")]
        public ActionResult DeleteNote(string userId, int noteId)
        {
            try
            {
                bool deleted = _service.DeleteNote(userId, noteId);

                if (deleted)
                {
                    return Ok("Note deleted successfully.");
                }
                else
                {
                    return NotFound("Note not found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{userId}/{noteId}")]
        public ActionResult UpdateNote(string userId, int noteId, [FromBody] Note note)
        {
            try
            {
                var updated = _service.UpdateNote(noteId, userId, note);

                if (updated != null)
                {
                    return Ok("Note updated successfully.");
                }
                else
                {
                    return NotFound("Note not found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{userId}")]
        public ActionResult<List<Note>> GetAllNotesByUser(string userId)
        {
            try
            {
                var notes = _service.GetAllNotesByUserId(userId);

                if (notes != null && notes.Count > 0)
                {
                    return Ok(notes);
                }
                else
                {
                    return NotFound("No notes found for this user.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{userId}/{noteId}")]
        public ActionResult<Note> GetNoteById(string userId, int noteId)
        {
            try
            {
                var note = _service.GetAllNotesByUserId(userId).FirstOrDefault();

                if (note != null)
                {
                    return Ok(note);
                }
                else
                {
                    return NotFound("Note not found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
