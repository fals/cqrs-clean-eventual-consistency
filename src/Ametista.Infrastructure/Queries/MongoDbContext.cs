using Ametista.Application.Queries;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Ametista.Infrastructure.Queries
{
    public class MongoDbContext
    {
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _database;

        public MongoDbContext(string connectionString, string databaseName)
        {
            _mongoClient = new MongoClient(connectionString);
            _database = _mongoClient.GetDatabase(databaseName);
            Map();
        }

        internal IMongoCollection<MinesQueryModel> MinesMaterializedView
        {
            get
            {
                return _database.GetCollection<MinesQueryModel>("MinesMaterializedView");
            }
        }

        internal IMongoCollection<MinersQueryModel> MinersMaterializedView
        {
            get
            {
                return _database.GetCollection<MinersQueryModel>("MinersMaterializedView");
            }
        }

        private void Map()
        {
            BsonClassMap.RegisterClassMap<MinesQueryModel>(cm =>
            {
                cm.AutoMap();
            });

            BsonClassMap.RegisterClassMap<MinersQueryModel>(cm =>
            {
                cm.AutoMap();
            });
        }
    }
}
