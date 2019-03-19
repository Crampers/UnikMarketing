using MongoDB.Bson.Serialization.Attributes;

namespace Unik.Marketing.Api.Data.MongoDb.MarketingCase
{
    public class MarketingCaseDocument
    {
        [BsonElement("rental_object_id")] public int RentalObjectId { get; set; }
        [BsonElement("title")] public string Titel { get; set; }
        [BsonElement("description")] public string Description { get; set; }
        [BsonElement("deposit")] public decimal? Deposit { get; set; }
        [BsonElement("prepaid_rent")] public decimal? PrepaidRent { get; set; }
        [BsonElement("link_to_prospect")] public string LinkToProspect { get; set; }
        [BsonElement("from_date")] public string FromDate { get; set; }
        [BsonElement("to_date")] public string ToDate { get; set; }
        [BsonElement("available_from_date")] public string AvailableFromDate { get; set; }
        [BsonElement("show_on_site")] public bool ShowOnSite { get; set; }
        [BsonElement("appartment_comment")] public string AppartmentComment { get; set; }
        [BsonElement("status_proved")] public bool StatusProved { get; set; }
        [BsonElement("status_approved_initials")] public string StatusApprovedInitials { get; set; }
        [BsonElement("status_approved_date")] public string StatusApprovedDate { get; set; }
        [BsonElement("status_approved_up_to_date")] public bool StatusProspectUpToDate { get; set; }
        [BsonElement("address_primary")] public string Address1 { get; set; }
        [BsonElement("address_secondary")] public string Address2 { get; set; }
    }
}
