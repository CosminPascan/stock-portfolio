# Stock Portfolio Manager
This is a simple C# console application built for users to manage their stock portfolios. Data is stored in a relational database and handled using SQLite and ADO.NET.

## Features
- **Console application menu:** automated menu to ease navigation through all options
- **CRUD operations on database:** you can perform buy/sell transactions, see your stock portfolio, add/delete a stock or modify a stock price

## Run Locally
Clone the project
```bash
  git clone https://github.com/CosminPascan/stock-portfolio.git
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