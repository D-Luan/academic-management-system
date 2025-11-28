# Academic Management System

![license](https://img.shields.io/badge/license-MIT-green)
![C#](https://img.shields.io/badge/language-C%23-purple)
![ASP.NET Core](https://img.shields.io/badge/framework-ASP.NET%20Core-blue)
![Status](https://img.shields.io/badge/status-in%20progress-yellow)

## About
Academic Management System is an Enterprise-level RESTful API designed to manage academic processes. Built with .NET 9, this project demonstrates the application of modern software engineering practices, focusing on scalability, maintainability, and code quality.

The architecture follows the Clean Architecture principles, ensuring strict separation of concerns between the Domain (Core), Infrastructure, and Presentation layers. It also applies DDD (Domain-Driven Design) tactical patterns and TDD (Test-Driven Development) to guarantee robust business rules.

## Topics

- [Features](#features)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [License](#license)

## Features

**Domain & Architecture:**
    
- Clean Architecture implementation (Core, Infrastructure, Web).

- DDD Patterns: Rich Domain Models, Value Objects (Address), Repository Pattern, and Domain Services.

- Validations: Domain-level validation (Entities) and Input validation (FluentValidation).

**Security & Identity:**

- Full Authentication & Authorization system using ASP.NET Core Identity.

- Secure endpoints for Registration, Login, and Token management.

**Infrastructure & Quality:**

- Containerized environment using Docker and Docker Compose.

- Automated Testing: Unit Tests (xUnit + Moq) and Functional Tests (WebApplicationFactory + InMemory DB).

- Observability: Structured Logging with Serilog.

- Global Error Handling: Custom Middleware for standardized API responses (RFC 7807).

- API Documentation: Modern UI with Scalar (OpenAPI).

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

- [Docker](https://www.docker.com/get-started/)

- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

- [PostgreSQL](https://www.postgresql.org/download/)

## Installation

1. Clone the repository:
    
        git clone https://github.com/D-Luan/academic-management-system.git
        cd academic-management-system

2. Setup Infrastructure (Database):

    Use Docker Compose to spin up the PostgreSQL database container:
            
        docker-compose up -d

3. Configure Environment Variables:

        cd src/AcademicSystem.Web
        dotnet user-secrets init
        dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5434;Database=AcademicSystemDb;Username=postgres;Password=YourDockerPassword!;"

4. Run the Application:

        dotnet run

5. Access the API Documentation:

        http://localhost:5257/scalar/v1

## License

Distributed under the MIT License. See the [LICENSE](./LICENSE) for more information.