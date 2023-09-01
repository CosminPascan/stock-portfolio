using StockPortfolioTracker.menu;
using StockPortfolioTracker.stock;
using StockPortfolioTracker.transaction;

// headers
string headerMainMenu = "Welcome to STOCK PORTFOLIO TRACKER! Please choose your access level...";
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
userMenuItems.Add(new MenuOption("My portfolio", TransactionService.CalculatePortfolio));
userMenuItems.Add(new MenuOption("Add transaction", TransactionService.AddTransaction));

// admin menu items
adminMenuItems.Add(new MenuOption("Add stock", StockService.AddStock));
adminMenuItems.Add(new MenuOption("Modify stock price", StockService.ModifyStockPrice));
adminMenuItems.Add(new MenuOption("Delete stock", StockService.DeleteStock));

mainMenu.Run();
