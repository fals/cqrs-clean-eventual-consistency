using MongoDB.Driver;

namespace Ametista.Infrastructure.Queries
{
    public class ReadDbContext
    {
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _database;

        public ReadDbContext(string connectionString, string databaseName)
        {
            _mongoClient = new MongoClient(connectionString);
            _database = _mongoClient.GetDatabase(databaseName);
            //Map();
        }

        //internal IMongoCollection<MinesViewQueryModel> MinesMaterializedView
        //{
        //    get
        //    {
        //        return _database.GetCollection<MinesViewQueryModel>("MinesMaterializedView");
        //    }
        //}

        //internal IMongoCollection<MinersViewQueryModel> MinersMaterializedView
        //{
        //    get
        //    {
        //        return _database.GetCollection<MinersViewQueryModel>("MinersMaterializedView");
        //    }
        //}

        //private void Map()
        //{
        //    BsonClassMap.RegisterClassMap<MinesViewQueryModel>(cm =>
        //    {
        //        cm.AutoMap();
        //    });

        //    BsonClassMap.RegisterClassMap<MinersViewQueryModel>(cm =>
        //    {
        //        cm.AutoMap();
        //    });
        //}
    }
}
