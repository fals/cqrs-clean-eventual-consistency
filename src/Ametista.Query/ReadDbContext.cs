using Ametista.Core;
using Ametista.Query.Queries;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Ametista.Query
{
    public class ReadDbContext
    {
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _database;

        public ReadDbContext(AmetistaConfiguration ametistaConfiguration)
        {
            _mongoClient = new MongoClient(ametistaConfiguration.ConnectionStrings.MongoConnectionString);
            _database = _mongoClient.GetDatabase(ametistaConfiguration.ConnectionStrings.MongoDatabase);
            Map();
        }

        internal IMongoCollection<CardViewQueryModel> CardViewMaterializedView
        {
            get
            {
                return _database.GetCollection<CardViewQueryModel>("CardViewMaterializedView");
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