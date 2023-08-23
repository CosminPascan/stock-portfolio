namespace StockPortfolio
{
    public class Menu
    {
        private Menu _root;
        private string _header;
        private List<MenuItem> _menuItems;

        public Menu(Menu root, string header, List<MenuItem> menuItems)
        {
            _root = root;
            _header = header;
            _menuItems = menuItems;
        }

        public Menu Root { get => _root; set => _root = value; }
        public string Header { get => _header; set => _header = value; }
        public List<MenuItem> MenuItems { get => _menuItems; set => _menuItems = value; }

        public void Display()
        {   
            Console.Clear();
            Console.WriteLine(_header + "\n");
            for(int i = 0; i < _menuItems.Count; i++)
            {
                Console.WriteLine( (i + 1) + " - " + _menuItems[i].Text );
            }
            // optiunea Back nu este disponibila in main menu
            if(_root != null)
            {
                Console.WriteLine( (_menuItems.Count + 1) + " - " + "Back" );
            }      
            Console.WriteLine("\nPress 0 to exit application...");
        }

        public void Run()
        {   
            Display();
            int input = -1;
            if (_root == null)
                input = Helper.GetInput(0, _menuItems.Count); // main menu nu permite Back
            else
                input = Helper.GetInput(0, _menuItems.Count + 1); // optiunea Back corespunde _menuItems.Count + 1
            if (input == 0)
            {
                Console.WriteLine("\nApplication exited successfully!");
                Environment.Exit(0);
            }
            if(input == _menuItems.Count + 1) 
                _root.Run();
            else
            {
                Action action = _menuItems[input - 1].Action;
                action();               
            }     
        }
    }
}
