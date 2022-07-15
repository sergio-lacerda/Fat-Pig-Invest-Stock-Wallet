# Fat Pig Invest - Stock Wallet

_**[English]**_ This is a self-study solution developed for stock portfolio management for the Brazilian stock market. 

_**[Português]**_ Esta é uma solução de autoestudo desenvolvida para o gerenciamento de carteira de ações para o mercado de ações brasileiro. 

_**[Español]**_ Esta es una solución de autoaprendizaje desarrollada para la gestión de cartera de acciones para la bolsa de valores brasileña.

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
- RegEx: Regular Expressions
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

- **Program.cs:** At line 11, the database server version is setted as MariaDB 10.4.24, since it's the version used for development. If you are running a diferent version or database, you can edit this line before running the solution. For further information, please refer to the Pomelo project documentation.

```csharp
var serverVersion = new MariaDbServerVersion(new Version(10, 4, 24));
```