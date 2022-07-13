# Fat Pig Invest - Stock Wallet

Waiting for repository description...

<br />

## Screenshots 
<br />

Waiting for screnshots...

<br />

## Technologies 

- .Net Core 6
- C#
- MVC
- Entity Framework
- Linq
- Lambda Expressions
- Pomelo.EntityFrameworkCore.MySql
- HTML 5
- CSS 3
- Bootstrap
- Javascript / JQuery
- MySQL Database
- MySQL Connector
- Google Charts

<br />

## Installation

Please, follow the instructions below in order to install and run this project:

    
### 1. Clone the repository

```console
git clone https://github.com/sergio-lacerda/Fat-Pig-Invest-Stock-Wallet.git
```

   
### 2. Database creation

For this project, a MySQL Database Server is required. If you don't have it, you can use a XAMPP distribution containing MariaDB.

Since the solutions was developed using a Code First Approach, the database is created by the solution itself and there's no need to execute any scripts.

   
### 3. Settings

- **appsettings.json:** Edit the key "DatabaseConnStr" and configure the connection string to the solution database (dbStockWallet).

```json
"ConnectionStrings": {
        "DatabaseConnStr": "Server=localhost;port=3306;database=dbStockWallet;uid=root;password=''"
    }
```