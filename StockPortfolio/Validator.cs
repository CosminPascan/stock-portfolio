namespace StockPortfolio
{
    public static class Validator
    {
        public static int GetNumberInRange(int low, int high)
        {
            int number = -1;
            do
            {
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                    if (number < low || number > high)
                    {
                        Console.WriteLine($"\nInvalid input! Please enter a number between {low} and {high}...");
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"\nInvalid number! Please enter a number between {low} and {high}...");
                }
                catch (FormatException)
                {
                    Console.WriteLine($"\nCharacters are not allowed! Please enter a number between {low} and {high}...");
                }
            } while (number < low ||  number > high);
            return number;
        }

        public static string GetStockSymbol()
        {
            string symbol = "";
            do
            {
                Console.WriteLine("\nEnter stock symbol (2-5 characters, only letters)...");
                symbol = Console.ReadLine().ToUpper();
            } while (symbol.Any(char.IsDigit) || symbol.Length < 2 || symbol.Length > 5);
            return symbol;
        }

        public static bool FindStockSymbol(string symbol)
        {
            bool found = false;
            List<Stock> stocks = SQLiteDataAccess.LoadStocks();
            foreach (Stock stock in stocks)
            {
                if (stock.Symbol.Equals(symbol)) 
                {
                    found = true;
                }
            }
            return found;
        }

        public static double GetPrice()
        {
            Console.WriteLine("\nEnter stock price...");
            double price = 0;
            do
            {   
                try
                {
                    price = Convert.ToDouble(Console.ReadLine());
                    if (price <= 0)
                        Console.WriteLine("\nNumber too low! Please enter a value greater than 0...");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"\nInvalid number! Please enter a value greater than 0...");
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nCharacters are not allowed! Please enter a value greater than 0...");
                }
            } while (price <= 0);
            return price;
        }

        public static TransactionType GetTransactionType()
        {
            string typeString = "";
            do
            {
                Console.WriteLine("\nEnter transaction type (BUY or SELL)...");
                typeString = Console.ReadLine().ToUpper();
            } while (!typeString.Equals("BUY") && !typeString.Equals("SELL"));
            Enum.TryParse(typeString, out TransactionType type);
            return type;
        }

        public static int GetQuantityByType(string symbol, TransactionType type)
        {
            int qnt = 0;
            List<Transaction> transactions = SQLiteDataAccess.LoadTransactions();
            foreach (Transaction transaction in transactions)
            {
                if (transaction.StockSymbol.Equals(symbol) && transaction.Type == type)
                {
                    qnt += transaction.Quantity;
                }
            }
            return qnt;
        }

        public static int GetQuantity(TransactionType type, int stockQnt)
        {
            int qnt = 0;
            if (type == TransactionType.BUY)
            {
                qnt = GetNumberInRange(1, 1000);
            }
            else
            {
                qnt = GetNumberInRange(1, stockQnt);
            }
            return qnt;
        }
    }
}
