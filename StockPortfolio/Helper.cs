using System.Xml.Schema;

namespace StockPortfolio
{
    public class Helper
    {
        // show stocks - USER
        public static void ShowMyStocks()
        {
            Console.Clear();
            Console.WriteLine("My stocks...");
            Console.WriteLine("\n{0,-10} {1,-17} {2}", "Symbol", "Quantity", "Total price");
            Console.WriteLine(new string('-', 40));
            List<Stock> stocks = SQLiteDataAccess.LoadStocks();
            double total = 0;
            foreach (Stock stock in stocks)
            {
                int buyTypeQnt = Validator.GetQuantityByType(stock.Symbol, TransactionType.BUY);
                int sellTypeQnt = Validator.GetQuantityByType(stock.Symbol, TransactionType.SELL);
                int stockQnt = buyTypeQnt - sellTypeQnt;
                if (stockQnt > 0)
                {
                    Console.WriteLine("{0,-10} {1,8} {2,20:C2}", stock.Symbol, stockQnt, stock.Price * stockQnt);
                    total += stock.Price * stockQnt;
                }
            }
            Console.WriteLine("\nYour stock portfolio is worth {0:C2}!", total);
        }
        // add a transaction - USER
        public static void AddTransaction()
        {
            Console.Clear();
            Console.WriteLine("Adding a new transaction...");

            string symbol = "";
            bool found;
            do
            {
                symbol = Validator.GetStockSymbol();
                found = Validator.FindStockSymbol(symbol);
                if (!found)
                {
                    Console.WriteLine($"\nStock with symbol {symbol} not found.");
                }
            } while (!found);

            TransactionType type = Validator.GetTransactionType();

            int buyTypeQnt = Validator.GetQuantityByType(symbol, TransactionType.BUY);
            if (buyTypeQnt == 0 && type == TransactionType.SELL)
            {
                Console.WriteLine($"\nYou don't have any stocks with symbol {symbol}. Please buy first!");
                return;
            }
            int sellTypeQnt = Validator.GetQuantityByType(symbol, TransactionType.SELL);
            int stockQnt = buyTypeQnt - sellTypeQnt;
            Console.WriteLine($"\nEnter quantity (you have {stockQnt} stocks)...");
            int qnt = Validator.GetQuantity(type, stockQnt);
            
            Transaction transaction = new Transaction(symbol, type, qnt);
            SQLiteDataAccess.SaveTransaction(transaction);
            Console.WriteLine($"\nYou made a {type} transaction of {qnt} {symbol} stocks!");
        }
        // add a new stock - ADMIN
        public static void AddStock()
        {
            Console.Clear();
            Console.WriteLine("Adding a new stock...");

            string symbol = "";
            bool found;
            do
            {
                symbol = Validator.GetStockSymbol();
                found = Validator.FindStockSymbol(symbol);
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

            double price = Validator.GetPrice();  
            
            Stock s = new Stock(symbol, company, price);
            SQLiteDataAccess.SaveStock(s);
            Console.WriteLine($"\nStock with symbol {symbol} has been added!");
        }  
        // modify stock price - ADMIN
        public static void ModifyStockPrice()
        {
            Console.Clear();
            Console.WriteLine("Modifying a stock price...");

            string symbol = "";
            bool found;
            do
            {
                symbol = Validator.GetStockSymbol();
                found = Validator.FindStockSymbol(symbol);
                if (!found)
                {
                    Console.WriteLine($"\nStock with symbol {symbol} not found.");
                }
            } while (!found);

            double price = Validator.GetPrice();

            SQLiteDataAccess.UpdatePrice(symbol, price);
            Console.WriteLine("\nPrice of stock {0} has been updated - {1:C2}!", symbol, price);
        }
        // delete a stock - ADMIN
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
            string symbol = Validator.GetStockSymbol();
            bool found = Validator.FindStockSymbol(symbol);    
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
