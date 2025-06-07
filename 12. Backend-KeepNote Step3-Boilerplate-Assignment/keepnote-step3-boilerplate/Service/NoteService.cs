using DAL;
using Entities;
using Exceptions;
using System;
using System.Collections.Generic;

namespace Service
{
    /*
     * Service classes are used here to implement additional business logic/validation
     */
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IReminderRepository _reminderRepository;

        // Constructor Injection to inject all required dependencies.
        public NoteService(INoteRepository noteRepository, ICategoryRepository categoryRepository, IReminderRepository reminderRepository)
        {
            _noteRepository = noteRepository ?? throw new ArgumentNullException(nameof(noteRepository));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _reminderRepository = reminderRepository ?? throw new ArgumentNullException(nameof(reminderRepository));
        }

        /*
         * This method should be used to save a new note.
         */
        public Note CreateNote(Note note)
        {
            if (note == null)
                throw new NoteNotFoundException(nameof(note));

            if (string.IsNullOrWhiteSpace(note.NoteTitle))
                throw new NoteNotFoundException("Note title cannot be empty.");

            if (note.Category == null || _categoryRepository.GetCategoryById(note.Category.CategoryId).Equals(null))
                throw new CategoryNotFoundException($"Category with ID {note.CategoryId} does not exist.");

            if (note.Reminder == null || _reminderRepository.GetReminderById(note.Reminder.ReminderId).Equals(null))
                throw new ReminderNotFoundException($"Reminder with ID {note.ReminderId} does not exist.");

            return _noteRepository.CreateNote(note);
        }

        /* This method should be used to delete an existing note. */
        public bool DeleteNote(int noteId)
        {
            var note = _noteRepository.GetNoteByNoteId(noteId);
            if (note == null)
            {
                throw new NoteNotFoundException($"Note with ID {noteId} does not exist.");
            }

            return _noteRepository.DeleteNote(noteId);
        }

        /*
         * This method should be used to get all notes by userId.
         */
        public List<Note> GetAllNotesByUserId(int userId)
        {
            var notes = _noteRepository.GetAllNotesByUserId(userId);
            if (notes == null || notes.Count == 0)
            {
                throw new NoteNotFoundException($"No notes found for user with ID {userId}.");
            }

            return notes;
        }

        // This method should be used to get a note by noteId.
        public Note GetNoteByNoteId(int noteId)
        {
            var note = _noteRepository.GetNoteByNoteId(noteId);
            if (note == null)
                throw new NoteNotFoundException($"Note with ID {noteId} does not exist.");

            return note;
        }

        // This method should be used to update an existing note.
        public bool UpdateNote(int noteId, Note note)
        {
            if (note == null)
                throw new ArgumentNullException(nameof(note));

            var existingNote = _noteRepository.GetNoteByNoteId(noteId);
            if (existingNote == null)
                throw new NoteNotFoundException($"Note with ID {noteId} does not exist.");

            // Optional: Additional validations
            if (note.Category == null || _categoryRepository.GetCategoryById(note.Category.CategoryId).Equals(null))
                throw new CategoryNotFoundException($"Category with ID {note.CategoryId} does not exist.");

            if (note.Reminder == null || _reminderRepository.GetReminderById(note.Reminder.ReminderId).Equals(null))
                throw new ReminderNotFoundException($"Reminder with ID {note.ReminderId} does not exist.");

            note.NoteId = noteId; // Ensure the note ID matches the one being updated.
            return _noteRepository.UpdateNote(note);
        }
    }
}
