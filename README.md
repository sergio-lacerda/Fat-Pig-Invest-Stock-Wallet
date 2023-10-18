![Fat Pig Invest - Stock Wallet Logo](https://github.com/sergio-lacerda/Fat-Pig-Invest-Stock-Wallet/blob/master/Preview/logo.png "Fat Pig Invest - Stock Wallet Logo")

# Fat Pig Invest - Stock Wallet

<img height="12px" src="https://github.com/hampusborgos/country-flags/blob/main/png250px/us.png"/> This is a self-study solution developed for stock portfolio management for the Brazilian stock market. 

<img height="12px" src="https://github.com/hampusborgos/country-flags/blob/main/png250px/br.png"/> Esta é uma solução de autoestudo desenvolvida para o gerenciamento de carteira de ações para o mercado de ações brasileiro. 

<img height="12px" src="https://github.com/hampusborgos/country-flags/blob/main/png250px/es.png"/> Esta es una solución de autoaprendizaje desarrollada para la gestión de cartera de acciones para la bolsa de valores brasileña.

<br />

## Screenshots 
<br />

![Fat Pig Invest - Stock Wallet Main Page](https://github.com/sergio-lacerda/Fat-Pig-Invest-Stock-Wallet/blob/master/Preview/Index.png "Fat Pig Invest - Stock Wallet Main Page")

![Fat Pig Invest - Stock Wallet Orders](https://github.com/sergio-lacerda/Fat-Pig-Invest-Stock-Wallet/blob/master/Preview/NotasDeNegociacao.png "Fat Pig Invest - Stock Wallet Orders")

![Fat Pig Invest - Stock Wallet Earnings](https://github.com/sergio-lacerda/Fat-Pig-Invest-Stock-Wallet/blob/master/Preview/Proventos.png "Fat Pig Invest - Stock Wallet Earnings")

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
- CSS 3 (not fully responsive sample)
- Bootstrap
- Javascript / JQuery
- MySQL / MariaDB Database
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

Since the solutions was developed by using a Code First Approach, the database is created by the Migrations commands and there's no need to execute any external database scripts.

   
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


### 4. Migrations

Run the Migrations commands bellow in order to create the database based on the project classes (It´s recommended to delete the "Migrations" Folder before running these commands).

```console
add-migration FirstMigration
```
```console
Update-database
```