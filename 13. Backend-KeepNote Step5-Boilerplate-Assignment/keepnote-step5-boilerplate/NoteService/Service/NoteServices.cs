using System;
using System.Collections.Generic;
using System.Linq;
using NoteService.Exceptions;
using NoteService.Models;
using NoteService.Repository;

namespace NoteService.Service
{
    public class NoteServices : INoteService
    {
        private INoteRepository _noteRepository;

        public NoteServices(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public bool CreateNote(Note note)
        {
            if (note == null)
                throw new ArgumentException("Note cannot be null");

            return _noteRepository.CreateNote(note);
        }

        public bool DeleteNote(string userId, int noteId)
        {
            return _noteRepository.DeleteNote(userId, noteId);
        }

        public List<Note> GetAllNotesByUserId(string userId)
        {
            return _noteRepository.FindAllNotesByUser(userId);
        }

        public Note UpdateNote(int noteId, string userId, Note note)
        {
            if (note == null)
                throw new ArgumentException("Note cannot be null");

            var result = _noteRepository.UpdateNote(noteId, userId, note);

            if (result)
            {
                return _noteRepository.FindAllNotesByUser(userId).FirstOrDefault();
            }
            else
            {
                throw new NoteNotFoundException($"Note with ID {noteId} not found");
            }
        }
    }
}
