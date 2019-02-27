namespace Unik.Marketing.Integration.Service.Model
{
    public class MarketingCase
    {
        public int Marketingcaseid { get; set; }
        public string Titel { get; set; }
        public string Description { get; set; }
        public decimal Deposit { get; set; }
        public decimal PrepaidRent { get; set; }
        public string LinkToProspect { get; set; }
        public string FromDate { get; set; } //Effectively date
        public string ToDate { get; set; } //Effectively date
        public string AvailibleFromDate { get; set; } //Effectively date
        public string Online { get; set; }
        public string Comment { get; set; }
        public string Approved { get; set; }
        public string ApprovedUserInitials { get; set; }
        public string Approveddate { get; set; } //Effectively date
        public string StatusProspectAjourned { get; set; }
        public string Adresse1 { get; set; }
        public string Adresse2 { get; set; }
    }
}