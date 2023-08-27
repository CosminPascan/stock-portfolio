namespace StockPortfolio
{   
    public enum TransactionType { BUY, SELL }

    public class Transaction
    {
        private string _stockSymbol;
        private TransactionType _type;
        private int _quantity;

        public Transaction(string stockSymbol, TransactionType type, int quantity)
        {
            _stockSymbol = stockSymbol;
            _type = type;
            _quantity = quantity;
        }

        public string StockSymbol { get => _stockSymbol; set => _stockSymbol = value; }
        public TransactionType Type { get => _type; set => _type = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
    }
}
