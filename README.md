# Sample Application
This repository shows a common solution that the WSAC team uses when creating new projects.

It uses a simple Domain-Driven-Developement (DDD) philosophy and does not introduce higher level concepts such as CQRS or Event-Sourcing.

## Projects
```
/solution.sln
/src
  /Sample.Domain
    /Entities
    /ValueObjects
    /Aggregates
    /Repositories
    /Services
    /Specifications
    /Events
    /Exceptions
    Sample.Domain.csproj
  /Sample.Application
    /Services
    Sample.Application.csproj
  /Sample.Infrastructure
    /Persistence
    /Repositories
    Sample.Infrastructure.csproj
  /Sample.API
    /Controllers
    /Models
    Sample.API.csproj
  /Sample.Web
    /Controllers
    /Views
    /Models
    /wwwroot
    Sample.Web.csproj
/tests
  /Sample.Domain.Tests
    Sample.Domain.Tests.csproj
  /Sample.Application.Tests
    Sample.Application.Tests.csproj
  /Sample.Infrastructure.Tests
    Sample.Infrastructure.Tests.csproj
  /Sample.API.Tests
    Sample.API.Tests.csproj
  /Sample.WebApp.Tests
    Sample.WebApp.Tests.csproj
```

### Sample.Domain

Purpose: Contains the core domain logic and entities.
Contents:
- Entities: Core data structures of your domain.
- ValueObjects: Immutable objects defined by their properties.
- Aggregates: Root entities that control access to other entities.
- Repositories: Interfaces for accessing and persisting aggregates.
- Services: Domain services encapsulating business logic.
- Specifications: Encapsulate business rules and query logic.
- Events: Domain events representing something that happened in the domain.
- Exceptions: Custom domain-specific exceptions.

### Sample.Application
Purpose: Orchestrates business logic and enforce application-specific policies, including access control.
- Services: Application services orchestrating use cases.

### Sample.Infrastructure
Purpose: Handle all external dependencies and data access within the infrastructure layer.
- Persistence: Database context and related classes.
- Repositories: Implementations of repository interfaces.

### Sample.API
Purpose: Provides backend API endpoints.
Contents:
- Controllers: Handle API requests and responses.
- Models: Request and response models for the API.

### Sample.Web
Purpose: Acts as the presentation layer.
Contents:
- Controllers: Handle web requests and return views.
- Views: UI components, typically using Razor pages or MVC views.
- Models: View models specific to the web application.
- wwwroot: Static files like CSS, JavaScript, and images.
