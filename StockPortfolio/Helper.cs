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
        // show stocks from portfolio
        public static void ShowStocks()
        {
            Console.Clear();
            Console.WriteLine("My stocks...soon");
            GoBackToMain();
        }
        // add a stock to portfolio
        public static void AddStock()
        {
            Console.Clear();
            Console.WriteLine("Adding a new stock...soon");
            GoBackToMain();
        }
        // remove a stock from portfolio
        public static void RemoveStock()
        {
            Console.Clear();
            Console.WriteLine("Removing a stock from portfolio...soon");
            GoBackToMain();
        }
        // edit a stock
        public static void EditStock()
        {
            Console.Clear();
            Console.WriteLine("Editing a stock...soon");
            GoBackToMain();
        }
    }
}
