namespace SuperSaverSe
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            Crawler crawler = new Crawler();
            //string searchCriteriaString = args[0].ToString();
            string searchCriteriaString = "VNO|JFK|2021|03|19|2021|03|26|E|R|XXX|0";
            bool isDataCollected = crawler.Start(searchCriteriaString);
            Console.WriteLine("Finished: " + isDataCollected);
        }
    }
}
