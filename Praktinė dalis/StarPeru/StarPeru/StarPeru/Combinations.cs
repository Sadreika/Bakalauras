namespace StarPeru
{
    public class Combinations
    {
        public Flight Outbound;
        public Flight Inbound;
        public Combinations(Flight outbound, Flight inbound = null)
        {
            Outbound = outbound;
            Inbound = inbound;
        }
    }
}
