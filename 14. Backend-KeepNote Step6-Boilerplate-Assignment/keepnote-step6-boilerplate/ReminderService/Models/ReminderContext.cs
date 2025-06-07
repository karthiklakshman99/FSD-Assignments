using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace ReminderService.Models
{
    public class ReminderContext
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Reminder> _reminders;

        public ReminderContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDBConnection");
            var databaseName = configuration.GetValue<string>("MongoDBDatabaseName");

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);

            _reminders = _database.GetCollection<Reminder>("Reminders");
        }

        public IMongoCollection<Reminder> Reminders => _reminders;
    }
}

