# WSCA Base Solution

## Overview
This project demonstrates a sample application using a .NET Core backend and a React frontend. The backend follows Domain-Driven Design (DDD) principles, uses the MediatR library for handling domain events, and Entity Framework Core for data persistence. The frontend is built with React and styled using Bootstrap. This setup provides a robust foundation for building scalable, maintainable, and testable applications.

## Design Decisions

### Domain-Driven Design (DDD)
**Domain-Driven Design (DDD)** is an approach to software development that emphasizes collaboration between technical and domain experts, aiming to create a shared understanding of the domain and model it effectively in software.

- **Entities and Value Objects**: The domain layer includes entities such as `Order` and `OrderItem`, which are core business objects. These entities encapsulate business logic and rules.
- **Aggregate Roots**: `Order` is the aggregate root, ensuring consistency within the aggregate. It manages a collection of `OrderItem` objects and enforces business rules.
- **Repositories**: Repositories like `OrderRepository` handle the persistence of aggregates. They abstract data access logic, making the domain model more expressive and focused on business rules.

### MediatR for Domain Events
**MediatR** is used to handle domain events, promoting loose coupling and separation of concerns. It allows domain events to be published and handled without the publisher needing to know about the subscribers.

- **Domain Events**: Events like `OrderCreatedEvent` and `OrderItemAddedEvent` are raised within the domain model. These events are handled asynchronously by MediatR handlers, allowing for side effects such as sending notifications or updating other systems.
- **Event Handlers**: Handlers like `OrderCreatedEventHandler` and `OrderItemAddedEventHandler` process domain events. This pattern enables adding or modifying side effects without changing the domain model.

### Entity Framework Core (EF Core)
**Entity Framework Core (EF Core)** is used for data persistence, providing a robust ORM for interacting with the database.

- **DbContext**: The `ApplicationDbContext` class manages the database connections and sets up entity configurations. It also dispatches domain events after saving changes to the database.
- **In-Memory Database**: An in-memory database is used for simplicity and demonstration purposes. This can be replaced with a relational database like SQL Server or PostgreSQL for production use.

## Architecture

### Layers

1. **Domain Layer**
   - **Entities**: Core business objects (e.g., `Order`, `OrderItem`).
   - **Value Objects**: Immutable objects representing concepts like `Money` or `Address`.
   - **Repositories**: Interfaces defining persistence operations (e.g., `IOrderRepository`).
   - **Domain Events**: Events representing significant occurrences in the domain.

2. **Infrastructure Layer**
   - **Repositories**: Implementations of repository interfaces, handling data access logic (e.g., `OrderRepository`).
   - **Data**: Database context (`ApplicationDbContext`) and configuration.
   - **Services**: Infrastructure-specific services like `DomainEventDispatcher`.

3. **Application Layer**
   - **Services**: Application services coordinating domain logic (e.g., `OrderService`).
   - **Event Handlers**: Handlers processing domain events using MediatR.

4. **API Layer**
   - **Controllers**: API endpoints exposing application functionality (e.g., `OrderController`).

5. **Client Layer**
   - **Components**: React components for UI (e.g., `OrderList`, `CreateOrder`, `AddOrderItem`).
   - **Services**: API service for HTTP requests (e.g., `api.js`).

## Best Practices

- **Separation of Concerns**: Each layer has a distinct responsibility, promoting single responsibility and maintainability.
- **Dependency Injection**: Dependencies are injected, not hardcoded, enabling easier testing and inversion of control.
- **Always-Valid Entities**: Entities use factory methods to ensure they are always in a valid state, reducing bugs and unexpected behaviors.
- **Event-Driven Architecture**: Domain events and event handlers decouple side effects from core business logic, making the system more flexible and easier to extend.
- **Clean Code**: Following principles like DRY (Don't Repeat Yourself), SOLID, and YAGNI (You Aren't Gonna Need It) ensures code is clean, readable, and maintainable.

## Structure
```
/solution.sln
/src
  /WscaBaseSolution.Domain
    /Entities
    /ValueObjects
    /Aggregates
    /Repositories
    /Services
    /Contracts
      /Queries
      /Commands
    /Events
    /Exceptions
    WscaBaseSolution.Domain.csproj
  /WscaBaseSolution.Application
    /Services
    WscaBaseSolution.Application.csproj
  /WscaBaseSolution.Infrastructure
    /Persistence
    /Repositories
    WscaBaseSolution.Infrastructure.csproj
  /WscaBaseSolution.API
    /Controllers
    /Models
    WscaBaseSolution.API.csproj
  /WscaBaseSolution.Web
    /Controllers
    /Views
    /Models
    /wwwroot
    WscaBaseSolution.Web.csproj
/tests
  /WscaBaseSolution.Domain.Tests
    WscaBaseSolution.Domain.Tests.csproj
  /WscaBaseSolution.Application.Tests
    WscaBaseSolution.Application.Tests.csproj
  /WscaBaseSolution.Infrastructure.Tests
    WscaBaseSolution.Infrastructure.Tests.csproj
  /WscaBaseSolution.API.Tests
    WscaBaseSolution.API.Tests.csproj
  /WscaBaseSolution.WebApp.Tests
    WscaBaseSolution.WebApp.Tests.csproj
```

## Packages used

- MediatR
- FluentValidation
- CSharpFunctionalExtensions
- NHibernate
- Npgsql 
- Serilog

For tests:
- XUnit
- FluentAssertions
- NSubstitute

## Getting Started

1. **Backend Setup**:
   - Navigate to the "Server" project's directory.
   - Restore dependencies: `dotnet restore`.
   - Run the application: `dotnet run`.

2. **Frontend Setup**:
   - Navigate to the frontend (Client) directory.
   - Install dependencies: `npm install`.
   - Start the development server: `npm run dev`.

## Usage

- **Creating an Order**: Use the `CreateOrder` component to create a new order by entering a customer name.
- **Adding Order Items**: Select an order from the `OrderList`, then use the `AddOrderItem` component to add items to the order.
- **Viewing Orders**: The `OrderList` component displays all orders and their items.

## Conclusion

This project provides a well-structured starting point for building scalable and maintainable applications. By following DDD principles, leveraging MediatR for domain events, and using EF Core for persistence, it ensures a robust foundation. The React frontend, offers a responsive and user-friendly interface. Other developers can use this project as a reference for implementing similar architectures in their own applications.

Feel free to contribute to this project by opening issues or submitting pull requests. Happy coding!
