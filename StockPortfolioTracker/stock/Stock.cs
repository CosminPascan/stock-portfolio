namespace StockPortfolioTracker.stock
{
    public class Stock
    {
        public string Symbol { get; set; }
        public string Company { get; set; }
        public double Price { get; set; }

        public Stock(string symbol, string company, double price)
        {
            Symbol = symbol;
            Company = company;
            Price = price;
        }
    }
}
