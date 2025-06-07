using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace NoteService.Models
{
    public class Note
    {
        [BsonId]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public Category Category { get; set; }

        public List<Reminder> Reminders { get; set; } = new List<Reminder>();

        public string CreatedBy { get; set; }
    }
}
