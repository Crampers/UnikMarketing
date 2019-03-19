using System.Threading.Tasks;
using MongoDB.Driver;
using Unik.Marketing.Api.Domain.Request.Events;
using Unik.Marketing.Api.Messaging;

namespace Unik.Marketing.Api.Data.MongoDb.Request.Events
{
    public class NoteUpdatedViewHandler : IEventHandler<NoteUpdatedEvent>
    {
        private readonly IMongoDatabase _database;

        public NoteUpdatedViewHandler(IMongoDatabase database)
        {
            _database = database;
        }

        public Task Handle(NoteUpdatedEvent @event)
        {
            var collection = _database.GetCollection<RequestDocument>(Collections.Requests);
            var filter = Builders<RequestDocument>.Filter.Eq(x => x.AggregateId, @event.RequestId);
            var update = Builders<RequestDocument>.Update.Set(x => x.Note, @event.Note);

            return collection.FindOneAndUpdateAsync(filter, update);
        }
    }
}
