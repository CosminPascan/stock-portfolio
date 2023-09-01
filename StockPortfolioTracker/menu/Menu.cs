namespace StockPortfolioTracker.menu
{
    public class Menu
    {
        public Menu Root { get; set; }
        public string Header { get; set; }
        public List<MenuOption> Options { get; set; }

        public Menu(Menu root, string header, List<MenuOption> options)
        {
            Root = root;
            Header = header;
            Options = options;
        }

        public void DisplayOptions()
        {
            Console.Clear();
            Console.WriteLine(Header + "\n");
            foreach (MenuOption option in Options)
            {   
                int index = Options.IndexOf(option) + 1;
                Console.WriteLine(index + " - " + option.Text);
            }
            // optiunea Back nu este disponibila in main menu
            if (Root != null)
            {
                Console.WriteLine( (Options.Count + 1) + " - Back" );
            }
            Console.WriteLine("\nPress 0 to exit application...");
        }

        public void GoBackOrExit()
        {
            Console.WriteLine("\n1 - Back");
            Console.WriteLine("\nPress 0 to exit application...");
            int userOption = Helper.GetNumberInRange(0, 1);
            if (userOption == 0)
            {
                Console.WriteLine("\nApplication exited successfully!");
                Environment.Exit(0);
            }
            if (userOption == 1)
            {
                Run();
            }
        }

        public void Run()
        {
            DisplayOptions();
            int userOption;
            if (Root == null)
            {
                // optiunea Back nu exista in main menu
                userOption = Helper.GetNumberInRange(0, Options.Count);
            }
            else
            {
                // optiunea Back corespunde Options.Count + 1
                userOption = Helper.GetNumberInRange(0, Options.Count + 1);
            }
            if (userOption == 0)
            {
                Console.WriteLine("\nApplication exited successfully!");
                Environment.Exit(0);
            }
            if (userOption == Options.Count + 1)
            {
                Root.Run();
            }
            else
            {
                Action action = Options[userOption - 1].Action;
                action();
                if (Root != null)
                {
                    GoBackOrExit();
                }
            }
        }
    }
}
