namespace SuperSaverSe
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            Crawler crawler = new Crawler();
            string searchCriteriaString = args[0].ToString();
            bool isDataCollected = crawler.Start(searchCriteriaString);
            Console.WriteLine("Finished: " + isDataCollected);
        }
    }
}
