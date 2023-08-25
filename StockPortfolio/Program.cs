namespace StockPortfolio
{
    public class Program
    {
        private static Menu mainMenu;

        public static Menu MainMenu { get => mainMenu; set => mainMenu = value; }

        public static void Main()
        {
            // headers
            string headerMainMenu = "Welcome to STOCK PORTFOLIO! Please choose your access level...";
            string headerUserMenu = "Welcome to USER menu! Please enter a number...";
            string headerAdminMenu = "Welcome to ADMIN menu! Please enter a number...";

            List<MenuItem> mainMenuItems = new List<MenuItem>();
            List<MenuItem> userMenuItems = new List<MenuItem>();
            List<MenuItem> adminMenuItems = new List<MenuItem>();

            // menus
            mainMenu = new Menu(null, headerMainMenu, mainMenuItems);
            Menu userMenu = new Menu(mainMenu, headerUserMenu, userMenuItems);
            Menu adminMenu = new Menu(mainMenu, headerAdminMenu, adminMenuItems);

            // main menu items
            mainMenuItems.Add(new MenuItem("User", userMenu.Run));
            mainMenuItems.Add(new MenuItem("Admin", adminMenu.Run));

            // user menu items
            userMenuItems.Add(new MenuItem("Add new user", Helper.AddUser));
            userMenuItems.Add(new MenuItem("My stocks", Helper.ShowMyStocks));
            userMenuItems.Add(new MenuItem("Add transaction", Helper.AddTransaction));

            // admin menu items
            adminMenuItems.Add(new MenuItem("List users", Helper.ListUsers));
            adminMenuItems.Add(new MenuItem("Add stock", Helper.AddStock));
            adminMenuItems.Add(new MenuItem("Delete stock", Helper.DeleteStock));
            
            mainMenu.Run();
        }
    }
}