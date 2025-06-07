using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using CategoryService.Models;

namespace CategoryService.Models
{
    public class CategoryContext
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Category> _categories;

        public CategoryContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDBConnection");
            var databaseName = configuration.GetValue<string>("MongoDBDatabaseName");

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);

            _categories = _database.GetCollection<Category>("Categories");
        }

        public IMongoCollection<Category> Categories => _categories;
    }
}
