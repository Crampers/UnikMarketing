namespace UnikMarketing.Integration.Tools.Models
{
    public class RentalObjectDto
    {
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
    }
}
