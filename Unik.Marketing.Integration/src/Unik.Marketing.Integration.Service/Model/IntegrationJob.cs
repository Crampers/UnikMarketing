using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Quartz;
using Unik.Marketing.Integration.Tools;

namespace Unik.Marketing.Integration.Service.Model
{
    internal class IntegrationJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            
            var connectionString = context.MergedJobDataMap.Get("ConnectionString") as string;
            /*
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("test");

            string text = System.IO.File.ReadAllText(@"records.JSON");

            var document = BsonSerializer.Deserialize<IMongoCollection<BsonDocument>>(text);
            var collection = database.GetCollection<BsonDocument>("test_collection");
            //await collection.InsertOneAsync(document); */

            //TODO: Writer
            return Task.Run(() =>
            {
                var json = SequelToJson.GetSerializedJson(connectionString);
                //var sometool = WriteJsonToMongoDb;  
            });
        }
    }
}