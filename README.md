# ⚽ Full Control Football — Backend API

**Full Control Football** is a backend system designed to manage and track historical data from *EA Sports FC 25 Career Mode saves*.

This API provides a structured, scalable, and production-ready foundation for storing and analyzing football career data such as:

- Seasons
- Competitions
- Standings
- Top scorers
- Top assists
- Transfers

---

## 🚀 Tech Stack

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- JWT Authentication
- Refresh Tokens
- Google Authentication (prepared)
- FluentValidation
- Serilog
- Swagger / OpenAPI

---

## 🧱 Architecture

This project follows a **Clean Architecture** approach:
## 🧱 Architecture

This project follows a **Clean Architecture** approach:


src/
FullControlFootball.Api/
FullControlFootball.Application/
FullControlFootball.Domain/
FullControlFootball.Infrastructure/

tests/
FullControlFootball.UnitTests/
FullControlFootball.IntegrationTests/


### Principles

- Separation of concerns
- Domain-driven design (DDD inspired)
- Scalable and maintainable structure
- Ready for vertical slice evolution
- No business logic inside controllers

---

