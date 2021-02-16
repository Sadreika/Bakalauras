using System;

namespace Fly540
{
    public class Program
    {
        static void Main(string[] args)
        {
            Crawler crawler = new Crawler();
            //string searchCriteriaString = args[0].ToString();
            string searchCriteriaString = "MBA|NBO|2021|02|19|2021|02|21|E|R|XXX|0";
            bool isDataCollected = crawler.Start(searchCriteriaString);
            Console.WriteLine("Finished: " + isDataCollected);
        }
    }
}
