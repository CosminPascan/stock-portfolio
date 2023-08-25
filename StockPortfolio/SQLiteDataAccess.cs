using System.Data.SQLite;

namespace StockPortfolio
{
    public class SQLiteDataAccess
    {
        public static string GetConnectionString()
        {
            string executableFileDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = @"..\..\..\data\database.db";
            string connectionString = Path.GetFullPath(Path.Combine(executableFileDirectoryPath, relativePath));
            return connectionString;
        }

        public static List<string> LoadUsers()
        {   
            List<string> users = new List<string>();    
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={GetConnectionString()}; Version=3;"))
            {
                connection.Open();
                string query = "SELECT Username FROM Users";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        users.Add(reader.GetString(0));
                }
                connection.Close();
            }
            return users;
        }

        public static void SaveUser(string username)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={GetConnectionString()}; Value=3;"))
            {
                connection.Open();
                string query = "INSERT INTO Users (Username) VALUES (?)";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.Add("username", System.Data.DbType.String).Value = username;
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                connection.Close();
            }
        }

        public static List<Stock> LoadStocks()
        {   
            List<Stock> stocks = new List<Stock>();
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={GetConnectionString()}; Version=3;"))
            {
                connection.Open();
                string query = "SELECT Symbol, Company, CurrentPrice FROM Stocks";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Stock s = new Stock(reader.GetString(0), reader.GetString(1), reader.GetDouble(2));
                        stocks.Add(s);
                    }
                }
                connection.Close();
            }
            return stocks;
        }

        public static void SaveStock(Stock s)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={GetConnectionString()}; Value=3;"))
            {
                connection.Open();
                string query = "INSERT INTO Stocks (Symbol, Company, CurrentPrice) VALUES (?, ?, ?)";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.Add("symbol", System.Data.DbType.String).Value = s.Symbol;
                    command.Parameters.Add("company", System.Data.DbType.String).Value = s.Company;
                    command.Parameters.Add("current price", System.Data.DbType.Double).Value = s.CurrentPrice;
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                connection.Close();
            }
        }

        public static void DeleteStock(string symbol)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={GetConnectionString()}; Version=3;"))
            {
                connection.Open();
                string query = "DELETE FROM Stocks WHERE Symbol = ?";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.Add("symbol", System.Data.DbType.String).Value = symbol;
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                connection.Close();
            }
        }
    }
}
