using System.Threading.Tasks;
using MongoDB.Driver;
using Unik.Marketing.Api.Domain.Request.Events;
using Unik.Marketing.Api.Messaging;

namespace Unik.Marketing.Api.Data.MongoDb.Request.Events
{
    public class RequestCreatedViewHandler : IEventHandler<RequestCreatedEvent>
    {
        private readonly IMongoDatabase _database;

        public RequestCreatedViewHandler(IMongoDatabase database)
        {
            _database = database;
        }

        public Task Handle(RequestCreatedEvent @event)
        {
            var collection = _database.GetCollection<RequestDocument>(Collections.Requests);

            return collection.InsertOneAsync(new RequestDocument()
            {
                Id = @event.Id.ToString(),
                Note = @event.Note,
                UserId = @event.UserId
            });
        }
    }
}
