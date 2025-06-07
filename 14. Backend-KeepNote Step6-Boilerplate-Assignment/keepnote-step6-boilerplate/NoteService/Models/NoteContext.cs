using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace NoteService.Models
{
    public class NoteContext
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Note> _notes;

        public NoteContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDBConnection");
            var databaseName = configuration.GetValue<string>("MongoDBDatabaseName");

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);

            _notes = _database.GetCollection<Note>("Notes");
        }

        public IMongoCollection<Note> Notes => _notes;
    }
}
