namespace UnikMarketing.Data.MongoDb.Documents
{
    class CriteriaDocument
    {
        public decimal SizeFrom { get; set; }
        public decimal SizeTo { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }
        public int FloorFrom { get; set; }
        public int FloorTo { get; set; }
    }
}
