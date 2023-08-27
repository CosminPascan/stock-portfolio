# Stock Portfolio Manager
This is a simple C# console application built for users to manage their stock portfolios. Data is stored in a relational database and handled using SQLite and ADO.NET.

## Features
- **Console application menu:** automated menu to ease navigation through all options
- **CRUD operations on database:** you can perform buy/sell transactions, see you stock portfolio, add/delete a stock

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
| TransactionId | `INTEGER` | PK, not null |
| StockId | `INTEGER` | FK, not null |
| Quantity | `INTEGER` | not null |

## Roadmap
- modify stock price option in ADMIN menu
