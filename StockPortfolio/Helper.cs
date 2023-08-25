namespace StockPortfolio
{
    public class Helper
    {
        public static int GetInput(int minInput, int maxInput)
        {
            int input = -1;
            while (input < minInput || input > maxInput)
            {
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input < minInput || input > maxInput)
                        Console.WriteLine($"\nInvalid input! Please enter a number between {minInput} and {maxInput}...");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"\nInvalid input! Please enter a number between {minInput} and {maxInput}...");
                }
                catch (FormatException)
                {
                    Console.WriteLine($"\nCharacters are not allowed! Please enter a number between {minInput} and {maxInput}...");
                }
            }
            return input;
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

        public static void GoBackToMain()
        {
            Console.WriteLine("\n1 - Back to main menu");
            Console.WriteLine("\nPress 0 to exit application...");
            int input = GetInput(0, 1);
            if (input == 0)
            {
                Console.WriteLine("\nApplication exited successfully!");
                Environment.Exit(0);
            }
            if (input == 1)
            {
                Program.MainMenu.Run();
            }
        }
        // add an user - USER
        public static void AddUser()
        {
            Console.Clear();
            Console.WriteLine("Adding a new user...");
            List<string> users = SQLiteDataAccess.LoadUsers();
            string username = "";
            bool exist = true;
            while (exist)
            {
                Console.WriteLine("\nPlease enter a new username...");
                username = Console.ReadLine().ToLower();
                exist = false;
                foreach (string user in users)
                {
                    if (user.Equals(username))
                        exist = true;
                }
                if (exist)
                    Console.WriteLine("Username already used!");
            }
            SQLiteDataAccess.SaveUser(username);
            Console.WriteLine($"\nUser {username} has been added!");
            GoBackToMain();
        }
        // show stocks from portfolio - soon
        public static void ShowMyStocks()
        {
            Console.Clear();
            Console.WriteLine("My stocks...soon");
            // create transaction table...
            GoBackToMain();
        }
        // add a transaction to portfolio - soon
        public static void AddTransaction()
        {
            Console.Clear();
            Console.WriteLine("Adding a new transaction...soon");
            GoBackToMain();
        }
        // list users - ADMIN
        public static void ListUsers()
        {
            Console.Clear();
            Console.WriteLine("List of users:\n");
            List<string> users = SQLiteDataAccess.LoadUsers();
            foreach (string user in users)
                Console.WriteLine(user);
            GoBackToMain();
        }
        // add a new stock - ADMIN
        public static void AddStock()
        {
            Console.Clear();
            Console.WriteLine("Adding a new stock...");

            // validare symbol - verifica existenta in tabelul Stocks
            List<Stock> stocks = SQLiteDataAccess.LoadStocks();
            string symbol = GetStockSymbol();
            bool exist = true;
            while (exist)
            {
                exist = false;
                foreach (Stock stock in stocks)
                {
                    if (stock.Symbol.Equals(symbol))
                        exist = true;
                }   
                if (exist)
                {
                    Console.WriteLine($"\nStock with symbol {symbol} already exists!");
                    symbol = GetStockSymbol();
                }
            }

            // company
            Console.WriteLine("\nEnter company...");
            string company = Console.ReadLine();

            // validari currentPrice - real pozitiv
            Console.WriteLine("\nEnter current price...");
            double currentPrice = -1;
            while (currentPrice <= 0)
            {
                try
                {
                    currentPrice = Convert.ToDouble(Console.ReadLine());
                    if (currentPrice <= 0)
                        Console.WriteLine("\nInvalid input! Please enter a value greater than 0...");
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nCharacters are not allowed! Please enter a value greater than 0...");
                }
            }    
            
            Stock s = new Stock(symbol, company, currentPrice);
            SQLiteDataAccess.SaveStock(s);
            Console.WriteLine($"\nStock with symbol {symbol} has been added!");
            GoBackToMain();
        }  
        // delete a stock - ADMIN
        public static void DeleteStock()
        {
            Console.Clear();
            Console.WriteLine("Deleting a stock...");      
            Console.WriteLine("\nCurrent list of stocks:");
            Console.WriteLine("\n{0,-10} {1,-26} {2,17}", "Symbol", "Company", "Current price");
            Console.WriteLine(new string('-', 55));
            List<Stock> stocks = SQLiteDataAccess.LoadStocks();
            foreach (Stock stock in stocks)
                Console.WriteLine("{0,-10} {1,-26} {2,17:C2}", stock.Symbol, stock.Company, stock.CurrentPrice);
            // validare symbol - daca nu exista, interogarea nu poate avea loc
            string symbol = GetStockSymbol();
            bool exist = false;
            foreach (Stock stock in stocks)
            {
                if (stock.Symbol.Equals(symbol))
                    exist = true;
            }
            if (exist)
            {
                SQLiteDataAccess.DeleteStock(symbol);
                Console.WriteLine($"\nStock with symbol {symbol} has been deleted!");
            }
            else
                Console.WriteLine($"\nStock with symbol {symbol} doesn't exist!");
            GoBackToMain();
        }
    }
}
