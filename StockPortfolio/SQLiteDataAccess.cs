using System;
using System.Data.SQLite;
using System.Net.NetworkInformation;
using System.Transactions;

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

        public static List<Transaction> LoadTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={GetConnectionString()}; Version=3;"))
            {
                connection.Open();
                string query = "SELECT StockSymbol, Type, Quantity FROM Transactions";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Enum.TryParse(reader.GetString(1), out TransactionType type);
                        Transaction transaction = new Transaction(reader.GetString(0), type, reader.GetInt32(2));
                        transactions.Add(transaction);
                    }
                }
                connection.Close();
            }
            return transactions;
        }

        public static void SaveTransaction(Transaction t)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={GetConnectionString()}; Value=3;"))
            {
                connection.Open();
                string query = "INSERT INTO Transactions (StockSymbol, Type, Quantity) VALUES (?, ?, ?)";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.Add("stock symbol", System.Data.DbType.String).Value = t.StockSymbol;
                    command.Parameters.Add("type", System.Data.DbType.String).Value = Enum.GetName(typeof(TransactionType), t.Type);
                    command.Parameters.Add("quantity", System.Data.DbType.Int32).Value = t.Quantity;
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
                string query = "SELECT Symbol, Company, Price FROM Stocks";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Stock stock = new Stock(reader.GetString(0), reader.GetString(1), reader.GetDouble(2));
                        stocks.Add(stock);
                    }
                }
                connection.Close();
            }
            return stocks;
        }

        public static void SaveStock(Stock stock)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={GetConnectionString()}; Value=3;"))
            {
                connection.Open();
                string query = "INSERT INTO Stocks (Symbol, Company, Price) VALUES (?, ?, ?)";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.Add("symbol", System.Data.DbType.String).Value = stock.Symbol;
                    command.Parameters.Add("company", System.Data.DbType.String).Value = stock.Company;
                    command.Parameters.Add("price", System.Data.DbType.Double).Value = stock.Price;
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
