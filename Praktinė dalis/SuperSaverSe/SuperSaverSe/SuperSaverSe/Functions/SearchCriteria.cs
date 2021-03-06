namespace SuperSaverSe.Functions
{
    using System;
    using System.Globalization;
    public class SearchCriteria
    {
        public string Origin { get; }
        public string Destination { get; }
        public string OutboundYear { get; }
        public string OutboundMonth { get; }
        public string OutboundDay { get; }
        public DateTime OutboundDate { get; }
        public string InboundYear { get; }
        public string InboundMonth { get; }
        public string InboundDay { get; }
        public DateTime InboundDate { get; }
        public bool IsRt { get; }
        public char CabinClass { get; }
        public string Connection { get; }
        public int ConnectionCount { get; }

        public SearchCriteria(string searchCriteria)
        {
            string[] searchCriteriaArray = searchCriteria.Split('|');

            IsRt = searchCriteriaArray[9].Equals("R") ? true : false;

            Origin = searchCriteriaArray[0];
            Destination = searchCriteriaArray[1];

            OutboundYear = searchCriteriaArray[2];
            OutboundMonth = searchCriteriaArray[3];
            OutboundDay = searchCriteriaArray[4];
            DateTime.TryParseExact(searchCriteriaArray[2] + "-" + searchCriteriaArray[3] + "-" + searchCriteriaArray[4], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime outboundDate);
            OutboundDate = outboundDate;

            if(IsRt)
            {
                InboundYear = searchCriteriaArray[5];
                InboundMonth = searchCriteriaArray[6];
                InboundDay = searchCriteriaArray[7];
                DateTime.TryParseExact(searchCriteriaArray[5] + "-" + searchCriteriaArray[6] + "-" + searchCriteriaArray[7], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime inboundDate);
                InboundDate = inboundDate;
            }

            CabinClass = searchCriteriaArray[8].ToCharArray()[0];
            Connection = searchCriteriaArray[10];
            ConnectionCount = int.Parse(searchCriteriaArray[11]);
        }
    }
}
