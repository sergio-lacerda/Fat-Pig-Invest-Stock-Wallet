![Fat Pig Invest - Stock Wallet Logo](https://github.com/sergio-lacerda/Fat-Pig-Invest-Stock-Wallet/blob/master/Preview/logo.png "Fat Pig Invest - Stock Wallet Logo")

# 🐷 Fat Pig Invest - Stock Wallet

A self-study project designed to manage stock portfolios focused on the Brazilian stock market.

---

### 🌎 About the Project

<img src="https://cdn.jsdelivr.net/gh/hjnilsson/country-flags@master/svg/us.svg" width="20" style="display: inline; vertical-align: middle;" /> This is a self-study solution developed for stock portfolio management, focused on the Brazilian stock market. 

<img src="https://cdn.jsdelivr.net/gh/hjnilsson/country-flags@master/svg/br.svg" width="20" style="display: inline; vertical-align: middle;" /> Esta é uma solução de autoestudo desenvolvida para o gerenciamento de carteira de ações voltada ao mercado brasileiro. 

<img src="https://cdn.jsdelivr.net/gh/hjnilsson/country-flags@master/svg/es.svg" width="20" style="display: inline; vertical-align: middle;" /> Esta es una solución de autoaprendizaje desarrollada para la gestión de carteras de acciones enfocada en el mercado brasileño.

---

## 📸 Screenshots

![Main Page](https://github.com/sergio-lacerda/Fat-Pig-Invest-Stock-Wallet/blob/master/Preview/Index.png "Main Page")

![Orders](https://github.com/sergio-lacerda/Fat-Pig-Invest-Stock-Wallet/blob/master/Preview/NotasDeNegociacao.png "Orders")

![Earnings](https://github.com/sergio-lacerda/Fat-Pig-Invest-Stock-Wallet/blob/master/Preview/Proventos.png "Earnings")

---

## 🛠️ Technologies

- .Net 6 MVC App
- C#
- Entity Framework Core
- LINQ & Lambda Expressions
- Regular Expressions (RegEx)
- Pomelo.EntityFrameworkCore.MySql
- MySQL / MariaDB
- HTML5 & CSS3 *(non-responsive sample)*
- Bootstrap
- Javascript / JQuery
- Google Charts

---

## 🚀 Getting Started

Follow the steps below to set up and run the project locally.

    
### 1. Clone the repository

```console
git clone https://github.com/sergio-lacerda/Fat-Pig-Invest-Stock-Wallet.git
```
   
### 2. Database Setup

This project requires a MySQL or MariaDB server.
- If you don’t have one installed, you can use distributions like XAMPP (which includes MariaDB).
- The project uses a Code First approach, so the database will be created via migrations — no manual scripts required.
   
### 3. Configuration

📌 appsettings.json
Update the connection string:

```json
"ConnectionStrings": {
        "DatabaseConnStr": "Server=localhost;port=3306;database=dbStockWallet;uid=root;password=''"
    }
```

📌 Program.cs
The default configuration uses MariaDB 10.4.24:

```csharp
var serverVersion = new MariaDbServerVersion(new Version(10, 4, 24));
```
If you're using a different version or database, adjust this accordingly.
For more details, refer to the Pomelo documentation.

### 4. Run Migrations
Before running migrations, it's recommended to delete the existing Migrations folder.

Then execute:

```console
add-migration FirstMigration
```
```console
Update-database
```

---

## 📌 Notes

- This project was created for learning purposes.
- The UI is a functional prototype and not fully responsive.
- Feel free to fork, improve, and adapt it to your needs.

---

## 🤝 Contributing

Contributions, suggestions, and feedback are always welcome!

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
