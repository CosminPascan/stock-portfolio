namespace StockPortfolioTracker.stock
{
    public class StockService
    {
        public static void AddStock()
        {
            Console.Clear();
            Console.WriteLine("Adding a new stock...");

            string symbol = "";
            bool found;
            do
            {
                symbol = Helper.GetStockSymbol();
                found = Helper.FindStockSymbol(symbol);
                if (found)
                {
                    Console.WriteLine($"\nStock with symbol {symbol} already exists!");
                }
            } while (found);

            string company = "";
            do
            {
                Console.WriteLine("\nEnter company (at least 2 characters)...");
                company = Console.ReadLine();
            } while (company.Length < 2);

            double price = Helper.GetPositiveDouble();

            Stock s = new Stock(symbol, company, price);
            SQLiteDataAccess.SaveStock(s);
            Console.WriteLine($"\nStock with symbol {symbol} has been added!");
        }

        public static void ModifyStockPrice()
        {
            Console.Clear();
            Console.WriteLine("Modifying a stock price...");

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

            double price = Helper.GetPositiveDouble();

            SQLiteDataAccess.UpdatePrice(symbol, price);
            Console.WriteLine("\nPrice of stock {0} has been updated - {1:C2}!", symbol, price);
        }

        public static void DeleteStock()
        {
            Console.Clear();
            Console.WriteLine("Deleting a stock...");
            Console.WriteLine("\nCurrent list of stocks:");
            Console.WriteLine("\n{0,-10} {1,-26} {2,12}", "Symbol", "Company", "Price");
            Console.WriteLine(new string('-', 50));
            List<Stock> stocks = SQLiteDataAccess.LoadStocks();
            foreach (Stock stock in stocks)
            {
                Console.WriteLine("{0,-10} {1,-26} {2,12:C2}", stock.Symbol, stock.Company, stock.Price);
            }
            string symbol = Helper.GetStockSymbol();
            bool found = Helper.FindStockSymbol(symbol);
            if (found)
            {
                SQLiteDataAccess.DeleteStock(symbol);
                Console.WriteLine($"\nStock with symbol {symbol} has been deleted!");
            }
            else
            {
                Console.WriteLine($"\nStock with symbol {symbol} not found!");
            }
        }
    }
}
