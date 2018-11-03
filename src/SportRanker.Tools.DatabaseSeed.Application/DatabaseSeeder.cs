using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace SportRanker.Tools.DatabaseSeed.Application
{
    public class DatabaseSeeder
    {
        private readonly MongoClient _client;

        private const string DbConnectionString = @"mongodb://dbadmin:D1s!r1but3d@ds048279.mlab.com:48279/sportranker";
        private const string DbName = "sportranker";
        
        public DatabaseSeeder()
        {
            _client = new MongoClient(DbConnectionString);
        }

        public async Task SeedData<T>(ICollection<T> data, string collectionName)
        {
            var database = _client.GetDatabase(DbName);

            var collection = database.GetCollection<T>(collectionName);

            await collection.InsertManyAsync(data);
        }
    }
}
