using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ReminderService.Models
{
    public class Reminder
    {
        [BsonId]
        public int Id { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string CreatedBy { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    }
}
