using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatCenter.Data
{
    internal class DB
    {
        private static MongoClient GetClient()
        {
            const string connectionUri = "your connection string";
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            return client;
        }

        public static IMongoCollection<Models.Cat> CatCollection()
        {
            var client = GetClient();
            var database = client.GetDatabase("CatCenter");
            var catCollection = database.GetCollection<Models.Cat>("Our Cats");
            return catCollection;
        }
    }
}
