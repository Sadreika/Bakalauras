namespace StarPeru
{
    using System.Collections.Generic;
    public class Combinations
    {
        public Flight Outbound;
        public Flight Inbound;
        public Combinations(Flight outbound, Flight inbound = null)
        {
            Outbound = outbound;
            Inbound = inbound;
        }
        public static List<Combinations> GetCombinations(List<Flight> outBoundData, List<Flight> inBoundData)
        {
            List<Combinations> combinationsList = new List<Combinations>();
            foreach (Flight outbound in outBoundData)
            {
                if (inBoundData.Count != 0)
                {
                    foreach (Flight inbound in inBoundData)
                    {
                        Combinations combinations = new Combinations(outbound, inbound);
                        combinationsList.Add(combinations);
                    }
                }
                else
                {
                    Combinations combinations = new Combinations(outbound);
                    combinationsList.Add(combinations);
                }
            }

            return combinationsList;
        }
    }
}
