# Stock Portfolio Tracker
This is a simple console application (C# .NET 6) built for users to track their stock portfolios. Data is stored in a relational database and handled using SQLite and ADO.NET.

## Features
- **Console application menu:** automated menu to ease navigation through all options
- **CRUD operations on database:** perform buy/sell transactions, add/delete a stock or modify a stock price
- **Portfolio calculator:** calculate your portfolio based on your transactions

## Run Locally
Clone the project
```bash
  git clone https://github.com/CosminPascan/stock-portfolio-tracker.git
```
Go to the project directory
```bash
  cd my-project
```
Run application
```bash
  dotnet run
```

## Database Structure
### Stocks table
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| Symbol | `TEXT` | unique, not null |
| Company | `TEXT` | not null |
| Price | `REAL` | not null |
### Transactions table
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| TransactionId | `INTEGER` | PK, unique, not null |
| StockSymbol | `TEXT` | FK, not null |
| Quantity | `INTEGER` | not null |