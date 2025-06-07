using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoteService.Models;

namespace NoteService.Service
{
    public interface INoteService
    {
        bool CreateNote(Note note);
        bool DeleteNote(string userId, int noteId);
        Note UpdateNote(int noteId, string userId, Note note);
        List<Note> GetAllNotesByUserId(string userId);
    }
}
