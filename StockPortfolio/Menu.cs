namespace StockPortfolio
{
    public class Menu
    {
        private Menu _root;
        private string _header;
        private List<MenuOption> _menuOptions;

        public Menu(Menu root, string header, List<MenuOption> menuOptions)
        {
            _root = root;
            _header = header;
            _menuOptions = menuOptions;
        }

        public Menu Root { get => _root; set => _root = value; }
        public string Header { get => _header; set => _header = value; }
        public List<MenuOption> MenuOptions { get => _menuOptions; set => _menuOptions = value; }

        public void Display()
        {   
            Console.Clear();
            Console.WriteLine(_header + "\n");
            for (int i = 0; i < _menuOptions.Count; i++)
            {
                Console.WriteLine( (i + 1) + " - " + _menuOptions[i].Text );
            }
            // optiunea Back nu este disponibila in main menu
            if (_root != null)
            {
                Console.WriteLine((_menuOptions.Count + 1) + " - Back");
            }     
            Console.WriteLine("\nPress 0 to exit application...");
        }

        public void GoBackOrExit()
        {
            Console.WriteLine("\n1 - Back");
            Console.WriteLine("\nPress 0 to exit application...");
            int option = Validator.GetNumberInRange(0, 1);
            if (option == 0)
            {
                Console.WriteLine("\nApplication exited successfully!");
                Environment.Exit(0);
            }
            if (option == 1)
            {
                Run();
            }
        }

        public void Run()
        {   
            Display();
            int option = -1;
            if (_root == null)
            {
                // main menu nu permite Back
                option = Validator.GetNumberInRange(0, _menuOptions.Count); 
            }
            else
            {
                // optiunea Back corespunde _menuItems.Count + 1
                option = Validator.GetNumberInRange(0, _menuOptions.Count + 1); 
            }
            if (option == 0)
            {
                Console.WriteLine("\nApplication exited successfully!");
                Environment.Exit(0);
            }
            if(option == _menuOptions.Count + 1)
            {
                _root.Run();
            }
            else
            {
                Action action = _menuOptions[option - 1].Action;
                action();
                if (_root != null)
                {
                    GoBackOrExit();
                }
            }     
        }
    }
}
