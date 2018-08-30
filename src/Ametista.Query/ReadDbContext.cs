using Ametista.Query.Queries;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Ametista.Query
{
    public class ReadDbContext
    {
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _database;

        public ReadDbContext(string connectionString, string databaseName)
        {
            _mongoClient = new MongoClient(connectionString);
            _database = _mongoClient.GetDatabase(databaseName);
            Map();
        }

        internal IMongoCollection<CardViewQueryModel> CardViewQueryModel
        {
            get
            {
                return _database.GetCollection<CardViewQueryModel>("CardViewQueryModel");
            }
        }

        //internal IMongoCollection<MinersViewQueryModel> MinersMaterializedView
        //{
        //    get
        //    {
        //        return _database.GetCollection<MinersViewQueryModel>("MinersMaterializedView");
        //    }
        //}

        private void Map()
        {
            BsonClassMap.RegisterClassMap<CardViewQueryModel>(cm =>
            {
                cm.AutoMap();
            });

            //BsonClassMap.RegisterClassMap<MinersViewQueryModel>(cm =>
            //{
            //    cm.AutoMap();
            //});
        }
    }
}