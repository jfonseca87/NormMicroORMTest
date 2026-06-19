# NormMicroORMTest

A .NET 9 Minimal API that showcases the **Norm.net** micro-ORM for SQL Server data access. The project exposes three REST endpoints to query a database with tables for projects (`Proyectos`), people (`Personas`), and a combined dashboard view.

Norm.net is a lightweight, high-performance micro-ORM that extends `DbConnection` with fluent methods like `ReadAsync<T>()`, supporting multiple result sets in a single database round-trip. This project demonstrates that capability by executing two `SELECT` queries in one batch to build the dashboard model (`DashboardViewModel`), reducing latency compared to separate queries.

## Technologies / Libraries

- **.NET 9** (ASP.NET Core Minimal API)
- **Norm.net** 5.4.0 — Micro-ORM
- **Microsoft.Data.SqlClient** 6.1.1 — SQL Server driver
- **Swashbuckle.AspNetCore** 9.0.4 — Swagger UI
- **System.Linq.Async** 6.0.3 — Async LINQ for `ToListAsync()`

## Key Features

- **Dashboard endpoint** (`GET /api/dashboard`) — returns high-priority projects and recently registered people in one round-trip via Norm.net's multiple result sets.
- **Projects endpoint** (`GET /api/projects`) — queries `Proyectos` with a parameterized filter (`Prioridad = 3`).
- **People endpoint** (`GET /api/people`) — queries all records from `Persona`.
- **Record mapping** — uses C# records/classes with `init`-only properties (e.g., `Persona`, `Direccion`, `Proyecto`) for immutable data transfer.
- **Connection factory pattern** — `IConnectionFactory` / `SqlConnectionFactory` abstracts `SqlConnection` creation with async open.

## How to Run

1. Ensure SQL Server is running on `localhost:1433` (or update the connection string in `appsettings.json`).
2. Create the required tables (`Proyectos`, `Persona`, `Direccion`) and seed data.
3. Run the project:
   ```bash
   dotnet run --project NormMicroORMTest
   ```
4. Open the browser at `http://localhost:5000` — Swagger UI loads at the root path.
