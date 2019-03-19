﻿using System;
using System.Collections.Generic;
using System.Text;
using Unik.Marketing.Api.Messaging;

namespace Unik.Marketing.Api.Domain.MarketingCase.Events
{
    public class MarketingCaseCreatedEvent : IEvent
    {
        public MarketingCaseCreatedEvent(Guid id, int rentalObjectId, string titel, string description, decimal? deposit, decimal? prepaidRent, string linkToProspect, string fromDate, string toDate, string availableFromDate, bool showOnSite, string appartmentComment, bool statusProved, string statusApprovedInitials, string statusApprovedDate, bool statusProspectUpToDate, string address1, string address2)
        {
            Id = id;
            RentalObjectId = rentalObjectId;
            Titel = titel;
            Description = description;
            Deposit = deposit;
            PrepaidRent = prepaidRent;
            LinkToProspect = linkToProspect;
            FromDate = fromDate;
            ToDate = toDate;
            AvailableFromDate = availableFromDate;
            ShowOnSite = showOnSite;
            AppartmentComment = appartmentComment;
            StatusProved = statusProved;
            StatusApprovedInitials = statusApprovedInitials;
            StatusApprovedDate = statusApprovedDate;
            StatusProspectUpToDate = statusProspectUpToDate;
            Address1 = address1;
            Address2 = address2;
        }

        public Guid Id { get; set; }
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
        public int Version { get; set; }

    }
}
