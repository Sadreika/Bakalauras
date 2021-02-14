namespace StarPeru
{
    public class Program
    {
        static void Main(string[] args)
        {
            Crawler crawler = new Crawler();
            bool isDataCollected = crawler.Start("LIM|HUU|2021|03|19|2021|03|26|E|R|XXX|2");
        }
    }
}
