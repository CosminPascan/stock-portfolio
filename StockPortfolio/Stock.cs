namespace StockPortfolio
{
    public class Stock
    {
        private string _symbol;
        private string _company;
        private double _currentPrice;

        public Stock(string symbol, string company, double currentPrice)
        {
            _symbol = symbol;
            _company = company;
            _currentPrice = currentPrice;
        }

        public string Symbol { get => _symbol; set => _symbol = value; }
        public string Company { get => _company; set => _company = value; }
        public double CurrentPrice { get => _currentPrice; set => _currentPrice = value; }
    }
}
