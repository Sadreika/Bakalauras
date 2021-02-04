namespace Currency_crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Crawler crawler = new Crawler();
            crawler.StartCurrencyCrawler();
            crawler.StartConversionCrawler("USD", "CAD");
        }
    }
}
