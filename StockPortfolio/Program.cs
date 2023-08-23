namespace StockPortfolio
{
    public class Program
    {
        private static Menu mainMenu;

        public static Menu MainMenu { get => mainMenu; set => mainMenu = value; }

        public static void Main()
        {
            // headers
            string headerMainMenu = "Welcome to STOCKS PORTFOLIO! Please choose your access level...";
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
            userMenuItems.Add(new MenuItem("Show my stocks", Helper.ShowStocks));
            userMenuItems.Add(new MenuItem("Add new stock", Helper.AddStock));
            userMenuItems.Add(new MenuItem("Remove stock", Helper.RemoveStock));

            // admin menu items
            adminMenuItems.Add(new MenuItem("Edit stock", Helper.EditStock));

            mainMenu.Run();
        }
    }
}