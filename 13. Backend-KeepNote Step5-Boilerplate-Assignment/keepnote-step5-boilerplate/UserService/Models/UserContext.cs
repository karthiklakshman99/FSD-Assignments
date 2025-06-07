using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace UserService.Models
{
    public class UserContext
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<User> _users;

        public UserContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDBConnection");
            var databaseName = configuration.GetValue<string>("MongoDBDatabaseName");

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);

            _users = _database.GetCollection<User>("Users");
        }

        public IMongoCollection<User> Users => _users;
    }
}
