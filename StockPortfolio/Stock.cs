namespace StockPortfolio
{
    public class Stock
    {
        private string _symbol;
        private string _company;
        private double _price;

        public Stock(string symbol, string company, double price)
        {
            _symbol = symbol;
            _company = company;
            _price = price;
        }

        public string Symbol { get => _symbol; set => _symbol = value; }
        public string Company { get => _company; set => _company = value; }
        public double Price { get => _price; set => _price = value; }
    }
}
