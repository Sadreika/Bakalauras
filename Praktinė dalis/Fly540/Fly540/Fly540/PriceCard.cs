namespace Fly540
{
    public class Pricecard
    {
        public string Farefamily;
        public decimal? Price;
        public char Class;
        public string Currency;

        public Pricecard(string farefamily, string currency, string price)
        {
            this.Farefamily = farefamily;
            this.Class = 'E';
            if (price != null && price != "")
            {
                if(decimal.TryParse(price, out decimal priceDecimal))
                {
                    Price = priceDecimal;
                }
                Currency = currency;
            }
        }
    }
}