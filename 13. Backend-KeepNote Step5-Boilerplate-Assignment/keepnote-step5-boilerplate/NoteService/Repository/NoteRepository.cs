using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using NoteService.Models;

namespace NoteService.Repository
{
    public class NoteRepository : INoteRepository
    {
        private NoteContext _context;

        public NoteRepository(NoteContext context)
        {
            _context = context;
        }

        public bool CreateNote(Note note)
        {
            note.Id = (int)(_context.Notes.CountDocuments(new BsonDocument()) + 101);

            var existingUser = _context.Notes.Find(user => user.CreatedBy == note.CreatedBy).FirstOrDefault();

            if (existingUser == null)
            {
                var newUser = new NoteUser();
                newUser.Notes.Add(note);
                _context.Notes.InsertOne(note);
            }
            else
            {
                _context.Notes.InsertOne(note);
                _context.Notes.ReplaceOne(user => user.CreatedBy == note.CreatedBy, existingUser);
            }

            return true;
        }

        public List<Note> FindAllNotesByUser(string userId)
        {
            var user = _context.Notes.Find(u => u.CreatedBy == userId).ToList();
            return user ?? new List<Note>();
        }

        public bool DeleteNote(string userId, int noteId)
        {
            var user = _context.Notes.Find(u => u.CreatedBy == userId).FirstOrDefault();

            if (user == null)
                return false;

            var noteToDelete = _context.Notes.Find(note => note.Id == noteId).FirstOrDefault();

            if (noteToDelete == null)
                return false;

            _context.Notes.DeleteOne(x => x.Id == noteToDelete.Id);

            _context.Notes.ReplaceOne(u => u.CreatedBy == userId, user);

            return true;
        }

        public bool UpdateNote(int noteId, string userId, Note note)
        {
            var user = _context.Notes.Find(u => u.CreatedBy == userId).FirstOrDefault();

            if (user == null)
                return false;

            var existingNote = _context.Notes.Find(n => n.Id == noteId).FirstOrDefault();

            if (existingNote == null)
                return false;

            existingNote.Title = note.Title;
            existingNote.Content = note.Content;
            existingNote.Category = note.Category;
            existingNote.Reminders = note.Reminders;
            existingNote.CreatedBy = note.CreatedBy;

            _context.Notes.ReplaceOne(u => u.CreatedBy == userId, user);

            return true;
        }
    }
}
