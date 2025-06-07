using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace NoteService.Models
{
    public class NoteUser
    {
        [BsonId]
        public string UserId { get; set; }

        public List<Note> Notes { get; set; } = new List<Note>();
    }
}
