namespace StockPortfolioTracker.transaction
{   
    public class Transaction
    {
        public string StockSymbol { get; set; }
        public TransactionType Type { get; set; }
        public int Quantity { get; set; }

        public Transaction(string stockSymbol, TransactionType type, int quantity)
        {
            StockSymbol = stockSymbol;
            Type = type;
            Quantity = quantity;
        }
    }
}
