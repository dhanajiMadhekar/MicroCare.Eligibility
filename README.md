MicroCare API (Backend)

A robust, scalable RESTful Web API built with .NET 8 using Clean
Architecture principles. This backend powers the MicroCare Eligibility &
Booking System, handling secure authentication, business logic, and data
persistence.

Tech Stack

Framework: .NET 8 Web API Language: C# 12 Database: SQL Server ORM:
Entity Framework Core (Code-First) Object Mapping: AutoMapper
Authentication: JWT (JSON Web Tokens) API Documentation: Swagger /
OpenAPI

Architecture Overview

The solution follows Clean Architecture to ensure separation of
concerns, testability, and maintainability.

Layers

Domain Core business entities and enums No dependencies on other layers
Examples: EligibilityRequest User RequestStatus, Gender

Application Business logic and contracts DTOs, interfaces, services, and
mapping profiles Depends only on the Domain layer Examples:
CreateEligibilityDto EligibilityService IEligibilityRepository

Infrastructure Implements Application interfaces Database context and
repository implementations Handles EF Core migrations Examples:
ApplicationDbContext EligibilityRepository

API Entry point of the application Controllers and dependency injection
JWT authentication and middleware configuration Examples:
EligibilityController AuthController

 Project Structure
MicroCare.Backend/
├── Api/                         # Controllers & Program.cs
│   ├── Controllers/
│   └── appsettings.json
├── Application/                 # Business Logic
│   ├── DTOs/
│   ├── Interfaces/
│   ├── Mappings/
│   └── Services/
├── Domain/                      # Core Entities
│   ├── Entities/
│   └── Enums/
└── Infrastructure/              # Database & Repositories
    ├── Data/
    ├── Migrations/
    └── Repositories/

Prerequisites

.NET 8 SDK https://dotnet.microsoft.com/download

SQL Server (LocalDB / Express / Full)

IDE Visual Studio 2022 (recommended)

Getting Started

Clone the Repository git clone
https://github.com/dhanajiMadhekar/MicroCare.Eligibility.git cd
MicroCare.Backend

Configure Database

Open Api/appsettings.json and update the connection string:

“ConnectionStrings”: { “DefaultConnection”:
“Server=(localdb);Database=MicroCareDb;Trusted_Connection=True;MultipleActiveResultSets=true”
}

Apply Database Migrations

dotnet tool install –global dotnet-ef dotnet ef database update –project
Infrastructure –startup-project Api

Run the Application

cd Api dotnet run

The API will start at: HTTP: http://localhost:5278

Open: http://localhost:5278/swagger

Swagger Features Test endpoints from browser JWT authentication using
Authorize button Interactive request and response models

Authentication (/api/Auth) POST /login - Authenticate user and return
JWT token Default Credentials: admin / Admin123

Eligibility Requests (/api/Eligibility) GET / - Get all eligibility
requests GET /{id} - Get request details POST / - Create eligibility
request PUT /{id} - Update eligibility request DELETE /{id} - Delete
eligibility request

Security JWT-based authentication Token validation middleware
