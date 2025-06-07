using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserService.Models
{
    public class User
    {
        [BsonId]
        public string UserId { get; set; }

        public string Name { get; set; }

        public string Contact { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    }
}
