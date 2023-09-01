using StockPortfolioTracker.stock;

namespace StockPortfolioTracker.transaction
{
    public class TransactionService
    {
        public static void AddTransaction()
        {
            Console.Clear();
            Console.WriteLine("Adding a new transaction...");

            string symbol = "";
            bool found;
            do
            {
                symbol = Helper.GetStockSymbol();
                found = Helper.FindStockSymbol(symbol);
                if (!found)
                {
                    Console.WriteLine($"\nStock with symbol {symbol} not found.");
                }
            } while (!found);

            TransactionType type = Helper.GetTransactionType();

            int buyTypeQnt = Helper.GetQuantityByType(symbol, TransactionType.BUY);
            if (buyTypeQnt == 0 && type == TransactionType.SELL)
            {
                Console.WriteLine($"\nYou don't have any stocks with symbol {symbol}. Please buy first!");
                return;
            }
            int sellTypeQnt = Helper.GetQuantityByType(symbol, TransactionType.SELL);
            int stockQnt = buyTypeQnt - sellTypeQnt;
            Console.WriteLine($"\nEnter quantity (you have {stockQnt} stocks)...");
            int qnt = Helper.GetQuantity(type, stockQnt);

            Transaction transaction = new Transaction(symbol, type, qnt);
            SQLiteDataAccess.SaveTransaction(transaction);
            Console.WriteLine($"\nYou made a {type} transaction of {qnt} {symbol} stocks!");
        }

        public static void CalculatePortfolio()
        {
            Console.Clear();
            Console.WriteLine("My portfolio...");
            Console.WriteLine("\n{0,-10} {1,-17} {2}", "Symbol", "Quantity", "Total price");
            Console.WriteLine(new string('-', 40));
            List<Stock> stocks = SQLiteDataAccess.LoadStocks();
            double total = 0;
            foreach (Stock stock in stocks)
            {
                int buyTypeQnt = Helper.GetQuantityByType(stock.Symbol, TransactionType.BUY);
                int sellTypeQnt = Helper.GetQuantityByType(stock.Symbol, TransactionType.SELL);
                int stockQnt = buyTypeQnt - sellTypeQnt;
                if (stockQnt > 0)
                {
                    Console.WriteLine("{0,-10} {1,8} {2,20:C2}", stock.Symbol, stockQnt, stock.Price * stockQnt);
                    total += stock.Price * stockQnt;
                }
            }
            Console.WriteLine("\nYour stock portfolio is worth {0:C2}!", total);
        }
    }
}
