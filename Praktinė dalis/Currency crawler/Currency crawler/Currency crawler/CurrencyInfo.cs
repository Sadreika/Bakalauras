namespace Currency_crawler
{
    public class CurrencyInfo
    {
        public string Search;
        public string Value;
        public string Display;

        public CurrencyInfo(string search, string value, string display)
        {
            Search = search;
            Value = value;
            Display = display;
        }
    }
}
