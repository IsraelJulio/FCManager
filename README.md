# ⚽ Full Control Football — Backend API

<p align="center">
  <strong>Career Mode data tracker for EA Sports FC saves</strong>
</p>

<p align="center">
  <img src="https://img.shields.io/badge/.NET-10-512BD4?style=for-the-badge&logo=dotnet" />
  <img src="https://img.shields.io/badge/ASP.NET_Core-Web_API-512BD4?style=for-the-badge&logo=dotnet" />
  <img src="https://img.shields.io/badge/PostgreSQL-Database-336791?style=for-the-badge&logo=postgresql" />
  <img src="https://img.shields.io/badge/Architecture-Clean_Architecture-0F172A?style=for-the-badge" />
  <img src="https://img.shields.io/badge/Auth-JWT-000000?style=for-the-badge&logo=jsonwebtokens" />
</p>

---

## 📌 About

Full Control Football is a backend API designed to manage and track historical data from EA Sports FC Career Mode saves.

---

## 🚀 Tech Stack

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- JWT Authentication
- FluentValidation
- Swagger
- Serilog

---

## 🧱 Architecture

Clean Architecture:

src/
  Api/
  Application/
  Domain/
  Infrastructure/

---

## 🧠 Core Flow

User → CareerSave → Season → Competition

---

## 📦 Features

- Career saves
- Seasons
- Standings
- Top scorers
- Top assists
- Transfers

---

## 🔐 Auth

- JWT
- Refresh Tokens
- Google login (prepared)

---

## 🧾 Swagger

https://localhost:{port}/swagger

---

## ⚙️ Run

dotnet restore  
dotnet ef database update  
dotnet run

---

## 📄 Author

Israel Jhonatas
