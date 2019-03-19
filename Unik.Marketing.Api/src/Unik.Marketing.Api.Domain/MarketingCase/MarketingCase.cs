using System;
using Unik.Marketing.Api.Domain.MarketingCase.Events;

namespace Unik.Marketing.Api.Domain.MarketingCase
{
    public class MarketingCase : AggregateRoot
    {
        private Guid _id;
        public int RentalObjectId { get; set; }
        public string Titel { get; set; }
        public string Description { get; set; }
        public decimal? Deposit { get; set; }
        public decimal? PrepaidRent { get; set; }
        public string LinkToProspect { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string AvailableFromDate { get; set; }
        public bool ShowOnSite { get; set; }
        public string AppartmentComment { get; set; }
        public bool StatusProved { get; set; }
        public string StatusApprovedInitials { get; set; }
        public string StatusApprovedDate { get; set; }
        public bool StatusProspectUpToDate { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public MarketingCase(int rentalObjectId, string titel, string description, decimal? deposit, decimal? prepaidRent, string linkToProspect, string fromDate, string toDate, string availableFromDate, bool showOnSite, string appartmentComment, bool statusProved, string statusApprovedInitials, string statusApprovedDate, bool statusProspectUpToDate, string address1, string address2)
        {
            ApplyChange(new MarketingCaseCreatedEvent(
                Guid.NewGuid(),
                rentalObjectId,
                titel,
                description,
                deposit,
                prepaidRent,
                linkToProspect,
                fromDate,
                toDate,
                availableFromDate,
                showOnSite,
                appartmentComment,
                statusProved,
                statusApprovedInitials,
                statusApprovedDate,
                statusProspectUpToDate,
                address1,
                address2
            ));
        }

        private void Apply(MarketingCaseCreatedEvent @event)
        {
            RentalObjectId = @event.RentalObjectId;
            Titel = @event.Titel;
            Description = @event.Description;
            Deposit = @event.Deposit;
            PrepaidRent = @event.PrepaidRent;
            LinkToProspect = @event.LinkToProspect;
            FromDate = @event.FromDate;
            ToDate = @event.ToDate;
            AvailableFromDate = @event.AvailableFromDate;
            ShowOnSite = @event.ShowOnSite;
            AppartmentComment = @event.AppartmentComment;
            StatusProved = @event.StatusProved;
            StatusApprovedInitials = @event.StatusApprovedInitials;
            StatusApprovedDate = @event.StatusApprovedDate;
            StatusProspectUpToDate = @event.StatusProspectUpToDate;
            Address1 = @event.Address1;
            Address2 = @event.Address2;
        }

        public override Guid Id => _id;
    }
}