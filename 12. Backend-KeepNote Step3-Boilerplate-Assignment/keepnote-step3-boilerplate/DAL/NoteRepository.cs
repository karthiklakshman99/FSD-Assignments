using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    //Repository class is used to implement all Data access operations
    public class NoteRepository : INoteRepository
    {
        private readonly KeepDbContext _dbContext;
        public NoteRepository(KeepDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // This method should be used to save a new note.
        public Note CreateNote(Note note)
        {
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }

            _dbContext.Notes.Add(note);
            _dbContext.SaveChanges();
            return note;
        }

        /* This method should be used to delete an existing note. */
        public bool DeleteNote(int noteId)
        {
            var note = _dbContext.Notes.FirstOrDefault(n => n.NoteId == noteId);
            if (note == null)
            {
                return false;
            }

            _dbContext.Notes.Remove(note);
            _dbContext.SaveChanges();
            return true;
        }

        //* This method should be used to get all note by userId.
        public List<Note> GetAllNotesByUserId(int userId)
        {
            return _dbContext.Notes
                             .Where(c => c.User.UserId == userId)
                             .ToList();
        }
        //This method should be used to get a note by noteId.
        public Note GetNoteByNoteId(int noteId)
        {
            return _dbContext.Notes.FirstOrDefault(c => c.NoteId == noteId);
        }
        //This method should be used to update a existing note.
        public bool UpdateNote(Note note)
        {
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }

            var existingNote = _dbContext.Notes.FirstOrDefault(c => c.NoteId == note.NoteId);
            if (existingNote == null)
            {
                return false;
            }

            existingNote.NoteTitle = note.NoteTitle;
            existingNote.NoteContent = note.NoteContent;
            existingNote.NoteStatus = note.NoteStatus;
            existingNote.CategoryId = note.CategoryId;
            existingNote.ReminderId = note.ReminderId;
            existingNote.CreatedBy = note.CreatedBy;
            existingNote.CreatedAt = note.CreatedAt;

            _dbContext.Entry(existingNote).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }
    }
}
