using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Unik.Marketing.Api.Data.MongoDb.Request;
using Unik.Marketing.Api.Domain.MarketingCase.Events;
using Unik.Marketing.Api.Messaging;

namespace Unik.Marketing.Api.Data.MongoDb.MarketingCase.Events
{
    public class MarketingCaseCreatedViewHandler : IEventHandler<MarketingCaseCreatedEvent>
    {
        private readonly IMongoDatabase _database;

        public MarketingCaseCreatedViewHandler(IMongoDatabase database)
        {
            _database = database;
        }

        public Task Handle(MarketingCaseCreatedEvent @event)
        {
            var collection = _database.GetCollection<MarketingCaseDocument>(Collections.MarketingCases);

            return collection.InsertOneAsync(new MarketingCaseDocument()
            {
                RentalObjectId = @event.RentalObjectId,
                Titel = @event.Titel,
                Description = @event.Description,
                Deposit = @event.Deposit,
                PrepaidRent = @event.PrepaidRent,
                LinkToProspect = @event.LinkToProspect,
                FromDate = @event.FromDate,
                ToDate = @event.ToDate,
                AvailableFromDate = @event.AvailableFromDate,
                ShowOnSite = @event.ShowOnSite,
                AppartmentComment = @event.AppartmentComment,
                StatusProved = @event.StatusProved,
                StatusApprovedInitials = @event.StatusApprovedInitials,
                StatusApprovedDate = @event.StatusApprovedDate,
                StatusProspectUpToDate = @event.StatusProspectUpToDate,
                Address1 = @event.Address1,
                Address2 = @event.Address2
            });
        }
    }
}
