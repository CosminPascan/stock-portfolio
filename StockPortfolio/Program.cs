namespace StockPortfolio
{
    public class Program
    {
        public static void Main()
        {
            // headers
            string headerMainMenu = "Welcome to STOCK PORTFOLIO! Please choose your access level...";
            string headerUserMenu = "Welcome to USER menu! Please enter a number...";
            string headerAdminMenu = "Welcome to ADMIN menu! Please enter a number...";

            List<MenuOption> mainMenuItems = new List<MenuOption>();
            List<MenuOption> userMenuItems = new List<MenuOption>();
            List<MenuOption> adminMenuItems = new List<MenuOption>();

            // menus
            Menu mainMenu = new Menu(null, headerMainMenu, mainMenuItems);
            Menu userMenu = new Menu(mainMenu, headerUserMenu, userMenuItems);
            Menu adminMenu = new Menu(mainMenu, headerAdminMenu, adminMenuItems);

            // main menu items
            mainMenuItems.Add(new MenuOption("User", userMenu.Run));
            mainMenuItems.Add(new MenuOption("Admin", adminMenu.Run));

            // user menu items
            userMenuItems.Add(new MenuOption("My stocks", Helper.ShowMyStocks));
            userMenuItems.Add(new MenuOption("Add transaction", Helper.AddTransaction));

            // admin menu items
            adminMenuItems.Add(new MenuOption("Add stock", Helper.AddStock));
            adminMenuItems.Add(new MenuOption("Modify stock price", Helper.ModifyStockPrice));
            adminMenuItems.Add(new MenuOption("Delete stock", Helper.DeleteStock));
            
            mainMenu.Run();
        }
    }
}