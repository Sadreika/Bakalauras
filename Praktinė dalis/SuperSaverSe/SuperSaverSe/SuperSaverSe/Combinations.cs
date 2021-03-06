namespace SuperSaverSe
{
    public class Combinations
    {
        public Flight Outbound;
        public Flight Inbound;
        public decimal? FullPrice { get; set; }
        public decimal? PriceWithoutTaxes { get; set; }
        public decimal? Taxes { get; set; }
        public string Currency { get; set; }
        public Combinations(Flight outbound, Flight inbound = null)
        {
            Outbound = outbound;
            Inbound = inbound;
        }
    }
}