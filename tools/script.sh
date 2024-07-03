#!/bin/sh

APP_NAME=Sample

rm -R src
mkdir src
cd src

dotnet new sln -n "$APP_NAME"

# Create main projects
dotnet new classlib -o "1. Domain/$APP_NAME.Domain"
dotnet new classlib -o "2. Infrastructure/$APP_NAME.Infrastructure"
dotnet new classlib -o "3. Application/$APP_NAME.Application"
dotnet new webapi --use-controllers -o "4. Server/$APP_NAME.API"

# Create tests projects
dotnet new classlib -o "1. Domain/$APP_NAME.Domain.Tests"
dotnet new classlib -o "2. Infrastructure/$APP_NAME.Infrastructure.Tests"
dotnet new classlib -o "3. Application/$APP_NAME.Application.Tests"
dotnet new classlib -o "4. Server/$APP_NAME.API.Tests"

# Add main projects to sln to the root 
dotnet sln add "1. Domain/$APP_NAME.Domain" --solution-folder "1. Domain"
dotnet sln add "2. Infrastructure/$APP_NAME.Infrastructure" --solution-folder "2. Infrastructure"
dotnet sln add "3. Application/$APP_NAME.Application" --solution-folder "3. Application"
dotnet sln add "4. Server/$APP_NAME.API" --solution-folder "4. Server"

# Add tests projects to sln to a tests solution folder
dotnet sln add "1. Domain/$APP_NAME.Domain.Tests" --solution-folder "1. Domain"
dotnet sln add "2. Infrastructure/$APP_NAME.Infrastructure.Tests" --solution-folder "2. Infrastructure"
dotnet sln add "3. Application/$APP_NAME.Application.Tests" --solution-folder "3. Application"
dotnet sln add "4. Server/$APP_NAME.API.Tests" --solution-folder "4. Server"

# Add reference to projects
dotnet add "2. Infrastructure/$APP_NAME.Infrastructure/$APP_NAME.Infrastructure.csproj" reference "1. Domain/$APP_NAME.Domain/$APP_NAME.Domain.csproj"
dotnet add "3. Application/$APP_NAME.Application/$APP_NAME.Application.csproj" reference "1. Domain/$APP_NAME.Domain/$APP_NAME.Domain.csproj" "2. Infrastructure/$APP_NAME.Infrastructure/$APP_NAME.Infrastructure.csproj"
dotnet add "4. Server/$APP_NAME.API/$APP_NAME.API.csproj" reference "3. Application/$APP_NAME.Application/$APP_NAME.Application.csproj"

# Add reference to tests projects
dotnet add "2. Infrastructure/$APP_NAME.Infrastructure.Tests/$APP_NAME.Infrastructure.Tests.csproj" reference "1. Domain/$APP_NAME.Domain/$APP_NAME.Domain.csproj"
dotnet add "3. Application/$APP_NAME.Application.Tests/$APP_NAME.Application.Tests.csproj" reference "1. Domain/$APP_NAME.Domain/$APP_NAME.Domain.csproj" "2. Infrastructure/$APP_NAME.Infrastructure/$APP_NAME.Infrastructure.csproj"
dotnet add "4. Server/$APP_NAME.API.Tests/$APP_NAME.API.Tests.csproj" reference "3. Application/$APP_NAME.Application/$APP_NAME.Application.csproj"

# Add common packages
dotnet add "1. Domain/$APP_NAME.Domain/$APP_NAME.Domain.csproj" package "CSharpFunctionalExtensions"
dotnet add "1. Domain/$APP_NAME.Domain/$APP_NAME.Domain.csproj" package "MediatR"
dotnet add "2. Infrastructure/$APP_NAME.Infrastructure/$APP_NAME.Infrastructure.csproj" package "Microsoft.EntityFrameworkCore"
dotnet add "3. Application/$APP_NAME.Application/$APP_NAME.Application.csproj" package "Microsoft.EntityFrameworkCore"
dotnet add "4. Server/$APP_NAME.API/$APP_NAME.API.csproj" package "Microsoft.EntityFrameworkCore"
dotnet add "4. Server/$APP_NAME.API/$APP_NAME.API.csproj" package "Microsoft.EntityFrameworkCore.InMemory"

# Add common packages for tests projects (xunit, fluentassertions and nsubstitute)
dotnet add "1. Domain/$APP_NAME.Domain.Tests/$APP_NAME.Domain.Tests.csproj" package "FluentAssertions"
dotnet add "1. Domain/$APP_NAME.Domain.Tests/$APP_NAME.Domain.Tests.csproj" package "xunit"
dotnet add "1. Domain/$APP_NAME.Domain.Tests/$APP_NAME.Domain.Tests.csproj" package "xunit.runner.visualstudio"
dotnet add "1. Domain/$APP_NAME.Domain.Tests/$APP_NAME.Domain.Tests.csproj" package "NSubstitute"
dotnet add "2. Infrastructure/$APP_NAME.Infrastructure.Tests/$APP_NAME.Infrastructure.Tests.csproj" package "FluentAssertions"
dotnet add "2. Infrastructure/$APP_NAME.Infrastructure.Tests/$APP_NAME.Infrastructure.Tests.csproj" package "xunit"
dotnet add "2. Infrastructure/$APP_NAME.Infrastructure.Tests/$APP_NAME.Infrastructure.Tests.csproj" package "xunit.runner.visualstudio"
dotnet add "2. Infrastructure/$APP_NAME.Infrastructure.Tests/$APP_NAME.Infrastructure.Tests.csproj" package "NSubstitute"
dotnet add "3. Application/$APP_NAME.Application.Tests/$APP_NAME.Application.Tests.csproj" package "FluentAssertions"
dotnet add "3. Application/$APP_NAME.Application.Tests/$APP_NAME.Application.Tests.csproj" package "xunit"
dotnet add "3. Application/$APP_NAME.Application.Tests/$APP_NAME.Application.Tests.csproj" package "xunit.runner.visualstudio"
dotnet add "3. Application/$APP_NAME.Application.Tests/$APP_NAME.Application.Tests.csproj" package "NSubstitute"
dotnet add "4. Server/$APP_NAME.API.Tests/$APP_NAME.API.Tests.csproj" package "FluentAssertions"
dotnet add "4. Server/$APP_NAME.API.Tests/$APP_NAME.API.Tests.csproj" package "xunit"
dotnet add "4. Server/$APP_NAME.API.Tests/$APP_NAME.API.Tests.csproj" package "xunit.runner.visualstudio"
dotnet add "4. Server/$APP_NAME.API.Tests/$APP_NAME.API.Tests.csproj" package "NSubstitute"


# The following creates the client application. It requires Node installed.
npx create-react-app $APP_NAME-Client
cd $APP_NAME-Client

npm install axios
npm install bootstrap
npm install reactstrap

cd ..
dotnet sln add "5. Client/$APP_NAME-Client" --solution-folder "5. Client"


